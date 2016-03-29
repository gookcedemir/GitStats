using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitStats.Lib;
using Microsoft.Practices.Unity;

namespace GitStats
{
	class Program
	{
		static int Main(string[] args)
		{
			if (args.Length != 3)
			{
				Usage();
				return -1;
			}
			if (!Directory.Exists(args[0]))
			{
				Usage();
				Console.WriteLine("Directory does not exist :" + args[0] );
				return -1;
			}
			var repo = args[0];
			int count;
			if (!Int32.TryParse(args[1], out count))
			{
				Usage();
				Console.WriteLine("Commit Count is not a number :" + args[1]);
				return -1;
			}

			string branch = null;
			if (!string.IsNullOrEmpty(args[2]))
			{
				branch = args[2];
			}

			IGetStatsCollection collection = GitStats.Lib.Resolver.Instance.Container.Resolve<IGetStatsCollection>();
			foreach (var stats in collection)
			{
				stats.Get(repo, count, branch);
			}
			return 0;
		}

		static void Usage()
		{
			Console.WriteLine("Usage: GitStats.exe <path to local git repo> <commit count> [branch name]");
			Console.WriteLine(@"Example: GitStats.exe 'C:\projects\GitStats\' 200 master");
			Console.WriteLine(@"Example: GitStats.exe 'C:\projects\GitStats\' 200 // Defaults to your current branch");
		}
	}
}
