using System;
using GitStats.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetStats.Lib.Test
{
	[TestClass]
	public class BrittlesTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			MostChanged mostChanged = new MostChanged();
			Assert.IsNotNull(mostChanged);
		}

		[TestMethod]
		public void GetBrittlesDefaultTest()
		{
			MostChanged mostChanged = new MostChanged();
			mostChanged.Get(@"C:\Projects\ClearLaunch\TiffsTreats\onlineordering");
			Assert.IsNotNull(mostChanged);
		}

		[TestMethod]
		public void GetBrittlesNumCommitsTest()
		{
			MostChanged mostChanged = new MostChanged();
			mostChanged.Get(@"C:\Projects\ClearLaunch\TiffsTreats\onlineordering",50);
			Assert.IsNotNull(mostChanged);
		}

		[TestMethod]
		public void GetBrittlesBranchTest()
		{
			MostChanged mostChanged = new MostChanged();
			mostChanged.Get(@"C:\Projects\ClearLaunch\TiffsTreats\onlineordering",50,"master");
			Assert.IsNotNull(mostChanged);
		}


	}
}
