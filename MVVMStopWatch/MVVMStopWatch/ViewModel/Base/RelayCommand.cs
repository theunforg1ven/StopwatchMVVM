using System;
using System.Windows.Input;

namespace MVVMStopWatch
{
	class RelayCommand : ICommand
	{
		// an action to run
		private Action _action;

		// the event that fired when the CanExecute() value has changed
		public event EventHandler CanExecuteChanged = (sender, e) => { };

		// simple constructor
		public RelayCommand(Action action) => _action = action;

		/// <summary>
		/// A relay command can always execute
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			return true;
		}

		/// <summary>
		/// Executes the command Action
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			_action();
		}
	}
}
