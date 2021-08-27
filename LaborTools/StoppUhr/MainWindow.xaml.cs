namespace StoppUhr
{
    public partial class MainWindow
    {
        public readonly ViewModel.ViewModel ViewModel;
        public MainWindow()
        {
            ViewModel = new ViewModel.ViewModel();

            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}