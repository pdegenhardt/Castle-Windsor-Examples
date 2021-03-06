// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Samples.WindsorSilverlight.Installers
{
	using Castle.Facilities.TypedFactory;
	using Castle.MicroKernel.Registration;
	using Castle.MicroKernel.SubSystems.Configuration;
	using Castle.Samples.WindsorSilverlight.Factories;
	using Castle.Samples.WindsorSilverlight.Services;
	using Castle.Samples.WindsorSilverlight.Services.Impl;
	using Castle.Windsor;

	public class ServiceInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			//Register using Service / Impl style using default lifestyle (singleton)
			//Each customer may override the default lifestyle using an attribute (see Customer Factory)
			container.AddFacility<TypedFactoryFacility>();
			container.Register(Component.For<ICustomerRepository>()
			                   	.ImplementedBy<CustomerRepository>()
			                   	.DependsOn(Property.ForKey("serviceUri")
			                   	           	.Eq("Fake service Uri for fake repository, but you get the idea")),
			                   Component.For<IModelFactory>()
			                   	.AsFactory());
		}

		#endregion
	}
}