using DialogsDemo.Models;
using System.Diagnostics;

namespace DialogsDemo;

public partial class CustomDialogDemoPage : ContentPage
{
	List<ToDo>? toDos;

	public CustomDialogDemoPage()
	{
		InitializeComponent();
		toDos = new List<ToDo>();
		toDos.Add(new ToDo()
			{
				Title = "Go shopping",
				Description = "Eggs, toast, juice",
				DateCreated = DateTime.Now
			}
		);

        toDos.Add(new ToDo()
        {
            Title = "Oil Change",
            Description = "100000000000 miles",
            DateCreated = DateTime.Now
        }
        );

        toDos.Add(new ToDo()
        {
            Title = "Clean Work shop",
            Description = "Safety first! Or at least in the top five.",
            DateCreated = DateTime.Now
        }
        );
        ToDoListView.ItemsSource = toDos;
	}

    private async void ShowCustomDialogButton_ClickedAsync(object sender, EventArgs e)
    {
        ToDo item = new ToDo();
        await Navigation.PushModalAsync(new ToDoPage(UpdateToDoList)); //<-- How do we access this in UpdateToDoList?
        Debug.WriteLine($"New todo is {item.Title}");
    }

    public void UpdateToDoList()
    {
        //TODO: Get access to the ToDo property in the ToDoPage here.
        Debug.WriteLine($"UpdateToDoList called");
    }
}