import React from 'react';

//importando navigation
import {NavigationContainer} from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';


//importando pages
import  Login  from "./src/screens/Login";
import  main  from "./src/screens/main";

const AuthStack = createStackNavigator();

export default function App() {

  return (
   
      <NavigationContainer>
        <AuthStack.Navigator 
        headerMode ='none'
        >
          <AuthStack.Screen name='Login' component={Login} /> 
          <AuthStack.Screen name='main' component={main} />
        </AuthStack.Navigator>
      </NavigationContainer>
   
  );
}



