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
                <button class="createBtn" type="button"><a href="/Create"><b>Create</b></a> </button>
                <table>
                    <colgroup span="4"></colgroup>
                    <thead>
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>

                            <th>User Email</th>
                            <th>Description</th>
                            <th>Create Date</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                            <th>Estimated Hours</th>
                            <th>Elapsed Hours</th>
                            <th>Pending Hours</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>{
                        this.state.data.$values.map(function (item, key) {

                        return (
                            <tr key={key}>
                                <td>{item.AppUsers.FirstName}</td>
                                <td>{item.AppUsers.LastName}</td>

                                <td>{item.AppUsers.Email}</td>
                                <td>{item.Projects.Description}</td>
                                <td>{item.Projects.CreateDate}</td>
                                <td>{item.Projects.StartDate}</td>
                                <td>{item.Projects.EndDate}</td>
                                <td>{item.Projects.EstimatedHours}</td>
                                <td>{item.Projects.ElapsedHours}</td>
                                <td>{item.Projects.PendingHours}</td>
                                <td>{item.Projects.Status}</td>
                                <td>
                                    <button className="createBtn" type="button"><a href="/Create"><b>Edit</b></a> </button>
                                    <button className="createBtn" type="button"><a href="/Create"><b>Delete</b></a> </button>
                                </td>

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