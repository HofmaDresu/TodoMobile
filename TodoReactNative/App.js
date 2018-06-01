import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import TodoListScreen from './TodoListScreen';
import { createStackNavigator } from 'react-navigation';

export default createStackNavigator({
  Home: TodoListScreen ,
});
