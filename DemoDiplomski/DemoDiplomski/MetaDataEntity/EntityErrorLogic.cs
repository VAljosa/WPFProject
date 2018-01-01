using DemoDiplomski.Utility;
using DemoDiplomski.Validation;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections;
using DemoDiplomski.Converters;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DemoDiplomski.Model
{
    //BaseEntity klasa u WpfEF prim.
    public class EntityErrorLogic : NotifyContext, INotifyDataErrorInfo
    {
        private RelayCommand<NameErrorProperty> konverzijaKomanda;
        private RelayCommand<string> noviIzvorKomanda;

        public RelayCommand<NameErrorProperty> KonverzijaKomanda
        {
            get
            {
                return konverzijaKomanda ?? (konverzijaKomanda = new RelayCommand<NameErrorProperty>(nameErrorProperty =>
                    {
                        if (nameErrorProperty.Dodato)
                        {
                            DodajError(nameErrorProperty.NazivError, nameErrorProperty.Error, SourceOfError.Conversion);
                        }
                        KolekcijaErrora();
                    }
                ));
            }

        }

        public RelayCommand<string> NoviIzvorKomanda
        {
            get
            {
                return noviIzvorKomanda ?? (noviIzvorKomanda = new RelayCommand<string>
                (noviIzvor => 
                    {
                        ValidacijaProperty(noviIzvor);
                    }
                 ));
            }

        }

        public void ValidacijaProperty(string nazivSvojstva)
        {
            //U slucaju validacije svojstva onda ne postoji konverzija greske
            errors.Remove(nazivSvojstva);
            var validacijaContext = new ValidationContext(this, null, null);
            validacijaContext.MemberName = nazivSvojstva;
            List<ValidationResult> vResults = new List<ValidationResult>();
            Validator.TryValidateProperty(this.GetType().GetProperty(nazivSvojstva).GetValue(this, null), validacijaContext, vResults);

            TransformErrors(vResults);
        }

        public bool JeValidno()
        {
            UkloniKonvertovaneGreske();

            var validacijaContext = new ValidationContext(this, null, null);
            List<ValidationResult> vResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, validacijaContext, vResults, true);
            TransformErrors(vResults);
            var nazivP = errors.Keys.ToList();
            nazivP.ForEach(nP => NotifyErrors(nP));
            NotifyErrorProperties();
            KolekcijaErrora();

            if(nazivP.Count > 0)
            {
                return false;
            }
            return true;
        }

        private void UkloniKonvertovaneGreske()
        {
            foreach (KeyValuePair<string, List<ErrorSelekcija>> kvp in errors)
            {
                List<ErrorSelekcija> lista = kvp.Value;
                lista.RemoveAll(x => x.Source == SourceOfError.Validation);
            }

            var ukloniProperties = errors.Where(x => x.Value.Count == 0)
                .Select(x => x.Key)
                .ToList();
            foreach (string key in ukloniProperties)
                errors.Remove(key);
        }

        private void TransformErrors(List<ValidationResult> vResults)
        {
            foreach (ValidationResult validationResult in vResults)
            {
                foreach (string ppty in validationResult.MemberNames)
                {
                    DodajError(ppty, validationResult.ErrorMessage, SourceOfError.Validation);
                }
            }
        }

        private ObservableCollection<NameErrorProperty> errorKolecija = new ObservableCollection<NameErrorProperty>();
        public ObservableCollection<NameErrorProperty> ErrorKolekcija
        {
            get
            {
                return errorKolecija;
            }

            set
            {
                errorKolecija = value;
                NotifyPropertyChanged();
            }
        }


        private void KolekcijaErrora()
        {
            ObservableCollection<NameErrorProperty> kolekcija_Errora = new ObservableCollection<NameErrorProperty>();
            foreach (var property in errors.Keys)
            {
                List<ErrorSelekcija> err = errors[property];
                foreach(ErrorSelekcija errorSelekcija in err)
                {
                    kolekcija_Errora.Add(new NameErrorProperty { NazivError = property, Error = errorSelekcija.Tekst });
                }
            }
            ErrorKolekcija = kolekcija_Errora;
        }

        private void NotifyErrorProperties()
        {
            foreach(var properties in errors.Keys)
            {
                NotifyErrors(properties);
            }
        }

        private void NotifyErrors(string nazivSvojstva)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nazivSvojstva));
        }

        protected Dictionary<string, List<ErrorSelekcija>> errors = new Dictionary<string, List<ErrorSelekcija>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string nazivSvojstva)
        {
            if (string.IsNullOrEmpty(nazivSvojstva))
            {
                return null;
            }
            if(errors.ContainsKey(nazivSvojstva) && errors[nazivSvojstva] != null && errors[nazivSvojstva].Count > 0)
            {
                return errors[nazivSvojstva].Select(x => x.Tekst).ToList();
            }
            return null;
        }

        public bool HasErrors
        {
            get
            {
                return errors.Count > 0;
            }
        }


        private void DodajError(string ppty, string error, SourceOfError source)
        {
            List<ErrorSelekcija> listA;
            if(!errors.TryGetValue(ppty, out listA))
            {
                errors.Add(ppty, listA = new List<ErrorSelekcija>());
            }
            if(!listA.Any(x => x.Tekst == error))
            {
                listA.Add(new ErrorSelekcija { Tekst = error, Source = source });
            }
        }

        
        public void ClearErrors()
        {
            errors.Clear();
            ErrorKolekcija.Clear();
            NotifyErrors("");
        }
    }
}
