namespace HesapMakinesi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Kayıtlı temayı al, yoksa "Sistem" varsayılan olsun
            var tema = Preferences.Default.Get("tema", "Sistem");
            Application.Current.UserAppTheme = tema switch
            {
                "Açık" => AppTheme.Light,
                "Koyu" => AppTheme.Dark,
                _ => AppTheme.Unspecified
            };
        }

        // MainPage yerine artık yeni standart olan CreateWindow kullanıyoruz
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}