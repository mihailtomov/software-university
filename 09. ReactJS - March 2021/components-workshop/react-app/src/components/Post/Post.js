import style from './Post.module.css';
import PostAuthor from '../PostAuthor/PostAuthor.js';

const Post = () => {
    return (
        <div className={style.Post}>
            <img src="blue-origami-bird.png" alt="blue origami"/>
            <p className={style.description}>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sed quae esse ipsam sint saepe possimus autem odit aliquid nihil doloribus quia reprehenderit blanditiis ex minima officiis quibusdam reiciendis, nemo, aliquam repellat asperiores! Reiciendis quis ex necessitatibus laudantium, ipsum, at eaque beatae expedita consectetur a nemo ipsam? Unde nesciunt corporis magnam aliquid amet iusto, rerum eveniet aspernatur sit quidem, recusandae dolores.</p>
            <PostAuthor />
        </div>
    )
}

export default Post;