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
    /// Логика взаимодействия для FormFridge.xaml
    /// </summary>
    public partial class FormFridge : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IFridgeService service;

        private int? id;

        public FormFridge(IFridgeService service)
        {
            InitializeComponent();
            this.service = service;
            Loaded += FormFridge_Load;
        }

        private void FormFridge_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    FridgeViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        FFrName.Text = view.FridgeName;
                        FFrList.ItemsSource = view.FridgeIngredients;
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
                if (id.HasValue)
                {
                    service.UpdElement(new FridgeBindingModel
                    {
                        Id = id.Value,
                        FridgeName = FFrName.Text
                    });
                }
                else
                {
                    service.AddElement(new FridgeBindingModel
                    {
                        FridgeName = FFrName.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
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
