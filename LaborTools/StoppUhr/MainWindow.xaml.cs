namespace StoppUhr
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            var viewModel = new ViewModel.ViewModel(this);

            InitializeComponent();
        }
    }
}
