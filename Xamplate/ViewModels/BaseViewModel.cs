using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using $safeprojectname$.Interfaces;

namespace $safeprojectname$.ViewModels
{
	public abstract class BaseViewModel : IViewModelBase
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
		}
	}
}
