using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitStats.Lib
{
	public class GetStatsCollection : IGetStatsCollection
	{
		private List<IGetStats> stats;
		public GetStatsCollection()
		{
			this.stats = new List<IGetStats>();
		}

		public IEnumerator<IGetStats> GetEnumerator()
		{
			return this.stats.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public void Add(IGetStats stats)
		{
			this.stats.Add(stats);
		}
	}

	public interface IGetStatsCollection: IEnumerable<IGetStats>
	{
	}
}
