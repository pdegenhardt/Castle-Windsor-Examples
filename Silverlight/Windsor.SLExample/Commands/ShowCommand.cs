// Copyright 2004-2009 Castle Project - http://www.castleproject.org/
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

using System;
using System.Windows;
using System.Windows.Input;
using Castle.Core;
using Windsor.SLExample.Views;

namespace Windsor.SLExample.Commands
{
    [CastleComponent(typeof(ShowCommand<>), Lifestyle = LifestyleType.Transient)]
    public class ShowCommand<TView> : ICommand where TView : UIElement
    {
        private readonly MainView _mainView;

        public ShowCommand(MainView mainView)
        {
            _mainView = mainView;
        }

        private void Show()
        {
            _mainView.Show<TView>();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Show();
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }
}