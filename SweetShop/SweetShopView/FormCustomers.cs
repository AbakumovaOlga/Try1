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
    public partial class FormCustomers : Form
    {
        public FormCustomers()
        {
            InitializeComponent();
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Customer/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<CustomerViewModel> list = APICustomer.GetElement<List<CustomerViewModel>>(response);
                    if (list != null)
                    {
                        FCusSList.DataSource = list;
                        FCusSList.Columns[0].Visible = false;
                        FCusSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void FCusSAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCustomer();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void FCusSUpd_Click(object sender, EventArgs e)
        {
            if (FCusSList.SelectedRows.Count == 1)
            {
                var form = new FormCustomer();
                form.Id = Convert.ToInt32(FCusSList.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void FCusSDel_Click(object sender, EventArgs e)
        {
            if (FCusSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FCusSList.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        var response = APICustomer.PostRequest("api/Customer/DelElement", new CustomerBindingModel { Id = id });
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


        private void FCusSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}