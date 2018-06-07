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
    /// Логика взаимодействия для FormReplenishFridge.xaml
    /// </summary>
    public partial class FormReplenishFridge : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IFridgeService serviceF;

        private readonly IIngredientService serviceI;

        private readonly IMainService serviceM;

        public FormReplenishFridge(IFridgeService serviceF, IIngredientService serviceI, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceF = serviceF;
            this.serviceI = serviceI;
            this.serviceM = serviceM;
            Loaded += FormReplenishFridge_Load;
        }

        private void FormReplenishFridge_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                List<IngredientViewModel> listC = serviceI.GetList();
                if (listC != null)
                {
                    FRFIngredient.DisplayMemberPath = "IngredientName";
                    FRFIngredient.SelectedValuePath = "Id";
                    FRFIngredient.ItemsSource = listC;
                    FRFIngredient.SelectedItem = null;
                }
                List<FridgeViewModel> listS = serviceF.GetList();
                if (listS != null)
                {
                    FRFFridge.DisplayMemberPath = "FridgeName";
                    FRFFridge.SelectedValuePath = "Id";
                    FRFFridge.ItemsSource = listS;
                    FRFFridge.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FRFSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FRFNumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FRFIngredient.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FRFFridge.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.PutIngredientOnFridge(new FridgeIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(FRFIngredient.SelectedValue),
                    FridgeId = Convert.ToInt32(FRFFridge.SelectedValue),
                    Count = Convert.ToInt32(FRFNumber.Text)
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

        private void FRFCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
