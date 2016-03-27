using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitStats.Lib
{
	public class MostChanges : IMostChanges
	{
		Dictionary<string, ChangeRecord> lookup = new Dictionary<string, ChangeRecord>();
		private Repository repo;

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
					var diff = repo.Diff.Compare<Patch>(commits[i + 1].Tree, commits[i].Tree);
					foreach (var changes in diff)
					{
						if (!lookup.ContainsKey(changes.Path))
						{
							lookup.Add(changes.Path,new ChangeRecord());
						}
						lookup[changes.Path].Added += changes.LinesAdded;
						lookup[changes.Path].Deleted += changes.LinesDeleted;
					}
				}
			}
			catch (Exception)
			{
			}

			var addOrdered = lookup.OrderBy(x => x.Value.Added).Reverse();
			OutputConsole(addOrdered, commitsNum,"Added");

			var deletedOrdered = lookup.OrderBy(x => x.Value.Deleted).Reverse();
			OutputConsole(deletedOrdered, commitsNum, "Deleted");
		}


		private void OutputConsole(IEnumerable<KeyValuePair<string, ChangeRecord>> ordered, int commitsNum,string header)
		{
			Console.WriteLine("Most "+header);
			Console.WriteLine("FileName\tLinesAdded\tLinesDeleted");
			foreach (var line in ordered)
			{
				Console.WriteLine(line.Key + "\t" + line.Value.Added + "\t" + line.Value.Deleted);
			}
		}

		class ChangeRecord
		{
			public int Added { get; set; }
			public int Deleted { get; set; }
			public string Path { get; set; }
		}
	}

	public interface IMostChanges : IGetStats
	{
	}

}
