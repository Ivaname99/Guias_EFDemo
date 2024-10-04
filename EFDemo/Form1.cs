using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CustomerRepository cr = new CustomerRepository();

        private Customers CrearCliente()
        {
            var cliente = new Customers
            {
                CustomerID = tbxCustomerID.Text,
                CompanyName = tbxCompanyName.Text,
                ContactName = tbxContactName.Text,
                ContactTitle = tbxContactTitle.Text,
                Address = tbxAddress.Text,
            };
            return cliente;
        }

        private void llenarCampos(Customers customers)
        {
            tbxCustomerID.Text = customers.CustomerID;
            tbxCompanyName.Text = customers.CompanyName;
            tbxContactName.Text = customers.ContactName;
            tbxContactTitle.Text = customers.ContactTitle;
            tbxAddress.Text = customers.Address;
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerTodos();
            dgvCustomers.DataSource = cliente;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerPorID(tbxObtenerTodos.Text);
            List<Customers> lista1 = new List<Customers>{cliente};

            if (cliente != null)
            {
                llenarCampos(cliente);
            }
            dgvCustomers.DataSource = lista1;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se inserto: {resultado}");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var ClienteActualizado = CrearCliente();
            cr.UpdateCliente(ClienteActualizado);
            var resultado = cr.ObtenerPorID(ClienteActualizado.CustomerID);
            List<Customers> lista1 = new List<Customers> { resultado };
            dgvCustomers.DataSource = lista1;
        }
    }
}
