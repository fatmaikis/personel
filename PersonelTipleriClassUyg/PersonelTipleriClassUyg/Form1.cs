using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTipleriClassUyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label1.Visible = true;
                aditxt.Visible = true;
                label2.Visible = true;
                ssktxt.Visible = true;
                label3.Visible = true;
                zamtxt.Visible = true;
                label4.Visible = true;
                maastxt.Visible = true;
                departmankartxt.Visible = false;
                label5.Visible = false;
                satistxt.Visible = false;
                label7.Visible = false;
            }
            else if (radioButton2.Checked == true)
            {
                label1.Visible = true;
                aditxt.Visible = true;
                label2.Visible = true;
                ssktxt.Visible = true;
                label3.Visible = true;
                zamtxt.Visible = true;
                label4.Visible = true;
                maastxt.Visible = true;
                label5.Visible = true;
                departmankartxt.Visible = true;
                satistxt.Visible = false;
                label7.Visible = false;
            }
            else if (radioButton3.Checked == true)
            {
                label1.Visible = true;
                aditxt.Visible = true;
                label2.Visible = true;
                ssktxt.Visible = true;
                label3.Visible = true;
                zamtxt.Visible = true;
                label4.Visible = true;
                maastxt.Visible = true;
                label5.Visible = true;
                departmankartxt.Visible = false;
                label5.Visible = false;
                satistxt.Visible = true;
                label7.Visible = true;
            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {

           


        }

        private void eklebtn_Click(object sender, EventArgs e)
        {



            Calisan calisan = new Calisan();
            calisan.AD = aditxt.Text;
            calisan.SSKNO = Convert.ToInt32(ssktxt.Text);
            calisan.MAAS = Convert.ToDouble(maastxt.Text);
            calisan.ZamYap(Convert.ToDouble(zamtxt.Text));
            
            //listBox1.Items.Add(calisan.ZamYap());




            Mudur mudur = new Mudur();
            mudur.AD = aditxt.Text;
            mudur.SSKNO = Convert.ToInt32(ssktxt.Text);
            mudur.MAAS = Convert.ToDouble(maastxt.Text);
            mudur.DEPARTMANKAR = Convert.ToDouble(departmankartxt.Text);
            mudur.ZamYap(Convert.ToDouble(zamtxt.Text));




            Satisci satisci = new Satisci();
            satisci.AD = aditxt.Text;
            satisci.SSKNO = Convert.ToInt32(ssktxt.Text);
            satisci.MAAS = Convert.ToDouble(maastxt.Text);
            satisci.SATISSAYISI = Convert.ToInt32(satistxt.Text);
            satisci.ZamYap(Convert.ToDouble(zamtxt.Text));




        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calisan calisan = new Calisan();
            listBox1.Items.Add(calisan.AD);
            listBox1.Items.Add(calisan.SSKNO);
            listBox1.Items.Add(calisan.MAAS);


            Mudur mudur = new Mudur();
          
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }

    class Calisan : IDisposable
    {
        private int sskNo;

        public int SSKNO
        {
            get { return sskNo; }
            set { sskNo = value; }
        }

        private string Adi;

        public string AD
        {
            get { return Adi; }
            set { Adi = value; }
        }

        protected double maas;

        public double MAAS
        {
            get { return maas; }
            set { maas = value; }
        }

        public virtual void ZamYap(double zam)
        {
            MAAS += zam;
        }

        public virtual string BilgiVer()
        {
            return this.SSKNO + "/" + this.AD + "/" + this.MAAS;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    } 

    class Mudur : Calisan
    {
        private double departmanKar;

        public double DEPARTMANKAR
        {
            get { return departmanKar; }
            set { departmanKar = value; }
        }

        public override void ZamYap(double zam)
        {
            double ekstraZam = 0;

            if (DEPARTMANKAR > 0 && DEPARTMANKAR < 100000)
            {
                ekstraZam = 10000;
            }
            else if (DEPARTMANKAR > 100000)
                ekstraZam = 15000;

            else if (DEPARTMANKAR < 0)
                ekstraZam = -3000;
            MAAS += zam + ekstraZam;


        }
    }

    class Satisci : Calisan
    {
        private int satisSayisi;

        public int SATISSAYISI
        {
            get { return satisSayisi; }
            set { satisSayisi = value; }


        }

        public override void ZamYap(double zam)
        {
            double ekstraZam = 0;

            if (SATISSAYISI > 0 && SATISSAYISI < 100000)
            {
                ekstraZam = 10000;
            }
            else if (SATISSAYISI > 100000)
                ekstraZam = 15000;

            else if (SATISSAYISI < 0)
                ekstraZam = -3000;
            MAAS += zam;

        }

        public override string BilgiVer()
        {
            return base.BilgiVer() + " / " + this.SATISSAYISI;

        }

    }



}
