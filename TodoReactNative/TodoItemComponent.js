import React from 'react';
import { StyleSheet, Text, View, TouchableHighlight } from 'react-native';

function TodoItemActionButton({title, isDestructive, onPress, ...props}) {
  return (
    <TouchableHighlight style={ isDestructive ? styles.destructiveActionButton : styles.actionButton } 
      onPress={onPress}>
      <Text style={styles.actionButtonText}>{title}</Text>
    </TouchableHighlight>
  );
}

export default function TodoItem({itemKey, title, isCompleted, onToggleCompleted,
                                  onDeleteItem, ...props}) {
  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.todoTitle}>{title}</Text>
        <TodoItemActionButton title={isCompleted ? "Uncomplete" : "Complete"} 
          isDestructive={false}
          onPress={() => onToggleCompleted(itemKey)} />
        <TodoItemActionButton title="Delete" 
          isDestructive={true}
          onPress={() => onDeleteItem(itemKey)} />
      </View>
      <View style={styles.border} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    display: 'flex',
    flexDirection: 'column',
    height: 40,
    backgroundColor: '#fff',
  },
  content: {
    flexGrow: 1,
    alignItems: 'stretch',
    display: 'flex',
    flexDirection: 'row',
    justifyContent: 'flex-start',
  },
  border: {
    height: 1,
    backgroundColor: '#aaa',
  },
  todoTitle: {
    flexGrow: 1,
    alignSelf: 'center',
  },
  actionButton: {
    backgroundColor: '#00f',
    display: 'flex',
    justifyContent:'center',
  },
  destructiveActionButton: {
    backgroundColor: '#f00',
    display: 'flex',
    justifyContent:'center',
  },
  actionButtonText: {
    color: '#fff',
    paddingLeft: 10,
    paddingRight: 10,
  },
});
