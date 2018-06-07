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
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IBakerService serviceB;

        private readonly IMainService serviceM;

        private int? id;

        public FormTakeRequestInWork(IBakerService serviceB, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceB = serviceB;
            this.serviceM = serviceM;
            Loaded += FormTakeRequestInWork_Load;
        }

        private void FormTakeRequestInWork_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!id.HasValue)
                {
                    MessageBox.Show("Не указан заказ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
                List<BakerViewModel> listI = serviceB.GetList();
                if (listI != null)
                {
                    FTRBaker.DisplayMemberPath = "BakerFIO";
                    FTRBaker.SelectedValuePath = "Id";
                    FTRBaker.ItemsSource = listI;
                    FTRBaker.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FTRSave_Click(object sender, RoutedEventArgs e)
        {
            if (FTRBaker.SelectedValue == null)
            {
                MessageBox.Show("Выберите исполнителя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.TakeRequestInWork(new RequestBindingModel
                {
                    Id = id.Value,
                    BakerId = Convert.ToInt32(FTRBaker.SelectedValue)
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

        private void FTRCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
