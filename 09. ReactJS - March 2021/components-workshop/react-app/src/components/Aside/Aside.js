import Link from '../Link/Link.js';
import style from './Aside.module.css';

const Aside = () => {
    return (
        <aside className={style.Aside}>
            <ul>
                <Link>Going to 1</Link>
                <Link>Going to 2</Link>
                <Link>Going to 3</Link>
                <Link>Going to 4</Link>
                <Link>Going to 5</Link>
                <Link>Going to 6</Link>
                <Link>Going to 7</Link>
                <Link>Going to 8</Link>
                <Link>Going to 9</Link>
                <Link>Going to 10</Link>
                <Link>Going to 11</Link>
            </ul>
        </aside>
    )
}

export default Aside;