import { Component } from 'react';

class LikeArticle extends Component {
    constructor() {
        super();

        this.state = {
            isLiked: false,
        };
    }

    setLiked() {
        this.setState({ isLiked: true });
    }

    render() {
        if (!this.state.isLiked) {
            return (
                <button onClick={this.setLiked.bind(this)}>Like</button>
            );
        } else {
            return (
                <p>Thank you for liking this article!</p>
            );
        }
    }
}

export default LikeArticle;