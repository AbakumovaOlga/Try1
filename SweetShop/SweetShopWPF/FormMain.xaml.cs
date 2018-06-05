using Microsoft.Win32;
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
    /// Логика взаимодействия для FormMain.xaml
    /// </summary>
    public partial class FormMain : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IMainService service;
        private readonly IReportService reportService;
        public FormMain(IMainService service, IReportService reportService)
        {
            InitializeComponent();
            this.service = service;
            this.reportService = reportService;
            Loaded += FormMain_Load;
        }

        private void FormMain_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<RequestViewModel> list = service.GetList();
                if (list != null)
                {
                    FMList.ItemsSource = list;
                    FMList.Columns[0].Visibility = Visibility.Hidden;
                    FMList.Columns[1].Visibility = Visibility.Hidden;
                    FMList.Columns[3].Visibility = Visibility.Hidden;
                    FMList.Columns[5].Visibility = Visibility.Hidden;
                    FMList.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void cakesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormCakes>();
            form.ShowDialog();
        }

        private void bakersToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormBakers>();
            form.ShowDialog();
        }

        private void customersToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }

        private void fridgesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormFridges>();
            form.ShowDialog();
        }

        private void ingredientsToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormIngredients>();
            form.ShowDialog();
        }

        private void replenishToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormReplenishFridge>();
            form.ShowDialog();
        }

        private void FMCreate_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormCreateRequest>();
            form.ShowDialog();
            LoadData();
        }

        private void FMPay_Click(object sender, RoutedEventArgs e)
        {
            if (FMList.SelectedItem != null)
            {
                int id = ((RequestViewModel)FMList.SelectedItem).Id;
                try
                {
                    service.PayRequest(id);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void FMTake_Click(object sender, RoutedEventArgs e)
        {
            if (FMList.SelectedItem != null)
            {
                var form = Container.Resolve<FormTakeRequestInWork>();
                form.Id = ((RequestViewModel)FMList.SelectedItem).Id;
                form.ShowDialog();
                LoadData();
            }
        }

        private void FMFinish_Click(object sender, RoutedEventArgs e)
        {
            if (FMList.SelectedItem != null)
            {
                int id = ((RequestViewModel)FMList.SelectedItem).Id;
                try
                {
                    service.FinishRequest(id);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void FMRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void priceCakesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    reportService.SaveCakePrice(new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void customersRequestsToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {

            var form = Container.Resolve<FormCustomerRequests>();
            form.ShowDialog();
        }

        private void fullnessOfFridgesToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    reportService.SaveFridgesLoad(new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
