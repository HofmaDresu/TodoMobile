using System;
using System.Collections.Generic;

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

        public List<TodoItem> GetList()
        {
            return _todoList;
        }

        public void DeleteItem(TodoItem itemToDelete)
        {
            _todoList.Remove(itemToDelete);
        }

        public void ChangeItemIsCompleted(TodoItem itemToChange)
        {
            itemToChange.IsCompleted = !itemToChange.IsCompleted;
        }

        public void AddItem(TodoItem itemToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
