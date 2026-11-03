namespace HesapMakinesi;

public partial class AyarlarPage : ContentPage
{
    public AyarlarPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        TemaPicker.SelectedItem = Preferences.Default.Get("tema", "Sistem");
    }

    private void TemaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TemaPicker.SelectedItem is string secim)
        {
            Application.Current.UserAppTheme = secim switch
            {
                "Açık" => AppTheme.Light,
                "Koyu" => AppTheme.Dark,
                _ => AppTheme.Unspecified
            };
            Preferences.Default.Set("tema", secim);
        }
    }
}