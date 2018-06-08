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
    /// Логика взаимодействия для FormFridges.xaml
    /// </summary>
    public partial class FormFridges : Window
    {
        public FormFridges()
        {
            InitializeComponent();
            Loaded += FormFridges_Load;
        }

        private void FormFridges_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Fridge/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<FridgeViewModel> list = APICustomer.GetElement<List<FridgeViewModel>>(response);
                    if (list != null)
                    {
                        FFrSList.ItemsSource = list;
                        FFrSList.Columns[0].Visibility = Visibility.Hidden;
                        FFrSList.Columns[1].Width = DataGridLength.Auto;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void FFrSAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormFridge();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void FFrSUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FFrSList.SelectedItem != null)
            {
                var form = new FormFridge();
                form.Id = ((FridgeViewModel)FFrSList.SelectedItem).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void FFrSRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void FFrSDel_Click(object sender, RoutedEventArgs e)
        {
            if (FFrSList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((FridgeViewModel)FFrSList.SelectedItem).Id;
                    try
                    {
                        var response = APICustomer.PostRequest("api/Fridge/DelElement", new CustomerBindingModel { Id = id });
                        if (!response.Result.IsSuccessStatusCode)
                        {
                            throw new Exception(APICustomer.GetError(response));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
