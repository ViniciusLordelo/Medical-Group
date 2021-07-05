import './Paciente.css';
import { Component } from 'react';


class Paciente extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listagem: [],

        }
    }


  
    buscarcadastros = () => {
        console.log('agora vamos fazer a chamada a api (listando-a!)')

        //faz a chamada para a api usando o fetch
        fetch('http://localhost:5000/api/Consultas')


            //define o dado da requisição de retorno em JSON
            .then(resposta => resposta.json())

            .then(data => this.setState({ listagem: data }))

            .catch((erro) => console.log(erro))
    


    }

    componentDidMount() {
        this.buscarcadastros();
    };


render() {
    return (
        <body>

        <section className="containerprincipal">

                <h1>Consultas</h1>
               
                <table>

                    <thead>
                        <tr>
                        
                        <th>Nome do Paciente</th>
                        <th>Nome do Médico</th>
                        <th>Situação</th>
                        <th>Data</th>
                        <th>Horario</th>
                       </tr>
                    </thead>


                    <tbody>{
                        
                        this.state.listagem.map(
                            (L) => {
                                return (
                                    <tr key={L.idConsulta}>
                                        <td>{L.idPacienteNavigation.nome}</td>
                                        <td>{L.idMedicoNavigation.nome}</td>
                                        <td>{L.idSituacaoNavigation.titulo}</td>
                                        <td>{L.dataAgendamento}</td>
                                        <td>{L.descricao}</td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>


                </table>

            </section>
       
       
            </body>
       
       
       
       );
    }
}
export default Paciente;
