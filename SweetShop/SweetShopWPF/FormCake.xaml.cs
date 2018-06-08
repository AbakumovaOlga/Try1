using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public int Id { set { id = value; } }
        
        private int? id;

        private List<CakeIngredientViewModel> CakeIngredients;

        public FormCake()
        {
            InitializeComponent();
            Loaded += FormCake_Load;
        }

        private void FormCake_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APICustomer.GetRequest("api/Cake/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var Cake = APICustomer.GetElement<CakeViewModel>(response);
                        FCakeName.Text = Cake.CakeName;
                        FCakePrice.Text = Cake.Price.ToString();
                        CakeIngredients = Cake.CakeIngredients;
                        LoadData();
                    }
                    else
                    {
                        throw new Exception(APICustomer.GetError(response));
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
            var form = new FormCakeIngredient();
            if (form.ShowDialog() == true)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                        form.Model.CakeId = id.Value;
                    CakeIngredients.Add(form.Model);
                }
                LoadData();
            }
        }

        private void FCakeUpd_Click(object sender, RoutedEventArgs e)
        {
            if (FCList.SelectedItem != null)
            {
                var form = new FormCakeIngredient();
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
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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
                MessageBox.Show("Заполните заготовки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                List<CakeIngredientBindingModel> productComponentBM = new List<CakeIngredientBindingModel>();
                for (int i = 0; i < CakeIngredients.Count; ++i)
                {
                    productComponentBM.Add(new CakeIngredientBindingModel
                    {
                        Id = CakeIngredients[i].Id,
                        CakeId = CakeIngredients[i].CakeId,
                        IngredientId = CakeIngredients[i].IngredientId,
                        Count = CakeIngredients[i].Count
                    });
                }
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APICustomer.PostRequest("api/Cake/UpdElement", new CakeBindingModel
                    {
                        Id = id.Value,
                        CakeName = FCakeName.Text,
                        Price = Convert.ToInt32(FCakePrice.Text),
                        CakeIngredients = productComponentBM
                    });
                }
                else
                {
                    response = APICustomer.PostRequest("api/Cake/AddElement", new CakeBindingModel
                    {
                        CakeName = FCakeName.Text,
                        Price = Convert.ToInt32(FCakePrice.Text),
                        CakeIngredients = productComponentBM
                    });
                }
                if (response.Result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                    Close();
                }
                else
                {
                    throw new Exception(APICustomer.GetError(response));
                }
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
