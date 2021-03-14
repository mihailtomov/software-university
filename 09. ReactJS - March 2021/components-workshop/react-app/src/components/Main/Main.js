import style from './Main.module.css';
import Posts from '../Posts/Posts.js';

const Main = () => {
    return (
        <main className={style.Main}>
            <h1>Sooooooooome Heading</h1>
            <Posts />
        </main>
    )
}

export default Main;