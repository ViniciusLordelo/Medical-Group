import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch } from
  'react-router-dom';

import './index.css';
import Login from './Login';
import Adm from './Adm';
import Medico from './Medico';
import Paciente from './Paciente';

import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} />
        <Route path="/Adm" component={Adm} />
        <Route path="/Paciente" component={Paciente} />
        <Route path="/Medico" component={Medico} />
      </Switch>
    </div>
  </ Router>
)
ReactDOM.render(routing, document.getElementById('root'))


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
