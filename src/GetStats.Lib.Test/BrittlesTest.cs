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
			Brittles brittles = new Brittles(@"C:\Projects\ClearLaunch\TiffsTreats\onlineordering");
			Assert.IsNotNull(brittles);
		}

		[TestMethod]
		public void GetBrittlesDefaultTest()
		{
			Brittles brittles = new Brittles(@"C:\Projects\ClearLaunch\TiffsTreats\onlineordering");
			brittles.GetBrittles();
			Assert.IsNotNull(brittles);
		}

		[TestMethod]
		public void GetBrittlesNumCommitsTest()
		{
			Brittles brittles = new Brittles(@"C:\Projects\ClearLaunch\TiffsTreats\onlineordering");
			brittles.GetBrittles(50);
			Assert.IsNotNull(brittles);
		}

		[TestMethod]
		public void GetBrittlesBranchTest()
		{
			Brittles brittles = new Brittles(@"C:\Projects\ClearLaunch\TiffsTreats\onlineordering");
			brittles.GetBrittles(50,"master");
			Assert.IsNotNull(brittles);
		}


	}
}
