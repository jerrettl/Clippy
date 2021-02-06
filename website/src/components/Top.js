import React from 'react';
import './Top.css';
import Login from './Login';

export default function Top() {
    return (
        <div className="login" style={{backgroundImage: `url(${process.env.PUBLIC_URL}/assets/clip-front-page.jpg)`}}>
            <div className="login__menu">
                <Login />
            </div>
        </div>
    )
}
