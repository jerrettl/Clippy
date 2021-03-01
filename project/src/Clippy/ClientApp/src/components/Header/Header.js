import React from 'react';
import './Header.css';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';

export default function Header() {
    return (
        <div className="Header">
            <Link className="ClippyLogo" href="/">
                <img src={require("../../assets/logo.png")} />
            </Link>

            <div className="Links">
                <Link className="About" href="/" color="#06D6A0">
                    About
                </Link>
                <Button className="SignIn" href="/signin" variant="contained" color="primary">
                    Sign in
                </Button>
            </div>
        </div>
    )
}
