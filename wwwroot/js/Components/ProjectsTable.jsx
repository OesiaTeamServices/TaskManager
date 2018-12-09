class ProjectsTable extends React.Component {
        constructor(props) {
            super(props);
            this.state = {
                data: []
                //filteredHeader: data[0]
            };
            //this.loadDataFromServer = this.loadDataFromServer.bind(this);
        }

        loadDataFromServer() {
            const xhr = new XMLHttpRequest();
            xhr.open('get', this.props.url, true);
            console.log(this.props.url)
            xhr.onload = () => {
                console.log(xhr.responseText)
                const data = JSON.parse(xhr.responseText);
                console.log(data)
                this.setState({ data: data });
                console.log(data)
            };
            xhr.send();
        }

        componentDidMount() {
            this.loadDataFromServer();
        }

    render() {
        //let filteredHeader = data[0];
        //console.log(filetredHeader);
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
                        <tbody>{this.state.data.map(function (item, key) {

                            return (
                                <tr key={key}>                                 
                                    <td>{item.projectId}</td>
                                    <td>{item.description}</td>
                                    <td>{item.userId}</td>
                                    <td>{item.createDate}</td>
                                    <td>{item.startDate}</td>
                                    <td>{item.endDate}</td>
                                    <td>{item.estimatedHours}</td>
                                    <td>{item.elapsedHours}</td>
                                    <td>{item.pendingHours}</td>
                                    <td>{item.status}</td>
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



class CommentList extends React.Component {
    render() {
        console.log(this.props.data) 
        const commentNodes = this.props.data.map(project => (           
            <Comment userId={project.description} key={project.projectId} />
        ));
        return <div className="commentList">{commentNodes}</div>;
    }
}

class Comment extends React.Component {
    render() {
        return (
            <div className="comment">
                <h2 className="commentAuthor" key={this.projectId}>{this.props.userId}</h2>
            </div>
        );
    }
}

//ReactDOM.render(
//    <ProjectsTable url="/ProjectsJson" />,
//    document.getElementById('content')
//);

ReactDOM.render(
    <ProjectsTable url="/ProjectsJson" />,
    document.getElementById('content'),
);