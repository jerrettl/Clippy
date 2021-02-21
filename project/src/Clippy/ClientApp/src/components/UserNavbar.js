import React, { Component } from 'react'
import './UserNavbar.css';
import SearchIcon from '@material-ui/icons/Search';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import { Avatar } from '@material-ui/core';

export default class UserNavbar extends Component {
    render() {
        return (
            <div className="header">
            <div className="header__left">
                <img src={require('../assets/logo.png')} alt="logo"/>
                
                <div className="header__input">
                    <SearchIcon />
                    <input type="text"/>
                </div>
            </div>

            <div className="header__right">
                <Link className="header__option" href="#" color="#06D6A0">Explore</Link>
                <Avatar className="" alt ="Randy Rando" src={require('../assets/rando.jpg')}/>
            </div>
        </div>
        )
    }
}