using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.Validators
{
    public class BusinessValidator : Validator
    {
        public static string SprawdzVAT(decimal? vat)
        {
            if (vat < 0 || vat > 100 || vat == null)
                return "VAT powinien być w przedziale od zera do stu, popraw to";
            return null;
        }
        public static string SprawdzPesel(string pesel)
        {
            if (pesel != null)
            {
                if (pesel.Length != 11)
                    return "Pesel ma 11 znaków, popraw to :)";
            }
            return null;
        }
        public static string SprawdzNIP(string NIP)
        {
            if (NIP != null)
            {
                if (NIP.Length != 10)
                    return "NIP ma 10 znaków, popraw to :)";
            }
            return null;
        }
        public static string SprawdzREGON(string regon)
        {
            if (regon != null)
            {
                if (regon.Length != 9)
                    return "REGON ma 9 znaków, popraw to :)";
            }
            return null;
        }
        public static string SprawdzBank(string bank)
        {
            string nazwa = "nieznany";
            if (bank != null && bank.Length==26)
            {
                if (bank.Substring(2, 6) == "1010")
                {
                    nazwa = "Narodowy Bank Polski";
                }
                if (bank.Substring(2, 6) == "1020")
                {
                    nazwa = "PKO BP";
                }
                if (bank.Substring(2, 6) == "1030")
                {
                    nazwa = "Bank Handlowy (Citi Handlowy)";
                }
                if (bank.Substring(2, 6) == "1050")
                {
                    nazwa = "ING Bank Śląski";
                }
                if (bank.Substring(2, 6) == "1090")
                {
                    nazwa = "Santander Bank Polska";
                }
                if (bank.Substring(2, 6) == "1130")
                {
                    nazwa = "BGK";
                }
                if (bank.Substring(2, 6) == "1140")
                {
                    nazwa = "mBank";
                }
                if (bank.Substring(2, 6) == "1160")
                {
                    nazwa = "Bank Millenium";
                }
                if (bank.Substring(2, 6) == "1240")
                {
                    nazwa = "Pekao SA";
                }
                if (bank.Substring(2, 6) == "1320")
                {
                    nazwa = "Bank Pocztowy";
                }
                if (bank.Substring(2, 6) == "1540")
                {
                    nazwa = "BOŚ Bank";
                }
                if (bank.Substring(2, 6) == "1580")
                {
                    nazwa = "Mercedes-Benz Bank Polska";
                }
                if (bank.Substring(2, 6) == "1610")
                {
                    nazwa = "SGB - Bank";
                }
                if (bank.Substring(2, 6) == "1680")
                {
                    nazwa = "Plus Bank";
                }
                if (bank.Substring(2, 6) == "1840")
                {
                    nazwa = "Societe Genrale";
                }
                if (bank.Substring(2, 6) == "1870")
                {
                    nazwa = "Nest Bank";
                }
                if (bank.Substring(2, 6) == "1930")
                {
                    nazwa = "Bank Polskiej Spółdzielni";
                }
                if (bank.Substring(2, 6) == "1940")
                {
                    nazwa = "Credit Agricole Bank Polska";
                }
                if (bank.Substring(2, 6) == "2030")
                {
                    nazwa = "BNP Parbias";
                }
                if (bank.Substring(2, 6) == "2120")
                {
                    nazwa = "Santander Consumer Bank";
                }
                if (bank.Substring(2, 6) == "2160")
                {
                    nazwa = "Toyota Bank";
                }
                if (bank.Substring(2, 6) == "2190")
                {
                    nazwa = "DNB Bank Polska";
                }
                if (bank.Substring(2, 6) == "2490")
                {
                    nazwa = "Alior Bank";
                }
                if (bank.Substring(2, 6) == "2710")
                {
                    nazwa = "FCE Bank Polska";
                }
                if (bank.Substring(2, 6) == "2720")
                {
                    nazwa = "Inbank";
                }
                if (bank.Substring(2, 6) == "2770")
                {
                    nazwa = "Volkswagen Bank";
                }
                if (bank.Substring(2, 6) == "2800")
                {
                    nazwa = "HSBC";
                }
                if (bank.Substring(2, 6) == "2850")
                {
                    nazwa = "BFF Bank";
                }
                if (bank.Substring(2, 6) == "2910")
                {
                    nazwa = "Aion Bank";
                }
                if (bank.Substring(2, 6) == "2930")
                {
                    nazwa = "VeloBank";
                }
            }
            return nazwa;
        }
        public static string NumerIBAN(string konto)
        {
            if (konto != null)
            {
                konto = konto.Trim();
                konto = konto.Replace(" ", "");
                if (konto.Length != 26)
                    return "Numer konta ma 26 cyferek, popraw to :)";
            }
            return null;
        }
        public static string SprawdzKodPocztowy(string kodPocztowy)
        {
            if (kodPocztowy != null)
            {
                if (kodPocztowy.Substring(2, 3) != "-")
                    return "kod pocztowy wygląda tak: 00-000, zapomniałeś o myślniku albo jest w złym miejscu. Popraw to :)";
                if (kodPocztowy.Length != 6)
                    return "Zła liczba znaków, popraw to";
            }
            return null;
        }
        public static string SprawdzNumerTelefonu(string numerTelefonu)
        {
            if (numerTelefonu != null)
            {
                numerTelefonu = numerTelefonu.Trim();
                numerTelefonu = numerTelefonu.Replace(" ", "");
                if (numerTelefonu.Length < 9 || numerTelefonu.Length > 12)
                    return "Niepoprawny numer telefonu, popraw :)";
            }
            return null;
        }
        public static string SprawdzNumerFaktury(string numerFaktura)
        {
            if (numerFaktura != null)
            {
                if (numerFaktura.Length > 10)
                    return "Za długi numer maksymalnie 10 znaków :)";
            }
            return null;
        }
        public static string SprawdzNumerUmowy(string numerUmowa)
        {
            if (numerUmowa != null)
            {
                if (numerUmowa.Length > 10)
                    return "Za długi numer maksymalnie 10 znaków :)";
            }
            return null;
        }
        public static string StawkaNettoMniejsza(decimal? netto, decimal? brutto)
        {
            if (brutto < netto)
                return "Brutto to to większe :P, a może Boruto hehe XD I'm tired";
            return null;
        }
        public static string ZaliczkaMniejsza(decimal? zaliczka, decimal? stawka)
        {
            if (stawka < zaliczka)
                return "Zaliczka musi być mniejsza niż stawka dummy :P, hehe XD I'm tired";
            return null;
        }
        public static string JestWczesniej(DateTime? pierwsza, DateTime? druga)
        {
            if (druga < pierwsza)
                return "Nie opłacaj czegoś co nie istnieje, bo sie sparzysz Dummy XDDDDDDD";
            return null;
        }
    }
}
