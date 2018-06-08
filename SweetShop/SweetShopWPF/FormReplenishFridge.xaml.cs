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
    /// Логика взаимодействия для FormReplenishFridge.xaml
    /// </summary>
    public partial class FormReplenishFridge : Window
    {

        public FormReplenishFridge()
        {
            InitializeComponent();
            Loaded += FormReplenishFridge_Load;
        }

        private void FormReplenishFridge_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var responseC = APICustomer.GetRequest("api/Ingredient/GetList");
                if (responseC.Result.IsSuccessStatusCode)
                {
                    List<IngredientViewModel> list = APICustomer.GetElement<List<IngredientViewModel>>(responseC);
                    if (list != null)
                    {
                        FRFIngredient.DisplayMemberPath = "IngredientName";
                        FRFIngredient.SelectedValuePath = "Id";
                        FRFIngredient.ItemsSource = list;
                        FRFIngredient.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(responseC));
                }
                var responseS = APICustomer.GetRequest("api/Fridge/GetList");
                if (responseS.Result.IsSuccessStatusCode)
                {
                    List<FridgeViewModel> list = APICustomer.GetElement<List<FridgeViewModel>>(responseS);
                    if (list != null)
                    {
                        FRFFridge.DisplayMemberPath = "FridgeName";
                        FRFFridge.SelectedValuePath = "Id";
                        FRFFridge.ItemsSource = list;
                        FRFFridge.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(responseC));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FRFSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FRFNumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FRFIngredient.SelectedItem == null)
            {
                MessageBox.Show("Выберите заготовку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FRFFridge.SelectedItem == null)
            {
                MessageBox.Show("Выберите базу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var response = APICustomer.PostRequest("api/Main/ReplenishFridge", new FridgeIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(FRFIngredient.SelectedValue),
                    FridgeId = Convert.ToInt32(FRFFridge.SelectedValue),
                    Count = Convert.ToInt32(FRFNumber.Text)
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

        private void FRFCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
