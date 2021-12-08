namespace TodoListApp.Models
{
    public class TodoItemModel
    {
        public int Id { get; set; }

        private static int IdCounter = 0;
        public string Name { get; set; }
        public string Description { get; set; }

        public TodoItemModel()
        {
            Id = ++IdCounter;
        }
    }
}
