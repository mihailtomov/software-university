const domElement = document.getElementById('root');

// const reactElement = React.createElement(
//     'header',
//     {},
//     React.createElement('h1', {}, 'Hello from React Element!'),
//     React.createElement('h2', {}, 'The Best Framework Ever!')
// );

const reactJSXElement = <header>
    <h1>Hello from React JSX Element!</h1>
    <h2>Pretty cool, eh!</h2>
    <ul>
        <li>1</li>
        <li>2</li>
        <li>3</li>
    </ul>
</header>

ReactDOM.render(reactJSXElement, domElement);