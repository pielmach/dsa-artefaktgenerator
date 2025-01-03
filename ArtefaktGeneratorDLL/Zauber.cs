﻿using System;
using System.ComponentModel;

namespace ArtefaktGenerator
{
    public class Zauber : INotifyPropertyChanged
    {
        public enum Komplexitaet : short { A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7 };

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public Zauber()
        {
            komp = Komplexitaet.A;
            staple = 1;
            asp = 1;
            summierung = 1;
            eigene_rep = true;
        }

        private String _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("name");
            }
        }

        private Komplexitaet _komp;
        public Komplexitaet komp
        {
            get { return _komp; }
            set
            {
                _komp = value;
                NotifyPropertyChanged("komp");
            }
        }

        private Decimal _staple;
        public Decimal staple
        {
            get { return _staple; }
            set
            {
                _staple = value;
                NotifyPropertyChanged("staple");
            }
        }

        private Decimal _summierung;
        public Decimal summierung
        {
            get { return _summierung; }
            set
            {
                _summierung = value;
                NotifyPropertyChanged("summierung");
            }
        }

        private Decimal _asp;
        public Decimal asp
        {
            get { return _asp; }
            set
            {
                _asp = value;
                NotifyPropertyChanged("asp");
            }
        }

        private bool _eigene_rep;
        public bool eigene_rep
        {
            get { return _eigene_rep; }
            set
            {
                _eigene_rep = value;
                NotifyPropertyChanged("eigene_rep");
            }
        }

        public string KomplexitaetToString(Komplexitaet komp)
        {
            switch (komp)
            {
                case Komplexitaet.A:
                    return "A";
                case Komplexitaet.B:
                    return "B";
                case Komplexitaet.C:
                    return "C";
                case Komplexitaet.D:
                    return "D";
                case Komplexitaet.E:
                    return "E";
                case Komplexitaet.F:
                    return "F";
                case Komplexitaet.G:
                    return "G";
                case Komplexitaet.H:
                    return "H";
                default:
                    break;
            }
            return "X";
        }

        public override string ToString()
        {
            return name + "\t" + komp + "\t" + staple + "\t" + asp + "\t" + (eigene_rep ? "eigene" : "fremde");
        }
    }
}
