import * as React from 'react';
import Axios from 'axios';

class CreateClientForm extends React.Component {

    state = {
        address: '',
        city: '',
        country: 'RS',
        name: '',
        zipCode: 0
    }

    handleChange = (evt) => {
        const value = evt.target.value;
        this.setState({
            ...this.state,
            [evt.target.name]: value
        });
    }

    onSaveClient() {
        const newClient = {
            ...this.state,
            zipCode: parseInt(this.state.zipCode, 10)
        };
        Axios.post("clients", newClient)
            .then(response => {
                const createdClient = { ...newClient, id: response.data }
                console.log(createdClient)
            })
    }

    render() {
        return (
            <React.Fragment>
                <div className="new-member-inner">
                    <form className="form">
                        <br/>
                        <h2>Create a new client:</h2>
                        <div>
                            <label>Client name:</label>
                            <input name="name" onChange={this.handleChange} type="text" className="in-text" />
                        </div>
                        <div>
                            <label>Address:</label>
                            <input name="address" onChange={this.handleChange} type="text" className="in-text"/>
                        </div>
                        <div>
                            <label>City:</label>
                            <input name="city" onChange={this.handleChange} type="text" className="in-text"/>
                        </div>
                        <div>
                            <label>Zip/Postal code:</label>
                            <input name="zipCode" onChange={this.handleChange} type="text" className="in-text" />
                        </div>
                        <br /><br />
                        <select name="country" onChange={this.handleChange}>
                            <option value="RS">Srbija</option>
                            <option value="US">US</option>
                        </select>
                        <br /> <br />
                        <button className="btn green" type="button" onClick={()=>this.onSaveClient()}>Save</button>
                    </form>
                </div>
                
            </React.Fragment>
        );
    }
};

export default CreateClientForm;