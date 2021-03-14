import style from './Link.module.css';

const Link = (
    { children }
) => {
    return (
        <li className={style.listItem}>
            <a href="#">{children}</a>
        </li>
    )
}

export default Link;