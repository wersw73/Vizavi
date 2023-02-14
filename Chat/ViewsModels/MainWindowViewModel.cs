using Chat.Infrastructures.Commands;
using Chat.Models;
using Chat.ViewsModels.Base;

using OxyPlot;
using OxyPlot.Series;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chat.ViewsModels {
    internal class MainWindowViewModel : ViewModel {

        #region  Tab control

        private int _SelectTabIndex = 1;

        public int SelectTabIndex {
            get => _SelectTabIndex;
            set => Set ( ref _SelectTabIndex, value );
        }

        #endregion

        #region   Plotting data

        //private IEnumerable<Models.DataPoint>  _TestDataPoints;

        // public IEnumerable<Models.DataPoint> TestDataPoints {
        //     get => _TestDataPoints;
        //     set => Set ( ref _TestDataPoints, value );
        // }

        public PlotModel Model { get; private set; }

        #endregion

        #region Title
        private string _Title = "Chat Vizavi";

        public string Title {
            get => _Title;
            set => Set ( ref _Title, value );
        }
        #endregion

        #region Status
        private string? _Status = "Ready";

        public string Status {
            get => _Status;
            set => Set ( ref _Status, value );
        }
        #endregion

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

            #region  Test data constructor
            var tmp = new PlotModel{ Title="Cosines",Subtitle=""};
            var series = new LineSeries {Title="", MarkerType=MarkerType.Cross};
            // var data_point = new List<Models.DataPoint> ((int)(360 / 0.1));
            for ( var x = 0d; x <= 360; x += 0.1 ) {

                const double to_rad = Math.PI/180;
                var y = Math.Cos( x * to_rad );
                // data_point.Add ( new Models.DataPoint { XValue = x, YValue = y } );
                series.Points.Add ( new OxyPlot.DataPoint ( x, y ) );

            }
            tmp.Series.Add ( series );
            // TestDataPoints = data_point;
            this.Model = tmp;
            #endregion
        }
    }
}
