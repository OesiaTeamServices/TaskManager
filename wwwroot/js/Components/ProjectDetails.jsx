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
                                return item.AppUsersId === "1b34f4e6-3072-4f56-bc0b-309f7da777b9";
                                console.log(username);
                                console.log(item.AppUsersId);
                            } else {
                                return null;
                            }

                        })
                            .map((item, key) => {
                                return (
                                    <div key={key} className="presentationBlock">
                                        <p><span className="titlePresentation">ID:</span> {item.Projects.ProjectId}</p>
                                        <p><span className="titlePresentation">Project Manager:</span> {item.Projects.UserId}</p>
                                        <p><span className="titlePresentation">Create Date:</span> {item.Projects.CreateDate}</p>
                                        <p><span className="titlePresentation">Start Day:</span> {item.Projects.StartDate}</p>
                                        <p><span className="titlePresentation">End day:</span> {item.Projects.EndDate}</p>
                                        <p><span className="titlePresentation">Time Est. (h):</span> {item.Projects.EstimatedHours}</p>
                                        <p><span className="titlePresentation">Progress:</span>
                                        <div className="progress">
                                            <div className="progress-bar details" role="progressbar" aria-valuenow="70"
                                            aria-valuemin="0" aria-valuemax="100">
                                                <span className="sr-only"></span>40%
                                            </div>
                                        </div>
                                    </p>
                                        <p><span className="titlePresentation">Project Status:</span> {item.Projects.Status}</p>
                                    </div>
                                )
                            })
                }
                </li>
                <li role="presentation"><a href="#">Modules</a></li>
                <li role="presentation"><a href="#">Submodules</a></li>
                <li role="presentation"><a href="#">Tasks</a></li>
                <li role="presentation"><a href="#">Subtasks</a></li>
                <li role="presentation"><a href="#">Calendar</a></li>
            </ul>
        );
    }
}


ReactDOM.render(
    <ProjectDetails />,
    document.getElementById('content'),
);