import React from 'react';
import ReactDOM from 'react-dom';
import BookmarkPage from './../BookmarkPage'

it("renders without crashing", ()=>{
  const div = document.createElement("div");
  ReactDOM.render(<BookmarkPage></BookmarkPage>, div)
})
