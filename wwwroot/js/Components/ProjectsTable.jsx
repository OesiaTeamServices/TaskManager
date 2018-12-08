class ProjectsTable extends React.Component {
    render() {
        constructor(props) {
            super(props);
            this.state = { data: [] };
        }

        componentWillMount() {
            const xhr = new XMLHttpRequest();
            xhr.open('get', this.props.url, true);
            xhr.onload = () => {
                const data = JSON.parse(xhr.responseText);
                this.setState({ data: data });
            };
            xhr.send();
        }
        //loadDataFromServer() {
        //    const xhr = new XMLHttpRequest();
        //    xhr.open('get', this.props.url, true);
        //    xhr.onload = () => {
        //        const data = JSON.parse(xhr.responseText);
        //        this.setState({ data: data });
        //    };
        //    xhr.send();
        //}

        //componentDidMount() {
        //    this.loadDataFromServer();
        //    window.setInterval(
        //        () => this.loadDataFromServer(),
        //        this.props.pollInterval,
        //    );
        //}

        return (
            <div className="ProjectsTable">
                <h1>Projects</h1>
                <TableHeader data={this.state.data} />
                <TableBode data={this.state.data}/>
            </div>
        );
    }
}

class TableHeader extends React.Component {
    render() {
        return (
            <InfoBlock data={this.props.data} />
        );
    }
}

class InfoBlock extends React.Component {
    render() {
  
        return (
            <div className="info">

                <h2 className="commentAuthor">{this.props.Description}</h2>
            </div>
        );
    }
}
ReactDOM.render(<ProjectsTable url="/ProjectsJson" />, document.getElementById('content'));