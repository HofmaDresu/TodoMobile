using SQLite;

namespace TodoXamarinNative.Core
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
