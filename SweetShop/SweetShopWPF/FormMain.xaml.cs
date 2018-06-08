using Microsoft.Win32;
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
    /// Логика взаимодействия для FormMain.xaml
    /// </summary>
    public partial class FormMain : Window
    {
        public FormMain()
        {
            InitializeComponent();
            Loaded += FormMain_Load;
        }

        private void FormMain_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Main/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<RequestViewModel> list = APICustomer.GetElement<List<RequestViewModel>>(response);
                    if (list != null)
                    {
                        FMList.ItemsSource = list;
                        FMList.Columns[0].Visibility = Visibility.Hidden;
                        FMList.Columns[1].Visibility = Visibility.Hidden;
                        FMList.Columns[3].Visibility = Visibility.Hidden;
                        FMList.Columns[5].Visibility = Visibility.Hidden;
                        FMList.Columns[1].Width = DataGridLength.Auto;
                    }
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
        private void cakesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormCakes();
            form.ShowDialog();
        }

        private void bakersToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormBakers();
            form.ShowDialog();
        }

        private void customersToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormCustomers();
            form.ShowDialog();
        }

        private void fridgesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormFridges();
            form.ShowDialog();
        }

        private void ingredientsToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormIngredients();
            form.ShowDialog();
        }

        private void replenishToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormReplenishFridge();
            form.ShowDialog();
        }

        private void FMCreate_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormCreateRequest();
            form.ShowDialog();
            LoadData();
        }

        private void FMPay_Click(object sender, RoutedEventArgs e)
        {
            if (FMList.SelectedItem != null)
            {
                int id = ((RequestViewModel)FMList.SelectedItem).Id;
                try
                {
                    var response = APICustomer.PostRequest("api/Main/PayRequest", new RequestBindingModel
                    {
                        Id = id
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        LoadData();
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

        private void FMTake_Click(object sender, RoutedEventArgs e)
        {
            if (FMList.SelectedItem != null)
            {
                var form = new FormTakeRequestInWork();
                form.Id = ((RequestViewModel)FMList.SelectedItem).Id;
                form.ShowDialog();
                LoadData();
            }
        }

        private void FMFinish_Click(object sender, RoutedEventArgs e)
        {
            if (FMList.SelectedItem != null)
            {
                int id = ((RequestViewModel)FMList.SelectedItem).Id;
                try
                {
                    var response = APICustomer.PostRequest("api/Main/FinishRequest", new RequestBindingModel
                    {
                        Id = id
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        LoadData();
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

        private void FMRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void priceCakesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };

            if (sfd.ShowDialog() == true)
            {
                try
                {
                    var response = APICustomer.PostRequest("api/Report/SaveCakePrice", new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        throw new Exception(APICustomer.GetError(response));
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void customersRequestsToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {

            var form = new FormCustomerRequests();
            form.ShowDialog();
        }

        private void fullnessOfFridgesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    var response = APICustomer.PostRequest("api/Report/SaveCakePrice", new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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
    }
}
