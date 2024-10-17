using System.Diagnostics;

namespace DialogsDemo;

public partial class ActionSheetDemoPage : ContentPage
{
	public ActionSheetDemoPage()
	{
		InitializeComponent();
    }

    private async void ActionSheetDemoButton_ClickedAsync(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
        Debug.WriteLine("Action: " + action);
    }

    private async void ActionSheetWithDestroyDemoButton_ClickedAsync(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("ActionSheet: SavePhoto?", "Cancel", "Delete", "Photo Roll", "Email");
        Debug.WriteLine("Action: " + action);
    }
}