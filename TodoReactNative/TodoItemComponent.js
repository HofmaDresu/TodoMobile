import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

export default function TodoItem({title, isCompleted, ...props}) {
  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text>{title}</Text>
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
    justifyContent: 'center',
  },
  border: {
    height: 1,
    backgroundColor: '#aaa',
  },
});
