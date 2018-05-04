using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;

namespace SweetShopView
{
    public partial class FormIngredients : Form
    {
        public FormIngredients()
        {
            InitializeComponent();
        }

        private void FormIngredients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<IngredientViewModel> list = Task.Run(() => APICustomer.GetRequestData<List<IngredientViewModel>>("api/Ingredient/GetList")).Result;
                if (list != null)
                {
                    FIngrSList.DataSource = list;
                    FIngrSList.Columns[0].Visible = false;
                    FIngrSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
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

        private void FIngrSAdd_Click(object sender, EventArgs e)
        {
            var form = new FormIngredient();
            form.ShowDialog();
        }

        private void FIngrSUpd_Click(object sender, EventArgs e)
        {
            if (FIngrSList.SelectedRows.Count == 1)
            {
                var form = new FormIngredient
                {
                    Id = Convert.ToInt32(FIngrSList.SelectedRows[0].Cells[0].Value)
                };
                form.ShowDialog();
            }
        }

        private void FIngrSDel_Click(object sender, EventArgs e)
        {
            if (FIngrSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FIngrSList.SelectedRows[0].Cells[0].Value);

                    Task task = Task.Run(() => APICustomer.PostRequestData("api/Ingredient/DelElement", new CustomerBindingModel { Id = id }));

                    task.ContinueWith((prevTask) => MessageBox.Show("Запись удалена. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information),
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
                }
            }
        }

        private void FIngrSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}