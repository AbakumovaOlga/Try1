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
    /// Логика взаимодействия для FormBakers.xaml
    /// </summary>
    public partial class FormBakers : Window
    {
        public FormBakers()
        {
            InitializeComponent();
            Loaded += FormBakers_Load;
        }

        private void FormBakers_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Baker/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<BakerViewModel> list = APICustomer.GetElement<List<BakerViewModel>>(response);
                    if (list != null)
                    {
                        FBakSList.ItemsSource = list;
                        FBakSList.Columns[0].Visibility = Visibility.Hidden;
                        FBakSList.Columns[1].Width = DataGridLength.Auto;
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

        private void FBakSRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void FBakSDel_Click(object sender, RoutedEventArgs e)
        {
            if (FBakSList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((BakerViewModel)FBakSList.SelectedItem).Id;
                    try
                    {
                        var response = APICustomer.PostRequest("api/Baker/DelElement", new CustomerBindingModel { Id = id });
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

        private void FBakSUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FBakSList.SelectedItem != null)
            {
                var form = new Baker();
                form.Id = ((BakerViewModel)FBakSList.SelectedItem).Id;
                if (form.ShowDialog() == true)
                    LoadData();
            }
        }

        private void FBakSAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = new Baker();
            if (form.ShowDialog() == true)
                LoadData();
        }
    }
}
