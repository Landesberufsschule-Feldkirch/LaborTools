using System;
using System.ComponentModel;
using System.Threading;

namespace StoppUhr.ViewModel
{
    public class VisuAnzeigen : INotifyPropertyChanged
    {
        private readonly Model.StoppUhr _stoppUhr;
        private readonly MainWindow _mainWindow;

        public VisuAnzeigen(MainWindow mw, Model.StoppUhr stoppUhr)
        {
            _mainWindow = mw;


            System.Threading.Tasks.Task.Run(VisuAnzeigenTask);
        }

        internal void Taster(object obj)
        {
            throw new NotImplementedException();
        }

        private void VisuAnzeigenTask()
        {
            while (true)
            {
               

                Thread.Sleep(10);
            }

            // ReSharper disable once FunctionNeverReturns
        }

        internal void Schalter(object obj)
        {
            throw new NotImplementedException();
        }


        #region iNotifyPeropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion iNotifyPeropertyChanged Members
    }
}