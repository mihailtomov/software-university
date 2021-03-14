import style from './Posts.module.css';
import Post from '../Post/Post.js';

const Posts = () => {
    return (
        <div className={style.Posts}>
            <Post />
            <Post />
            <Post />
        </div>
    )
}

export default Posts;