import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router } from 'react-router-dom';
import BookmarkPage from './../BookmarkPage'

it("renders without crashing", ()=>{
  const div = document.createElement("div");
  ReactDOM.render(<Router><BookmarkPage></BookmarkPage></Router>, div)
})
