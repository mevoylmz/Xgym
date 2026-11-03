namespace HesapMakinesi;

public partial class BilimselPage : ContentPage
{
    double ilkSayi = 0;
    string aktifIslem = "";
    bool yeniSayiGiris = true;

    public BilimselPage()
    {
        InitializeComponent();
    }

    private void Rakam_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        if (BilimselEkran.Text == "Hata")
            BilimselEkran.Text = "0";

        if (yeniSayiGiris)
        {
            BilimselEkran.Text = btn.Text == "," ? "0," : btn.Text;
            yeniSayiGiris = false;
        }
        else
        {
            if (btn.Text == "," && BilimselEkran.Text.Contains(",")) return;
            BilimselEkran.Text += btn.Text;
        }
    }

    private void Islem_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (double.TryParse(BilimselEkran.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out ilkSayi))
        {
            aktifIslem = btn.Text;
            yeniSayiGiris = true;
        }
    }

    private void BilimselIslem_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (double.TryParse(BilimselEkran.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out double sayi))
        {
            double sonuc = 0;
            try
            {
                sonuc = btn.Text switch
                {
                    "x²" => Math.Pow(sayi, 2),
                    "√" => sayi >= 0 ? Math.Sqrt(sayi) : throw new ArgumentException(),
                    "log" => sayi > 0 ? Math.Log10(sayi) : throw new ArgumentException(),
                    "ln" => sayi > 0 ? Math.Log(sayi) : throw new ArgumentException(),
                    "sin" => Math.Sin(sayi * Math.PI / 180), 
                    "cos" => Math.Cos(sayi * Math.PI / 180),
                    "tan" => Math.Tan(sayi * Math.PI / 180),
                    _ => sayi
                };
                BilimselEkran.Text = sonuc.ToString().Replace('.', ',');
            }
            catch
            {
                BilimselEkran.Text = "Hata";
            }
            yeniSayiGiris = true;
        }
    }

    private void Sabit_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (btn.Text == "π")
            BilimselEkran.Text = Math.PI.ToString().Replace('.', ',');
        else if (btn.Text == "e")
            BilimselEkran.Text = Math.E.ToString().Replace('.', ',');

        yeniSayiGiris = true;
    }

    private void Esittir_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(BilimselEkran.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out double ikinciSayi))
        {
            double sonuc = 0;
            try
            {
                sonuc = aktifIslem switch
                {
                    "+" => ilkSayi + ikinciSayi,
                    "-" => ilkSayi - ikinciSayi,
                    "*" => ilkSayi * ikinciSayi,
                    "/" => ikinciSayi != 0 ? ilkSayi / ikinciSayi : throw new DivideByZeroException(),
                    "x^y" => Math.Pow(ilkSayi, ikinciSayi),
                    _ => ikinciSayi
                };
                BilimselEkran.Text = sonuc.ToString().Replace('.', ',');
            }
            catch
            {
                BilimselEkran.Text = "Hata";
            }

            yeniSayiGiris = true;
            aktifIslem = "";
        }
    }

    private void Temizle_Clicked(object sender, EventArgs e)
    {
        BilimselEkran.Text = "0";
        ilkSayi = 0;
        aktifIslem = "";
        yeniSayiGiris = true;
    }

    private void Sil_Clicked(object sender, EventArgs e)
    {
        if (BilimselEkran.Text.Length > 1 && !yeniSayiGiris && BilimselEkran.Text != "Hata")
            BilimselEkran.Text = BilimselEkran.Text.Remove(BilimselEkran.Text.Length - 1);
        else
            BilimselEkran.Text = "0";
    }

    private void IsaretDegistir_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(BilimselEkran.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out double sayi) && sayi != 0)
        {
            sayi *= -1;
            BilimselEkran.Text = sayi.ToString().Replace('.', ',');
        }
    }
}