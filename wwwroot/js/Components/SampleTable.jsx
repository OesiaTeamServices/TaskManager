import React from 'react';
import ReactDOM from 'react-dom';
import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';

import { sampleProducts } from './sample-products.jsx';

class App extends React.Component {
    state = {
        data: sampleProducts.slice(0),
        editID: null
    }

    render() {
        return (
            <Grid
                style={{ height: '420px' }}
                data={this.state.data.map((item) =>
                    Object.assign({
                        inEdit: item.ProductID === this.state.editID
                    }, item)
                )}
                editField="inEdit"

                onRowClick={this.rowClick}
                onItemChange={this.itemChange}
            >
                <GridToolbar>
                    <div onClick={this.closeEdit}>
                        <button title="Add new" className="k-button k-primary" onClick={this.addRecord} >
                            Add new
                    </button>
                    </div>
                </GridToolbar >
                <Column field="ProductID" title="Id" width="50px" editable={false} />
                <Column field="ProductName" title="Name" />
                <Column field="FirstOrderedOn" title="First Ordered" editor="date" format="{0:d}" />
                <Column field="UnitsInStock" title="Units" width="150px" editor="numeric" />
                <Column field="Discontinued" title="Discontinued" editor="boolean" />
            </Grid >
        );
    }

    rowClick = (e) => {
        this.setState({
            editID: e.dataItem.ProductID
        });
    };

    itemChange = (e) => {
        const data = this.state.data.slice();
        const index = data.findIndex(d => d.ProductID === e.dataItem.ProductID);
        data[index] = { ...data[index], [e.field]: e.value };
        this.setState({
            data: data
        });
    };

    closeEdit = (e) => {
        if (e.target === e.currentTarget) {
            this.setState({ editID: null });
        }

    };

    addRecord = () => {
        const newRecord = { ProductID: this.state.data.length + 1 };
        const data = this.state.data.slice();
        data.unshift(newRecord);
        this.setState({
            data: data,
            editID: newRecord.ProductID
        });
    };
}

ReactDOM.render(
   document.getElementById('content'),
);
