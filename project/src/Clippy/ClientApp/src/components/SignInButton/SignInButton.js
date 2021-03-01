import React, { Component } from 'react';
import { Link, Route } from 'react-router-dom';
import Button from '@material-ui/core/Button';
import GitHubIcon from '@material-ui/icons/GitHub'
import BookmarkPage from './../BookmarkPage/BookmarkPage';

import "./SignInButton.css";


export class SignInButton extends Component {
  static displayName = SignInButton.name;

  render () {
    return (
      <div className="bg-image">
        <div className="signin-position">
          <div className="container">
              <div className="container__quote">
                  <p>Sign in to</p>
                  <p>Clippy</p>
              </div>
              <Link className="container__link" to="./bookmarks">
                  <div className="signin__github">
                      <Button className="signin__github">
                          <GitHubIcon  className="git-icon"/>
                          Sign in with github
                      </Button>
                  </div>
              </Link>
          </div>
        </div>
      </div>
    );
  }
}
