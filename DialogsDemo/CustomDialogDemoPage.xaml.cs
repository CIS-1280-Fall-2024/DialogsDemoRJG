using DialogsDemo.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DialogsDemo;

public partial class CustomDialogDemoPage : ContentPage
{
	ObservableCollection<ToDo>? toDos;
    ToDoPage toDoPage;

    public CustomDialogDemoPage()
	{
		InitializeComponent();
		toDos = new ObservableCollection<ToDo>();
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


    private async void AddTodoItem_Clicked(object sender, EventArgs e)
    {
        toDoPage = new ToDoPage(AddTodoItem);
        await Navigation.PushModalAsync(toDoPage); //<-- How do we access this in UpdateToDoList?
    }

    public void AddTodoItem()
    {
        //TODO: Get access to the ToDo property in the ToDoPage here.
        ToDo toDo = toDoPage.ToDo;
        toDos.Add(toDo);
        Debug.WriteLine($"Added new ToDo item {toDo.Title} to list.");
    }

    public void UpdateToDoItem()
    {
        ToDoListView.ItemsSource = null;
        ToDoListView.ItemsSource = toDos;
    }

    public void DeleteToDoItem()
    {
        if (item != null)
        {
            toDos?.Remove(item);
        }
    }

    ToDo? item;

    private async void ToDoListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
    {
        item = (ToDo) e.SelectedItem; //Unbox (cast) to original type
        toDoPage = new ToDoPage(UpdateToDoItem, DeleteToDoItem, item);
        await Navigation.PushModalAsync(toDoPage);
    }

}