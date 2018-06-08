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
    /// Логика взаимодействия для FormFridge.xaml
    /// </summary>
    public partial class FormFridge : Window
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormFridge()
        {
            InitializeComponent();
            Loaded += FormFridge_Load;
        }

        private void FormFridge_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Fridge/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var Fridge = APICustomer.GetElement<FridgeViewModel>(response);
                        FFrName.Text = Fridge.FridgeName;
                        FFrList.ItemsSource = Fridge.FridgeIngredients;
                        FFrList.Columns[0].Visibility = Visibility.Hidden;
                        FFrList.Columns[1].Visibility = Visibility.Hidden;
                        FFrList.Columns[2].Visibility = Visibility.Hidden;
                        FFrList.Columns[3].Width = DataGridLength.Auto;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void FRSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FFrName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Fridge/UpdElement", new FridgeBindingModel
                    {
                        Id = id.Value,
                        FridgeName = FFrName.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Fridge/AddElement", new FridgeBindingModel
                    {
                        FridgeName = FFrName.Text
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

        private void FRCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
