using Blazorise;
using System;

namespace Syrna.BlazoriseQuartz.Blazor.Components
{
	public static class ModelExtensions
	{
		public static string GetTriggerTypeIcon(this TriggerType triggerType)
		{
			switch (triggerType)
			{
				case TriggerType.Cron:
					return "fa-clock";
				case TriggerType.Daily:
					return "fa-calendar-day";
				case TriggerType.Simple:
					return "fa-repeat";
				case TriggerType.Calendar:
					return "fa-calendar";
				default:
					return "fa-gear";
			}
		}

		/// <summary>
		/// Converts <see cref="TimeSpan"/> objects to a simple human-readable string.  Examples: 3.1 seconds, 2 minutes, 4.23 hours, etc.
		/// </summary>
		/// <param name="span">The timespan.</param>
		/// <param name="significantDigits">Significant digits to use for output.</param>
		/// <returns></returns>
		public static string ToHumanTimeString(this TimeSpan span, int significantDigits = 3)
		{
			var format = "G" + significantDigits;
			return span.TotalMilliseconds < 1000 ? span.TotalMilliseconds.ToString(format) + " ms"
				: span.TotalSeconds < 60 ? span.TotalSeconds.ToString(format) + (span.TotalSeconds == 1 ? " sec" : " secs")
					: span.TotalMinutes < 60 ? span.TotalMinutes.ToString(format) + (span.TotalMinutes == 1 ? " min" : " mins")
						: span.TotalHours < 24 ? span.TotalHours.ToString(format) + (span.TotalHours == 1 ? " hr" : " hrs")
												: span.TotalDays.ToString(format) + (span.TotalDays == 1 ? " day" : " days");
		}
	}
}

