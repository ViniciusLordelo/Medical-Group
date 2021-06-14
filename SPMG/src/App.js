
import './App.css';
import fundo from './images/fundo-abstrato-azul.png';
import logo from './images/logo1.png';

function App() {
  return (
    <div className='login__App'>
     <header className='App-header'>
      </header> 

      <body>
       
        <div className='login__retangulo'>
          <div className='login__retangulo2'>
            <img src={logo} alt='logo medicalgroup' />
          </div>
          <div className='login__content'>
            <form action className='form_login'>
              <h1>Login</h1>
              <input type='email' className='input_login' placeholder='Email' />
              <input type='password' className='input_login' placeholder='Senha' />
              <button type='submit' onclick=''>Login</button>
            </form>
          </div>
        </div>


      </body>

    </div>
  );
}

export default App;
