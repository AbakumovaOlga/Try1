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
    /// Логика взаимодействия для FormFridges.xaml
    /// </summary>
    public partial class FormFridges : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IFridgeService service;

        public FormFridges(IFridgeService service)
        {
            InitializeComponent();
            this.service = service;
            Loaded += FormFridges_Load;
        }

        private void FormFridges_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                List<FridgeViewModel> list = service.GetList();
                if (list != null)
                {
                    FFrSList.ItemsSource = list;
                    FFrSList.Columns[0].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void FFrSAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormFridge>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void FFrSUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FFrSList.SelectedItem != null)
            {
                var form = Container.Resolve<FormFridge>();
                form.Id = ((BakerViewModel)FFrSList.SelectedItem).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void FFrSRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void FFrSDel_Click(object sender, RoutedEventArgs e)
        {
            if (FFrSList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((FridgeViewModel)FFrSList.SelectedItem).Id;
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
