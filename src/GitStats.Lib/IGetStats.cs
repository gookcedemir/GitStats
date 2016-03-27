using System.Collections.Generic;

namespace GitStats.Lib
{
	public interface IGetStats
	{
		void Get(string gitRepo, int commitsNum = 200, string branch = null);
	}
}