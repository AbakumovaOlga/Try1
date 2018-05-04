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
                var response = APICustomer.GetRequest("api/Ingredient/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<IngredientViewModel> list = APICustomer.GetElement<List<IngredientViewModel>>(response);
                    if (list != null)
                    {
                        FIngrSList.DataSource = list;
                        FIngrSList.Columns[0].Visible = false;
                        FIngrSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                else
                {
                    throw new Exception(APICustomer.GetError(response));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FIngrSAdd_Click(object sender, EventArgs e)
        {
            var form = new FormIngredient();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void FIngrSUpd_Click(object sender, EventArgs e)
        {
            if (FIngrSList.SelectedRows.Count == 1)
            {
                var form = new FormIngredient();
                form.Id = Convert.ToInt32(FIngrSList.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void FIngrSDel_Click(object sender, EventArgs e)
        {
            if (FIngrSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FIngrSList.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        var response = APICustomer.PostRequest("api/Ingredient/DelElement", new CustomerBindingModel { Id = id });
                        if (!response.Result.IsSuccessStatusCode)
                        {
                            throw new Exception(APICustomer.GetError(response));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void FIngrSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
