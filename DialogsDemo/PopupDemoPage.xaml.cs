
using System.Diagnostics;

namespace DialogsDemo;

public partial class PopupDemoPage : ContentPage
{
	public PopupDemoPage()
	{
		InitializeComponent();
	}

    private async void ShowPopupButton_ClickedAsync(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "You have been alerted", "OK");
    }

    private async void ShowConfirmDeletePopupButton_ClickedAsync(object sender, EventArgs e)
    {
        bool isConfirmed = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this?", "Yes", "No");
        Debug.WriteLine($"Delete item: {isConfirmed}");
    }
}