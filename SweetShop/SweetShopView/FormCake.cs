using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using SweetShopView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SweetShopView
{
    public partial class FormCake : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        private List<CakeIngredientViewModel> CakeIngredients;

        public FormCake()
        {
            InitializeComponent();
        }

        private void FormCake_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var Cake = Task.Run(() => APICustomer.GetRequestData<CakeViewModel>("api/Cake/Get/" + id.Value)).Result;
                    FCakeName.Text = Cake.CakeName;
                    FCakePrice.Text = Cake.Price.ToString();
                    CakeIngredients = Cake.CakeIngredients;
                    LoadData();
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    FCList.DataSource = null;
                    FCList.DataSource = CakeIngredients;
                    FCList.Columns[0].Visible = false;
                    FCList.Columns[1].Visible = false;
                    FCList.Columns[2].Visible = false;
                    FCList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCakeAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCakeIngredient();
            if (form.ShowDialog() == DialogResult.OK)
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

        private void FCakeUpd_Click(object sender, EventArgs e)
        {
            if (FCList.SelectedRows.Count == 1)
            {
                var form = new FormCakeIngredient();
                form.Model = CakeIngredients[FCList.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CakeIngredients[FCList.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void FCakeDel_Click(object sender, EventArgs e)
        {
            if (FCList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        CakeIngredients.RemoveAt(FCList.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void FCakeRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FCakeSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FCakeName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(FCakePrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CakeIngredients == null || CakeIngredients.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            string name = FCakeName.Text;
            int price = Convert.ToInt32(FCakePrice.Text);
            Task task;
            if (id.HasValue)
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Cake/UpdElement", new CakeBindingModel
                {
                    Id = id.Value,
                    CakeName = name,
                    Price = price,
                    CakeIngredients = CakeIngredientBM
                }));
            }
            else
            {
                task = Task.Run(() => APICustomer.PostRequestData("api/Cake/AddElement", new CakeBindingModel
                {
                    CakeName = name,
                    Price = price,
                    CakeIngredients = CakeIngredientBM
                }));
            }

            task.ContinueWith((prevTask) => MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }, TaskContinuationOptions.OnlyOnFaulted);

            Close();
        }

        private void FCakeCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}