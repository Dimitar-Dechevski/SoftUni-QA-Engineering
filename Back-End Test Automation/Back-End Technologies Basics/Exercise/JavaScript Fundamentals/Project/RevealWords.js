function solve(words, input) {
    let wordArray = words.split(', ');
    let textArray = input.split(' ');

    for (let i = 0; i < wordArray.length; i++) {
        let wordLength = wordArray[i].length;
        let searchWord = '*'.repeat(wordLength);

        for (let k = 0; k < textArray.length; k++) {
            let element = textArray[k];

            if (element === searchWord) {
                input = input.replace(textArray[k], wordArray[i]);
            }
        }
    }

    console.log(input);
}

solve('great', 'softuni is ***** place for learning new programming languages');
solve('great, learning', 'softuni is ***** place for ******** new programming languages');