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
    public partial class FormFridges : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IFridgeService service;

        public FormFridges(IFridgeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormFridges_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<FridgeViewModel> list = service.GetList();
                if (list != null)
                {
                    FFrSList.DataSource = list;
                    FFrSList.Columns[0].Visible = false;
                    FFrSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FFrSAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFridge>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void FFrSUpd_Click(object sender, EventArgs e)
        {
            if (FFrSList.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormFridge>();
                form.Id = Convert.ToInt32(FFrSList.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void FFrSDel_Click(object sender, EventArgs e)
        {
            if (FFrSList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(FFrSList.SelectedRows[0].Cells[0].Value);
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

        private void FFrSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
