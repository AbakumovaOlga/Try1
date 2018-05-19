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
    /// Логика взаимодействия для FormCakes.xaml
    /// </summary>
    public partial class FormCakes : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICakeService service;

        public FormCakes(ICakeService service)
        {
            InitializeComponent();
            this.service = service;
            Loaded += FormCakes_Load;
        }

        private void FormCakes_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CakeViewModel> list = service.GetList();
                if (list != null)
                {
                    FCakeSList.ItemsSource = list;
                    FCakeSList.Columns[0].Visibility = Visibility.Hidden;
                    FCakeSList.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FCakeSAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormCake>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void FCakeSAddDel_Click(object sender, RoutedEventArgs e)
        {
            if (FCakeSList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((BakerViewModel)FCakeSList.SelectedItem).Id;
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

        private void FCakeSUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FCakeSList.SelectedItem != null)
            {
                var form = Container.Resolve<FormCake>();
                form.Id = ((CakeViewModel)FCakeSList.SelectedItem).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void FCakeSAddRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

    }
}
