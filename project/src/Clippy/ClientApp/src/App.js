import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout/Layout';
import { FetchStatus } from './components/FetchStatus';
import SignInPage from './components/SignInPage/SignInPage';
import AboutPage from './components/AboutPage/AboutPage';
import BookmarkPage from './components/BookmarkPage/BookmarkPage'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
       <div>
         <Route exact path='/' component={AboutPage} />
         <Route exact path='/bookmarks' component={BookmarkPage} />
         <Route exact path='/signin' component={SignInPage} />
       </div>
    );
  }
}

// <Layout>
//         <Route exact path='/' component={Home} />
//         <Route path='/fetch-status' component={FetchStatus} />
//       </Layout>
