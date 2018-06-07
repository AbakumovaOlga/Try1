using SweetShopService.Interfaces;
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
    /// Логика взаимодействия для FormCustomers.xaml
    /// </summary>
    public partial class FormCustomers : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICustomerService service;

        public FormCustomers(ICustomerService service)
        {
            InitializeComponent();
            this.service = service;
            Loaded += FormCustomers_Load;
        }

        private void FormCustomers_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CustomerViewModel> list = service.GetList();
                if (list != null)
                {
                    FCusSList.ItemsSource = list;
                    FCusSList.Columns[0].Visibility = Visibility.Hidden;
                    FCusSList.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FCusSAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormCustomer>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void FCusSRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void FCusSDel_Click(object sender, RoutedEventArgs e)
        {
            if (FCusSList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((CustomerViewModel)FCusSList.SelectedItem).Id;
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void FCusSUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FCusSList.SelectedItem != null)
            {
                var form = Container.Resolve<FormCustomer>();
                form.Id = ((CustomerViewModel)FCusSList.SelectedItem).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }
    }
}
