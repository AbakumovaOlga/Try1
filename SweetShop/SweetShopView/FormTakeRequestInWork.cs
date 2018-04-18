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
using Unity;
using Unity.Attributes;

namespace SweetShopView
{
    public partial class FormTakeRequestInWork : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IBakerService serviceB;

        private readonly IMainService serviceM;

        private int? id;

        public FormTakeRequestInWork(IBakerService serviceB, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceB = serviceB;
            this.serviceM = serviceM;
        }

        private void FormBaker_Load(object sender, EventArgs e)
        {
            try
            {
                if (!id.HasValue)
                {
                    MessageBox.Show("Не указан заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                List<BakerViewModel> listI = serviceB.GetList();
                if (listI != null)
                {
                    FTRBaker.DisplayMember = "BakerFIO";
                    FTRBaker.ValueMember = "Id";
                    FTRBaker.DataSource = listI;
                    FTRBaker.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FTRSave_Click(object sender, EventArgs e)
        {
            if (FTRBaker.SelectedValue == null)
            {
                MessageBox.Show("Выберите исполнителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.TakeRequestInWork(new RequestBindingModel
                {
                    Id = id.Value,
                    BakerId = Convert.ToInt32(FTRBaker.SelectedValue)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FTRCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
