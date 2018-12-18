class ProjectDetails extends React.Component {
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
            <ul className="nav nav-tabs">
                <li role="presentation" className="active">
                    <a href="#">General Info</a>
                    {
                        this.state.userProjectsData.$values.filter((item, username) => {
                            if (("$id" in item) && (item.Projects !== null) && (item.AppUsersId !== null)) {
                                return item.AppUsersId === "67591114-9549-4001-b505-fb8652ca3f15";
                                console.log(username);
                                console.log(item.AppUsersId);
                            } else {
                                return null;
                            }

                        })
                            .map((item, key) => {
                                return (
                                    <div key={key}>
                                    <p>{item.AppUsersId}</p>
                                    <p>{item.Projects.ProjectId}</p>
                                    <p>{item.Projects.UserId}</p>
                                    <p>{item.Projects.CreateDate}</p>
                                    <p>item.Projects.StartDate}</p>
                                    <p>{item.Projects.EndDate}</p>
                                    <p>{item.Projects.EstimatedHours}</p>
                                    <p>{item.Projects.ElapsedHours}</p>
                                    <p>{item.Projects.PendingHours}</p>
                                    <p>{item.Projects.Status}</p>
                                    </div>
                                )
                            })
                    }
                </li>
                <li role="presentation"><a href="#">Modules</a></li>
                <li role="presentation"><a href="#">Submodules</a></li>
                <li role="presentation"><a href="#">Tasks</a></li>
                <li role="presentation"><a href="#">Subtasks</a></li>
            </ul>
        );
    }
}


ReactDOM.render(
    <ProjectDetails />,
    document.getElementById('content'),
);