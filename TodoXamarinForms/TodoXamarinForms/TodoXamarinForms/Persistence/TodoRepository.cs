using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoXamarinForms.Persistence
{
    public class TodoRepository
    {
        private List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem { Id = 0, Title = "Create First Todo", IsCompleted = true},
            new TodoItem { Id = 1, Title = "Run a Marathon"},
            new TodoItem { Id = 2, Title = "Create TodoXamarinForms blog post"},
        };

        public Task<List<TodoItem>> GetList()
        {
            return Task.FromResult(_todoList);
        }

        public Task DeleteItem(TodoItem itemToDelete)
        {
            _todoList.Remove(itemToDelete);
            return Task.Delay(100);
        }

        public Task ChangeItemIsCompleted(TodoItem itemToChange)
        {
            itemToChange.IsCompleted = !itemToChange.IsCompleted;
            return Task.Delay(100);
        }

        public Task AddItem(TodoItem itemToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
