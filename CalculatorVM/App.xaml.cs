
namespace CalculatorVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);
            window.MinimumWidth = 375;
            window.MinimumHeight = 620;
            window.Width = window.MinimumWidth;
            window.Height = window.MinimumHeight;
            return window;
        }
    }
}