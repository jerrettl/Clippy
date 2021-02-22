import React, { Component } from 'react';
import { Link, Route } from 'react-router-dom';
import SignIn from './../SignIn/Signin';
import BookmarkPage from './../BookmarkPage/BookmarkPage';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div className="bg-image">
        <div>
            <SignIn />
        </div>
      </div>
    );
  }
}
