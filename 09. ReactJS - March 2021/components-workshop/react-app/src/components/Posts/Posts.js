import { Component } from 'react';
import style from './Posts.module.css';
import Post from '../Post/Post.js';

class Posts extends Component {
    constructor() {
        super();

        this.state = {
            posts: []
        }
    }

    componentDidMount() {
        fetch('http://localhost:9999/api/origami')
            .then(res => res.json())
            .then(data => this.setState(() => ({ posts: data })));
    }

    render() {

        return (
            <div className={style.Posts}>
                {this.state.posts.map(x => <Post key={x._id} author={x.author} description={x.description} />)}
            </div>
        )
    }
}

export default Posts;