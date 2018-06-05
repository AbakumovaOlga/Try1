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
    public partial class FormCreateRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ICustomerService serviceC;

        private readonly ICakeService serviceCake;

        private readonly IMainService serviceM;

        public FormCreateRequest(ICustomerService serviceC, ICakeService serviceCake, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceCake = serviceCake;
            this.serviceM = serviceM;
        }

        private void FormCreateRequest_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    FCRCustomer.DisplayMember = "CustomerFIO";
                    FCRCustomer.ValueMember = "Id";
                    FCRCustomer.DataSource = listC;
                    FCRCustomer.SelectedItem = null;
                }
                List<CakeViewModel> listP = serviceCake.GetList();
                if (listP != null)
                {
                    FCRCake.DisplayMember = "CakeName";
                    FCRCake.ValueMember = "Id";
                    FCRCake.DataSource = listP;
                    FCRCake.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (FCRCake.SelectedValue != null && !string.IsNullOrEmpty(FCRNumber.Text))
            {
                try
                {
                    int id = Convert.ToInt32(FCRCake.SelectedValue);
                    CakeViewModel Cake = serviceCake.GetElement(id);
                    int Number = Convert.ToInt32(FCRNumber.Text);
                    FCRSum.Text = (Number * (int)Cake.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FCRNumber_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void FCRCake_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void FCRSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FCRNumber.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FCRCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FCRCake.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.CreateRequest(new RequestBindingModel
                {
                    CustomerId = Convert.ToInt32(FCRCustomer.SelectedValue),
                    CakeId = Convert.ToInt32(FCRCake.SelectedValue),
                    Count = Convert.ToInt32(FCRNumber.Text),
                    Sum = Convert.ToInt32(FCRSum.Text)
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

        private void FCRCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
