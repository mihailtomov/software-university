import './App.css';
import Header from './components/Header';
import Footer from './components/Footer';
import ArticleList from './components/ArticleList';

const articlesData = [
    { title: "Dark Wizard", description: "Kingdom of Wizards, descendant of Arka, he has an inferior physical condition but has an enormous power and can command attacking spells freely." },
    { title: "Dark Knight", description: "Kingdom of Knights, descendant of Lorencia. With a powerful strength and swordsmanship he can handle most of the close-range weapons. " },
    { title: "Fairy Elf", description: "Kingdom of Elves, descendant of Noria. A master of arrows and bows and she can command various spells." },
];

function App() {
    return (
        <div className="site-wrapper">
            <Header />

            <ArticleList articles={articlesData} />

            <Footer />
        </div>
    );
}

export default App;