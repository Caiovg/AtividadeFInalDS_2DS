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
using BLL_ProjetoFinalDS_EAD;
using DTO_ProjetoFinalDS_EAD;
using System.Globalization;

namespace ProjetoFinalDS_EAD
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public Form5(DTO_Usuario obj)
        {
            InitializeComponent();
            CultureInfo cultureinfo = Thread.CurrentThread.CurrentCulture;
            label2.Text = cultureinfo.TextInfo.ToTitleCase(label2.Text = obj.Nome);

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
        }
        
    }
}
