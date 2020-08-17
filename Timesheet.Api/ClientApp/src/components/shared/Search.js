import * as React from 'react';

class Search extends React.PureComponent {

    state = {
        searchText: ""
    }

    handleChange = (evt) => {
        const value = evt.target.value;
        this.setState({
            ...this.state,
            [evt.target.name]: value
        }, () => {
                this.props.searchClients(this.state.searchText);
        });
    }

    render() {
        return (
            <React.Fragment>
                <div className="search-page">
                    <input type="search" name="searchText" value={this.state.searchText} onChange={this.handleChange} className="in-search" />
                </div>
            </React.Fragment>
        );
    }
};

export default Search;
