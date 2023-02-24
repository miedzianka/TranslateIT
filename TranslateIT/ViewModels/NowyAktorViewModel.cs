﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslateIT.Helpers;
using TranslateIT.Model.EntitiesForView;
using TranslateIT.Model.Entity;
using TranslateIT.ViewModels.Abstract;

namespace TranslateIT.ViewModels
{
    public class NowyAktorViewModel : OneViewModel<Aktorzy>
    {
        public NowyAktorViewModel() : base("Aktor")
        {
            Item = new Aktorzy();
            Messenger.Default.Register<PracownikForAllView>(this, GetWybranyPracownik);
        }
        #region Commands
        private BaseCommand _ShowPracownicyCommand;
        public ICommand ShowPracownicyCommand
        {
            get
            {
                if (_ShowPracownicyCommand == null)
                {
                    _ShowPracownicyCommand = new BaseCommand(() => ShowPracownicy());
                }
                return _ShowPracownicyCommand;
            }
        }
        public void ShowPracownicy()
        {
            Messenger.Default.Send("PracownicyAll");
        }
        #endregion
        #region Properties

        public string OpisAktora
        {
            get
            {
                return Item.OpisAktora;
            }
            set
            {
                if (Item.OpisAktora != value)
                {
                    Item.OpisAktora = value;
                    base.OnPropertyChanged(() => OpisAktora);
                }
            }
        }

        private int? _IdPracownika;
        public int? PracownikId
        {
            get
            {
                return _IdPracownika;
            }
            set
            {
                if (value != _IdPracownika)
                {
                    _IdPracownika = value;
                    base.OnPropertyChanged(() => _IdPracownika);
                }
            }
        }
        private string _Imie;
        public string Imie
        {
            get
            {
                return _Imie;
            }
            set
            {
                if (value != _Imie)
                {
                    _Imie = value;
                    base.OnPropertyChanged(() => _Imie);
                }
            }
        }

        private string _Nazwisko;
        public string Nazwisko
        {
            get
            {
                return _Nazwisko;
            }
            set
            {
                if (value != _Nazwisko)
                {
                    _Nazwisko = value;
                    base.OnPropertyChanged(() => _Nazwisko);
                }
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywne = true;
            Db.Aktorzy.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void GetWybranyPracownik(PracownikForAllView pracownikForAllView)
        {
            PracownikId = pracownikForAllView.IdPracownika;
            Imie = pracownikForAllView.Imie;
            Nazwisko = pracownikForAllView.Nazwisko;
        }
        #endregion
    }
}
