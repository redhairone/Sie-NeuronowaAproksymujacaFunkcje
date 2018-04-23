using System;

namespace IADZadaniePierwsze
{
    class Siec
    {
        //POSZCZEGOLNE WARSTWY W NASZEJ SIECI
        public double[,] Wejscie;
        public Neuron[] Ukryte;
        public Neuron Wyjscie;
        //MACIERZ NA OBLICZONE WARTOSCI ORAZ LICZBA NAURONOW W SIECI
        public double[,] Wyniki;

        //KONSTRUKTOR
        public Siec(int _ileNeuronow)
        {
            //TWORZYMY ODPOWIEDNIA ILOSC NERONOW W TABLICY NEURONOW
            Ukryte = new Neuron[_ileNeuronow];
            for (int i = 0; i < Ukryte.Length; i++) Ukryte[i] = new Neuron(1, false);
            //TWORZYMY NEURON WYJSCIOWY Z ODPOWIEDNIA ILOSCIA WEJSC
            Wyjscie = new Neuron(_ileNeuronow, true);
        }

        //METODA APROKSYMUJACA
        public void Test()
        {
            //WCZYTUJEMY DANE DO MACIERZY
            Wejscie = Program.TestDane;
            //TWORZYMY MACIERZ NA PRZECHOWYWANIE OBLICZONYCH DANYCH
            Wyniki = new double[2, Program.TestDane.Length / 2];
            //PRZECHODZIMY PRZEZ WSZYSTKIE DANE
            for (int i=0; i<Wejscie.Length/2; i++)
            {
                //OBLICZ SUME DLA KAZDEGO UKRYTEGO
                ObliczSumeUkrytych(Wejscie[0, i]);
                //OBLICZ WYJSCIE DLA KAZDEGO UKRYTEGO
                ObliczWyjscieUkrytych();
                //LICZYMY SUME DLA WYJSCIOWEGO OD BIASU
                Wyjscie.Suma = Wyjscie.Wagi[0] * 1;
                //LICZYMY SUME NA NEURONIE WYJSCIOWYM OD NEURONOW UKRYTYCH
                for (int j=0; j<Ukryte.Length ; j++)
                {
                    Wyjscie.Suma += Wyjscie.Wagi[1 + j]*Ukryte[j].Wyjscie;
                }
                //PRZEPISUJEMY WYNIKI DO MACIERZY WYNIKOWEJ
                Wyniki[0, i] = Wejscie[0, i];
                Wyjscie.Funkcja();
                Wyniki[1, i] = Wyjscie.Wyjscie;
            }
            //PO SKONCZENIU OBLICZEN PRZENOSIMY WYNIKI DO MACIERZY WYNIKOWEJ W PROGRAM.
            Program.ObliczoneDane = Wyniki;
        }

