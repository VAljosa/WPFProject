using DemoDiplomski.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.Validation
{
    public class ValidacijaLogika : NotifyContext, IDataErrorInfo
    {
        private static readonly Dictionary<string, Func<ValidacijaLogika, object>>
            dohvatiSvojstvo = typeof(ValidacijaLogika).GetProperties()
                              .Where(p => DohvatiValidaciju(p).Length != 0)
                              .ToDictionary(p => p.Name, p => DohvatiVrednost(p));

        private static readonly Dictionary<string, ValidationAttribute[]> validatori =
            typeof(ValidacijaLogika).GetProperties()
            .Where(p => DohvatiValidaciju(p).Length != 0)
            .ToDictionary(p => p.Name, p => DohvatiValidaciju(p));

        public string this[string columnName]
        {
            get
            {
                if (dohvatiSvojstvo.ContainsKey(columnName))
                {
                    var value = dohvatiSvojstvo[columnName](this);
                    var errors = validatori[columnName].Where(v => !v.IsValid(value))
                        .Select(v => v.ErrorMessage).ToArray();
                    NotifyPropertyChanged("Error");
                    return string.Join(Environment.NewLine, errors);
                }
                NotifyPropertyChanged("Error");
                return string.Empty;
            }
        }

        public string Error
        {
            get
            {
                var errors = from i in validatori
                             from v in i.Value
                             where !v.IsValid(dohvatiSvojstvo[i.Key](this))
                             select v.ErrorMessage;
                return string.Join(Environment.NewLine, errors.ToArray());

            }
        }

        private static ValidationAttribute[] DohvatiValidaciju(PropertyInfo svojstvo)
        {
            return (ValidationAttribute[])svojstvo.GetCustomAttributes(typeof(ValidationAttribute), true);
        }

        private static Func<ValidacijaLogika, object> DohvatiVrednost(PropertyInfo svojstvo)
        {
            var instanca = Expression.Parameter(typeof(ValidacijaLogika), "i");
            var cast = Expression.TypeAs(Expression.Property(instanca, svojstvo), typeof(object));
            return (Func<ValidacijaLogika, object>)Expression.Lambda(cast, instanca).Compile();
        }

    }
}
