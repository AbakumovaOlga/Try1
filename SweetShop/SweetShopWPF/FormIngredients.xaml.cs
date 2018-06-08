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
    /// Логика взаимодействия для FormIngredients.xaml
    /// </summary>
    public partial class FormIngredients : Window
    {
        public FormIngredients()
        {
            InitializeComponent();
            Loaded += FormIngredients_Load;
        }

        private void FormIngredients_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Ingredient/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<IngredientViewModel> list = APICustomer.GetElement<List<IngredientViewModel>>(response);
                    if (list != null)
                    {
                        FIngrSList.ItemsSource = list;
                        FIngrSList.Columns[0].Visibility = Visibility.Hidden;
                        FIngrSList.Columns[1].Width = DataGridLength.Auto;
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

        private void FIngrSAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = new FormIngredient();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void FIngrSRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void FIngrSDel_Click(object sender, RoutedEventArgs e)
        {
            if (FIngrSList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((IngredientViewModel)FIngrSList.SelectedItem).Id;
                    try
                    {
                        var response = APICustomer.PostRequest("api/Ingredient/DelElement", new CustomerBindingModel { Id = id });
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

        private void FIngrSUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FIngrSList.SelectedItem != null)
            {
                var form = new FormIngredient();
                form.Id = ((IngredientViewModel)FIngrSList.SelectedItem).Id;
                if (form.ShowDialog() == true)
                    LoadData();
            }
        }
    }
}
