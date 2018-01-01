/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DemoDiplomski"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace DemoDiplomski.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}J;
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //SimpleIoc.Default.Register<MainWindowViewModel>();
            //SimpleIoc.Default.Register<UredjajUCViewModel>();
            //SimpleIoc.Default.Register<DeloviUCViewModel>();
            //SimpleIoc.Default.Register<KorisnikUCViewModel>();
        }

        //public MainWindowViewModel MainWindowVM
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        //    }
        //}

        //public KorisnikUCViewModel KorisnikUCVM
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<KorisnikUCViewModel>();
        //    }
        //}

        //public UredjajUCViewModel UredjajUCVM
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<UredjajUCViewModel>();
        //    }
        //}

        //public DeloviUCViewModel DeloviUCVM
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<DeloviUCViewModel>();
        //    } 
        //}


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}