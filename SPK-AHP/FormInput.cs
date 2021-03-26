using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPK_AHP
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
            
        }

        int jmlKriteria = 0;
        int jmlAlternatif = 0;

        int countKriteria = 0;
        int countAlternatif = 0;

        List<string> listKriteria = new List<string>();
        List<string> listAlternatif = new List<string>();

        private void buttonGO_Click(object sender, EventArgs e)
        {
            buttonGO.Enabled = false;

            jmlKriteria = (int)numericUpDownKriteria.Value;
            jmlAlternatif = (int)numericUpDownAlternatif.Value;

            buttonInputKriteria.Enabled = true;
            buttonInputAlternatif.Enabled = true;

            textBoxNamaAlternatif.Enabled = true;
            textBoxNamaKriteria.Enabled = true;
        }

        private void FormAlternatifDanKriteria_Load(object sender, EventArgs e)
        {
            textBoxNamaAlternatif.Enabled = false;
            textBoxNamaKriteria.Enabled = false;

            buttonInputKriteria.Enabled = false;
            buttonInputAlternatif.Enabled = false;
        }

        private void buttonInputKriteria_Click(object sender, EventArgs e)
        {
            listKriteria.Add(textBoxNamaKriteria.Text);
            countKriteria++;
            textBoxNamaKriteria.Text = "";
            textBoxNamaKriteria.Focus();
            if (countKriteria == jmlKriteria)
                buttonInputKriteria.Enabled = false;

            if (countKriteria == jmlKriteria && countAlternatif == jmlAlternatif)
            {
                FormHitung AHP = new FormHitung(listKriteria, listAlternatif);
                AHP.Owner = this;
                AHP.ShowDialog();
            }

        }

        private void buttonInputAlternatif_Click(object sender, EventArgs e)
        {
            listAlternatif.Add(textBoxNamaAlternatif.Text);
            countAlternatif++;
            textBoxNamaAlternatif.Text = "";
            textBoxNamaAlternatif.Focus();
            if (countAlternatif == jmlAlternatif)
                buttonInputAlternatif.Enabled = false;

            if (countKriteria == jmlKriteria && countAlternatif == jmlAlternatif)
            {
                FormHitung AHP = new FormHitung(listKriteria, listAlternatif);
                AHP.Owner = this;
                AHP.ShowDialog();
            }
        }
    }
}
