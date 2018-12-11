class ProjectsTable extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: { $values: [] }
        };
        //this.loadDataFromServer = this.loadDataFromServer.bind(this);
    }

    loadDataFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        console.log(this.props.url)
        xhr.onload = () => {
            const data = JSON.parse(JSON.parse(xhr.responseText));
            console.log(data);
            this.setState({ data: data });
        };
        xhr.send();
    }

    componentDidMount() {
        this.loadDataFromServer();
    }

    render() {
        return (
            <div className="commentBox">
                <h1>Projects</h1>
                <table>
                    <colgroup span="4"></colgroup>
                    <thead>
                        <tr>
                            <th>Project ID</th>
                            <th>Description</th>
                            <th>User ID</th>
                            <th>Create Date</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                            <th>Estimated Hours</th>
                            <th>Elapsed Hours</th>
                            <th>Pending Hours</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>{
                        this.state.data.$values.map(function (item, key) {

                        return (
                            <tr key={key}>
                                <td>{item.Email}</td>
                                <td>{item.Description}</td>
                                <td>{item.UserName}</td>
                                <td>{item.CreateDate}</td>
                                <td>{item.StartDate}</td>
                                <td>{item.EndDate}</td>
                                <td>{item.EstimatedHours}</td>
                                <td>{item.ElapsedHours}</td>
                                <td>{item.PendingHours}</td>
                                <td>{item.Status}</td>
                            </tr>
                        )
                    })}</tbody>
                </table>
            </div>
        );
    }
}

class TableRowHeader extends React.Component {
    render() {
        return (
            <tr>
                <TableHeader />
            </tr>
        );
    }
}

class TableRow extends React.Component {
    render() {
        return (
            <tr>
                <TableData />
            </tr>
        );
    }
}

class TableHeader extends React.Component {
    render() {
        return (
            <th>Header</th>
        );
    }
}

class TableData extends React.Component {
    render() {
        return (
            <td>Data</td>
        );
    }
}

ReactDOM.render(
    <ProjectsTable url="/UserProjectsJson" />,
    document.getElementById('content'),
);