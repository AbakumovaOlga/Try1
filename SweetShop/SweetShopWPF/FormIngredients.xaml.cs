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
    /// Логика взаимодействия для FormIngredients.xaml
    /// </summary>
    public partial class FormIngredients : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IIngredientService service;

        public FormIngredients(IIngredientService service)
        {
            InitializeComponent();
            this.service = service;
            Loaded += FormIngredients_Load;
        }

        private void FormIngredients_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<IngredientViewModel> list = service.GetList();
                if (list != null)
                {
                    FIngrSList.ItemsSource = list;
                    FIngrSList.Columns[0].Visibility = Visibility.Hidden;
                    FIngrSList.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FIngrSAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormIngredient>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void FIngrSRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void FIngrSDel_Click(object sender, RoutedEventArgs e)
        {
            if (FIngrSList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((IngredientViewModel)FIngrSList.SelectedItem).Id;
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

        private void FIngrSUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FIngrSList.SelectedItem != null)
            {
                var form = Container.Resolve<FormIngredient>();
                form.Id = ((IngredientViewModel)FIngrSList.SelectedItem).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }
    }
}
