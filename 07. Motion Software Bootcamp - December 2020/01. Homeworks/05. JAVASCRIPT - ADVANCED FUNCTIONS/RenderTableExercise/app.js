import { data } from './MOCK_DATA.js';

(function (data, document) {
    const keys = Object.keys(data[0]);

    function createTag(tag, content) {
        return `<${tag}>
        ${Array.isArray(content) ? content.join('')
                : content}
 </${tag}>`;
    }

    function createSingleTag(tag, attr, value) {
        return `<${tag} ${attr}="${value}" />`;
    }

    function renderDecorator(map, renderer, key, content) {
        if (typeof map[key] === 'function') {
            return renderer(map[key](content));
        }
        return renderer(content);
    }

    const renderTable = createTag.bind(undefined, 'table');
    const renderTHead = createTag.bind(undefined, 'thead');
    const renderTBody = createTag.bind(undefined, 'tbody');
    const renderTr = createTag.bind(undefined, 'tr');
    const renderTh = createTag.bind(undefined, 'th');
    const renderTd = createTag.bind(undefined, 'td');
    const renderUl = createTag.bind(undefined, 'ul');
    const renderLi = createTag.bind(undefined, 'li');

    const keysMap = {
        avatar: content => createSingleTag('img', 'src', content),
        friends: friendsArr => renderUl(friendsArr.map(fr => renderLi(`${fr['first_name']} ${fr['last_name']}`)))
    }
    
    const decoratedRenderTd = renderDecorator.bind(
        undefined,
        keysMap,
        renderTd,
    )

    const result = renderTable(
        renderTHead(
            renderTr(keys.map(key => renderTh(key)))
        ) +
        renderTBody(data.map(row => renderTr(Object.keys(row).map(key => decoratedRenderTd(key, row[key]))))
        )
    )

    document.getElementById('app').innerHTML = result;
}(data.slice(0, 20), document))



