using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using UI_ProjetoFinalDS_EAD;
using DTO_ProjetoFinalDS_EAD;
using BLL_ProjetoFinalDS_EAD;
using System.Globalization;
using System.IO;

namespace ProjetoFinalDS_EAD
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(DTO_Usuario obj)
        {
            InitializeComponent();
            CultureInfo cultureinfo = Thread.CurrentThread.CurrentCulture;
            label2.Text = cultureinfo.TextInfo.ToTitleCase(label2.Text = obj.Nome);
            label10.Text = cultureinfo.TextInfo.ToTitleCase(label10.Text = obj.Nome);
            label27.Text = cultureinfo.TextInfo.ToTitleCase(label27.Text = obj.Nome);
            label33.Text = cultureinfo.TextInfo.ToTitleCase(label33.Text = obj.Nome);
            label45.Text = cultureinfo.TextInfo.ToTitleCase(label45.Text = obj.Nome);
            label25.Text = cultureinfo.TextInfo.ToTitleCase(label25.Text = obj.Tipo);

            //label2.Text = obj.Nome;
            //label25.Text = obj.Tipo;
            label4.Text = DateTime.Now.ToString();
            TimeSpan tarde = new TimeSpan(12, 0, 0);
            TimeSpan noite = new TimeSpan(18, 0, 0);
            TimeSpan HoraAtual = DateTime.Now.TimeOfDay;
            if (HoraAtual < tarde)
            {
                label1.Text = "Bom Dia";
            }
            else if (HoraAtual < noite)
            {
                label1.Text = "Boa Tarde";
            }
            else
            {
                label1.Text = "Boa Noite";
            }

            if (obj.Tipo == "funcionario")
            {
                this.tabControl1.TabPages.Remove(PRODUTOS);
                this.tabControl1.TabPages.Remove(FUNCIONARIOS);
                this.tabControl1.TabPages.Remove(RELATORIOS);
                this.tabControl1.TabPages.Remove(FALECONOSCO);
                button1.Enabled = false;//vai desabitar o botão caso ele for funcionario
                button2.Enabled = false;

            }
            if (obj.Tipo == "operador")
            {
                this.tabControl1.TabPages.Remove(VENDAS);
                this.tabControl1.TabPages.Remove(PRODUTOS);
                this.tabControl1.TabPages.Remove(FUNCIONARIOS);
                this.tabControl1.TabPages.Remove(RELATORIOS);
                button1.Enabled = false;//vai desabitar o botão caso ele for funcionario
                button2.Enabled = false;
            }

        }
        string ImgOrigem;
        string ImgDestino = @"C:\Users\Dell\source\repos\ProjetoFinalDS_EAD\Supermecado\Resources";
        string ImgNovoNome;
        private void CadastrarProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Produtos obj = new DTO_Produtos();
                obj.CodBarras = textBox19.Text;
                obj.NomeProd = textBox20.Text;
                obj.DescProd = textBox30.Text;
                obj.PrecoProd = textBox21.Text;
                obj.EstoqueProd = textBox22.Text;
                obj.UnidadeProd = textBox23.Text;
                obj.TipoUnidProd = comboBox2.Text;
                if (radioButton1.Checked == true)
                {
                    obj.AtivoProd = "ativo";
                }
                if (radioButton2.Checked == true)
                {
                    obj.AtivoProd = "inativo";
                }
                obj.AcaoProd = "cadastro";
                File.Copy(ImgOrigem, ImgDestino);
                string mensagem = BLL_Produtos.ValidarProdutos(obj);
                MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox30.Clear();
            comboBox2.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox19.Focus();
        }

        private void Buscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string codBarras = textBox24.Text;
                DTO_Produtos obj = new DTO_Produtos();
                obj = BLL_Produtos.BuscarProdutos(codBarras);
                textBox29.Text = obj.IdProd.ToString();
                textBox24.Text = obj.CodBarras;
                textBox25.Text = obj.NomeProd;
                textBox31.Text = obj.DescProd;
                textBox26.Text = obj.PrecoProd;
                textBox27.Text = obj.EstoqueProd;
                textBox28.Text = obj.UnidadeProd;
                comboBox3.Text = obj.TipoUnidProd;
                if (obj.AtivoProd.ToLower() == "ativo")
                {
                    radioButton4.Checked = true;
                }
                if (obj.AtivoProd.ToLower() == "inativo")
                {
                    radioButton3.Checked = true;
                }
                btnAlterar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DTO_Produtos obj = new DTO_Produtos();
                obj.IdProd = int.Parse(textBox29.Text);
                obj.CodBarras = textBox24.Text;
                obj.NomeProd = textBox25.Text;
                obj.DescProd = textBox31.Text;
                obj.PrecoProd = textBox26.Text;
                obj.EstoqueProd = textBox27.Text;
                obj.UnidadeProd = textBox28.Text;
                obj.TipoUnidProd = comboBox3.Text;
                if (radioButton4.Checked == true)
                {
                    obj.AtivoProd = radioButton4.Text;
                }
                if (radioButton3.Checked == true)
                {
                    obj.AtivoProd = radioButton3.Text;
                }
                obj.AcaoProd = "alteracao";
                string mensagem = BLL_Produtos.ValidarProdutos(obj);
                MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAlterar.Enabled = false;
                textBox24.Clear();
                textBox25.Clear();
                textBox26.Clear();
                textBox27.Clear();
                textBox28.Clear();
                textBox29.Clear();
                textBox31.Clear();
                comboBox3.SelectedIndex = -1;
                radioButton4.Checked = false;
                radioButton3.Checked = false;
                textBox24.Focus();
                btnAlterar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();
            textBox31.Clear();
            comboBox3.SelectedIndex = -1;
            radioButton4.Checked = false;
            radioButton3.Checked = false;
            textBox24.Focus();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            DialogResult escolha;
            escolha = MessageBox.Show("Deseja se deslogar?", "Retornar a Home", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (escolha.ToString().ToLower() == "yes")
            {
                this.Hide();
                Form1 home = new Form1();
                home.ShowDialog();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Usuario obj = new DTO_Usuario();
                obj.Nome = textBox4.Text;
                obj.UserName = textBox12.Text;
                obj.Email = textBox7.Text;
                obj.CPF = maskedTextBox2.Text;
                obj.RG = textBox5.Text;
                obj.DataNascimento = maskedTextBox3.Text;
                obj.TelFixo = maskedTextBox4.Text;
                obj.TelCelular = maskedTextBox5.Text;
                obj.Endereco = textBox8.Text;
                obj.Numero = textBox9.Text;
                obj.Bairro = textBox10.Text;
                obj.Cidade = textBox11.Text;
                obj.Estado = comboBox4.Text;
                obj.CEP = maskedTextBox1.Text;
                obj.Tipo = comboBox1.Text;
                if (radioButton8.Checked == true)
                {
                    obj.Ativo = radioButton8.Text;
                }
                if (radioButton9.Checked == true)
                {
                    obj.Ativo = radioButton9.Text;
                }
                if (radioButton5.Checked == true)
                {
                    obj.Sexo = radioButton5.Text;
                }
                if (radioButton6.Checked == true)
                {
                    obj.Sexo = radioButton6.Text;
                }
                if (radioButton7.Checked == true)
                {
                    obj.Sexo = radioButton7.Text;
                }
                obj.Senha = textBox6.Text;
                obj.ConfSenha = textBox13.Text;

                obj.AcaoUsuario = "cadastro";
                MessageBox.Show(BLL_Cadastro.CadUsuario(obj));

                textBox4.Clear();
                textBox12.Clear();
                textBox7.Clear();
                maskedTextBox2.Clear();
                textBox5.Clear();
                maskedTextBox3.Clear();
                maskedTextBox4.Clear();
                maskedTextBox5.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                maskedTextBox1.Clear();
                textBox6.Clear();
                textBox13.Clear();
                textBox33.Clear();
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                textBox4.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            textBox4.Clear();
            textBox12.Clear();
            textBox7.Clear();
            maskedTextBox2.Clear();
            textBox5.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox5.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            maskedTextBox1.Clear();
            textBox6.Clear();
            textBox13.Clear();
            textBox33.Clear();
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            textBox4.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Usuario obj = new DTO_Usuario();
                obj.idUsuario = int.Parse(textBox33.Text);
                obj.Nome = textBox4.Text;
                obj.UserName = textBox12.Text;
                obj.Email = textBox7.Text;
                obj.CPF = maskedTextBox2.Text;
                obj.RG = textBox5.Text;
                obj.DataNascimento = maskedTextBox3.Text;
                obj.TelFixo = maskedTextBox4.Text;
                obj.TelCelular = maskedTextBox5.Text;
                obj.Endereco = textBox8.Text;
                obj.Numero = textBox9.Text;
                obj.Bairro = textBox10.Text;
                obj.Cidade = textBox11.Text;
                obj.Estado = comboBox4.Text;
                obj.CEP = maskedTextBox1.Text;
                obj.Tipo = comboBox1.Text;
                if (radioButton8.Checked == true)
                {
                    obj.Ativo = radioButton8.Text;
                }
                if (radioButton9.Checked == true)
                {
                    obj.Ativo = radioButton9.Text;
                }
                if (radioButton5.Checked == true)
                {
                    obj.Sexo = radioButton5.Text;
                }
                if (radioButton6.Checked == true)
                {
                    obj.Sexo = radioButton6.Text;
                }
                if (radioButton7.Checked == true)
                {
                    obj.Sexo = radioButton7.Text;
                }
                obj.Senha = textBox6.Text;
                obj.ConfSenha = textBox13.Text;

                obj.AcaoUsuario = "alteracao";
                MessageBox.Show(BLL_Cadastro.CadUsuario(obj));

                textBox4.Clear();
                textBox12.Clear();
                textBox7.Clear();
                maskedTextBox2.Clear();
                textBox5.Clear();
                maskedTextBox3.Clear();
                maskedTextBox4.Clear();
                maskedTextBox5.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                maskedTextBox1.Clear();
                textBox6.Clear();
                textBox13.Clear();
                textBox33.Clear();
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                textBox4.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string cpf = maskedTextBox2.Text;
            DTO_Usuario obj = new DTO_Usuario();
            obj = BLL_Cadastro.BuscarUsuario(cpf);
            textBox33.Text = obj.idUsuario.ToString();
            textBox4.Text = obj.Nome;
            textBox12.Text = obj.UserName;
            textBox7.Text = obj.Email;
            maskedTextBox2.Text = obj.CPF;
            textBox5.Text = obj.RG;
            maskedTextBox3.Text = obj.DataNascimento;
            maskedTextBox4.Text = obj.TelFixo;
            maskedTextBox5.Text = obj.TelCelular;
            textBox8.Text = obj.Endereco;
            textBox9.Text = obj.Numero;
            textBox10.Text = obj.Bairro;
            textBox11.Text = obj.Cidade;
            comboBox4.Text = obj.Estado;
            maskedTextBox1.Text = obj.CEP;
            comboBox1.Text = obj.Tipo;
            if (obj.Ativo.ToLower() == "ativo")
            {
                radioButton8.Checked = true;
            }
            if (obj.Ativo.ToLower() == "inativo")
            {
                radioButton9.Checked = true;
            }
            if (obj.Sexo.ToLower() == "masculino")
            {
                radioButton5.Checked = true;
            }
            if (obj.Sexo.ToLower() == "feminino")
            {
                radioButton6.Checked = true;
            }
            if (obj.Sexo.ToLower() == "outros")
            {
                radioButton7.Checked = true;
            }
            textBox6.Text = obj.Senha;
            textBox13.Text = obj.ConfSenha = obj.Senha;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string pasta = @"C:\teste12345\teste123456\teste1234567";
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            OpenFileDialog produto = new OpenFileDialog();
            if(produto.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.ImageLocation = produto.FileName;
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                ImgOrigem = produto.FileName;
                MessageBox.Show(ImgOrigem);
                ImgNovoNome = textBox19.Text + Path.GetExtension(produto.FileName);
                MessageBox.Show(ImgNovoNome);
                ImgDestino = Path.Combine(ImgDestino, ImgNovoNome);
                MessageBox.Show(ImgDestino);
                MessageBox.Show(ImgOrigem + "\n" + ImgDestino);
            }
        }
    }
    
}
