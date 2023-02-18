using Chat.Infrastructures.Commands;
using Chat.Models;
using Chat.Models.Decanat;
using Chat.ViewsModels.Base;

using OxyPlot;
using OxyPlot.Series;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chat.ViewsModels {
    internal class MainWindowViewModel : ViewModel {

        /*-----------------------------------------------------------------------------*/
        #region Decanat

        public ObservableCollection<Group> Groups { get; }

        private Group _SelectGroup;

        public Group SelectGroup {
            get => _SelectGroup;
            set => Set (ref _SelectGroup, value);
        }

        #endregion

        #region  Tab control

        private int _SelectTabIndex = 2;

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

        /*-----------------------------------------------------------------------------*/

        #region Commands


        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
       

        private bool CanCloseApplicationCommanExecute ( object p ) => true;

        private void OnCloseApplicationCommanExecute ( object p ) {
            Application.Current.Shutdown ();
        }
        #endregion

        #endregion

        /*-----------------------------------------------------------------------------*/
        public MainWindowViewModel () {

            #region Commands

            #region CloseApplicationCommand
            CloseApplicationCommand = new LambdaCommand ( OnCloseApplicationCommanExecute, CanCloseApplicationCommanExecute );
            #endregion

            #endregion

            #region  Test data constructor
            
            var tmp_data = new PlotModel{ Title="Cosines",Subtitle="Test input data", PlotAreaBackground=OxyColor.FromRgb(255,255,255)};
            var series = new LineSeries {Title="", MarkerType=MarkerType.Cross, BrokenLineColor=OxyColor.FromRgb(254,0,0)};
            // var data_point = new List<Models.DataPoint> ((int)(360 / 0.1));
            for ( var x = 0d; x <= 360; x += 0.1 ) {

                const double to_rad = Math.PI/180;
                var y = Math.Cos( x * to_rad );
                // data_point.Add ( new Models.DataPoint { XValue = x, YValue = y } );
                series.Points.Add ( new OxyPlot.DataPoint ( x, y ) );

            }
            tmp_data.Series.Add ( series );
            // TestDataPoints = data_point;
            this.Model = tmp_data;
            #endregion

            #region

            var student_index = 1;
            var studens = Enumerable.Range(1,10).Select(s => new Student{
                Name = $"Name {student_index} ",
                SurName = $"SurName {student_index} ",
                Patronymic = $"Patronymic {student_index++} ",
                Birthday = DateTime.Now,
                Rating= 0
            });

            var groups = Enumerable.Range( 1, 20 ).Select(i => new Group{
                Name = $"Group  {i}",
                Students = new ObservableCollection<Student>(studens)
            });
            Groups = new ObservableCollection<Group>(groups);

            #endregion

        }

        /*-----------------------------------------------------------------------------*/
    }
}
