using hotel.Models;

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

        var checkinDT = dtpck_checkin.Date!.Value;

        dtpck_checkout.MinimumDate = checkinDT.AddDays(1);
        dtpck_checkout.MaximumDate = checkinDT.AddMonths(6);

    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime dataCheckinDT = e.NewDate!.Value;

        dtpck_checkout.MinimumDate = dataCheckinDT.AddDays(1);
        dtpck_checkout.MaximumDate = dataCheckinDT.AddMonths(6);
    }



    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {

            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date!.Value,
                DataCheckOut = dtpck_checkout.Date!.Value,
            };



            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}