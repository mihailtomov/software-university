function solve(input) {
    const commandsInterpreter = {
        add: (arr, arg) => arr.push(arg),
        remove: (arr, arg) => {
            arr.forEach((str, i) => {
                if (str == arg) {
                    arr.splice(i, 1);
                }
            })
        },
        print: (arr, _) => console.log(arr.join(',')),
    }

    let arr = [];

    input.forEach(str => {
        const [command, arg] = str.split(' ');
        commandsInterpreter[command](arr, arg);
    })
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);