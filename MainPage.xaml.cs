using RaceTo21;
namespace MAUICardsGUI;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NumberPlayers());
        //Program.StartGame();
    }
}
