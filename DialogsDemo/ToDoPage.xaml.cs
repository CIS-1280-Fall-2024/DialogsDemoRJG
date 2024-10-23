using DialogsDemo.Models;

namespace DialogsDemo;

public partial class ToDoPage : ContentPage
{
	public ToDo ToDo { get; set; }
	private Action _submitMethod;
	private Action? _deleteMethod;

    public ToDoPage(Action submitMethod)
	{
		_submitMethod = submitMethod;
		InitializeComponent();
		ToDo = new ToDo();
	}

	public ToDoPage(Action submitMethod, Action deleteMethod, ToDo toDo)
	{
        _submitMethod = submitMethod;
        _deleteMethod = deleteMethod;
        InitializeComponent();
		DeleteButton.IsVisible = true;
        ToDo = toDo;
		TitleEntry.Text = toDo.Title;
		DescriptionEntry.Text = toDo.Description;
		DateCreatedPicker.Date = toDo.DateCreated;
		if (toDo.DateCompleted != null)
		{
			DateCompletedPicker.Date = (DateTime) toDo.DateCompleted;
		}
    }

    private async void SubmitToDoButton_Clicked(object sender, EventArgs e)
    {
		// Load model object from form controls
		ToDo.Title = TitleEntry.Text;
		ToDo.Description = DescriptionEntry.Text;
		ToDo.DateCreated = DateCreatedPicker.Date;
		ToDo.DateCompleted = DateCompletedPicker.Date;

		// Update the parent form
		_submitMethod();

		// Return control back to parent form 
		await Navigation.PopModalAsync();
    }

    private async void CancelButton_ClickedAsync(object sender, EventArgs e)
    {
        // Return control back to parent form 
        await Navigation.PopModalAsync();
    }

    private async void DeleteButton_ClickedAsync(object sender, EventArgs e)
    {
		if (_deleteMethod != null)
		{
			//Delete item
			_deleteMethod();

			// Return control back to parent form 
			await Navigation.PopModalAsync();
		}
    }
}