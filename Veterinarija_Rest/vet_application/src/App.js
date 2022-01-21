import {Home} from './Home';
import {User} from './User';
import {Pet} from './Pet';
import {Service} from './Service';
import {Visit} from './Visit';
import {Navigation} from './Navigation';
import {Login} from './Login';

import {BrowserRouter, Route ,Switch} from 'react-router-dom';
import React, {Component} from "react";


export class App extends Component
{

  render(){
    return (
      <BrowserRouter>
      <div className="container">
        <h3 className="m-3 d-flex justify-content-center">
          Veterinarijos sistema
        </h3>
        <Navigation/>
        <Switch>
          <Route exact path='/login' component={Login} />
          <Route exact path='/' component={Home} />
          <Route exact path='/user' component={User} />
          <Route exact path='/pet' component={Pet} />
          <Route exact path='/service' component={Service} />
          <Route exact path='/visit' component={Visit} />
        </Switch>
      </div>
      </BrowserRouter>
    );




      // return (
      //   <BrowserRouter>
      //   <div className="container">
      //     <h3 className="m-3 d-flex justify-content-center">
      //       Veterinarijos sistema
      //     </h3>
      //     console.log(this.state.user);

      //     <Navigation user={this.state.user} />
      //     <Switch>
      //       <Route exact path='/' component={()=> <Home user={this.state.user}/> } />
      //       <Route exact path='/login' component={Login} />

      //       <Route exact path='/user' component={()=> <User user={this.state.user}/> } />
      //       <Route exact path='/pet' component={()=> <Pet user={this.state.user}/> } />
      //       <Route exact path='/service' component={()=> <Service user={this.state.user}/> } />
      //       <Route exact path='/visit' component={()=> <Visit user={this.state.user}/> } />
      //     </Switch>
      //   </div>
      //   </BrowserRouter>
      // );
  }
}