import React from 'react';
import './Header.css';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';

export default function Header() {
    return (
        <div className="header">
            <div className="header__left">
                <img src={require('../assets/logo.png')}  alt="logo"/>
            </div>

            <div className="header__right">
                <Link className="header__option text-option" href="#" color="#06D6A0">About</Link>
                <Button className="header__option header__button" variant="contained" color="primary">
                    Sign in
                </Button>
            </div>
        </div>
    )
}
