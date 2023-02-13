using Chat.ViewsModels.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.ViewsModels {
    internal class MainWindowViewModels:ViewModel {

        private string _Title = "Chat Vizavi";

        public string Title {
            get => _Title;
            set => Set ( ref _Title,  value );
        }
    }
}
