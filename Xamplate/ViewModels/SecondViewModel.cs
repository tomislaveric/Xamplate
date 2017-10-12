using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamplate.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public string PageTitle => "Second Page";
        public string IncrementButtonText => "Increment";
        
        public int ValueToChange { get; set; }
        
        public ICommand IncrementValueCommand => new Command(() => ++ValueToChange);
    }
}