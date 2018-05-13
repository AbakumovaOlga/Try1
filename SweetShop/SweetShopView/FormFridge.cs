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
    public partial class FormFridge : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IFridgeService service;

        private int? id;

        public FormFridge(IFridgeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FFrCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FFrSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FFrName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new FridgeBindingModel
                    {
                        Id = id.Value,
                        FridgeName = FFrName.Text
                    });
                }
                else
                {
                    service.AddElement(new FridgeBindingModel
                    {
                        FridgeName = FFrName.Text
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

        private void FormFridge_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    FridgeViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        FFrName.Text = view.FridgeName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
