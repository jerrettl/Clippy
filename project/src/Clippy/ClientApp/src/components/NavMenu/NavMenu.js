import React, { Component } from 'react';
import { Form } from 'react-bootstrap';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3 background-color-primary " light>
          <Container>
            <NavbarBrand tag={Link} to="/">
              <img src={require('../../assets/logo.png')} width="156px" alt="logo" />
            </NavbarBrand>
            <NavbarBrand>
              <Form>
                <Form.Group controlID="exampleForm.ControlInput1">
                  <Form.Control className="search-alignment search-border search-background search-size" type="SearchBar" placeholder="Search"></Form.Control>
                </Form.Group>
              </Form>
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Explore</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/fetch-status">Fetch Status</NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
