class ProjectsTable extends React.Component {
        constructor(props) {
            super(props);
            this.state = {
                data: []
            };
            //this.loadDataFromServer = this.loadDataFromServer.bind(this);
        }

        ////componentWillMount() {
        ////    const xhr = new XMLHttpRequest();
        ////    xhr.open('get', this.props.url, true);
        ////    xhr.onload = () => {
        ////        const data = JSON.parse(xhr.responseText);
        ////        this.setState({ data: data });
        ////    };
        ////    xhr.send();
        ////    console.log(data);
        ////}

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
            return (
                <div className="commentBox">
                    <h1>Projects</h1>
                    <table>
                        <colgroup span="4"></colgroup>
                        <tbody>
                            <TableRowHeader />
                            <TableRow />
                            <TableRow />
                            <TableRow />
                            <TableRow />
                            <TableRow />
                            <TableRow />
                            <TableRow />
                        </tbody>
                    </table>
                    <CommentList data={this.state.data} />
                </div>
            );
        }
}

class TableRowHeader extends React.Component {
    render() {
        return (
            <tr>
                <TableHeader />
                <TableHeader />
                <TableHeader />
                <TableHeader />
                <TableHeader />
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
                <TableData />
                <TableData />
                <TableData />
                <TableData />
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