import React from 'react';
import { StyleSheet, Text, View, FlatList } from 'react-native';
import TodoItemComponent from './TodoItemComponent';



export default class TodoList extends React.Component {
  render() {
    return (
      <FlatList style={styles.container}
        data={this.props.todoItems}
        renderItem={({item, index, section}) => <TodoItemComponent {...item} />}
      />
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
});
