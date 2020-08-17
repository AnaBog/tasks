import React from 'react'
import { Route, BrowserRouter as Router } from 'react-router-dom'
import TimeSheet from './TimeSheet'
import Clients from './Clients'
import Categories from './Categories'
import Employees from './Employees'
import Projects from './Projects'
import Reports from './Reports'
import Header from './shared/Header'
import Footer from './shared/Footer'

const App = () => (
    <Router>
        <div>
            <Header></Header>
            <Route exact path='/' component={TimeSheet} />
            <Route path='/clients' component={Clients} />
            <Route path='/projects' component={Projects} />
            <Route path='/categories' component={Categories} />
            <Route path='/employees' component={Employees} />
            <Route path='/reports' component={Reports} />
            <Footer></Footer>
        </div>
    </Router>
)

export default App