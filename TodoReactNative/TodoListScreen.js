import React from 'react';
import { StyleSheet, Text, View, AsyncStorage } from 'react-native';
import TodoList from './TodoListComponent';

const initialTodoItems = [
  { key: '0', title: "Create first todo", isCompleted: true },
  { key: '1', title: "Climb a mountain", isCompleted: false },
  { key: '2', title: "Create React Native blog post", isCompleted: false },
 ];

export default class TodoListScreen extends React.Component {
  static navigationOptions = {
      title: 'Todo List',
  };
  constructor(props) {
    super(props);

    this.state = { todoItems: [] };

    // This binding is necessary to make `this` work in the callback
    this.toggleItemCompleted = this.toggleItemCompleted.bind(this);
    this.deleteItem = this.deleteItem.bind(this);
    this.initializeTodoList = this.initializeTodoList.bind(this);

    this.initializeTodoList();
  }
  initializeTodoList() {
    AsyncStorage.getAllKeys((err, keys) => {
      AsyncStorage.multiGet(keys, (err, stores) => {
        let todoItems = stores.length ? stores : initialTodoItems;
        let nextAvailableKey = Math.max(todoItems.map(todo => parseInt(todo.key, 10))) + 1;

        this.setState({todoItems, nextAvailableKey})
        if(stores.length) {
          todoItems = stores;
        } else {
          todoItems = initialTodoItems;
        }
      });
    });
  }
  toggleItemCompleted(itemKey) {
    this.setState((prevState, props) => {
      // Use a temporary variable to avoid directly modifying state
      const tempTodoItems = prevState.todoItems;
      const toggledItemIndex = tempTodoItems.findIndex(item => item.key === itemKey);
      tempTodoItems[toggledItemIndex].isCompleted = !tempTodoItems[toggledItemIndex].isCompleted;
      return {todoItems: tempTodoItems};
    });
  }
  deleteItem(itemKey) {
    this.setState((prevState, props) => {
      // Use a temporary variable to avoid directly modifying state
      let tempTodoItems = prevState.todoItems;
      const deletedItemIndex = tempTodoItems.findIndex(item => item.key === itemKey);
      tempTodoItems.splice(deletedItemIndex, 1);
      return {todoItems: tempTodoItems};
    });
  }
  render() {
    return (
      <TodoList todoItems={this.state.todoItems} onToggleItemCompleted={this.toggleItemCompleted}
        onDeleteItem={this.deleteItem} />
    );
  }
}
