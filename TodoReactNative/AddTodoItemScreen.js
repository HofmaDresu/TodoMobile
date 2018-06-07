import React from 'react';
import { StyleSheet, View, Text } from 'react-native';

export default class TodoListScreen extends React.Component {
  static navigationOptions = {
      title: 'Add Todo Item',
  };
  render() {
    return (
      <View style={styles.container}>
        <Text>Welcome to Add</Text>
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
});

