import React, { Component } from 'react';
import { Image,StyleSheet, Text, View } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';



import Consultas from './Consultas';
import Perfil from './Perfil';




const bottomTab = createBottomTabNavigator();

export default class App extends Component {


  render() {

    return (

      <View style={styles.container}>
        
          <bottomTab.Navigator
            tabBarOptions={
              {
                showLabel: false,
                inactiveBackgroundColor:'#55A2E3',
                activeBackgroundColor: '#0082F0',
                activeTintColor: '#FFF',
                inactiveTintColor: '#55A2E3',
                style: { height: 50 }
              }
            }
            screenOptions={({ route }) => ({
              tabBarIcon: () => {
                if (route.name === 'Consultas') {
                  return (
                    <Image
                      source={require('../../assets/icon-consulta.png')}
                      style={styles.tabBarIcon}
                    />
                  )

                } 

                if (route.name === 'Perfil') {
                  return (
                    <Image
                    source={require('../../assets/icon-perfil.png')}
                    style={styles.tabBarIcon}
                    />
                  )
                }
              }
            })}
          >

            <bottomTab.Screen name="Consultas" component={Consultas} />
            <bottomTab.Screen name="Perfil" component={Perfil} />

          </bottomTab.Navigator>
     

      </View>

    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },

  tabBarIcon: {
    width: 22,
    height: 22,
    tintColor: '#FFF',
  },


});

