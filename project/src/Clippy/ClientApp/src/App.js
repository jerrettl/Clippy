import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { FetchStatus } from './components/FetchStatus';
import HomePage from './components/HomePage';
import BookmarkPage from './components/BookmarkPage'

import './custom.css'
import { Bookmark } from '@material-ui/icons';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
       <div>
         <Route exact path='/' component={HomePage} />
         <Route exact path='/bookmarks' component={BookmarkPage} />
       </div>
    );
  }
}

// <Layout>
//         <Route exact path='/' component={Home} />
//         <Route path='/fetch-status' component={FetchStatus} />
//       </Layout>
