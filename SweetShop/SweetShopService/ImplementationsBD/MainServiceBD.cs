using SweetShop;
using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace SweetShopService.ImplementationsBD
{
    public class MainServiceBD : IMainService
    {
        private AbstractDbContext context;

        public MainServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<RequestViewModel> GetList()
        {
            List<RequestViewModel> result = context.Requests
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    CustomerId = rec.CustomerId,
                    CakeId = rec.CakeId,
                    BakerId = rec.BakerId,
                    DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                                    SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                                    SqlFunctions.DateName("yyyy", rec.DateCreate),
                    DateBaking = rec.DateBaking == null ? "" :
                                    SqlFunctions.DateName("dd", rec.DateBaking.Value) + " " +
                                    SqlFunctions.DateName("mm", rec.DateBaking.Value) + " " +
                                    SqlFunctions.DateName("yyyy", rec.DateBaking.Value),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    CustomerFIO = rec.Customer.CustomerFIO,
                    CakeName = rec.Cake.CakeName,
                    BakerName = rec.Baker.BakerFIO
                })
                .ToList();
            return result;
        }

        public void CreateRequest(RequestBindingModel model)
        {
            var request = new Request
            {
                CustomerId = model.CustomerId,
                CakeId = model.CakeId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = RequestStatus.Принят
            };
            context.Requests.Add(request);
            context.SaveChanges();

            var client = context.Customers.FirstOrDefault(x => x.Id == model.CustomerId);
            SendEmail(client.Mail, "Оповещение по заказам",
                string.Format("Заказ №{0} от {1} создан успешно", request.Id,
                request.DateCreate.ToShortDateString()));
        }

        public void TakeRequestInWork(RequestBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {

                    Request element = context.Requests.Include(rec => rec.Customer).FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    var CakeIngredients = context.CakeIngredients
                                                .Include(rec => rec.Ingredient)
                                                .Where(rec => rec.CakeId == element.CakeId);
                    // списываем
                    foreach (var CakeIngredient in CakeIngredients)
                    {
                        int countOnFridges = CakeIngredient.Count * element.Count;
                        var FridgeIngredients = context.FridgeIngredients
                                                    .Where(rec => rec.IngredientId == CakeIngredient.IngredientId);
                        foreach (var FridgeIngredient in FridgeIngredients)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (FridgeIngredient.Count >= countOnFridges)
                            {
                                FridgeIngredient.Count -= countOnFridges;
                                countOnFridges = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnFridges -= FridgeIngredient.Count;
                                FridgeIngredient.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnFridges > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                                CakeIngredient.Ingredient.IngredientName + " требуется " +
                                CakeIngredient.Count + ", не хватает " + countOnFridges);
                        }
                    }
                    element.BakerId = model.BakerId;
                    element.DateBaking = DateTime.Now;
                    element.Status = RequestStatus.Выполняется;
                    context.SaveChanges();
                    SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передеан в работу", element.Id, element.DateCreate.ToShortDateString()));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void FinishRequest(int id)
        {
            Request element = context.Requests.Include(rec => rec.Customer).FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = RequestStatus.Готов;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам",
string.Format("Заказ №{0} от {1} передан на оплату", element.Id,
element.DateCreate.ToShortDateString()));
        }

        public void PayRequest(int id)
        {
            Request element = context.Requests.Include(rec => rec.Customer).FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = RequestStatus.Оплачен;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам",
string.Format("Заказ №{0} от {1} оплачен успешно", element.Id, element.DateCreate.ToShortDateString()));
        }

        public void ReplenishFridge(FridgeIngredientBindingModel model)
        {
            FridgeIngredient element = context.FridgeIngredients
                                                .FirstOrDefault(rec => rec.FridgeId == model.FridgeId &&
                                                rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.FridgeIngredients.Add(new FridgeIngredient
                {
                    FridgeId = model.FridgeId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;

            try
            {
                objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                    ConfigurationManager.AppSettings["MailPassword"]);

                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}