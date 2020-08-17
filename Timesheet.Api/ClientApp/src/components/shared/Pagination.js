import React from 'react'

class Pagination extends React.PureComponent {

   

    render() {
        const pages = [];

        console.log(this.props)
        for (let i = 0; i < Math.ceil(this.props.totalItems / this.props.pageSize); i++) {
            pages.push(<li key={i} className={`${i + 1 == this.props.pageNumber ? 'active' : ''}`}><a onClick={()=>this.props.pageChange(i+1)} href="javascript:;">{i + 1}</a></li>)
        }
        console.log(Math.ceil(this.props.totalItems / this.props.pageSize))

        return (
            <div className="pagination">
                <ul>
                    {pages}
                    <li className="last">
                        <a onClick={() => this.props.pageChange(this.props.pageNumber + 1)} href="javascript:;">Next</a>
                    </li>
                </ul>
            </div>
        );    
    }
};
 
    export default Pagination;