import React, { Component } from 'react'
import './UserNavbar.css';
import SearchIcon from '@material-ui/icons/Search';
import { Avatar, Collapse, Button, Link} from '@material-ui/core';
import AddIcon from '@material-ui/icons/Add';

export default class UserNavbar extends Component {
    render() {
        return (
        <div className="header">
            <img src={require('../assets/logo.png')} alt="logo"/>
            
            <Link className="header__option">
                Explore
            </Link>

            <Link className="header__option">
                Following
            </Link>

            <div className="header__input">
                <SearchIcon />
                <input type="text"/>
            </div>


            <div className="header__right">
                <Link className="header__option" href="#" color="#06D6A0"><AddIcon /></Link>
                <Avatar className="" alt ="Randy Rando" src={require('../assets/rando.jpg')}/>
            </div>
        </div>
        )
    }
}