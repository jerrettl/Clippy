import React, { Component } from 'react';
import { Link, Route } from 'react-router-dom';
import SignIn from './SignIn';
import BookmarkPage from './BookmarkPage';
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
