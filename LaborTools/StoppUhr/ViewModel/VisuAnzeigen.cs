using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace StoppUhr.ViewModel
{
    public class VisuAnzeigen : INotifyPropertyChanged
    {
        private readonly Model.StoppUhr _stoppUhr;


        public VisuAnzeigen(Model.StoppUhr stoppUhr)
        {
            _stoppUhr = stoppUhr;

            for (var i = 0; i < 100; i++)
            {
                ButtonEnabled.Add(false);
                SichtbarEin.Add(Visibility.Visible);
            }

            CountDownAnzeige = 1;
            ZykluszeitText = "-";

            SichtbarEin[3] = Visibility.Collapsed;
            SichtbarEin[10] = Visibility.Collapsed;

            System.Threading.Tasks.Task.Run(VisuAnzeigenTask);
        }

        private void VisuAnzeigenTask()
        {
            while (true)
            {
                SichtbarEin[10] = _stoppUhr.ModusStoppUhr == Model.StoppUhr.Modusstoppuhr.CountDown ? Visibility.Visible : Visibility.Hidden;

                Thread.Sleep(10);
            }

            // ReSharper disable once FunctionNeverReturns
        }

        internal void Taster(object id)
        {
            if (id is not string str) return;

            switch (str)
            {
                case "CountDown":
                    _stoppUhr.ModusStoppUhr = Model.StoppUhr.Modusstoppuhr.CountDown;
                    _stoppUhr.CountDownZaehler = 3;
                    _stoppUhr.Startzeit = DateTime.Now;
                    SichtbarEin[0] = Visibility.Collapsed;
                    SichtbarEin[1] = Visibility.Collapsed;
                    SichtbarEin[2] = Visibility.Collapsed;
                    SichtbarEin[3] = Visibility.Visible;
                    SichtbarEin[20] = Visibility.Collapsed;
                    ButtonEnabled[3] = true;
                    break;
                case "Start":
                    _stoppUhr.ModusStoppUhr = Model.StoppUhr.Modusstoppuhr.Aktiv;
                    _stoppUhr.CountDownZaehler = 0;
                    _stoppUhr.Startzeit = DateTime.Now;
                    SichtbarEin[0] = Visibility.Collapsed;
                    SichtbarEin[1] = Visibility.Collapsed;
                    SichtbarEin[2] = Visibility.Collapsed;
                    SichtbarEin[3] = Visibility.Visible;
                    SichtbarEin[20] = Visibility.Collapsed;
                    ButtonEnabled[3] = true;
                    break;
                case "Stop":
                    _stoppUhr.ModusStoppUhr = Model.StoppUhr.Modusstoppuhr.Stop;
                    SichtbarEin[0] = Visibility.Visible;
                    SichtbarEin[1] = Visibility.Visible;
                    SichtbarEin[2] = Visibility.Visible;
                    SichtbarEin[3] = Visibility.Collapsed;
                    SichtbarEin[20] = Visibility.Visible;
                    break;
                case "Reset":
                    _stoppUhr.ModusStoppUhr = Model.StoppUhr.Modusstoppuhr.Stop;
                    _stoppUhr.ZyklusZeit = 0;
                    ZykluszeitText = "-";
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(id));
            }
        }
        
        private string _zykluszeitText;
        public string ZykluszeitText
        {
            get => _zykluszeitText;
            set
            {
                int.TryParse(value, out _stoppUhr.ZyklusZeit);
                _zykluszeitText = value;
                OnPropertyChanged(nameof(ZykluszeitText));

                if (_stoppUhr.ZyklusZeit > 0)
                {
                    ButtonEnabled[0] = true;
                    ButtonEnabled[1] = true;
                    ButtonEnabled[2] = true;
                }
                else
                {
                    ButtonEnabled[0] = false;
                    ButtonEnabled[1] = false;
                    ButtonEnabled[2] = false;
                }
            }
        }

        private int _countDownAnzeige;
        public int CountDownAnzeige
        {
            get => _countDownAnzeige;
            set
            {
                _countDownAnzeige = value;
                OnPropertyChanged(nameof(CountDownAnzeige));
            }
        }

        private ObservableCollection<bool> _buttonEnabled = new();
        public ObservableCollection<bool> ButtonEnabled
        {
            get => _buttonEnabled;
            set
            {
                _buttonEnabled = value;
                OnPropertyChanged(nameof(ButtonEnabled));
            }
        }

        private ObservableCollection<Visibility> _sichtbarEin = new();
        public ObservableCollection<Visibility> SichtbarEin
        {
            get => _sichtbarEin;
            set
            {
                _sichtbarEin = value;
                OnPropertyChanged(nameof(SichtbarEin));
            }
        }

        #region iNotifyPeropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion iNotifyPeropertyChanged Members
    }
}