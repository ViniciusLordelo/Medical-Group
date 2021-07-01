import './Adm.css';

import axios from 'axios';
import { useState, useEffect } from 'react';


export default function Adm() {


    //IdPaciente, IdMedico, IdSituacao, DataAgendamento


    // VARIÁVEIS PARA CADASTRO DE CONSULTAS
    const [idPaciente, setIdPaciente] = useState(0)
    console.log(idPaciente)

    const [idMedico, setIdMedico] = useState(0)
    console.log(idMedico)

    const [idSituacao, setIdSituacao] = useState(0)
    console.log(idSituacao)

    const [dataAgendamento, setDataAgendamento] = useState("")
    console.log(dataAgendamento)

    const [descricao, setDescricao] = useState("")
    console.log(descricao)



    // setStates para a listagem das consultas
    const [listaConsultas, setListaConsultas] = useState([])





    // buscar consultas do usuário (todas consultas - administrador)
    function getConsultas() {
        axios.get('http://localhost:5000/api/Consultas')
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsultas(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }


    // Funcionando
    function postConsultas(event) {
        event.preventDefault();


        axios.post('http://localhost:5000/api/Consultas', {

            idPaciente: idPaciente,
            idMedico: idMedico,
            idSituacao: idSituacao,
            dataAgendamento: dataAgendamento,
            descricao: descricao


        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {

                if (resposta.status === 202) {

                    console.log('Consulta cadastrada!')



                }
            })

            .catch(erro => {
                console.log(erro)

            })



    };

    // funções para ciclos de vida 
    useEffect(getConsultas, [])


    return (


        <section className="containerprincipal">

            <h1>Agendamento de consultas</h1>
            <div className="container1">
                <div className="container3">
                    <div className="A">
                        <form onSubmit={postConsultas} className="form_cadastro1">

                            <input name='nomePaciente' type="number" className="input_nome" placeholder="Nome do paciente" onChange={(event) => setIdPaciente(event.target.value)} required />
                            <input name='nomeMedico' type="number" className="input_nome" placeholder="Nome do Médico" onChange={(event) => setIdMedico(event.target.value)} required />
                            <input name='Situacao' type="number" className="input_nome" placeholder="Situação" onChange={(event) => setIdSituacao(event.target.value)} required />
                            <input name='dataAgendamento' className="input_nome" type="date" onChange={(event) => setDataAgendamento(event.target.value)} required />
                            <input name='descricao' className="input_nome" type="text" onChange={(event) => setDescricao(event.target.value)}  />
                            <button type="submit">    Cadastrar   </button>

                        </form>
                    </div>

                    {/* <div className="B">
    
                            <form className="form_cadastro2">
    
    
                            </form>
                        </div> */}
                </div>
            </div>

            <table>

                <thead>

                    <tr>

                        <th>Paciente </th>
                        <th>Médico   </th>
                        <th>Situação </th>
                        <th>Data     </th>
                        <th>Horario  </th>
                        <th>Descrição</th>

                    </tr>

                </thead>


                <tbody className="table">{

                    listaConsultas.map(
                        (L) => {
                            return (
                                <tr key={L.idConsulta}>
                                    <td>{L.idPacienteNavigation.nome}                      </td>
                                    <td>{L.idMedicoNavigation.nome}                        </td>
                                    <td>{L.idSituacaoNavigation.titulo}                    </td>
                                    <td>{new Date(L.dataAgendamento).toLocaleDateString()} </td>
                                    <td>{new Date(L.dataAgendamento).toLocaleTimeString([], {
                                        hour: '2-digit',
                                        minute: '2-digit'
                                    })
                                    }                                                      </td>
                                    <td>{L.descricao !== undefined ? L.descricao : 'N/A'}   </td>
                                </tr>
                            )
                        })
                }
                </tbody>


            </table>

        </section>






    );


}
// class Adm extends Component {
//     constructor(props) {
//         super(props);
//         this.state = {
//             listagem: [],
//             idTipoUsuario: '',
//             nomePaciente: '',
//             nomeMedico: '',
//             Situacao: '',
//             dataAgendamento: '',
//             horaAgendamento: '',



//         }
//     }



//     buscarcadastros = () => {
//         console.log('agora vamos fazer a chamada a api (listando-a!)')

//         //faz a chamada para a api usando o fetch
//         fetch('http://localhost:5000/api/Consultas')


//             //define o dado da requisição de retorno em JSON
//             .then(resposta => resposta.json())

//             .then(data => this.setState({ listagem: data }))

//             .catch((erro) => console.log(erro))



//     }

//     componentDidMount() {
//         this.buscarcadastros();
//     };



//     atualizaCadastro = async (consulta) => {
//         await this.setState({ [consulta.target.name]: consulta.target.value })
//         console.log(this.state.nomePaciente);
//         console.log(this.state.nomeMedico);
//         console.log(this.state.Situacao);
//         console.log(this.state.dataAgendamento);
//         console.log(this.state.horarioAgendamento);
//     };


//     cadastrarConsulta = () => {


//         axios.post('http://localhost:5000/api/Consultas',
//             {

//                 idTipoUsuario: this.state.idTipoUsuario,
//                 idPaciente: this.state.nome,
//                 IdMedico: this.state.nome,
//                 IdSituacao: this.state.titulo,
//                 DataAgendamento: new Date(this.state.dataAgendamento)

//             })

//             .then(Location.reload())

//     }




