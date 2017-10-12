using System;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace Xamplate.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public string PageTitle => "Second Page";
        public string IncrementButtonText => "Increment";
        
        public int ValueToChange { get; set; }
        
        [DependsOn(nameof(ValueToChange))]
        public string ValueToChangeIndirectly => $"I depend on the value #{ValueToChange} above";
        
        public ICommand IncrementValueCommand => new Command(() => ++ValueToChange);
    }
}