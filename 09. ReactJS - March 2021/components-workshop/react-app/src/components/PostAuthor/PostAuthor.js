import style from './PostAuthor.module.css';

const PostAuthor = () => {
    return (
        <div className={style['author-container']}>
            <span>
                <small>Author:</small>
                    Some Anonymous
            </span>
        </div>
    )
}

export default PostAuthor;