import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { AppBar, Avatar, InputBase, Collapse, List, ListSubheader, ListItem, ListItemText } from '@material-ui/core'
import SearchIcon from '@material-ui/icons/Search'
import ExpandLessIcon from '@material-ui/icons/ExpandLess'
import MenuIcon from '@material-ui/icons/Menu'
import AddIcon from '@material-ui/icons/Add'
import './UserNavbar.css';

export default class UserNavbar extends Component {
    render() {
        function CollapsableList() {
            const [open, setOpen] = React.useState(false);

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
                    {useViewport() < 800 ? <List className='List' subheader={
                        <ListSubheader className='ListSubheader' component="div" id="nested-list-subheader">
                            {open ? <ExpandLessIcon className='ExpandLessIcon' onClick={handleClick} /> : <MenuIcon className='MenuIcon' onClick={handleClick} />}
                        </ListSubheader>
                    }>
                        <Collapse className='Collapse' in={open} timeout="auto" unmountOnExit>
                            <ListItem button className='ListItem ExploreListItem'>
                                <ListItemText primary="Explore" />
                            </ListItem>
                            <ListItem button className='ListItem FollowingListItem'>
                                <ListItemText primary="Following" />
                            </ListItem>
                        </Collapse>
                    </List>
                    :
                    <div>
                        <Link className='Explore'>
                            Explore
                        </Link>
                        <Link className='Following'>
                            Following
                        </Link>
                    </div>
                    }

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
