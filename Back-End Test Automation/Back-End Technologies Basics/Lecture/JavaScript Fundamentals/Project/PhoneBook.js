function solve(input) {
    let phoneBook = {};

    for (let i = 0; i < input.length; i++) {
        let tokens = input[i].split(' ');
        let name = tokens[0];
        let phone = tokens[1];
        phoneBook[name] = phone;
    }

    for (let key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`);
    }

}

solve(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344']);
solve(['George 0552554', 'Peter 087587', 'George 0453112', 'Bill 0845344']);