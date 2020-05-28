using System;
using System.Windows.Forms;
using SourceCode.Controlador;
using SourceCode.Modelo;

namespace SourceCode.Vista
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            PoblarControles();
        }

        private void PoblarControles()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "username";
            comboBox1.DataSource = AppUserDAO.getLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCambiarContra unaVentana = new frmCambiarContra();
            unaVentana.ShowDialog();
            PoblarControles();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Encriptador.CompararMD5(textBox1.Text, comboBox1.SelectedValue.ToString()))
            {
                AppUser u = (AppUser) comboBox1.SelectedItem;
                

           
                    MessageBox.Show("¡Bienvenido!", 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    frmPrincipal ventana = new frmPrincipal(u);
                    ventana.Show();
                    this.Hide();
            
            }
            else
                MessageBox.Show("¡Contraseña incorrecta!", "SourceCode",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public AppOrder AppOrder { get; }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button2_Click(sender, e);
        }
    }
}