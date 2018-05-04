using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SweetShopView
{
    public partial class FormCreateRequest : Form
    {
        public FormCreateRequest()
        {
            InitializeComponent();
        }

        private void FormCreateRequest_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = Task.Run(() => APICustomer.GetRequestData<List<CustomerViewModel>>("api/Customer/GetList")).Result;
                if (listC != null)
                {
                    FCRCustomer.DisplayMember = "CustomerFIO";
                    FCRCustomer.ValueMember = "Id";
                    FCRCustomer.DataSource = listC;
                    FCRCustomer.SelectedItem = null;
                }

                List<CakeViewModel> listP = Task.Run(() => APICustomer.GetRequestData<List<CakeViewModel>>("api/Cake/GetList")).Result;
                if (listP != null)
                {
                    FCRCake.DisplayMember = "CakeName";
                    FCRCake.ValueMember = "Id";
                    FCRCake.DataSource = listP;
                    FCRCake.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (FCRCake.SelectedValue != null && !string.IsNullOrEmpty(FCRNumber.Text))
            {
                try
                {
                    int id = Convert.ToInt32(FCRCake.SelectedValue);
                    CakeViewModel Cake = Task.Run(() => APICustomer.GetRequestData<CakeViewModel>("api/Cake/Get/" + id)).Result;
                    int count = Convert.ToInt32(FCRNumber.Text);
                    FCRSum.Text = (count * (int)Cake.Price).ToString();
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FCRNumber_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void FCRCake_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void FCRSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FCRNumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FCRCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FCRCake.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int CustomerId = Convert.ToInt32(FCRCustomer.SelectedValue);
            int CakeId = Convert.ToInt32(FCRCake.SelectedValue);
            int count = Convert.ToInt32(FCRNumber.Text);
            int sum = Convert.ToInt32(FCRSum.Text);
            Task task = Task.Run(() => APICustomer.PostRequestData("api/Main/CreateRequest", new RequestBindingModel
            {
                CustomerId = CustomerId,
                CakeId = CakeId,
                Count = count,
                Sum = sum
            }));

            task.ContinueWith((prevTask) => MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }, TaskContinuationOptions.OnlyOnFaulted);

            Close();
        }

        private void FCRCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
