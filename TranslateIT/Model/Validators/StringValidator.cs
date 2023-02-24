using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIT.Model.Validators
{
    internal class StringValidator : Validator
    {
        public static string IsUpperCase(string wartosc)
        {
            try
            {
                if (!char.IsUpper(wartosc, 0))
                    return "Rozpocznij dużą literą!";
                return null;
            }
            catch(Exception ex)
            {
            }
            return null;
        }

    }
}
