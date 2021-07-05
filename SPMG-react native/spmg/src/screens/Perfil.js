import React, { Component } from 'react';
import {
    StyleSheet, Text, View
} from 'react-native';



export default class App extends Component {


    render() {

        return (

            <View style={styles.container}>
                <Text>Perfil</Text>
            </View>

        );
    }






}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#F1F1F1',
        alignItems: 'center',
        justifyContent: 'center',

    },
    });