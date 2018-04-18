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
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;

namespace SweetShopView
{
    public partial class FormIngredients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IIngredientService service;

        public FormIngredients(IIngredientService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FIngrSAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIngredient>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {
                List<IngredientViewModel> list = service.GetList();
                if (list != null)
                {
                    FIngrSList.DataSource = list;
                    FIngrSList.Columns[0].Visible = false;
                    FIngrSList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FIngrSUpd_Click(object sender, EventArgs e)
        {
            if (FIngrSList.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormIngredient>();
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

        private void FIngrSRel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormIngredients_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
