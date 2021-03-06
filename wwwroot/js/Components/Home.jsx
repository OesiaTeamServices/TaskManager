﻿class InputBox extends React.Component {
    render() {
        return (
            <input type={this.props.type} placeholder={this.props.message} />
        );
    }
}

class Button extends React.Component {
    render() {
        return (
            <button name="SubmitBtn">Log In</button>
        );
    }
}



class CommentBox extends React.Component {
    render() {
        return (
            <div>
                <Header />
                <InputBox type="text" message="your name" />
                <InputBox type="password" message="your password" />
                <Button />

            </div>
        );
    }
}

class Header extends React.Component {
    render() {
        return (
            <div>
                <img className="oesia-logo"
                    src="http://grupooesia.com/wp-content/uploads/2015/11/logo_oesia_011.png"
                    alt="Grapefruit slice atop a pile of other slices" />
            </div>
        );
    }
}

//class Footer extends React.Component {
//    render() {
//        return (
//            <footer>
//                <p className="footerPar"> ©GRUPO OESÍA 2018. ALL RIGHTS RESERVED.</p>
//            </footer>

//        );
//    }
//}

ReactDOM.render(<CommentBox />, document.getElementById('content'));