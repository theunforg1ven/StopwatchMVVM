using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MVVMStopWatch
{
	class StopwatchViewModel : BaseViewModel
	{
		#region Private members

		/// <summary>
		/// Current window
		/// </summary>
		private Window _window;

		/// <summary>
		/// StopwatchModel member
		/// </summary>
		private StopwatchModel _stopwatchModel = new StopwatchModel();

		/// <summary>
		/// DispatcherTimer object
		/// </summary>
		private DispatcherTimer _dispatcherTimer = new DispatcherTimer();

		/// <summary>
		/// Check hours changing
		/// </summary>
		private int _lastHours;

		/// <summary>
		/// Check minutes changing
		/// </summary>
		private int _lastMinutes;

		/// <summary>
		/// Check seconds changing
		/// </summary>
		private decimal _lastSeconds;

		/// <summary>
		/// Check if stopwatch is running
		/// </summary>
		private bool _lastRunning;

		/// <summary>
		/// Check lap hours changing
		/// </summary>
		private int _lastLapHours;

		/// <summary>
		/// Check lap minutes changing
		/// </summary>
		private int _lastLapMinutes;

		/// <summary>
		/// Check lap seconds changing
		/// </summary>
		private decimal _lastLapSeconds;

		#endregion

		#region Public Properties

		/// <summary>
		/// Check if stopwatch is run
		/// </summary>
		public bool IsRunning => _stopwatchModel.IsRunning;

		/// <summary>
		/// Count hours
		/// </summary>
		public int Hours =>  
			_stopwatchModel.Elapsed.HasValue? _stopwatchModel.Elapsed.Value.Hours : 0;

		/// <summary>
		/// Count minutes
		/// </summary>
		public int Minutes =>
			_stopwatchModel.Elapsed.HasValue ? _stopwatchModel.Elapsed.Value.Minutes : 0;

		/// <summary>
		/// Count seconds
		/// </summary>
		public decimal Seconds
		{
			get
			{
				if (_stopwatchModel.Elapsed.HasValue)
					return _stopwatchModel.Elapsed.Value.Seconds + (_stopwatchModel.Elapsed.Value.Milliseconds * .001M);
				else
					return 0.0M;
			}
		}

		/// <summary>
		/// Get lap hours
		/// </summary>
		public int LapHours =>
			_stopwatchModel.LapTime.HasValue ? _stopwatchModel.LapTime.Value.Hours : 0;

		/// <summary>
		/// Get lap minutes
		/// </summary>
		public int LapMinutes =>
			_stopwatchModel.LapTime.HasValue ? _stopwatchModel.LapTime.Value.Minutes : 0;

		/// <summary>
		/// Get lap seconds
		/// </summary>
		public decimal LapSeconds
		{
			get
			{
				if (_stopwatchModel.LapTime.HasValue)
					return _stopwatchModel.LapTime.Value.Seconds + (_stopwatchModel.LapTime.Value.Milliseconds * .001M);
				else
					return 0.0M;
			}
		}

		#endregion

		#region Public Commands

		/// <summary>
		/// Command to start timer
		/// </summary>
		public ICommand StartCommand { get; set; }

		/// <summary>
		/// Command to stop timer
		/// </summary>
		public ICommand StopCommand { get; set; }

		/// <summary>
		/// Command to create a lap
		/// </summary>
		public ICommand LapCommand { get; set; }

		/// <summary>
		/// Command to reset timer
		/// </summary>
		public ICommand ResetCommand { get; set; }

		#endregion

		/// <summary>
		/// Simple constructor
		/// </summary>
		/// <param name="window">Current window</param>
		public StopwatchViewModel(Window window)
		{
			_window = window;

			// initialize dispatcher timer
			_dispatcherTimer.Interval = TimeSpan.FromMilliseconds(50);
			_dispatcherTimer.Tick += TimerTick;
			_dispatcherTimer.Start();

			_stopwatchModel.LapTimeUpdated += LapTimeUpdatedEventHandler;

			// initialize commands
			StartCommand = new RelayCommand(() => _stopwatchModel.Start());
			StopCommand = new RelayCommand(() => _stopwatchModel.Stop());
			LapCommand = new RelayCommand(() => _stopwatchModel.Lap());
			ResetCommand = new RelayCommand(() => 
			{
				var isRunning = IsRunning;
				_stopwatchModel.Reset();
				if (isRunning)
					_stopwatchModel.Start();
			});
		}

		/// <summary>
		/// Changes properties on timer tick
		/// </summary>
		private void TimerTick(object sender, object e)
		{
			if (_lastRunning != IsRunning)
				_lastRunning = IsRunning;
			OnPropertyChanged(nameof(IsRunning));

			if (_lastHours != Hours)
				_lastHours = Hours;
			OnPropertyChanged(nameof(Hours));

			if (_lastMinutes != Minutes)
				_lastMinutes = Minutes;
			OnPropertyChanged(nameof(Minutes));

			if (_lastSeconds != Seconds)
				_lastSeconds = Seconds;
			OnPropertyChanged(nameof(Seconds));
		}

		/// <summary>
		/// Changes properties on laped time
		/// </summary>
		private void LapTimeUpdatedEventHandler(object sender, LapEventArgs e)
		{
			if (_lastLapHours != LapHours)
				_lastLapHours = LapHours;
			OnPropertyChanged(nameof(LapHours));

			if (_lastLapMinutes != LapMinutes)
				_lastLapMinutes = LapMinutes;
			OnPropertyChanged(nameof(LapMinutes));

			if (_lastLapSeconds != LapSeconds)
				_lastLapSeconds = LapSeconds;
			OnPropertyChanged(nameof(LapSeconds));
		}
	}
}
