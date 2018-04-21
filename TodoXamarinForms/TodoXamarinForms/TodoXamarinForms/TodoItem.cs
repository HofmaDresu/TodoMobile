using SQLite;

namespace TodoXamarinForms
{
    public class TodoItem : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } 
    }
}
