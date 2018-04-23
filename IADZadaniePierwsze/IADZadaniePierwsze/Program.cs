using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IADZadaniePierwsze
{
    static class Program
    {
        //ZMIENNE WYSTEPUJACE W SIECI
        public static double BETA = 1;
        public static double N = 0.001;
        public static double MOMENTUM = 0.1;

        //TABLICA NA X I Y PLIKOW DO NAUKI
        public static double[,] NaukaDane;
        //TABLICA PRZECHOWUJACA X I Y OBLICZONE PRZEZ SIEC
        public static double[,] ObliczoneDane;
        //TABLICA PRZECHOWUJACA X I Y PLIKOW DO TESTU
        public static double[,] TestDane;

        //METODA MAIN
        static void Main()
        {       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //METODA WCZYTUJACA WARTOSCI Z PLIKU DO NAUKADANE, SCIEZKA PLIKU W ARGUMENCIE
        public static void WczytajNauke(string tekst)
        {
            //TWORZYMY BUFFOR I WGRYWAMY DO NIEGO CALUTKI PLIK
            string[] textFile = File.ReadAllLines(tekst);
            //TWORZYMY MACIERZ PRZECHOWUJACA DANE
            NaukaDane = new double[2, textFile.Length];
            //TWORZYMY DWIE TABLICE BUFFOROWE POTRZEBNE DO PRZENIESIENIA DANYCH DO MACIERZY
            double[] matrix1 = new double[textFile.Length];
            double[] matrix2 = new double[textFile.Length];
            //KONWERTUJEMY WSZYSTKIE STRINGI NA DOUBLE 
            for (int i = 0; i < textFile.Length; i++)
            {
                matrix1[i] = Convert.ToDouble(textFile[i].Split(' ')[0], System.Globalization.CultureInfo.InvariantCulture);
                matrix2[i] = Convert.ToDouble(textFile[i].Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture);
            }
            //PRZENOSIMY DANE DO MACIERZY KONCOWEJ
            for (int i = 0; i < matrix1.Length; i++)
            {
                NaukaDane[0, i] = matrix1[i];
                NaukaDane[1, i] = matrix2[i];
            }
        }

        //METODA WCZYTUJACA WARTOSCI Z PLIKU DO TESTDANE
        public static void WczytajTest()
        {
            //TWORZYMY BUFFOR DO KTOREGO WGRYWAMY WSZYSTKIE DANE Z PLIKU
            string[] textFile = File.ReadAllLines("../../TEST.txt");
            //TWORZYMY MACIERZ DO PRZECHOWYWANIA DANYCH
            TestDane = new double[2, textFile.Length];
            //TWORZYMY DWIE TABLICE BUFFOROWE
            double[] matrix1 = new double[textFile.Length];
            double[] matrix2 = new double[textFile.Length];
            //KONWERTUJEMY STRINGI NA DOUBLE I WRZUCAMY JE DO NASZYCH TABLIC BOFFOROWYCH
            for (int i = 0; i < textFile.Length; i++)
            {
                matrix1[i] = Convert.ToDouble(textFile[i].Split(' ')[0], System.Globalization.CultureInfo.InvariantCulture);
                matrix2[i] = Convert.ToDouble(textFile[i].Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture);
            }
            //SORTUJEMY TABLICE ABY MOZLIWE BYLO NARYSOWANIE WYKRESU
            Array.Sort(matrix1, matrix2);
            //PRZEPISANIE WARTOSCI Z BUFFOROWYCH TABLIC DO OSTATECZNEJ MACIERZY
            for (int i = 0; i < matrix1.Length; i++)
            {
                TestDane[0, i] = matrix1[i];
                TestDane[1, i] = matrix2[i];
            }
        }
    }
}
