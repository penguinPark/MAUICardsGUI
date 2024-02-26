namespace MAUICardsGUI;

public partial class TotalWinningScore : ContentPage
{
	public TotalWinningScore()
	{
		InitializeComponent();
	}

    private void TotalWinningScoreButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}