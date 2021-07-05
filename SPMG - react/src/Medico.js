import './Medico.css';
import { Component } from 'react';



class Medico extends Component {
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

                                <th>Paciente</th>
                                <th>Médico</th>
                                <th>Situação</th>
                                <th>Data</th>
                                <th>Horario</th>
                                <th>Descrição</th>
                            </tr>
                        </thead>



                        <tbody className="table">{

                            this.state.listagem.map(
                                (L) => {
                                    return (
                                        <tr key={L.idConsulta}>
                                            <td>{L.idPacienteNavigation.nome}</td>
                                            <td>{L.idMedicoNavigation.nome}</td>
                                            <td>{L.idSituacaoNavigation.titulo}</td>
                                            <td>{new Date(L.dataAgendamento).toLocaleDateString()} </td>
                                            <td>{new Date(L.dataAgendamento).toLocaleTimeString([], {
                                                hour: '2-digit',
                                                minute: '2-digit'
                                            })
                                            }</td>
                                            <td>{L.descricao !== undefined ? L.descricao : 'N/A'}</td>
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
export default Medico;
