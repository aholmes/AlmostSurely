using System;
using System.Threading;

namespace AlmostSurely.Providers
{
	/// <summary>
	/// http://csharpindepth.com/Articles/Chapter12/Random.aspx
	/// </summary>
	public static class RandomProvider
	{
		private static int seed = Environment.TickCount;

		private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
			new Random(Interlocked.Increment(ref seed))
		);

		public static Random GetThreadRandom()
		{
			return randomWrapper.Value;
		}
	}
}
