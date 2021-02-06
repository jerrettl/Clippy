import React from 'react';
import './Header.css';
import SearchIcon from '@material-ui/icons/Search';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';

export default function Header() {
    return (
        <div className="header">
            <div className="header__left">
                <img src={`${process.env.PUBLIC_URL}/assets/logo.png`} alt="logo"/>
                
                <div className="header__input">
                    <SearchIcon />
                    <input type="text"/>
                </div>
            </div>

            <div className="header__right">
                <Link className="header__option" href="#" color="#06D6A0">Explore</Link>
                <Button className="header__option" variant="contained" color="primary">
                    Sign-up
                </Button>
            </div>
        </div>
    )
}
