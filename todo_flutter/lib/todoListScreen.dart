import 'package:flutter/material.dart';
import 'todoItem.dart';
import 'dart:async';

class TodoListScreen extends StatefulWidget {
  TodoListScreen({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _TodoListScreenState createState() => new _TodoListScreenState();
}

class _TodoListScreenState extends State<TodoListScreen> {
  List<TodoItem> _todoItems = List();

  @override
  initState() {
    super.initState();
    // TODO use dynamic todo items
    _todoItems.add(TodoItem(id: 0, name: "Create First Todo", isComplete: true));
    _todoItems.add(TodoItem(id: 1, name: "Run a Marathon"));
    _todoItems.add(TodoItem(id: 2, name: "Create Todo_Flutter blog post"));
  }

  void _addTodoItem() {
    // TODO navigate to Create Todo Item Screen
  }

  void _updateTodoCompleteStatus(TodoItem item, bool newStatus) {
    final tempTodoItems = _todoItems;
    tempTodoItems.firstWhere((i) => i.id ==item.id).isComplete = newStatus;
    setState(() { _todoItems = tempTodoItems; });
    // TODO: Persist change
  }

  void _deleteTodoItem(TodoItem item) {
    final tempTodoItems = _todoItems;
    tempTodoItems.remove(item);
    setState(() { _todoItems = tempTodoItems; });
    // TODO: Persist change
  }

  Future<Null> _displayDeleteConfirmationDialog(TodoItem item) {
    return showDialog<Null>(
      context: context,
      barrierDismissible: true, // Allow dismiss when tapping away from dialog
      builder: (BuildContext context) {
        return  AlertDialog(
          title: Text("Delete TODO"),
          content: Text("Do you want to delete \"${item.name}\"?"),
          actions: <Widget>[
            FlatButton(
              child: Text("Cancel"),
              onPressed: Navigator.of(context).pop, // Close dialog
            ),
            FlatButton(
              child: Text("Delete"),
              onPressed: () {
                _deleteTodoItem(item);
                Navigator.of(context).pop(); // Close dialog
              },
            ),
          ],
        );
      }
    );
  }

  Widget _createTodoItemWidget(TodoItem item) {
    return ListTile(
      title: Text(item.name),
      trailing: Checkbox(
        value: item.isComplete,
        onChanged: (value) => _updateTodoCompleteStatus(item, value),
      ),
      onLongPress: () => _displayDeleteConfirmationDialog(item),
    );
  }

  @override
  Widget build(BuildContext context) {
    _todoItems.sort();
    final todoItemWidgets = _todoItems.map(_createTodoItemWidget).toList();

    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: ListView(
        children: todoItemWidgets,
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _addTodoItem,
        tooltip: 'Add Todo',
        child: Icon(Icons.add),
      ),
    );
  }
}
