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
    public partial class FormBaker : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IBakerService service;

        private int? id;

        public FormBaker(IBakerService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormBaker_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    BakerViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        FBakFIO.Text = view.BakerFIO;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FBakSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FBakFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new BakerBindingModel
                    {
                        Id = id.Value,
                        BakerFIO = FBakFIO.Text
                    });
                }
                else
                {
                    service.AddElement(new BakerBindingModel
                    {
                        BakerFIO = FBakFIO.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FBakCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
