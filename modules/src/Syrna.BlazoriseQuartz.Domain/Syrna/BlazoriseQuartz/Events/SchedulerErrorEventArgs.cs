using System;
using System.Threading;
using Quartz;

namespace Syrna.BlazoriseQuartz.Events
{
	public class SchedulerErrorEventArgs : EventArgs
	{
		public string ErrorMessage { get; init; } = null!;
		public SchedulerException Exception { get; init; } = null!;
		public CancellationToken CancelToken { get; init; }
	}
}

