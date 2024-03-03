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
        Navigation.PushAsync(new NumberPlayers()); // when button is pushed, it will go to the next page that will ask for number of players
    }
}
