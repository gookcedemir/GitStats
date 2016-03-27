using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace GitStats.Lib
{
	public class Resolver
	{
		private IUnityContainer container;
		public static Resolver Instance { get; } = new Resolver();

		private Resolver()
		{
			Init();
		}

		public IUnityContainer Container => this.container;

		private void Init()
		{
			container = new UnityContainer();
			Register(container);
		}

		private IUnityContainer Register(IUnityContainer unityContainer)
		{
			unityContainer.RegisterType<IMostChanged, MostChanged>();
			unityContainer.RegisterType<IMostChanges, MostChanges>();

			var statsCollection = new GetStatsCollection();
			statsCollection.Add(unityContainer.Resolve<IMostChanged>());
			statsCollection.Add(unityContainer.Resolve<IMostChanges>());

			unityContainer.RegisterInstance<IGetStatsCollection>(statsCollection);

			return unityContainer;
		}

		private void Reset()
		{
			this.Init();
		}
	}
}
