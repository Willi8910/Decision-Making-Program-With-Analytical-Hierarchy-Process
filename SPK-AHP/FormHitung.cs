using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace SPK_AHP
{
    public partial class FormHitung : Form
    {
        List<String> lstAlternatif = new List<string> { "Univ A", "Univ B","Univ C"};
        List<String> lstKriteria = new List<string> { "PBM","LP","KS","PL","SK","MPA"};
        List<DataGridView> lstDtGrid;
        Matrix<double> mtKriteria;
        Matrix<double> mtHasil;

        public FormHitung()
        {
            InitializeComponent();
        }

        public FormHitung(List<String> lstKrit, List<String> lstAlt)
        {
            InitializeComponent();
            lstAlternatif = lstAlt;
            lstKriteria = lstKrit;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridViewInput.AutoSize = true;
            dataGridViewInput.ColumnCount = lstKriteria.Count;
            dataGridViewInput.RowCount = lstKriteria.Count;
            dtNorm(dataGridViewInput);
            dtCost.ColumnCount = 1;
            dtCost.RowCount = lstAlternatif.Count;
            AddLabelHasil(dtCost, lstAlternatif, panel1);
            AddLabel(dataGridViewInput, lstKriteria);
            //double[] bla = convert(new double[,] { { 2, 3 }, { 4, 5 } , {3,3} });          
            //List<double> lsthasil = bla.ToList();
            //lsthasil.Sort();
            //Matrix<double> x = DenseMatrix.OfArray(new double[,] { { 2,3 }, { 4,5 } });
            //x = x.Multiply( DenseMatrix.OfArray(new double[,] { { 3, 5 }, { 2, 5 } }));
            //Vector<double> y = x.RowAbsoluteSums();
            //y = y.Normalize(1);
            //DataTable t = ArraytoDatatable(new double[] { 2, 3, 4, 5, 5 });
            //dataGridViewInput.DataSource = t;

            panel1.Left = dataGridViewInput.Right + 10;
            panHasil.Left = panel1.Right + 25;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                btnHitung.Enabled = true;
                /*DataGridView dt = dataGridViewInput;  
                double[,] d = new double[dataGridViewInput.RowCount, dataGridViewInput.ColumnCount  ];
                for(int i = 0;i<dt.ColumnCount;i++)
                {
                    for (int j = 0; j < dt.RowCount; j++)
                    {
                        d[ j,i] = double.Parse(dt.Rows[j].Cells[i].Value.ToString());
                    }
                }

                double[,] d = DatatabletoArray(dataGridViewInput);
                Matrix<double> lala = DenseMatrix.OfArray(d);
                double[,] ard = lala.ToArray();
                DataTable dat = ArraytoDatatable(ard);*/
                //dtCopy.DataSource =dat ;

                mtKriteria = DenseMatrix.OfArray(DatatabletoArray(dataGridViewInput));
                Matrix<double> mtKr = mtKriteria.Clone();
                mtKriteria = mtKriteria.Multiply(mtKriteria);
                if (CekKonsistensi(mtKr, mtKriteria))
                {
                    int w = (lstAlternatif.Count + 2) * 100;
                    int h = (lstAlternatif.Count) * 25 + 150;
                    lstDtGrid = new List<DataGridView>();
                    panIsi.Controls.Clear();
                    for (int i = 0; i < lstKriteria.Count; i++)
                    {
                        Panel pan = new Panel();
                        pan.BorderStyle = BorderStyle.Fixed3D;
                        pan.Width = w;
                        pan.Height = h;
                        pan.Left = (i % 2) * w;
                        pan.Top = i / 2 * h;
                        //pan.AutoSize = true;
                        panIsi.Controls.Add(pan);
                        Label lab = new Label();
                        lab.Text = lstKriteria[i];
                        lab.Left = 10;
                        lab.Top = 10;
                        pan.Controls.Add(lab);
                        DataGridExample frm = new DataGridExample();
                        DataGridView dt = frm.dtExample;
                        dt.CellEndEdit += dataGridViewInput_CellEndEdit;
                        dt.Left = 100;
                        dt.Top = 75;
                        dt.AutoSize = true;
                        dt.ColumnCount = lstAlternatif.Count;
                        dt.Height = 25 * lstAlternatif.Count;
                        dt.RowCount = lstAlternatif.Count;
                        dt.Width = 100 * lstAlternatif.Count;
                        dtNorm(dt);
                        pan.Controls.Add(dt);
                        AddLabelPanel(dt, lstAlternatif, pan);

                        lstDtGrid.Add(dt);
                    }
                }
                else { MessageBox.Show("Maaf Tabel anda tidak Konsisten, silahkan diubah lagi"); }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Tolong diisi perbandingan kriteria yang benar dulu yaa");
            }
        }

        public bool CekKonsistensi(Matrix<double> mtAwal, Matrix<double> mtAkhir)
        {

            Vector<double> vcAwal = mtAwal.ColumnSums();
            Vector<double> vcAkhir = mtAkhir.RowSums();
            vcAkhir = vcAkhir.Normalize(1);
            double lamda = 0;
            for (int i = 0; i < vcAwal.Count; i++)
            {
                lamda += vcAwal[0] * vcAkhir[0];
            }
            double[] ArRI = new double[] { 0, 0, 0, 0.58, 0.9, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49 };
            double CI = (lamda - vcAkhir.Count) / (vcAkhir.Count - 1);
            double CR = CI / ArRI[vcAkhir.Count];
           // MessageBox.Show(CR.ToString());
            if(CR > 0.1)
            {
                return false;
            }
            return true;
        }

        public void AddLabel(DataGridView dt,List<String> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                Label lab1 = new Label(); //Column Header
                lab1.Text = lst[i];
                lab1.Top = dt.Top - 30;
                lab1.Width = 100;
                lab1.TextAlign = ContentAlignment.MiddleCenter;
                lab1.Left = dt.Left + i * 100;
                Controls.Add(lab1);

                Label lab2 = new Label(); //Column Header
                lab2.Text = lst[i];
                lab2.Top = dt.Top + i * 25;
                lab2.Width = 100;
                lab2.Height = 25;
                lab2.TextAlign = ContentAlignment.MiddleCenter;
                lab2.Left = dt.Left - 100;
                Controls.Add(lab2);
            }
        }

        public void AddLabelHasil(DataGridView dt, List<String> lst,Panel pan)
        {
            for (int i = 0; i < lst.Count ; i++)

            {

                //double data = double.Parse(dt.Rows[i].Cells[0].Value.ToString());
                Label lab2 = new Label(); //Column Header
                lab2.Text = lst[i];
                lab2.Top = dt.Top + i * 25;
                lab2.Width = 100;
                lab2.Height = 25;
                lab2.TextAlign = ContentAlignment.MiddleCenter;
                lab2.Left = dt.Left - 100;
                pan.Controls.Add(lab2);
            }
        }

        public void AddLabelPanel(DataGridView dt, List<String> lst,Panel pan)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                Label lab1 = new Label(); //Column Header
                lab1.Text = lst[i];
                lab1.Top = dt.Top - 30;
                lab1.Width = 100;
                lab1.TextAlign = ContentAlignment.MiddleCenter;
                lab1.Left = dt.Left + i * 100;
                pan.Controls.Add(lab1);

                Label lab2 = new Label(); //Column Header
                lab2.Text = lst[i];
                lab2.Top = dt.Top + i * 25;
                lab2.Width = 100;
                lab2.Height = 25;
                lab2.TextAlign = ContentAlignment.MiddleCenter;
                lab2.Left = dt.Left - 100;
                pan.Controls.Add(lab2);
            }
        }

        public static double[,] DatatabletoArray(DataGridView dt)
        {
            double[,] d = new double[dt.RowCount, dt.ColumnCount];
           
            for (int i = 0; i < dt.ColumnCount; i++)
            {
                for (int j = 0; j < dt.RowCount; j++)
                {
                    string math = dt.Rows[j].Cells[i].Value.ToString();
                    string value = new DataTable().Compute(math, null).ToString();

                    d[j, i] = double.Parse(value);
                }
            }
            return d;
        }

        public static DataTable ArraytoDatatable(double[] numbers)
        {
            DataTable dt = new DataTable();
            //for (int i = 0; i < numbers.GetLength(1); i++)
            //{
            //    dt.Columns.Add("Column" + (i + 1));
            //}
            dt.Columns.Add("Column" + 1);
            for (var i = (numbers.Length -1); i >= 0 ; --i) //for (var i = 0; i < numbers.Length; ++i)
            {
                DataRow row = dt.NewRow();
                //for (var j = 0; j < numbers.GetLength(1); ++j)
                //{
                //    row[j] = numbers[i, j];
                //}
                row[0] = numbers[i];
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            try {
                List<String> lstCR = new List<string> { };
                Matrix<double> mtAlternatif;
                Vector<double>[] arVect = new Vector<double>[lstDtGrid.Count];
                for (int i = 0; i < lstDtGrid.Count; i++)
                {
                    Matrix<double> Alter = DenseMatrix.OfArray(DatatabletoArray(lstDtGrid[i]));
                    Matrix<double> Alter2 = Alter.Multiply(Alter);
                    if(CekKonsistensi(Alter,Alter2))
                    {
                        //lstCR.Add(lstAlternatif[i]);
                    }
                    Vector<double> y = Alter2.RowAbsoluteSums();
                    arVect[i] = y.Normalize(1);

                }

                if (lstCR.Count == 0)
                {
                    mtAlternatif = DenseMatrix.OfColumnVectors(arVect);
                    Vector<double> vcKrit = mtKriteria.RowSums().Normalize(1);
                    mtHasil = mtAlternatif.Multiply(vcKrit.ToColumnMatrix());
                    Vector<double> vcnorm = DenseMatrix.OfArray(DatatabletoArray(dtCost)).RowSums().Normalize(1);


                    int a = 1;
                    ListView ks = kesimpulan;
                    panHasil.Controls.Clear();
                    Label lab = new Label();
                    lab.Text = "Hasil Perhitungan";
                    lab.Left = 10;
                    lab.Top = 10;
                    panHasil.Controls.Add(lab);
                    DataGridExample frm = new DataGridExample();
                    DataGridView dt = frm.dtExample;
                    dt.Left = 100;
                    dt.Top = 75;
                    dt.Width = 30;
                    dt.SendToBack();
                    //dt.AutoSize = true;
                    //dt.ColumnCount = 0;
                    dt.Height = 25 * lstAlternatif.Count;
                    //dt.RowCount = lstAlternatif.Count;
                    dt.Width = 100 * lstAlternatif.Count;
                    panHasil.Controls.Add(dt);
                    double[,] arHasil = mtHasil.ToArray();


                    double[] hasil = convert(arHasil);

                    //Tambahkan bagis Cost
                    double[] Hcost = vcnorm.ToArray();
                    for (int i = 0; i < hasil.Length; i++)
                    {
                        Hcost[i] = Hcost[i] / hasil[i];
                    }

                    hasil = Hcost;
                    double[] colne = (double[])hasil.Clone();
                    List<double> lsthasil = hasil.ToList();
                    lsthasil.Sort();
                    hasil = lsthasil.ToArray();

                    DataTable tab = ArraytoDatatable(hasil);
                    dt.DataSource = tab;
                    ks.Items.Clear();
                    int count = 0;
                    List<String> lstUrut = new List<string>();
                    for (int i = hasil.Length - 1; i >= 0; i--)
                    {
                        int idex = Array.IndexOf(colne, hasil[i]);
                        String kata = lstAlternatif[idex];
                        colne[idex] = -1;
                        lstUrut.Add(kata);
                        if (count == 0)
                        {
                            ks.Items.Add("Menurut perhitungan AHP, Alternatif terbaik adalah " + kata + ", hasil : " + hasil[i]);
                        }
                        else if (count <= 3)
                        {
                            ks.Items.Add("Alternatif terbaik ke " + (count + 1) + " adalah " + kata + ", hasil : " + hasil[i]);

                        }
                        count++;
                        //if (count > 3) break;


                    }
                    AddLabelHasil(dt, lstUrut, panHasil);
                    panHasil.Controls.Add(ks);
                    //panel1.Hide();
                }
                else
                {
                    String Msg = "Ada Data yang tidak konsisten : ";

                    for (int i = 0; i < lstCR.Count; i++)
                    {
                        Msg += lstCR[i] + ", ";
                    }
                    MessageBox.Show(Msg);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ada data yang belum terisi atau kesalahan inputan, tolong diperiksa kembali");
            }
        }
        public double[] convert(double[,] d)
        {
            double[] hasil = new double[d.GetLength(0)];
            for (int i = 0; i < d.GetLength(0); i++)
            {
                hasil[i] = d[i, 0];
            }
            return hasil;

        }

        public double StringInt(String m)
        {
            string math = m;
            string value = new DataTable().Compute(math, null).ToString();
            return double.Parse(value);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panHasil.Controls.Clear();
            panIsi.Controls.Clear();
            kesimpulan.Items.Clear();
            dataGridViewInput.Rows.Clear();
            dataGridViewInput.Columns.Clear();
            dataGridViewInput.ColumnCount = lstKriteria.Count;
            dataGridViewInput.RowCount = lstKriteria.Count;
            btnHitung.Enabled = false;
            panel1.Show();
        }

        private void dataGridViewInput_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void dtNorm(DataGridView dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt[i, i].Value = 1;
                dt[i, i].ReadOnly = true;
            }
        }


        private void dataGridViewInput_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dt = (DataGridView)sender;
           // string math = dt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
           // string value = new DataTable().Compute(math, null).ToString();
            //MessageBox.Show("" + e.RowIndex + "," + e.ColumnIndex);
            double hasil = 1/double.Parse(dt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            dt.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = hasil;

        }
    }

   
}
