using SweetShopService.BindingModels;
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
    public partial class FormCustomer : Form
    {
        [Dependency]

        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ICustomerService service;

        private int? id;

        public FormCustomer(ICustomerService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        FCusFIO.Text = view.CustomerFIO;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FCusSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FCusFIO.Text))
            {
                MessageBox.Show("Check FIO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new CustomerBindingModel
                    {
                        Id = id.Value,
                        CustomerFIO = FCusFIO.Text
                    });
                }
                else
                {
                    service.AddElement(new CustomerBindingModel
                    {
                        CustomerFIO = FCusFIO.Text
                    });
                }
                MessageBox.Show("Save: Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCusCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
