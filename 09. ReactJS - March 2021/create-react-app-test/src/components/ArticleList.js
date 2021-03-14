import { Component } from 'react';
import Article from './Article';

class ArticleList extends Component {
    render() {
        const articles = this.props.articles.map(
            a => <Article title={a.title} description={a.description} key={a.title} />
        );

        return (
            <main className="main">
                {articles}
            </main>
        );
    }
}

export default ArticleList;