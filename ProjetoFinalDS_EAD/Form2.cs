using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_ProjetoFinalDS_EAD;
using DTO_ProjetoFinalDS_EAD;

namespace ProjetoFinalDS_EAD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Usuario obj = new DTO_Usuario();
                obj.Nome = textBox1.Text;
                obj.UserName = textBox5.Text;
                obj.Email = textBox6.Text;
                obj.CPF = maskedTextBox1.Text;
                obj.RG = textBox4.Text;
                obj.DataNascimento = maskedTextBox3.Text;
                obj.TelFixo = maskedTextBox2.Text;
                obj.TelCelular = maskedTextBox4.Text;
                obj.Endereco = textBox3.Text;
                obj.Numero = textBox2.Text;
                obj.Bairro = textBox7.Text;
                obj.Cidade = textBox8.Text;
                obj.Estado = comboBox1.Text;
                obj.CEP = maskedTextBox5.Text;
                obj.Tipo = "cliente";
                obj.Ativo = "Ativo";
                if (radioButton1.Checked == true)
                {
                    obj.Sexo = radioButton1.Text;
                }
                if (radioButton2.Checked == true)
                {
                    obj.Sexo = radioButton2.Text;
                }
                if (radioButton3.Checked == true)
                {
                    obj.Sexo = radioButton3.Text;
                }
                obj.Senha = textBox10.Text;
                obj.ConfSenha = textBox9.Text;
                obj.AcaoUsuario = "cadastro";

                MessageBox.Show(BLL_Cadastro.CadUsuario(obj));

                textBox1.Clear();
                textBox5.Clear();
                textBox6.Clear();
                maskedTextBox1.Clear();
                textBox4.Clear();
                maskedTextBox3.Clear();
                maskedTextBox2.Clear();
                maskedTextBox4.Clear();
                textBox3.Clear();
                textBox2.Clear();
                textBox7.Clear();
                textBox8.Clear();
                comboBox1.SelectedIndex = -1;
                maskedTextBox5.Clear();
                textBox10.Clear();
                textBox9.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 login = new Form3();
            login.ShowDialog();
            this.Close();
        }
    }
}
