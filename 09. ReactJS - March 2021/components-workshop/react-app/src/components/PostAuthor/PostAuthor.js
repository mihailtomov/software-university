import style from './PostAuthor.module.css';

const PostAuthor = (
    { author }
) => {
    return (
        <div className={style['author-container']}>
            <span>
                <small>Author:</small>
                    {author}
            </span>
        </div>
    )
}

export default PostAuthor;