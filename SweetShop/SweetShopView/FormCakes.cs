using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SweetShopView
{
    public partial class FormCakes : Form
    {

        public FormCakes()
        {
            InitializeComponent();
        }

        private void FormCakes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Cake/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<CakeViewModel> list = APICustomer.GetElement<List<CakeViewModel>>(response);
                    if (list != null)
                    {
                        FCakeSList.DataSource = list;
                        FCakeSList.Columns[0].Visible = false;
                        FCakeSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void FCakeSAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCake();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void FCakeSUpd_Click(object sender, EventArgs e)
        {
            if (FCakeSList.SelectedRows.Count == 1)
            {
                var form = new FormCake();
                form.Id = Convert.ToInt32(FCakeSList.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void FCakeSDel_Click(object sender, EventArgs e)
        {
            if (FCakeSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FCakeSList.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        var response = APICustomer.PostRequest("api/Cake/DelElement", new CustomerBindingModel { Id = id });
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

        private void FCakeSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}

