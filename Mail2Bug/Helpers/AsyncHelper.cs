using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mail2Bug.Helpers
{
	public static class AsyncHelper
	{
		public static void RunSync(Func<Task> taskFactory)
		{
			SynchronizationContext originalContext = SynchronizationContext.Current;
			SynchronizationContext.SetSynchronizationContext(null);
			try
			{
				taskFactory().GetAwaiter().GetResult();
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(originalContext);
			}
		}

		public static TResult RunSync<TResult>(Func<Task<TResult>> taskFactory)
		{
			SynchronizationContext originalContext = SynchronizationContext.Current;
			SynchronizationContext.SetSynchronizationContext(null);
			try
			{
				return taskFactory().GetAwaiter().GetResult();
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(originalContext);
			}
		}
	}
}
