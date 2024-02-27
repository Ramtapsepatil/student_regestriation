// App.js

import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Login from './Login';
import MasterPage from './MasterPage';
import StudentPage from './StudentPage';
import ClassPage from './ClassPage';

const App = () => {
  const token = localStorage.getItem('token');

  return (
    <Router>
      <Switch>
        <Route path="/" exact>
          {token ? <MasterPage /> : <Login />}
        </Route>
        <Route path="/login" component={Login} />
        <Route path="/master" component={MasterPage} />
        <Route path="/students" component={StudentPage} />
        <Route path="/classes" component={ClassPage} />
      </Switch>
    </Router>
  );
};

export default App;
