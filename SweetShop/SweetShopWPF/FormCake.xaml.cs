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
    /// Логика взаимодействия для FormCake.xaml
    /// </summary>
    public partial class FormCake : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ICakeService service;

        private int? id;

        private List<CakeIngredientViewModel> CakeIngredients;
        public FormCake(ICakeService service)
        {
            InitializeComponent();
            this.service = service;
            Loaded += FormCake_Load;
        }

        private void FormCake_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CakeViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        FCakeName.Text = view.CakeName;
                        FCakePrice.Text = view.Price.ToString();
                        CakeIngredients = view.CakeIngredients;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                CakeIngredients = new List<CakeIngredientViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (CakeIngredients != null)
                {
                    FCList.ItemsSource = null;
                    FCList.ItemsSource = CakeIngredients;
                    FCList.Columns[0].Visibility = Visibility.Hidden;
                    FCList.Columns[1].Visibility = Visibility.Hidden;
                    FCList.Columns[2].Visibility = Visibility.Hidden;
                    FCList.Columns[3].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FCakeAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<FormCakeIngredient>();
            if (form.ShowDialog() == true)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.CakeId = id.Value;
                    }
                    CakeIngredients.Add(form.Model);
                }
                LoadData();
            }
        }

        private void FCakeUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FCList.SelectedItem != null)
            {
                var form = Container.Resolve<FormCakeIngredient>();
                form.Model = CakeIngredients[FCList.SelectedIndex];
                if (form.ShowDialog() == true)
                {
                    CakeIngredients[FCList.SelectedIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void FCakeDel_Click(object sender, RoutedEventArgs e)
        {
            if (FCList.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        CakeIngredients.RemoveAt(FCList.SelectedIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void FCakeRel_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void FCakeSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FCakeName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(FCakePrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (CakeIngredients == null || CakeIngredients.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                List<CakeIngredientBindingModel> CakeIngredientBM = new List<CakeIngredientBindingModel>();
                for (int i = 0; i < CakeIngredients.Count; ++i)
                {
                    CakeIngredientBM.Add(new CakeIngredientBindingModel
                    {
                        Id = CakeIngredients[i].Id,
                        CakeId = CakeIngredients[i].CakeId,
                        IngredientId = CakeIngredients[i].IngredientId,
                        Count = CakeIngredients[i].Count
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new CakeBindingModel
                    {
                        Id = id.Value,
                        CakeName = FCakeName.Text,
                        Price = Convert.ToInt32(FCakePrice.Text),
                        CakeIngredients = CakeIngredientBM
                    });
                }
                else
                {
                    service.AddElement(new CakeBindingModel
                    {
                        CakeName = FCakeName.Text,
                        Price = Convert.ToInt32(FCakePrice.Text),
                        CakeIngredients = CakeIngredientBM
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

        private void FCakeCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
