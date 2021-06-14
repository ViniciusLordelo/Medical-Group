import './Adm.css';
import { Component } from 'react';


class Adm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaAdm:
                [{
                    NomedoPaciente: '',
                    NomedoMédico: '',
                    Mensagem: ''
                }],

        }
    }

    buscarcadastros = () => {

        
    }

    componentDidMount() {
        this.buscarcadastros();
     };




    render() {
        return (

            <tbody>
                <section class="containerprincipal">

                    <h1>Agendamento de consultas</h1>
                    <div class="container1">
                        <div class="container3">
                            <div class="A">
                                <form action class="form_cadastro1">
                                    <input type="text" class="input_nome" placeholder="Nome do paciente" required />
                                    <input type="text" class="input_nome" placeholder="Nome do Médico" required />
                                    <textarea class="input-padrao" cols="70" rows="1" id="mensagem" placeholder="Mensagem" required ></textarea>
                                </form>
                            </div>

                            <div class="B">
                                <form action class="form_cadastro2">
                                    <input type="time" id="appt" name="appt" min="00:00" max="23:00" required />
                                    <input type="time" id="appt" name="appt" min="00:00" max="23:59" required />
                                    <input id="date" type="date" required />
                                    <button type="submit" onclick="">Cadastrar</button>
                                </form>
                            </div>
                        </div>
                    </div>

                    <table>
                        <thead>
                          <th>Nome do Paciente</th>
                          <th>Nome do Médico</th>
                          <th>Mensagem</th>
                        </thead>
                    <div>{
                        this.state.listaAdm.map((Adm) => {
                            return (
                                <tr>
                                    <td>{Adm.NomedoPaciente}</td>
                                    <td>{Adm.NomedoMédico}</td>
                                    <td>{Adm.Mensagem}</td>
                                </tr>
                            )
                        })
                    }</div>


                    </table>

                </section>
            </tbody>





        );
    }
}
export default Adm;
