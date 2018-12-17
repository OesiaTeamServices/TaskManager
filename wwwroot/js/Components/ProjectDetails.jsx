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
                <table>
                    <colgroup span="4"></colgroup>
                    <thead>
                        <tr>
                            <th>Project ID</th>
                            <th>Description</th>
                            <th>Project Manager</th>
                            <th>Create Date</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                            <th>Estimated Hours</th>
                            <th>Elapsed Hours</th>
                            <th>Pending Hours</th>
                            <th>Status</th>
                            <th>Progress Bar</th>
                        </tr>
                    </thead>
                    <tbody>{
                        this.state.userProjectsData.$values.map((item, key) => {
                            if (("$id" in item) && (item.Projects !== null) && (item.Projects.Module !== null)) {
                                return (
                                    <tr key={key}>
                                        <td>{item.Id}</td>
                                        <td>{item.Projects.ProjectId}</td>
                                        <td>{item.Projects.UserId}</td>
                                        <td>{item.Projects.CreateDate}</td>
                                        <td>{item.Projects.StartDate}</td>
                                        <td>{item.Projects.EndDate}</td>
                                        <td>{item.Projects.EstimatedHours}</td>
                                        <td>{item.Projects.ElapsedHours}</td>
                                        <td>{item.Projects.PendingHours}</td>
                                        <td>{item.Projects.Status}</td>
                                        <td>
                                            <div class="progress">
                                                <div class="progress-bar" role="progressbar" aria-valuenow="70"
                                                    aria-valuemin="0" aria-valuemax="100">
                                                    <span class="sr-only">70% Complete</span>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <button className="editBtn btn btn-default" type="button"><a href="/Edit"><b>Edit</b></a> </button>
                                            <button className="deleteBtn btn btn-default" type="button"><a href="/Delete"><b>Delete</b></a> </button>
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
    <ProjectDeatils />,
    document.getElementById('content'),
);