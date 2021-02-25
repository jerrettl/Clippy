import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { AppBar, Avatar, InputBase, Collapse } from '@material-ui/core'
import SearchIcon from '@material-ui/icons/Search'
import MenuIcon from '@material-ui/icons/Menu'
import AddIcon from '@material-ui/icons/Add'
import './UserNavbar.css';

export default class UserNavbar extends Component {  
    render() {
        function CollapsableList() {
            const [open, setOpen] = React.useState(true);

            const handleClick = () => {
                setOpen(!open);
            };

            const useViewport = () => {
                const [width, setWidth] = React.useState(window.innerWidth);

                React.useEffect(() => {
                    const handleWindowResize = () => setWidth(window.innerWidth);
                    window.addEventListener("resize", handleWindowResize);
                    return () => window.removeEventListener("resize", handleWindowResize);
                }, []);
                return width;
            }
            return (
                <div>
                    
                    {useViewport() > 750 && open == false ? setOpen(!open) : false }
                    {useViewport() < 700 && open == true ? setOpen(!open) : false }
                    {open ? true : <MenuIcon className='MenuIcon' onClick={handleClick} /> }
                    <Collapse in={open} timeout="auto" unmountOnExit>
                        <Link className='Explore'>
                            Explore
                        </Link>

                        <Link className='Following'>
                            Following
                        </Link>
                    </Collapse>
                </div>
            )
        }
        return (
            <div>
                <AppBar className='NavBar'>
                    <Link className='ClippyLogo' to="./bookmarks">
                        <img src={require("../../assets/logo.png")} />
                    </Link>
                    
                    <CollapsableList />                    

                    <InputBase className='SearchBar' placeholder="Search" type="text" startAdornment={<SearchIcon className='SearchIcon' />} />

                    <AddIcon className='AddIcon' />
                    <Avatar className='Avatar' alt="Randy Rando" src={require('../../assets/rando.jpg')} />
                </AppBar>
            </div>
        )
    }
}
