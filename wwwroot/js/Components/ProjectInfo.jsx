class ProjectInfo extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            userProjectsData: { $values: [] }
        };
        //this.loadDataFromServer = this.loadDataFromServer.bind(this);
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
                        this.state.userProjectsData.$values.map((item, key) => {
                            if ("$id" in item) {
                                return (
                                    <tr key={key}>
                                        <td>{item.AppUsers.UserName}</td>
                                        <td>
                                            <button className="createBtn" type="button"><a href="/Edit"><b>Edit</b></a> </button>
                                            <button className="createBtn" type="button"><a href="/Delete"><b>Delete</b></a> </button>
                                        </td>
                                    </tr>
                                )
                            } else {
                                return null;
                            }
                            })   
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}

ReactDOM.render(
    <ProjectInfo />,
    document.getElementById('content'),
);