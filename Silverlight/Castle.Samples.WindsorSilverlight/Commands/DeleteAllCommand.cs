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

namespace Castle.Samples.WindsorSilverlight.Commands
{
	using System;
	using System.Windows.Input;

	using Castle.Core;
	using Castle.Samples.WindsorSilverlight.Security;
	using Castle.Samples.WindsorSilverlight.Services;

	[CastleComponent(typeof(DeleteAllCommand), Lifestyle = LifestyleType.Transient)]
	public class DeleteAllCommand : ICommand
	{
		private readonly IStatusService statusService;

		public DeleteAllCommand(IStatusService statusService)
		{
			this.statusService = statusService;
		}

		#region ICommand Members

		public virtual bool CanExecute(object parameter)
		{
			return true;
		}

		[Authorize(Role = "SuperUser")]
		public virtual void Execute(object parameter)
		{
			//administrative level entry only.
			//do your crazy stuff in here.
			statusService.ShowMessage("Command executed successfully.");
		}

		public event EventHandler CanExecuteChanged;

		#endregion
	}
}