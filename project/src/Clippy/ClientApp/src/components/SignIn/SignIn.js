import React from 'react';
import { Link } from 'react-router-dom';
import Button from '@material-ui/core/Button';
import GitHubIcon from '@material-ui/icons/GitHub';

import "./SignIn.css";

export default function SignIn() {
    return (
        <div className="container">
            <div className="container__quote">
                <p>The source for all </p>
                <p> your needed bookmarks</p>
            </div>
            <Link className="container__link" to="./bookmarks">
                <div className="signin__github">
                    <Button className="signin__github">
                        <GitHubIcon  className="git-icon"/>
                        Sign in with github
                    </Button>
                </div>
            </Link>
        </div>
    )
}
