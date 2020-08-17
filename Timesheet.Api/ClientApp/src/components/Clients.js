import * as React from 'react'
import Search from './shared/Search'
import CreateClientForm from '../containers/CreateClientForm'
import Pagination from './shared/Pagination'
import Client from './Client'
import Axios from 'axios'
import { connect } from 'react-redux'
import * as actionTypes from '../actions'

class Clients extends React.Component {
    state = {
        formIsOpen: false,
        letters: ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"],
        firstLetter: null,
        searchText: '',
        pageNumber: 1,
        pageSize: null,
        totalItems: null
    }

    letterChange(letter) {
        if (letter === this.state.firstLetter) {
            letter = null
        }

        this.setState({
            firstLetter: letter
        }, () => {
                this.loadClients();
        });

    }

    createQueryString() {
        const params = new URLSearchParams();

        if (this.state.firstLetter) {
            params.append('firstLetter', this.state.firstLetter);
        }

        if (this.state.pageNumber) {
            params.append('pageNumber', this.state.pageNumber);
        }

        if (this.state.searchText !== '') {
            params.append('searchText', this.state.searchText)
        }
        
        return params;
    }

    openForm = () => {
        if (this.state.formIsOpen) {
            this.setState({
                formIsOpen: false
            })
        } else {
            this.setState({
                formIsOpen: true
            })
        }
    }

    loadClients() {
        Axios.get("clients", { params: this.createQueryString() })
            .then(response => {

                this.setState({
                    ...this.state,
                    pageSize: response.data.pageSize,
                    pageNumber: response.data.pageNumber,
                    totalItems: response.data.totalItems
                })

                this.props.onGetClients(response.data.clients)

            })
    }

    onSearchClients(sText) {
        console.log(sText)
        this.setState({
            searchText: sText,
        }, () => {
                this.loadClients();
        })
    }

    onPageChange(pageNum) {
        this.setState({
            pageNumber: pageNum,
        }, () => {
                this.loadClients();
        })
    }

    componentDidMount() {
        this.loadClients();
    }

    render() {
        return (
            <React.Fragment>
                <div className="wrapper">
                    <section className="content">
                        <h2>Clients</h2>

                        <div className="grey-box-wrap reports">
                            <button className="link new-member-popup" onClick={this.openForm}>Create a new client</button>
                            <Search searchClients={($event)=>this.onSearchClients($event)}></Search>
                            {
                                this.state.formIsOpen ? <CreateClientForm></CreateClientForm> : null
                            }
                        </div>

                        <div className="alpha">
                            <ul>
                                {
                                    this.state.letters.map(l => <li className={`${l === this.state.firstLetter ? "active" : ""}`}
                                        key={l} onClick={() => this.letterChange(l)}><span>{l}</span></li>)
                                }
                            </ul>
                        </div>

                        {
                            this.props.clients ? this.props.clients.map(c => <Client key={c.id} client={c}></Client>) : null
                        }
                        {
                            this.state.totalItems && this.state.pageSize ? <Pagination totalItems={this.state.totalItems}
                                pageNumber={this.state.pageNumber}
                                pageSize={this.state.pageSize}
                                pageChange={($event) => this.onPageChange($event)}></Pagination> : null
                        }
                        

                    </section>
                </div>
            </React.Fragment>
        );
    }
};

const mapStateToProps = state => ({
    clients: state.clientsReducer.clients
})

const mapDispatchToProps = dispatch => {
    return {
        onGetClients: (clients) => dispatch(actionTypes.onGetClients(clients))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Clients);