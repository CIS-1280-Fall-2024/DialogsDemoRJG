using System.Diagnostics;

namespace DialogsDemo;

public partial class DisplayPromptDemoPage : ContentPage
{
	public DisplayPromptDemoPage()
	{
		InitializeComponent();
    }

    private async void DisplayPromptButton_ClickedAsync(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Question 1", "What's your name?");
        Debug.WriteLine($"Name is {result}");
    }

    private async void DisplayNumericPromptButton_ClickedAsync(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Question 2", "What's 5 + 5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
        Debug.WriteLine($"User's answer is {result}");
    }
}