using DialogsDemo.Models;

namespace DialogsDemo;

public partial class ToDoPage : ContentPage
{
	public ToDo? ToDo { get; set; }

	public ToDoPage()
	{
		ToDo = new ToDo();
		InitializeComponent();
	}
}