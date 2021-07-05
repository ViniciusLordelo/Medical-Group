import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View, TouchableOpacity } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../services/api';

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaConsultas: [],

    };
  }


  buscarConsultas = async () => {
    const valorToken = await AsyncStorage.getItem('userToken');

    const resposta = await api.get('/consultas/minhas-consultas', {
      headers: {
        'Authorization': 'Bearer ' + valorToken
      }
    });
    console.log('resposta');
    const dadosDaApi = resposta.data;
    this.setState({ listaConsultas: dadosDaApi });


  };


  componentDidMount() {

    //realiza a chamada da api
    this.buscarConsultas();
  }


  realizarLogout = async () => {
    try {
      await AsyncStorage.removeItem('userToken');
      this.props.navigation.navigate('Login');
    } catch (error) {
      console.warn(error);
    }
  };

  render() {

    return (





      <View style={styles.container}>
        <View style={styles.mainHeader}>

        </View>
        <Text style={styles.text__cabecalho}>{'Consultas'.toUpperCase()}</Text>
        <View style={styles.mainHeaderLine} />




        <TouchableOpacity
          style={styles.btnLogout}
          onPress={this.realizarLogout}
        >
          <Text style={styles.btnLogoutText}>sair</Text>
        </TouchableOpacity>



        <View style={styles.mainBody}>
          <FlatList
            contentContainerStyle={styles.mainBodyConteudo}
            data={this.state.listaConsultas}
            keyExtractor={(item) => item.nomeConsultas}
            renderItem={this.renderizaConsulta}
          />
        </View>
      </View>

    );

  }

  renderizaConsulta = ({ item }) => (

    <View style={styles.flatItemLinha}>
      <View>

        <Text >{item.idPacienteNavigation.nome}</Text>
        <Text> {item.idMedicoNavigation.nome}</Text>
        <Text> {item.idSituacaoNavigation.titulo}</Text>
        <Text> {new Date(item.dataAgendamento).toLocaleDateString()}</Text>
        <Text>    {new Date(item.dataAgendamento).toLocaleDateString([], {
          hour: '2-digit',
          minute: '2-digit',
        })}</Text>

        <Text> {item.descricao !== undefined ? item.descricao : 'NULL'}</Text>
      </View>

    </View>

  );


}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#55A2E3',
    alignItems: 'center',
    justifyContent: 'center',

  },

  btnLogoutText: {
    color: 'red',

  },
  mainHeader: {

    flex: 1,

    backgroundColor: '#55A2E3',
    alignItems: 'center',
    justifyContent: 'center',
  },
  //conteudo da lista de consultas

  mainBodyConteudo: {

  },
  flatItemLinha: {


    borderWidth: 0.9,
    borderBottomColor: '#black',
  },

  text__cabecalho: {
    fontSize: 16,
    letterSpacing: 2,
    fontFamily: 'Open Sans',
  },

  mainBody: {
    flex: 4,

    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50,
  },

  mainHeaderLine: {
    width: 237,
    paddingTop: 10,
    borderBottomColor: 'black',
    borderBottomWidth: 1,

  },

  container2: {
    alignItems: 'flex-end',
    justifyContent: 'flex-end'
  },



});

