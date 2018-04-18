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
using Unity;
using Unity.Attributes;

namespace SweetShopView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMainService service;
        private readonly IReportService reportService;

        public FormMain(IMainService service, IReportService reportService)
        {
            InitializeComponent();
            this.service = service;
            this.reportService = reportService;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

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

        private void FMList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    reportService.SaveCakePrice(new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void fullnessOfFridgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFridgesLoad>();
            form.ShowDialog();
        }

        private void customersRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomerRequests>();
            form.ShowDialog();
        }
    }
}
