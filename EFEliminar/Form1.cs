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

namespace EFEliminar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CategoryRepository repository = new CategoryRepository();

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var categoria = repository.Obtener();
            dgvCategory.DataSource = categoria;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtObtenerTodos.Text);
            var categoria = repository.ObtenerPorID(id);
            List<Categories> lista1 = new List<Categories> { categoria };
            if (categoria != null)
            {
                llenarCampos(categoria);
            }
            dgvCategory.DataSource = lista1;
        }

        private void llenarCampos(Categories categories)
        {
            tbxCategoryID.Text = categories.CategoryID.ToString();
            tbxCategoryName.Text = categories.CategoryName;
            tbxDescription.Text = categories.Description;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbxCategoryID.Text, out int categoryID))
            {
                var eliminadas = repository.DeleteCategoria(categoryID);

                MessageBox.Show($"Se ha eliminado {eliminadas} filas ");
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido, porfax.");
            }
        }
    }
}
