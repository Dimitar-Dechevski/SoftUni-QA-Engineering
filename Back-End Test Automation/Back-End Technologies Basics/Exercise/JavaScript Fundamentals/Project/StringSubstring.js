function solve(word, input) {
    input = input.toLowerCase();
    let text = input.split(' ');
    let searchedWord = word.toLowerCase();

    if (text.includes(searchedWord)) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }

}

solve('javascript', 'JavaScript is the best programming language');
solve('python', 'JavaScript is the best programming language');