namespace HesapMakinesi;

public partial class StandartPage : ContentPage
{
   
    double ilkSayi = 0;
    string aktifIslem = "";
    bool yeniSayiGiris = true;

    public StandartPage()
    {
        InitializeComponent();
    }

    private void Rakam_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        
        if (SonucEkran.Text == "Hata")
            SonucEkran.Text = "0";

        if (yeniSayiGiris)
        {
            SonucEkran.Text = btn.Text == "," ? "0," : btn.Text;
            yeniSayiGiris = false;
        }
        else
        {
            if (btn.Text == "," && SonucEkran.Text.Contains(",")) return;
            SonucEkran.Text += btn.Text;
        }
    }

    private void Islem_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (double.TryParse(SonucEkran.Text, out ilkSayi))
        {
            aktifIslem = btn.Text;
            yeniSayiGiris = true;
        }
    }

    private void Esittir_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(SonucEkran.Text, out double ikinciSayi))
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
                    _ => ikinciSayi
                };
                SonucEkran.Text = sonuc.ToString();
            }
            catch (DivideByZeroException)
            {
             
                SonucEkran.Text = "Hata"; 
            }
            
            yeniSayiGiris = true;
            aktifIslem = "";
        }
    }

    private void Temizle_Clicked(object sender, EventArgs e)
    {
        SonucEkran.Text = "0";
        ilkSayi = 0;
        aktifIslem = "";
        yeniSayiGiris = true;
    }

    private void Sil_Clicked(object sender, EventArgs e)
    {
        if (SonucEkran.Text.Length > 1 && !yeniSayiGiris && SonucEkran.Text != "Hata")
            SonucEkran.Text = SonucEkran.Text.Remove(SonucEkran.Text.Length - 1);
        else
            SonucEkran.Text = "0";
    }

    private void IsaretDegistir_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(SonucEkran.Text, out double sayi) && sayi != 0)
        {
            sayi *= -1;
            SonucEkran.Text = sayi.ToString();
        }
    }
}