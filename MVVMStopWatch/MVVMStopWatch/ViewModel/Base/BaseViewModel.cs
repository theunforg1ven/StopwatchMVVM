using System.ComponentModel;


namespace MVVMStopWatch
{
	class BaseViewModel : INotifyPropertyChanged
	{
		// event fired, when any child property changes its value
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

		// call this to fire a "PropertyChanged" event
		public void OnPropertyChanged(string name)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}
}
