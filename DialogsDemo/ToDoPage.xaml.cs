using DialogsDemo.Models;

namespace DialogsDemo;

public partial class ToDoPage : ContentPage
{
	public ToDo ToDo { get; set; }
	private Action _updateMethod;

    public ToDoPage(Action updateMethod)
	{
		_updateMethod = updateMethod;
		InitializeComponent();
		ToDo = new ToDo();
	}

	public ToDoPage(Action updateMethod, ToDo toDo)
	{
        _updateMethod = updateMethod;
        InitializeComponent();
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
		_updateMethod();

		// Return control back to parent form 
		await Navigation.PopModalAsync();

    }

}