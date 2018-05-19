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
using Unity;
using Unity.Attributes;

namespace SweetShopView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMainService service;

        public FormMain(IMainService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<RequestViewModel> list = service.GetList();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }

        private void ingredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIngredients>();
            form.ShowDialog();
        }

        private void cakesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCakes>();
            form.ShowDialog();
        }

        private void fridgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFridges>();
            form.ShowDialog();
        }

        private void bakersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormBakers>();
            form.ShowDialog();
        }

        private void replenishFridgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReplenishFridge>();
            form.ShowDialog();
        }

        private void FMCreate_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateRequest>();
            form.ShowDialog();
            LoadData();
        }

        private void FMTake_Click(object sender, EventArgs e)
        {
            if (FMList.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTakeRequestInWork>();
                form.Id = Convert.ToInt32(FMList.SelectedRows[0].Cells[0].Value);
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
                    service.FinishRequest(id);
                    LoadData();
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
                    service.PayRequest(id);
                    LoadData();
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
    }
}
