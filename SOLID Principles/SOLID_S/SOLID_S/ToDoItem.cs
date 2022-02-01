public class ToDoItem
{
    public string Name { get; set; }
    public bool Completed { get; set; }

    public ToDoItem(string name)
    {
        Name = name;
        Completed = false;
    }

    public override string ToString()
    {
        var completed = Completed ? "complete" : "not complete";
        return $"{Name} is {completed} ?";
    }
}