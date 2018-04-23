using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADZadaniePierwsze
{
    public class Neuron
    {
        //TABLICA WAG NEURONA
        public double[] Wagi;
        public double[] PoprzednieWagi;
        //ZMIENNA PRZECHOWUJACA SUME WEJSC RAZY WAGI
        public double Suma = 0;
        //ZMIENA PRZECHOWUJACA WYJSCIE
        public double Wyjscie = 0;
        //ZMIENNA PRZECHOWUJACA BLAD NEURONA
        public double Blad = 0;
        //ZMIENNA INFORMUJACA CZY NEURON JEST LINIOWY
        public bool Liniowosc = false;

        //KONSTRUKTOR
        public Neuron(int _ileWejsc, bool _liniowosc)
        {
            //ZAPAMIETUJEMY WYBOR LINIOWOSCI
            Liniowosc = _liniowosc;
            //TWORZYMY GENERATOR LICZB PSEUDO-LOSOWYCH
            Random rand = new Random();
            //TWORZYMY TABLICE NA WAGI DLA WSZYSTKICH WEJSC I BIASA
            Wagi = new double[_ileWejsc + 1];
            PoprzednieWagi = new double[_ileWejsc + 1];
            //POCZATKOWA WAGA BIASA TO ZERO
            Wagi[0] = 0;
            //RESZTA WAG ZOSTANIE WYLOSOWANA
            for (int i=1 ; i<_ileWejsc + 1;i++)
            {
                Wagi[i] = rand.NextDouble() - 0.5;
                PoprzednieWagi[i] = Wagi[i];
            }
        }
        
        //METODA OBLICZAJACA FUNKCJE SIGMOIDALNA LUB LINIOWA NA WYJSCIE
        public void Funkcja()
        {
            if (Liniowosc) Wyjscie = Suma;
            else Wyjscie = 1 / (1 + Math.Exp(-Program.BETA * Suma));
        }

        //METODA ZWRACAJACA SIGMOIDALNA FUNKCJE PROPAGACJI
        public double Funkcja_propagacji()
        {
            return (Program.BETA * (Math.Exp(Program.BETA * Suma) / (Math.Pow((Math.Exp(Program.BETA * Suma) + 1), 2))));
        }
    }
}
