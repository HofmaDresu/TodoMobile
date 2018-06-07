import React from 'react';
import TodoListScreen from './TodoListScreen';
import AddTodoScreen from './AddTodoItemScreen';
import { createStackNavigator } from 'react-navigation';

export default createStackNavigator({
  Home: TodoListScreen ,
  AddTodoScreen,
});
