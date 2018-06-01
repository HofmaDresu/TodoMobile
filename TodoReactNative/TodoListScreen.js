import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import TodoList from './TodoListComponent';

const todoItems = [
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
    this.state = {todoItems};
    
    // This binding is necessary to make `this` work in the callback
    this.toggleItemCompleted = this.toggleItemCompleted.bind(this);
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
  render() {

    return (
      <TodoList todoItems={todoItems} onToggleItemCompleted={this.toggleItemCompleted} />
    );
  }
}
