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
    public partial class FormBakers : Form
    {
        public FormBakers()
        {
            InitializeComponent();
        }

        private void FormBakers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var response = APICustomer.GetRequest("api/Baker/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    List<BakerViewModel> list = APICustomer.GetElement<List<BakerViewModel>>(response);
                    if (list != null)
                    {
                        FBakSList.DataSource = list;
                        FBakSList.Columns[0].Visible = false;
                        FBakSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void FBakSAdd_Click(object sender, EventArgs e)
        {
            var form = new FormBaker();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void FBakSUpd_Click(object sender, EventArgs e)
        {
            if (FBakSList.SelectedRows.Count == 1)
            {
                var form = new FormBaker();
                form.Id = Convert.ToInt32(FBakSList.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void FBakSDel_Click(object sender, EventArgs e)
        {
            if (FBakSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FBakSList.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        var response = APICustomer.PostRequest("api/Baker/DelElement", new CustomerBindingModel { Id = id });
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

        private void FBakSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void FBakSList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
