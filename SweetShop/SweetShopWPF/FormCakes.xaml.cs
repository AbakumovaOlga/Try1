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
    /// Логика взаимодействия для FormCakes.xaml
    /// </summary>
    public partial class FormCakes : Window
    {
        public FormCakes()
        {
            InitializeComponent();
            Loaded += FormCakes_Load;
        }

        private void FormCakes_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Cake/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<CakeViewModel> list = APICustomer.GetElement<List<CakeViewModel>>(response);
                    if (list != null)
                    {
                        FCakeSList.ItemsSource = list;
                        FCakeSList.Columns[0].Visibility = Visibility.Hidden;
                        FCakeSList.Columns[1].Width = DataGridLength.Auto;
                        FCakeSList.Columns[3].Visibility = Visibility.Hidden;
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

        private void FCakeSAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormCake();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void FCakeSAddDel_Click(object sender, RoutedEventArgs e)
        {
            if (FCakeSList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    int id = ((CakeViewModel)FCakeSList.SelectedItem).Id;
                    try
                    {
                        var response = APICustomer.PostRequest("api/Cake/DelElement", new CustomerBindingModel { Id = id });
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

        private void FCakeSUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FCakeSList.SelectedItem != null)
            {
                var form = new FormCake();
                form.Id = ((CakeViewModel)FCakeSList.SelectedItem).Id;
                if (form.ShowDialog() == true)
                    LoadData();
            }
        }

        private void FCakeSAddRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

    }
}
