import React, { Component } from 'react';
import { Image, ImageBackground, TextInput, StyleSheet, Text, View, TouchableOpacity } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';



export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
        };
    }


    realizaLogin = async () => {
        console.warn(this.state.email + '' + this.state.senha);
        
        const resposta = await api.post('/Login', {
            email : this.state.email,
            senha : this.state.senha
        });

        const token = resposta.data.token;
        console.warn(token);

        await AsyncStorage.setItem('userToken', token);
        this.props.navigation.navigate('main');
    };

    render() {

        return (

            <ImageBackground
                source={require('../../assets/fundo-pages.jpg')}
                style={StyleSheet.absoluteFillObject}
            >
                <View style={styles.overlay} />
                <View style={styles.container}>

                    <Image
                        source={require('../../assets/logo-spmg.png')}
                        style={styles.logo__login}
                    />
                    <TextInput
                        style={styles.input__login}
                        placeholder="email"
                        placeholderTextColor='#FFF'
                        keyboardType='email-address'
                        onChangeText={email => this.setState({ email })}
                    />

                    <TextInput
                        style={styles.input__login}
                        placeholder="senha"
                        placeholderTextColor='#FFF'
                        secureTextEntry={true}
                        onChangeText={senha => this.setState({ senha })}
                    />


                    <TouchableOpacity
                        style={styles.botao__login}
                        onPress={this.realizaLogin}
                    >
                        <Text>Logar</Text>
                    </TouchableOpacity>
                </View>
            </ImageBackground>

        );
    }

}

const styles = StyleSheet.create({

    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: 'rgba(85,162,227,0.79)'
    },
    container: {
        width: '100%',
        height: '100%',
        justifyContent: 'center',
        alignItems: 'center',
        
    },

    logo__login: {
        tintColor: '#FFF',
        height: 130,
        width: 130,
        margin: 60,
        marginTop: 0,

    },

    input__login: {
        height: 38,
        width: 240,
        marginBottom: 40,
        fontSize: 16,
        color: '#FFF',
        borderColor: '#FFF',
        borderBottomWidth: 2,
        fontFamily: 'Open Sans Light',
        letterSpacing: 1
        
    },

    botao__login: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 240,
        backgroundColor: '#0082F0',
        borderColor: '#FFF',
        textColor: '#FFF',
        borderWidth: 1,
        borderRadius: 3,
        shadowOffset: { height: 1, width: 1 },
        textColor: '#FFF',
    },

});