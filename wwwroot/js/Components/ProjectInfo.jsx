class ProjectsTable extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            userProjectsData: [],
            projectsData: []
        };
        //this.loadDataFromServer = this.loadDataFromServer.bind(this);
    }

    componentDidMount() {
        fetch('https://myapioesia.azurewebsites.net/api/projects')

            .then(projectsData => projectsDate.json())
            .then(projectsData => this.setState({ projectsDate }))
        console.log("state", this.state.projectsDate)
    }

    componentDidMount() {
        fetch('https://myapioesia.azurewebsites.net/api/userprojects')

            .then(userProjectsData => userProjectsData.json())
            .then(userProjectsData => this.setState({ userProjectsData }))     
        console.log("state", this.state.userProjectsData)
    }


    render() {
        return (
            <div className="tableWithProjects">
                <h1>Projects</h1>
                <button className="createBtn" type="button"><a href="/Create"><b>Create</b></a> </button>
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

                        this.state.projectsData.filter(function (y) {

                            this.state.userProjectsData.map(function (i) {
                                return i.projectsId;
                            })
                            if (i.projectsId === y.id) {
                                console.log(i.projectsId)
                                this.state.projectsData.map(function (item, key) {                          
                        return (
                            <tr key={key}>
                                <td>{item.id}</td>
                                <td>{item.description}</td>
                                <td>{item.userId}</td>                        
                                <td>
                                    <button className="createBtn" type="button"><a href="/Edit"><b>Edit</b></a> </button>
                                    <button className="createBtn" type="button"><a href="/Delete"><b>Delete</b></a> </button>
                                </td>

                            </tr>
                                    )
                                })
                            }

                        })
                    }</tbody>
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