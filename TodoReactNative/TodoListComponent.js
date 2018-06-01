import React from 'react';
import { StyleSheet, FlatList } from 'react-native';
import TodoItemComponent from './TodoItemComponent';



export default function TodoList({todoItems, ...props}) {
  return (
    <FlatList style={styles.container}
      data={todoItems}
      renderItem={({item, index, section}) => <TodoItemComponent {...item} />}
    />
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
});
