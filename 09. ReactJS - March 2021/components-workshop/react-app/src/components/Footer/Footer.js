import style from './Footer.module.css';
import Link from '../Link/Link.js';

const Footer = () => {
    return (
        <footer className={style.Footer}>
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
                <img src="blue-origami-bird-flipped.png" alt="flipped-origami"/>
            </ul>
            <p>Software University &copy; 2019</p>
        </footer>
    )
}

export default Footer;