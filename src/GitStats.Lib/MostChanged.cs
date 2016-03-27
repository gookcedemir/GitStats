using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitStats.Lib
{
	public interface IMostChanged : IGetStats
	{
	}

	public class MostChanged : IMostChanged
	{
		Dictionary<string, int> lookup = new Dictionary<string, int>();
		private Repository repo;

		public MostChanged()
	    {
		}

		public void Get(string gitRepo, int commitsNum = 200, string branch = null)
	    {
			repo = new Repository(gitRepo);
			var commits = repo.Head.Commits.ToList();
			if (!string.IsNullOrEmpty(branch))
			{
				var branchref = repo.Branches.FirstOrDefault(x => x.FriendlyName == branch);
				if (branchref == null) throw new ArgumentException("Branch not found:" + branch);
				commits = branchref.Commits.ToList();
			}
			var numParents = commitsNum;

			try
			{
				for (int i = 0; i < numParents - 1; i++)
				{
					var diff = repo.Diff.Compare<TreeChanges>(commits[i + 1].Tree, commits[i].Tree);
					foreach (var changes in diff)
					{
						if (!lookup.ContainsKey(changes.Path))
						{
							lookup.Add(changes.Path, 0);
						}
						lookup[changes.Path]++;
					}
				}
			}
			catch (Exception)
			{
			}

			var ordered = lookup.OrderBy(x => x.Value).Reverse();
			OutputConsole(ordered,commitsNum);

		}

	    public void OutputConsole(IEnumerable<KeyValuePair<string, int>> ordered, int commitsNum)
	    {
		    Console.WriteLine("Most Changed");
		    Console.WriteLine("FileName\tNumberOfTimesChanged\tPercentTimesChanged");
			foreach (var line in ordered)
			{
				decimal per = Math.Round(((decimal)line.Value / commitsNum) * 100, 2, MidpointRounding.AwayFromZero);
				Console.WriteLine(line.Key + "\t" + line.Value + "\t" + per);
			}
		}
	}
}
