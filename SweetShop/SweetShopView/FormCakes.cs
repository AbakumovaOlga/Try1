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
using Unity;
using Unity.Attributes;

namespace SweetShopView
{
    public partial class FormCakes : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICakeService service;

        public FormCakes(ICakeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FCakeSAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCake>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void FCakeSUpd_Click(object sender, EventArgs e)
        {
            if (FCakeSList.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormCake>();
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
                        service.DelElement(id);
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

        private void FormCakes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CakeViewModel> list = service.GetList();
                if (list != null)
                {
                    FCakeSList.DataSource = list;
                    FCakeSList.Columns[0].Visible = false;
                    FCakeSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
