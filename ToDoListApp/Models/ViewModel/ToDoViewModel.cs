namespace ToDoListApp.Models.ViewModel
{
    public class ToDoViewModel
    {
        public List<ToDo> ToDoList { get; set; } = new List<ToDo>();

        public ToDo ToDo { get; set; } = new ToDo();
    }
}
