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
    /// Логика взаимодействия для FormCreateRequest.xaml
    /// </summary>
    public partial class FormCreateRequest : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICustomerService serviceC;

        private readonly ICakeService serviceCake;

        private readonly IMainService serviceM;

        public FormCreateRequest(ICustomerService serviceC, ICakeService serviceCake, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceCake = serviceCake;
            this.serviceM = serviceM;
            Loaded += FormCreateRequest_Load;
        }

        private void FormCreateRequest_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    FCRCustomer.DisplayMemberPath = "CustomerFIO";
                    FCRCustomer.SelectedValuePath = "Id";
                    FCRCustomer.ItemsSource = listC;
                    FCRCustomer.SelectedItem = null;
                }
                List<CakeViewModel> listP = serviceCake.GetList();
                if (listP != null)
                {
                    FCRCake.DisplayMemberPath = "CakeName";
                    FCRCake.SelectedValuePath = "Id";
                    FCRCake.ItemsSource = listP;
                    FCRCake.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CalcSum()
        {
            if (FCRCake.SelectedValue != null && !string.IsNullOrEmpty(FCRNumber.Text))
            {
                try
                {
                    int id = Convert.ToInt32(FCRCake.SelectedValue);
                    CakeViewModel Cake = serviceCake.GetElement(id);
                    int Number = Convert.ToInt32(FCRNumber.Text);
                    FCRSum.Text = (Number * Cake.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void FCRNumber_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }


        private void FCRCake_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void FCRSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FCRNumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FCRCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FCRCake.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.CreateRequest(new RequestBindingModel
                {
                    CustomerId = Convert.ToInt32(FCRCustomer.SelectedValue),
                    CakeId = Convert.ToInt32(FCRCake.SelectedValue),
                    Count = Convert.ToInt32(FCRNumber.Text),
                    Sum = Convert.ToInt32(FCRSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FCRCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void FCRCake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FCRNumber_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            CalcSum();
        }
    }
}
