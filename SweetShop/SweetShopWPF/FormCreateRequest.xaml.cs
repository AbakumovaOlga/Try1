using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для FormCreateRequest.xaml
    /// </summary>
    public partial class FormCreateRequest : Window
    {
        public FormCreateRequest()
        {
            InitializeComponent();
            Loaded += FormCreateRequest_Load;
        }

        private void FormCreateRequest_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var responseC = APICustomer.GetRequest("api/Customer/GetList");
                if (responseC.Result.IsSuccessStatusCode)
                {
                    List<CustomerViewModel> list = APICustomer.GetElement<List<CustomerViewModel>>(responseC);
                    if (list != null)
                    {
                        FCRCustomer.DisplayMemberPath = "CustomerFIO";
                        FCRCustomer.SelectedValuePath = "Id";
                        FCRCustomer.ItemsSource = list;
                        FCRCake.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(responseC));
                }
                var responseP = APICustomer.GetRequest("api/Cake/GetList");
                if (responseP.Result.IsSuccessStatusCode)
                {
                    List<CakeViewModel> list = APICustomer.GetElement<List<CakeViewModel>>(responseP);
                    if (list != null)
                    {
                        FCRCake.DisplayMemberPath = "CakeName";
                        FCRCake.SelectedValuePath = "Id";
                        FCRCake.ItemsSource = list;
                        FCRCake.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(responseP));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CalcSum()
        {
            if (FCRCake.SelectedItem != null && !string.IsNullOrEmpty(FCRNumber.Text))
            {
                try
                {
                    int id = ((CakeViewModel)FCRCake.SelectedItem).Id;
                    var responseP = APICustomer.GetRequest("api/Cake/Get/" + id);
                    if (responseP.Result.IsSuccessStatusCode)
                    {
                        CakeViewModel Cake = APICustomer.GetElement<CakeViewModel>(responseP);
                        int count = Convert.ToInt32(FCRNumber.Text);
                        FCRSum.Text = (count * (int)Cake.Price).ToString();
                    }
                    else
                    {
                        throw new Exception(APICustomer.GetError(responseP));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void FCRSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FCRNumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FCRCustomer.SelectedItem == null)
            {
                MessageBox.Show("Выберите получателя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FCRCake.SelectedItem == null)
            {
                MessageBox.Show("Выберите мебель", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var response = APICustomer.PostRequest("api/Main/CreateRequest", new RequestBindingModel
                {
                    CustomerId = Convert.ToInt32(FCRCustomer.SelectedValue),
                    CakeId = Convert.ToInt32(FCRCake.SelectedValue),
                    Count = Convert.ToInt32(FCRNumber.Text),
                    Sum = Convert.ToInt32(FCRSum.Text)
                });
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

        private void FCRCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void FCRNumber_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            CalcSum();
        }
    }
}
