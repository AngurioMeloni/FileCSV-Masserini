using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCSV_Masserini
{
    public partial class Form1 : Form
    {
        #region dichiarazioni
        public Form1()
        {
            InitializeComponent();
        }
        public Random r = new Random();
        public string fileName = @"masserini1.csv";
        public string fileName1 = @"masserini.csv";
        public int i = 0;
        public string n;
        public char de = ';';   
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region buttons

        private void button1_Click(object sender, EventArgs e)
        {
            Istruzione1();
        }

        #endregion

        #region funzioni di servizio
        private void Istruzione1()
        {
            StreamWriter writer = new StreamWriter(fileName, append: false);
            StreamReader reader = new StreamReader(fileName1);
            n = reader.ReadLine();
            while (n != null)
            {
                if (i == 0)
                {
                    writer.WriteLine(n + de + "Mio valore" + de + "Cancellazione Logica");
                }
                else
                {
                    int Nr = r.Next(10, 21);
                    writer.WriteLine(n + de + Nr + de + "true");
                }
                i++;
                n = reader.ReadLine();
            }
            writer.Close();
            reader.Close();
        }

        #endregion

    }
}
