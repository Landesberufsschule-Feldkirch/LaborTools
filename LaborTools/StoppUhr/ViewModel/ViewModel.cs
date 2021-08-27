using StoppUhr.Commands;
using System.Windows.Input;

namespace StoppUhr.ViewModel
{
    public class ViewModel
    {
        public Model.StoppUhr StoppUhr { get; }
        public VisuAnzeigen ViAnz { get; set; }

        public ViewModel()
        {
            StoppUhr = new Model.StoppUhr();
            ViAnz = new VisuAnzeigen(StoppUhr);
        }

        private ICommand _btnTaster;
        // ReSharper disable once UnusedMember.Global
        public ICommand BtnTaster => _btnTaster ??= new RelayCommand(ViAnz.Taster);
    }
}