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
        toDos?.Add(toDoPage.ToDo);
    }


    private async void ToDoListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
    {
        //if (e.SelectedItem is ToDo) <--Not needed all items in listview are todo items.
        //{
            ToDo item = (ToDo) e.SelectedItem; //Unbox (cast) to original type
            toDoPage = new ToDoPage(UpdateToDoItem, DeleteToDoItem, item);
            await Navigation.PushModalAsync(toDoPage);
        //}
    }

    public void UpdateToDoItem()
    {
        //Refresh the list view, the item has already been modified
        ToDoListView.ItemsSource = null;
        ToDoListView.ItemsSource = toDos;
    }

    public void DeleteToDoItem()
    {
        if (toDoPage.ToDo != null)
        {
            toDos?.Remove(toDoPage.ToDo);
        }
    }



}