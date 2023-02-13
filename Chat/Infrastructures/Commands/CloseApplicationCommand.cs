using Chat.Infrastructures.Commands.Base;

using System;
using System.Windows;

namespace Chat.Infrastructures.Commands {
    internal class CloseApplicationCommand : Command {
        public override bool CanExecute ( object? parameter ) => true;
    

        public override void Execute ( object? parameter ) => Application.Current.Shutdown ();
    }
}
