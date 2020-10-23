import React from 'react';
import ReactDOM from 'react-dom';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import './index.css';
import Home from './pages/home';
import * as serviceWorker from './serviceWorker';
import 'bootstrap/dist/css/bootstrap.min.css';


ReactDOM.render(
  <React.StrictMode>	  
     <Home />	    
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
