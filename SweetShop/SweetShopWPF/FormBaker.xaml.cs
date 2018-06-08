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
    /// Логика взаимодействия для Baker.xaml
    /// </summary>
    public partial class Baker : Window
    {
        public int Id { set { id = value; } }

        private int? id;

        public Baker()
        {
            InitializeComponent();
            Loaded += Baker_Load;
        }

        private void Baker_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Baker/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var rabochiy = APICustomer.GetElement<BakerViewModel>(response);
                        FBakFIO.Text = rabochiy.BakerFIO;
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

        private void FBSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FBakFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Baker/UpdElement", new BakerBindingModel
                    {
                        Id = id.Value,
                        BakerFIO = FBakFIO.Text
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Baker/AddElement", new BakerBindingModel
                    {
                        BakerFIO = FBakFIO.Text
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

        private void FBCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