        //METODA UCZACE SIEC NA PODSTAWIE DANYCH W PROGRAM.NAUKADANE
        public void Nauka(int _ileCykli)
        {
            //WCZYTANIE DO MACIERZY DANYCH WEJSCIOWYCH
            Wejscie = Program.NaukaDane;
            //TWORZENIE MACIERZY NA DANE OBLICZONE
            Wyniki = new double[2, Wejscie.Length/2];
            //PETLA OBSLUGUJACA ILOSC CYKLI
            for (int i=0; i< _ileCykli; i++)
            {
                //TOWRZYMY ZMIENNA PRZECHOWUJACA BLAD SREDNIOKWADRATOWY
                double BladSK = 0;
                //TWORZYMY PETLE OBSLUGUJACA WSZYSTKIE DANE W TABLICY
                for (int k = 0; k < Wejscie.Length / 2; k++)
                {
                    //OBLICZAMY SUME WSZYSTKICH NEURONOW UKRYTYCH
                    ObliczSumeUkrytych(Wejscie[0, k]);
                    //OBLICZAMY WYJSCIE KAZDEGO Z UKRYTYCH NEURONOW
                    ObliczWyjscieUkrytych();
                    //OBLICZAMY SUME NA WYJSCIU
                    Wyjscie.Suma = Wyjscie.Wagi[0] * 1;
                    //OBLICZAMY WYJSCIE NA NEURONIE WYJSCIOWYM
                    for (int j = 0; j < Ukryte.Length; j++)
                    {
                        Wyjscie.Suma += Wyjscie.Wagi[1 + j] * Ukryte[j].Wyjscie;
                    }
                    //PRZENOSIMY WYNIKI DO MACIERZY WYNIKOWEJ
                    Wyniki[0, k] = Wejscie[0, k];
                    Wyjscie.Funkcja();
                    Wyniki[1, k] = Wyjscie.Wyjscie;
                    //OBLICZAMY BLAD SREDNIOKWADRATOWY
                    BladSK += Math.Pow((Wyniki[1, k] - Wejscie[1, k]), 2);
                    //OBLICZAMY BLAD NA NEURONIE WYJSCIOWYM
                    Wyjscie.Blad = (Wyniki[1, k] - Wejscie[1, k]);
                    //LICZYMY BLAD NA NEURONACH UKRYTYCH
                    for (int j = 0; j < Ukryte.Length; j++)
                    {
                        Ukryte[j].Blad = Wyjscie.Blad * Wyjscie.Wagi[j + 1] * Ukryte[j].Funkcja_propagacji();
                    }
                    //ZMIENIAMY WAGI NA NEURONIE WYJSCIOWYM (NA BIASIE)
                    Wyjscie.Wagi[0] += -Program.N * Wyjscie.Blad * 1;
                    //ZMIENIAMY WAGI NA NEURONIE WYJSCIOWYM
                    for (int j = 0; j < Ukryte.Length; j++)
                    {
                        Wyjscie.Wagi[j + 1] += -Program.N * Wyjscie.Blad * Ukryte[j].Wyjscie;
                    }
                    //ZMIANA WAG NA NEURONACH UKRYTYCH
                    ZmienWagiUkrytych(Wejscie[0, k]);
                }
                //KONCZYMY LICZENIE BLEDU SREDNIOKWADRATOWEGO
                BladSK /= Wejscie.Length;
                //WYPISANIE NA KONSOLE BLEDU I EPOKI W KTOREJ ZOSTAL WYLICZONY
                Console.WriteLine("EPOKA: " + i + " || Blad = " + BladSK);
                //WYZEROWYWANIE BLEDOW NA NEURONACH UKRYTYCH
                for (int j = 0; j < Ukryte.Length; j++) Ukryte[j].Blad = 0;
                //WYZEROWANIE BLEDU NA NEURONIE WYJSCIOWYM
                Wyjscie.Blad = 0;
            }
        }

        //METODA OBLICZAJACA ZMIENNA SUMA DLA NAURONOW UKRYTYCH OD PODANEGO JEJ ATRYBUTU
        public void ObliczSumeUkrytych(double _wartosc)
        {
            for (int i=0; i<Ukryte.Length; i++)
            {
                Ukryte[i].Suma = Ukryte[i].Wagi[0] * 1 + Ukryte[i].Wagi[1] * _wartosc;
            }
        }

        //METODA OBLICZAJACA WYJSCIA W KAZDYM Z NEURONOW UKRYTYCH
        public void ObliczWyjscieUkrytych()
        {
            for (int i = 0; i < Ukryte.Length; i++)
            {
                Ukryte[i].Funkcja();
            }
        }

        //METODA ZMIENIAJACA WAGI W UKRYTYCH
        public void ZmienWagiUkrytych(double _wartosc)
        {
            double[] WagiHalp = new double[2];
            for (int i =0; i< Ukryte.Length; i++)
            {
                WagiHalp[0] = Ukryte[i].Wagi[0];
                WagiHalp[1] = Ukryte[i].Wagi[1];
                //ZMIANA WAGI DLA BIASU
                Ukryte[i].Wagi[0] += -Program.N * Ukryte[i].Blad + Program.MOMENTUM * (WagiHalp[0] - Ukryte[0].PoprzednieWagi[1]);
                //ZMIANA WAGI DLA PRAWDZIWEGO WEJSCIA
                Ukryte[i].Wagi[1] += -Program.N * Ukryte[i].Blad * _wartosc + Program.MOMENTUM * (WagiHalp[1] - Ukryte[i].PoprzednieWagi[1]);

                Ukryte[i].PoprzednieWagi[0] = WagiHalp[0];
                Ukryte[i].PoprzednieWagi[1] = WagiHalp[1];
            }
        }
    }
}
