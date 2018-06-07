import React from 'react';
import { StyleSheet, Text, View, Button, AsyncStorage } from 'react-native';
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
  async initializeTodoList() {
    let todoItems = initialTodoItems.slice();
    const storedTodoItems = await AsyncStorage.getItem("todoList");
    if(storedTodoItems != null) {
      const storedTodoArray = JSON.parse(storedTodoItems);
      if(storedTodoArray.length) todoItems = storedTodoArray;
    }

    this.setState({todoItems: todoItems});
  }
  toggleItemCompleted(itemKey) {
    this.setState((prevState, props) => {
      // Use a temporary variable to avoid directly modifying state
      const tempTodoItems = prevState.todoItems;
      const toggledItemIndex = tempTodoItems.findIndex(item => item.key === itemKey);
      tempTodoItems[toggledItemIndex].isCompleted = !tempTodoItems[toggledItemIndex].isCompleted;

      return {todoItems: tempTodoItems};
    }, () => AsyncStorage.setItem("todoList", JSON.stringify(this.state.todoItems)));
  }
  deleteItem(itemKey) {
    this.setState((prevState, props) => {
      // Use a temporary variable to avoid directly modifying state
      let tempTodoItems = prevState.todoItems;
      const deletedItemIndex = tempTodoItems.findIndex(item => item.key === itemKey);
      tempTodoItems.splice(deletedItemIndex, 1);
      return {todoItems: tempTodoItems};
    }, () => AsyncStorage.setItem("todoList", JSON.stringify(this.state.todoItems)));
  }
  render() {
    return (
      <View style={styles.container}>
        <TodoList todoItems={this.state.todoItems} onToggleItemCompleted={this.toggleItemCompleted}
          onDeleteItem={this.deleteItem} style={styles.todoList} />
        <Button title="Add Item" onPress={() => {}} />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    display: 'flex',
    flexGrow: 1,
    flexDirection: 'column',
  },
  todoList: {
    flexGrow: 1,
  },
});

