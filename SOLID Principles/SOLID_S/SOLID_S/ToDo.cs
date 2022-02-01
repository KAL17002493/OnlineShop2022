public class ToDo
{ 
    List<ToDoItem> ToDoList = new List<ToDoItem>();

    public string Name { get; set; }
    public bool Completed { get; set; }

    public ToDo(string name)
    {
        Name = name;
        Completed = false;
    }

    public override string ToString()
    {
        return String.Join("\n", ToDoList);
    }
}
