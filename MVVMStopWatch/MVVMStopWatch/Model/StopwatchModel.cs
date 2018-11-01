using System;

namespace MVVMStopWatch
{
	class StopwatchModel
	{
		/// <summary>
		/// Current DateTime
		/// </summary>
		private DateTime? _started;

		/// <summary>
		/// Count prev elapsed time
		/// </summary>
		private TimeSpan? _previousElapsedTime;

		/// <summary>
		/// Check if stopwatch is running
		/// </summary>
		public bool IsRunning => _started.HasValue;

		/// <summary>
		/// LapTime prop
		/// </summary>
		public TimeSpan? LapTime { get; private set; }

		/// <summary>
		/// Count current elapsed time
		/// </summary>
		public TimeSpan? Elapsed
		{
			get
			{
				if (_started.HasValue)
					if (_previousElapsedTime.HasValue)
						return CalculateTimeElapsedSinceStarted() + _previousElapsedTime;
					else
						return CalculateTimeElapsedSinceStarted();
				else
					return _previousElapsedTime;
			}
		}

		/// <summary>
		/// Simple constructor
		/// </summary>
		public StopwatchModel() => Reset();

		/// <summary>
		/// Start stopwatch
		/// </summary>
		public void Start()
		{
			_started = DateTime.Now;
			if (!_previousElapsedTime.HasValue)
				_previousElapsedTime = new TimeSpan(0);
		}

		/// <summary>
		/// Stop stopwatch
		/// </summary>
		public void Stop()
		{
			if (_started.HasValue)
				_previousElapsedTime += DateTime.Now - _started.Value;
			_started = null;
		}

		/// <summary>
		/// Reset stopwatch
		/// </summary>
		public void Reset()
		{
			_previousElapsedTime = null;
			_started = null;
			LapTime = null;
		}

		/// <summary>
		/// Create lap
		/// </summary>
		public void Lap()
		{
			LapTime = Elapsed;
			OnLapTimeUpdated(LapTime);
		}

		/// <summary>
		/// Calculate time from the beginning
		/// </summary>
		private TimeSpan CalculateTimeElapsedSinceStarted() => DateTime.Now - _started.Value;
		
		/// <summary>
		/// Event handler fires when lap time updates
		/// </summary>
		public event EventHandler<LapEventArgs> LapTimeUpdated;

		/// <summary>
		/// Do when LapTimeUpdated fires
		/// </summary>
		/// <param name="lapTime"> Invoke LapTimeUpdated </param>
		private void OnLapTimeUpdated(TimeSpan? lapTime) => LapTimeUpdated?.Invoke(this, new LapEventArgs(lapTime));
	}
}
