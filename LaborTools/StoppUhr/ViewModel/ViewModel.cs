using System.Windows.Input;
using StoppUhr.Commands;

namespace StoppUhr.ViewModel
{
    public class ViewModel
    {
        public Model.StoppUhr StoppUhr { get; }
        public VisuAnzeigen ViAnz { get; set; }

        public ViewModel(MainWindow mainWindow)
        {
            StoppUhr = new Model.StoppUhr();
            ViAnz = new VisuAnzeigen(mainWindow, StoppUhr);
        }

        private ICommand _btnTaster;
        // ReSharper disable once UnusedMember.Global
        public ICommand BtnTaster => _btnTaster ??= new RelayCommand(ViAnz.Taster);
    }
}