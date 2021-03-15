import style from './Post.module.css';
import PostAuthor from '../PostAuthor/PostAuthor.js';

const Post = (
    {
        author, 
        description
    }
) => {
    return (
        <div className={style.Post}>
            <img src="blue-origami-bird.png" alt="blue origami"/>
            <p className={style.description}>{description}</p>
            <PostAuthor author={author} />
        </div>
    )
}

export default Post;