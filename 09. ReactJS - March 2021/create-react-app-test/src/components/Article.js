import LikeArticle from './LikeArticle';

const Article = (props) => {
    return (
        <article>
            <h2>{props.title}</h2>
            <p>{props.description}</p>
            <LikeArticle />
        </article>
    );
}

export default Article;