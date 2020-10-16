function solve(input) {
    const listProcessor = function() {
        let list = [];

        return {
            add: text => list.push(text),
            remove: text => list = list.filter(x => x != text),
            print: () => console.log(list.join()),
        }
    }

    let commandEngine = listProcessor();

    input
    .map(str => str.split(' '))
    .forEach(([command, value]) => commandEngine[command](value));
}

solve(['add peter', 'add george', 'add peter', 'remove peter','print']);