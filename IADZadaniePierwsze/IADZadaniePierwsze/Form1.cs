using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IADZadaniePierwsze
{
    public partial class Form1 : Form
    {
        //ZMIENNA DO PRZECHOWYWANIA NASZEJ SIECI
        Siec SN;

        //FORMA, CZYLI MAIN GRAFICZNY
        public Form1()
        {
            InitializeComponent(); 
            //GDY KTOS NACISNIE PRZYCISK WYWOLAJ STARTKLIK
            START.Click += new EventHandler(StartKlik);
        }

        private void StartKlik(object sender, EventArgs e)
        {
            //USTAWIAMY WSPOLCZYNNIK NAUKI
            Program.N = Double.Parse(IleNauki.Text, System.Globalization.CultureInfo.InvariantCulture);
            //TWORZYMY NOWA SIEC NEURONOW
            SN = new Siec(Int32.Parse(IleNeuronow.Text));
            //UCZYMY PO DANYCH ZALEZNIE OD ZAZNACZENIA
            if (DaneUno.Checked)
            {
                Program.WczytajNauke("../../NAUKA_1.txt");
                SN.Nauka(Int32.Parse(IleEpok.Text));
            }
            if (DaneDuo.Checked)
            {
                Program.WczytajNauke("../../NAUKA_2.txt");
                SN.Nauka(Int32.Parse(IleEpok.Text));
            }
            //ODCZYTUJEMY PUNKTY DO NARYSOWANIA WYKRESU
            Program.WczytajTest();
            //SIEC WYLICZA Y DO WYKRESU
            SN.Test();
            //NAKRESLAMY WYKRES GRAFICZNIE
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(Chart.Chart1("Wizualizacja wynikow aproksymacji", Program.ObliczoneDane));
        }

    }
}

