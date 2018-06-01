import React from 'react';
import { StyleSheet, SectionList, Text } from 'react-native';
import TodoItemComponent from './TodoItemComponent';



export default function TodoList({todoItems, ...props}) {
  let activeItems = todoItems.filter(i => !i.isCompleted);
  let completedItems = todoItems.filter(i => i.isCompleted);
  let sections = [
    { title:"Active", data:activeItems },
    { title:"Completed", data:completedItems},
  ];

  return (
    <SectionList style={styles.container}
      sections={sections}
      renderItem={({item, index, section}) => <TodoItemComponent {...item} />}
      renderSectionHeader={({section: {title}}) => (
        <Text style={styles.sectionHeader}>{title}</Text>
      )}
    />
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  sectionHeader: {
    fontWeight: 'bold',
    backgroundColor: '#eee',
    paddingTop: 5,
    paddingBottom: 5,    
  },
});
