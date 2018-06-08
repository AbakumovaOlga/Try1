using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SweetShopView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Main/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<RequestViewModel> list = APICustomer.GetElement<List<RequestViewModel>>(response);
                    if (list != null)
                    {
                        FMList.DataSource = list;
                        FMList.Columns[0].Visible = false;
                        FMList.Columns[1].Visible = false;
                        FMList.Columns[3].Visible = false;
                        FMList.Columns[5].Visible = false;
                        FMList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCustomers();
            form.ShowDialog();
        }

        private void ingredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormIngredients();
            form.ShowDialog();
        }

        private void cakesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCakes();
            form.ShowDialog();
        }

        private void fridgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormFridges();
            form.ShowDialog();
        }

        private void bakersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormBakers();
            form.ShowDialog();
        }

        private void replenishFridgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReplenishFridge();
            form.ShowDialog();
        }

        private void FMCreate_Click(object sender, EventArgs e)
        {
            var form = new FormCreateRequest();
            form.ShowDialog();
            LoadData();
        }

        private void FMTake_Click(object sender, EventArgs e)
        {
            if (FMList.SelectedRows.Count == 1)
            {
                var form = new FormTakeRequestInWork
                {
                    Id = Convert.ToInt32(FMList.SelectedRows[0].Cells[0].Value)
                };
                form.ShowDialog();
                LoadData();
            }
        }

        private void FMFinish_Click(object sender, EventArgs e)
        {
            if (FMList.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(FMList.SelectedRows[0].Cells[0].Value);
                try
                {
                    var response = APICustomer.PostRequest("api/Main/FinishRequest", new RequestBindingModel
                    {
                        Id = id
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        LoadData();
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
        }

        private void FMPay_Click(object sender, EventArgs e)
        {
            if (FMList.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(FMList.SelectedRows[0].Cells[0].Value);
                try
                {
                    var response = APICustomer.PostRequest("api/Main/PayRequest", new RequestBindingModel
                    {
                        Id = id
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        LoadData();
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
        }

        private void FMRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void priceCakesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var response = APICustomer.PostRequest("api/Report/SaveCakePrice", new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void fullnessOfFridgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormFridgesLoad();
            form.ShowDialog();
        }

        private void customersRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCustomerRequests();
            form.ShowDialog();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}