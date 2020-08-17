import * as React from 'react'
import Axios from 'axios';
import { connect } from 'react-redux';
import * as actionTypes from '../actions/';

class Client extends React.Component {
	state = {
		address: '',
		city: '',
		country: '',
		id: '',
		name: '',
		zipCode: '',
		clientIsOpen: false
	}

	componentDidMount() {
		this.setState({
			address: this.props.client.address ? this.props.client.address : '',
			city: this.props.client.city ? this.props.client.city : '',
			country: this.props.client.country ? this.props.client.country : '',
			id: this.props.client.id,
			name: this.props.client.name ? this.props.client.name : '',
			zipCode: this.props.client.zipCode ? this.props.client.zipCode : ''
		})
	}

	handleChange = (evt) => {
		const value = evt.target.value;
		this.setState({
			...this.state,
			[evt.target.name]: value
		});
	}

	onDeleteClient(clientId) {

		Axios.delete(`clients/${clientId}`)
			.then(() => {
				this.props.onDeleteClient(clientId)
			})
	}

	onUpdateClient(clientId) {
		const updatedClient = {
			address: this.state.address,
			city: this.state.city,
			country: this.state.country,
			id: this.state.id,
			name: this.state.name,
			zipCode: parseInt(this.state.zipCode, 10)
		}

		Axios.put(`clients/${clientId}`, updatedClient)
			.then(response => {

				this.setState({
					...this.state,
					clientIsOpen: false
				})

				this.props.onUpdateClient(response.data)
			})

	}

	openClient() {
		if (this.state.clientIsOpen) {
			this.setState({
				...this.state,
				clientIsOpen: false
			})
		} else {
			this.setState({
				...this.state,
				clientIsOpen: true
			})
		}
	}

    render() {
        return (
            <React.Fragment>
                <div className="accordion-wrap clients">
                    <div className="item">
						<div className="heading" onClick={()=>this.openClient()}>
							<span>{this.state.name}</span>
							<i>+</i>
						</div>
						<div className="details" style={{ display: this.state.clientIsOpen ? "block" : "none"}}>
							<ul className="form">
								<li>
									<label>Client name:</label>
									<input type="text" name="name" value={this.state.name} onChange={this.handleChange} className="in-text" />
								</li>
								<li>
									<label>Zip/Postal code:</label>
									<input name="zipCode" value={this.state.zipCode} onChange={this.handleChange} type="text" className="in-text" />
								</li>
							</ul>
							<ul className="form">
								<li>
									<label>Address:</label>
									<input name="address" value={this.state.address} onChange={this.handleChange} type="text" className="in-text" />
								</li>
								<li>
									<label>Country:</label>
									<select value={this.state.country} name="country" onChange={this.handleChange}>
										<option>Select country</option>
										<option value="Serbia">Serbia</option>
										<option value="US">US</option>
									</select>
								</li>
							</ul>
							<ul className="form last">
								<li>
									<label>City:</label>
									<input name="city" value={this.state.city} onChange={this.handleChange} type="text" className="in-text" />
								</li>
							</ul>
							<div className="buttons">
								<div className="inner">
									<a href="javascript:;" onClick={() => this.onUpdateClient(this.state.id)}className="btn green">Save</a>
									<a href="javascript:;" onClick={() => this.onDeleteClient(this.state.id)} className="btn red">Delete</a>
								</div>
							</div>
						</div>
                    </div>
                </div>
            </React.Fragment>
        );
    }
};

const mapDispatchToProps = dispatch => {
	return {
		onDeleteClient: (clientId) => dispatch(actionTypes.onDeleteClient(clientId)),
		onUpdateClient: (updatedClient) => dispatch(actionTypes.onUpdateClient(updatedClient))
	}
}

export default connect(null, mapDispatchToProps)(Client);