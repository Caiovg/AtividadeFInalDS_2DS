using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_ProjetoFinalDS_EAD;
using DTO_ProjetoFinalDS_EAD;
using BLL_ProjetoFinalDS_EAD;

namespace ProjetoFinalDS_EAD
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Login obj = new DTO_Login();
                obj.Usuario = textBox1.Text;
                obj.Senha = textBox2.Text;
                DTO_Usuario obj2 = new DTO_Usuario();

                obj2 = BLL_Login.ValidarLogin(obj);
                if (obj2.StatusLogin == true)
                {
                    if (obj2.Ativo != "Ativo")
                    {
                        MessageBox.Show("Seu usuario está desativado! Contate o suporte técnico", "ERRO LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        switch (obj2.Tipo)
                        {
                            case "administrador":
                            case "funcionario":
                            case "operador":
                                this.Hide();
                                Form4 telaADM = new Form4(obj2);
                                telaADM.ShowDialog();
                                this.Close();
                                break;
                            case "cliente":
                                this.Hide();
                                Form5 telaCliente = new Form5(obj2);
                                telaCliente.ShowDialog();
                                this.Close();
                                break;
                            default:
                                MessageBox.Show("Contate o suporte técnico", "ERRO LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Credenciais Inválidas", "ERRO LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
