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
    /// Логика взаимодействия для FormCakeIngredient.xaml
    /// </summary>
    public partial class FormCakeIngredient : Window
    {

        public CakeIngredientViewModel Model { set { model = value; } get { return model; } }

        private CakeIngredientViewModel model;

        public FormCakeIngredient()
        {
            InitializeComponent();
            Loaded += FormCakeIngredient_Load;
        }

        private void FormCakeIngredient_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = APICustomer.GetRequest("api/Ingredient/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    FCIIngr.DisplayMemberPath = "IngredientName";
                    FCIIngr.SelectedValuePath = "Id";
                    FCIIngr.ItemsSource = APICustomer.GetElement<List<IngredientViewModel>>(response);
                    FCIIngr.SelectedItem = null;
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

            if (model != null)
            {
                FCIIngr.IsEnabled = false;
                FCIIngr.SelectedValue = model.IngredientId;
                FCINumber.Text = model.Count.ToString();
            }
        }

        private void FCISave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FCINumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FCIIngr.SelectedItem == null)
            {
                MessageBox.Show("Выберите заготовку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new CakeIngredientViewModel
                    {
                        IngredientId = Convert.ToInt32(FCIIngr.SelectedValue),
                        IngredientName = FCIIngr.Text,
                        Count = Convert.ToInt32(FCINumber.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(FCINumber.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FCICancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
