import React from 'react';
import { Button } from 'react-bootstrap';
import "./SignIn.css";

export default function SignIn() {
    return (
        <div className="content">
            <img src={require('../assets/GitHub-Mark-120px-plus.png')} alt="logo" />
            <img src={require('../assets/GitHub_Logo.png')} width="200px" alt="logo" />
            <Button variant="dark">Sign In with GitHub</Button>{' '}
            <p className="copyright-text"><br /><br /><br />Copyright © Clippy 2021</p>
        </div>
    )
}
