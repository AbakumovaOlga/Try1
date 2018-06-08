using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using Unity.Attributes;

namespace SweetShopWPF
{
    /// <summary>
    /// Логика взаимодействия для FormCustomer.xaml
    /// </summary>
    public partial class FormCustomer : Window
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormCustomer()
        {
            InitializeComponent();
            Loaded += FormCustomer_Load;
        }

        private void FormCustomer_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Customer/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var Customer = APICustomer.GetElement<CustomerViewModel>(response);
                        FCusFIO.Text = Customer.CustomerFIO;
                    }
                    else
                    {
                        throw new Exception(APICustomer.GetError(response));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void FCusSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FCusFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Customer/UpdElement", new CustomerBindingModel
                    {
                        Id = id.Value,
                        CustomerFIO = FCusFIO.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Customer/AddElement", new CustomerBindingModel
                    {
                        CustomerFIO = FCusFIO.Text
                    });
                }
                if (response.Result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                    Close();
                }
                else
                {
                    throw new Exception(APICustomer.GetError(response));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FCusCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
