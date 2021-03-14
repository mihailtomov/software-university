import style from './Navigation.module.css';

import Link from '../Link/Link.js';

const Navigation = () => {
    return (
        <nav className={style.Navigation}>
            <ul>
                <img src="white-origami-bird.png" alt="white-origami"/>
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
        </nav>
    )
}

export default Navigation;