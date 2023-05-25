﻿using System;
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
        public int contatore = 0;
        public int LMn = 0, Ln = 0;
        public int ad = 0;
        public int tempo;
        public string anno, nazione,note;
        public float MKwh;
        public int VRandom;
        public bool Vbooleano;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region buttons

        private void button1_Click(object sender, EventArgs e)
        {
            Istruzione1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il numero di campi è: " + Istruzione2());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il numero di caratteri è: " + Istruzione3());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            int[] MaxC = new int[contatore];
            MaxC = Istruzione3A();
            for (int i = 0; i < contatore; i++)
            {
                listView1.Items.Add(MaxC[i].ToString());
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Istruzione4();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            anno = textBox1.Text;
            nazione = textBox2.Text;
            MKwh = float.Parse(textBox3.Text);
            note = textBox4.Text;
            int VRandom = int.Parse(textBox5.Text);
            bool Vbooleano = bool.Parse(textBox6.Text);           
            Istruzione5();
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
                    writer.WriteLine(n + de + Nr + de + "false");
                }
                i++;
                n = reader.ReadLine();
            }
            writer.Close();
            reader.Close();
        }
        private int Istruzione2()
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            reader.Close();
            contatore = n.Split(';').Length;
            return contatore;
        }

        private int Istruzione3()
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            while (n != null)
            {
                Ln = n.Length;
                if (i != 0)
                {
                    if (LMn < Ln)
                    {
                        LMn = n.Length;
                    }
                }
                i++;
                n = reader.ReadLine();
            }
            reader.Close();
            return LMn;
        }

        private int [] Istruzione3A() 
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            int[] LMassima = new int[contatore];
            n = reader.ReadLine();
            while(n != null)
            {
                string[]split = n.Split(';');
                string[]array = new string[contatore];
                for(int i = 0; i < contatore; i++)
                {
                    reader.DiscardBufferedData();
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    n = reader.ReadLine();
                    ad = 0;
                    while(n != null)
                    {
                        string[] stringaSplit = n.Split(';');
                        if(ad != 0)
                        {
                            if (LMassima[i] < stringaSplit[i].Length)
                            {
                                LMassima[i] = stringaSplit[i].Length;
                            }                          
                        }
                        ad++;
                        n = reader.ReadLine();
                    }
                }
            }
            reader.Close();
            return LMassima;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Istruzione6();
        }

        private void Istruzione4()
        {
            StreamReader reader = new StreamReader(fileName);
            StreamWriter writer = new StreamWriter("appoggio.csv");
            n = reader.ReadLine();
            while(n != null)
            {
                if(i != 0)
                {
                    writer.WriteLine(n.PadRight(70));
                }
                else
                {
                    writer.WriteLine(n);
                }
                i++;
                n = reader.ReadLine();
            }
            reader.Close();
            writer.Close();
            File.Replace("appoggio.csv", fileName, "backup.csv");
        }   

        private void Istruzione5()
        {
            StreamReader reader = new StreamReader(fileName);
            StreamWriter writer = new StreamWriter("appoggio.csv");
            n = reader.ReadLine();
            while(n != null)
            {
                writer.WriteLine(n);
                n = reader.ReadLine();
            }
            writer.WriteLine(anno + de + nazione + de + MKwh + de + note + de + VRandom + de + Vbooleano);
            writer.Close();
            reader.Close();
            File.Replace("appoggio.csv", fileName, "backup.csv");
        }

        private void Istruzione6()
        {
            StreamReader reader = new StreamReader(fileName);
            n = reader.ReadLine();
            while(n != null)
            {
                String[] Split = n.Split(';');
                if (Split[6] == "false")
                {
                    listView1.Items.Add("Visualizzazione di Tre campi" + Split[0] + Split[1] + Split[4]);           
                }
                n = reader.ReadLine();
                i++;
            }
            reader.Close(); 
        }
        
        #endregion

    }
}
