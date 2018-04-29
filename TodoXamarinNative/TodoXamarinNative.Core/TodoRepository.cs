using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoXamarinNative.Core
{
    public class TodoRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public TodoRepository(string databaseFilePath)
        {
            _database = new SQLiteAsyncConnection(databaseFilePath);
            _database.CreateTableAsync<TodoItem>().Wait();
        }

        private List<TodoItem> _seedTodoList = new List<TodoItem>
        {
            new TodoItem { Title = "Create First Todo", IsCompleted = true},
            new TodoItem { Title = "Run a Marathon"},
            new TodoItem { Title = "Create TodoXamarinNative blog post"},
        };

        public async Task<List<TodoItem>> GetList()
        {
            if ((await _database.Table<TodoItem>().CountAsync() == 0))
            {
                await _database.InsertAllAsync(_seedTodoList);
            }

            return await _database.Table<TodoItem>().ToListAsync();
        }

        public Task DeleteItem(TodoItem itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete);
        }

        public Task ChangeItemIsCompleted(TodoItem itemToChange)
        {
            itemToChange.IsCompleted = !itemToChange.IsCompleted;
            return _database.UpdateAsync(itemToChange);
        }

        public Task AddItem(TodoItem itemToAdd)
        {
            return _database.InsertAsync(itemToAdd);
        }
    }
}
