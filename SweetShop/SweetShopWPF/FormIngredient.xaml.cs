using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
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
    /// Логика взаимодействия для FormIngredient.xaml
    /// </summary>
    public partial class FormIngredient : Window
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormIngredient()
        {
            InitializeComponent();
            Loaded += FormIngredient_Load;
        }

        private void FormIngredient_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Ingredient/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var Ingredient = APICustomer.GetElement<IngredientViewModel>(response);
                        FIngrName.Text = Ingredient.IngredientName;
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

        private void FIngrSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FIngrName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Ingredient/UpdElement", new IngredientBindingModel
                    {
                        Id = id.Value,
                        IngredientName = FIngrName.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Ingredient/AddElement", new IngredientBindingModel
                    {
                        IngredientName = FIngrName.Text
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

        private void FIngrCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
