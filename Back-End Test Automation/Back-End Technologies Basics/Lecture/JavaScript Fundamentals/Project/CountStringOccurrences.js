function solve(input, word) {
    let count = 0;
    let text = input.split(' ');

    for (let i = 0; i < text.length; i++) {
        let string = text[i];

        if (string === word) {
            count++;
        }
    }

    console.log(count);
}

solve('This is a word and it also is a sentence', 'is');
solve('softuni is great place for learning new programming languages', 'softuni');