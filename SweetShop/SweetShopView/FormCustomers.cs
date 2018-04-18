using SweetShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class FormCustomers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICustomerService service;

        public FormCustomers(ICustomerService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormCustomers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CustomerViewModel> list = service.GetList();
                if (list != null)
                {
                    FCusSList.DataSource = list;
                    FCusSList.Columns[0].Visible = false;
                    FCusSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCusSAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomer>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void FCusSUpd_Click(object sender, EventArgs e)
        {
            if (FCusSList.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormCustomer>();
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
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void FCusSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormCustomers_Load_1(object sender, EventArgs e)
        {

        }
    }
}
