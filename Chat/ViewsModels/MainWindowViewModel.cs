using Chat.Infrastructures.Commands;
using Chat.ViewsModels.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chat.ViewsModels {
    internal class MainWindowViewModel:ViewModel {

        private string _Title = "Chat Vizavi";

        public string Title {
            get => _Title;
            set => Set ( ref _Title,  value );
        }

        private string? _Status = "Ready";

        public string Status {
            get => _Status;
            set => Set ( ref _Status, value );
        }

        #region Commands


        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }


        private bool CanCloseApplicationCommanExecute ( object p ) => true;

        private void OnCloseApplicationCommanExecute ( object p ) {
            Application.Current.Shutdown ();
        }
        #endregion

        #endregion
        public MainWindowViewModel () {

            #region Commands

            #region CloseApplicationCommand
            CloseApplicationCommand = new LambdaCommand ( OnCloseApplicationCommanExecute, CanCloseApplicationCommanExecute );
            #endregion

            #endregion
        }
    }
}
