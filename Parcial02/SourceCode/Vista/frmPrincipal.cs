using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode.Vista
{
    public partial class frmPrincipal : Form
    {
            private AppUser appuser;
            
            
            
            
        public frmPrincipal(AppUser user )
        {
            InitializeComponent();
            
            appuser = user;
           

        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            label1.Text = 
                "Bienvenido " + appuser.username + " [" + (appuser.usertype ? "Administrador" : "Usuario") + "]";

            if (appuser.usertype)
            {
            
                tabControl1.TabPages[7].Parent= null;
                tabControl1.TabPages[7].Parent= null;
                tabControl1.TabPages[7].Parent= null;
                tabControl1.TabPages[7].Parent= null;
                tabControl1.TabPages[7].Parent= null;
                
                
                actualizarControles();
            }
            else
            {
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                
                
                actualizarControles();
               
            }
        }

        private void actualizarControles()
        {
            List<AppUser> lista = AppUserDAO.getLista();
            
           
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;

            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "iduser";
            comboBox1.DataSource = lista;

            List<Business> list = BusinessDAO.getLista();
            
            comboBox2.DataSource = null;
             comboBox2.DisplayMember = "idbusiness";
             comboBox2.DataSource = list;
             
             List<Product> lis = ProductDAO.getLista();
             
             comboBox3.DataSource = null;
             comboBox3.DisplayMember = "idbusiness";
             comboBox3.DataSource = list;
             
             
         
            
            comboBox4.DataSource = null;
            comboBox4.DisplayMember = "idbusiness";
            comboBox4.DataSource = list;
            
             List<Adress> listAdress = AdressDAO.getLista();
            
            
            comboBox6.DataSource = null;
            comboBox6.DisplayMember = "idbusiness";
            comboBox6.DataSource = list;
            
            List<AppOrder> listOrders = AppOrderDAO.getLista();
            
            comboBox8.DataSource = null;
            comboBox8.DisplayMember = "idorder";
            comboBox8.DataSource = listOrders;
            
             dataGridView2.DataSource = null;
             dataGridView2.DataSource = listOrders;
             
                         comboBox7.DataSource = null;
                         comboBox7.DisplayMember = "idproduct";
                         comboBox7.DataSource = lis;
                         
                         comboBox5.DataSource = null;
                         comboBox5.DisplayMember = "idadress";
                         comboBox5.DataSource = listAdress;
                         
                         List<Adress> listaAdress = AdressDAO.getListaAdress(appuser.iduser);
                         
                         dataGridView3.DataSource = null;
                         dataGridView3.DataSource = listaAdress;

                         List<AppOrder> listaAppOrders = AppOrderDAO.getListaAppOrder(appuser.iduser);
                         
                         dataGridView5.DataSource = null;
                         dataGridView5.DataSource = listaAppOrders;



        }


        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir, " + appuser.username + "?", 
                "SourceCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    
                    e.Cancel = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha sucedido un error, favor intente dentro de un minuto.", 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    AppUserDAO.crearNuevo(textBox1.Text, textBox2.Text);
                    
                    MessageBox.Show("¡Usuario agregado exitosamente! Valores por defecto: passwor igual a username y no admin" , 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox1.Clear();
                    actualizarControles();
                }
                else
                    MessageBox.Show("Favor no deje campos vacios", 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario que ha digitado, no se encuentra disponible.", 
                    "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizarControles();
        }


        private void button3_Click(object sender, EventArgs e)
        {
        
            if (MessageBox.Show("¿Seguro que desea eliminar al usuario " + comboBox1.Text + "?", 
                "SourceCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppUserDAO.eliminar(comboBox1.Text);
                
                MessageBox.Show("¡Usuario eliminado exitosamente!", 
                    "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarControles();
            }
            
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text.Length > 0 && textBox4.Text.Length > 0 )
                {
                    BusinessDAO.crearNuevo(textBox3.Text, textBox4.Text);
                    MessageBox.Show("¡Negocio agregado exitosamente!",
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox3.Clear();
                    
                    actualizarControles();

                }
                else
                    MessageBox.Show("No deje espacios en blanco",
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("El Negocio que ha digitado, no se encuentra disponible.", 
                    "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el Negocio " + comboBox2.Text + "?", 
                "SourceCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BusinessDAO.eliminar(comboBox2.Text);
                
                MessageBox.Show("¡Negocio eliminado exitosamente!", 
                    "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarControles();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
                       {
                           if (textBox5.Text.Length > 0)
                           {
                               ProductDAO.crearNuevo(comboBox3.Text , textBox5.Text);
                               
                               MessageBox.Show("¡Producto ingresado exitosamente!" , 
                                   "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                               textBox5.Clear();
                               actualizarControles();
                           }
                           else
                               MessageBox.Show("Favor no deje espacios en blanco", 
                                   "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       }
                       catch (Exception)
                       {
                           MessageBox.Show("El producto que ha digitado, no se encuentra disponible.", 
                               "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                   }


        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el Producto " + comboBox4.Text + "?", 
                "SourceCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProductDAO.eliminar(comboBox4.Text);
                
                MessageBox.Show("¡Producto eliminado exitosamente!", 
                    "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarControles();
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            actualizarControles();
        }


        private void button9_Click(object sender, EventArgs e)
        {
        
            try
            {
                if (textBox6.Text.Length > 0)
                {
                    AdressDAO.crearNuevo( appuser.iduser , textBox6.Text);
                               
                    MessageBox.Show("¡Direccion ingresada exitosamente!" , 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                    textBox5.Clear();
                    actualizarControles();
                }
                else
                    MessageBox.Show("Favor no deje espacios en blanco", 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("La Direccion que ha digitado, no se encuentra disponible.", 
                    "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
        
        actualizarControles();                                                                                             
                                               
    }

        private void button10_Click(object sender, EventArgs e)
        {
            

          
                    AppOrderDAO.crearNuevo( ((DateTime.Now)).ToString(@"yyyy-MM-dd"), comboBox7.Text, comboBox5.Text);
                               
                    MessageBox.Show("¡Pedido realizado exitosamente!" , 
                        "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                    
                    actualizarControles();
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AdressDAO.actualizarDireccion(textBox7.Text, comboBox6.Text);
                        
            MessageBox.Show("¡Adress  actualizada exitosamente!", 
                "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
            actualizarControles();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar la direccion " + comboBox6.SelectedItem + "?", 
                            "SourceCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            AdressDAO.eliminar(comboBox6.Text);
                            
                            MessageBox.Show("¡Producto eliminado exitosamente!", 
                                "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                            actualizarControles();
                        }
        }

        private void button13_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("¿Seguro que desea eliminar el pedido " + comboBox8.Text + "?", 
                           "SourceCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        AppOrderDAO.eliminar(comboBox8.Text);
                                        
                                        MessageBox.Show("¡Pedido eliminado exitosamente!", 
                                            "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    
                                        actualizarControles();
                                    }
        }


        private void button16_Click(object sender, EventArgs e)
        {
            actualizarControles();
             
            MessageBox.Show("¡Datos obtenidos exitosamente!", 
                "SourceCode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    }
