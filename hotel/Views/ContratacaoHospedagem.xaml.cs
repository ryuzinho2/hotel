namespace hotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(1);

        var checkinDT = dtpck_checkin.Date.GetValueOrDefault(DateTime.Now);

        dtpck_checkout.MinimumDate = checkinDT.AddDays(1);
        dtpck_checkout.MaximumDate = checkinDT.AddMonths(6);
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime dataCheckinDT = e.NewDate.GetValueOrDefault(DateTime.Now);

        dtpck_checkout.MinimumDate = dataCheckinDT.AddDays(1);
        dtpck_checkout.MaximumDate = dataCheckinDT.AddMonths(6);
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}