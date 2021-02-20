import React, { Component } from 'react';
import SignIn from './SignIn';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div className="bg-image">
        <div className="signin-position">
          <SignIn />
        </div>
      </div>
    );
  }
}
