using System;
using System.Linq;
using GitStats.Lib;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetStats.Lib.Test
{
	[TestClass]
	public class ResolverTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var res = Resolver.Instance.Container.ResolveAll<IGetStats>();
			Assert.IsNotNull(res);
			Assert.IsTrue(res.Count() > 1);
		}

		[TestMethod]
		public void TestRun()
		{
			var res = Resolver.Instance.Container.Resolve<IGetStatsCollection>();
			res.ForEach(x => x.Get(@"C:\Projects\ClearLaunch\TiffsTreats\onlineordering", 50, "master"));
		}
	}
}
