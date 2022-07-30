using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEA1
{
    public partial class frmTipoDocumentoEdit : Form
    {
        private int? Id;
       

        public frmTipoDocumentoEdit(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void frmTipoDocumentoEdit_Load(object sender, EventArgs e)
        {
            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new dsAppTableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptador.GetDataByld((int)this.Id);
                var fila = (dsApp.TipoDocumentoRow)tabla.Rows[0];
                txtNombre.Text = fila.Nombre;
                chkDoc.Checked = fila.Estado == 1 ? true : false;
            }
            else
            {
                this.Text = "Nuevo";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int estado = chkDoc.Checked ? 1 : 0;
            string nombre = txtNombre.Text;
            var adaptador = new dsAppTableAdapters.TipoDocumentoTableAdapter();
            if (this.Id == null)
            {
                adaptador.Add(nombre, (byte)estado);
            }
            else
            {
                adaptador.Edit(nombre, (byte)estado, (int)this.Id);
            }
            this.Close();

        }
    }
}
