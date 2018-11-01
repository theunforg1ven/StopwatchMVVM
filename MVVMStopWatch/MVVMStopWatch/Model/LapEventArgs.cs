using System;

namespace MVVMStopWatch
{
	class LapEventArgs : EventArgs
	{
		/// <summary>
		/// Nullable LapTime prop
		/// </summary>
		public TimeSpan? LapTime { get; private set; }

		/// <summary>
		/// Simple constructor
		/// </summary>
		public LapEventArgs(TimeSpan? lapTime) => LapTime = lapTime;
	}
}
