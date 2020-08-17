import React from 'react'
import { NavLink } from 'react-router-dom'

const Header = () => (
   <div className="header">
       <div className="top-bar"></div>
       <div className="wrapper">
            <NavLink className="logo" exact to="/">
                <img src="./assets/img/logo.png" alt="VegaIT logo"/>
            </NavLink>

            <nav>
                <ul className="menu">
                    <li><NavLink className="btn nav" exact activeclasslink="active" to="/">TimeSheet</NavLink></li>
                    <li><NavLink className="btn nav" activeclasslink="active" to="/clients">Clients</NavLink></li>
                    <li><NavLink className="btn nav" activeclasslink="active" to="/projects">Projects</NavLink></li>
                    <li><NavLink className="btn nav" activeclasslink="active" to="/categories">Categories</NavLink></li>
                    <li><NavLink className="btn nav" activeclasslink="active" to="/employees">Team members</NavLink></li>
                    <li className="last"><NavLink className="btn nav" activeclasslink="active" to="/reports">Reports</NavLink></li>
                </ul>
            </nav>
       </div>
   </div>   
)

export default Header