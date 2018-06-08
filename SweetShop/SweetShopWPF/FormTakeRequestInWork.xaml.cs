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
    /// Логика взаимодействия для FormTakeRequestInWork.xaml
    /// </summary>
    public partial class FormTakeRequestInWork : Window
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormTakeRequestInWork()
        {
            InitializeComponent();
            Loaded += FormTakeRequestInWork_Load;
        }

        private void FormTakeRequestInWork_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!id.HasValue)
                {
                    MessageBox.Show("Не указана заявка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
                var response = APICustomer.GetRequest("api/Baker/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<BakerViewModel> list = APICustomer.GetElement<List<BakerViewModel>>(response);
                    if (list != null)
                    {
                        FTRBaker.DisplayMemberPath = "BakerFIO";
                        FTRBaker.SelectedValuePath = "Id";
                        FTRBaker.ItemsSource = list;
                        FTRBaker.SelectedItem = null;

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

        private void FTRSave_Click(object sender, RoutedEventArgs e)
        {
            if (FTRBaker.SelectedItem == null)
            {
                MessageBox.Show("Выберите рабочего", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var response = APICustomer.PostRequest("api/Main/TakeRequestInWork", new RequestBindingModel
                {
                    Id = id.Value,
                    BakerId = ((BakerViewModel)FTRBaker.SelectedItem).Id,
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

        private void FTRCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
