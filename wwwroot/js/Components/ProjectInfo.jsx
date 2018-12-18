class ProjectInfo extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            //userGlobal: username,
            userProjectsData: { $values: [] },
            query: '',
            filteredProjects: []
        };
        //this.handleUpdateQuery = this.handleUpdateQuery.bind(this);
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
                <table>
                    <colgroup span="4"></colgroup>
                    <thead>
                        <tr>
                            <th>Project ID</th>
                            <th>Description</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                            <th>Time Est. (h)</th>                          
                            <th>Progress Bar</th>
                        </tr>
                    </thead>
                    <tbody>{
                        this.state.userProjectsData.$values.filter((item, userGlobal) => {
                            if (("$id" in item) && (item.Projects !== null) && (item.AppUsersId !== null)) {
                                return item.AppUsersId === username;
                                console.log(userGlobal);
                                console.log(item.AppUsersId);
                            } else {
                                return null;
                            }
                        })                     
                            .map((item, key) => {
                                return (
                                    <tr key={key}>
                                        <td>{item.Projects.ProjectId}</td>
                                        <td>{item.Projects.Description}</td>
                                        <td>{item.Projects.StartDate}</td>
                                        <td>{item.Projects.EndDate}</td>
                                        <td>{item.Projects.EstimatedHours}</td>
                                        <td>
                                            <div className="progress">
                                                <div className="progress-bar" role="progressbar" aria-valuenow="20"
                                                    aria-valuemin="0" aria-valuemax="100">
                                                    <span className="sr-only"></span>
                                                    20%
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <button className="editBtn btn btn-default" type="button"><a href="/Edit"><span className="glyphicon glyphicon-pencil"></span></a> </button>
                                            <button className="deleteBtn btn btn-default" type="button"><a href="/Delete"><span className="glyphicon glyphicon-remove"></span></a> </button>
                                        </td>
                                    </tr>
                                )
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