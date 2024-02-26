namespace MAUICardsGUI;

public partial class NamePage : ContentPage
{
	public NamePage()
	{
		InitializeComponent();
	}

    private void IntroduceNameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TotalWinningScore());

    }
}