function solve(input) {
    let digitCount = 0;
    let isSpecialCharacter = false;
    let isValid = true;

    for (let i = 0; i < input.length; i++) {
        let symbol = input.charCodeAt(i);

        if (symbol >= 48 && symbol <= 57) {
            digitCount++;
        } else if (symbol >= 65 && symbol <= 90) {
            continue;
        } else if (symbol >= 97 && symbol <= 122) {
            continue;
        } else {
            isSpecialCharacter = true;
        }

    }

    if (input.length < 6 || input.length > 10) {
        console.log(`Password must be between 6 and 10 characters`);
        isValid = false;
    }
    if (isSpecialCharacter) {
        console.log(`Password must consist only of letters and digits`);
        isValid = false;
    }
    if (digitCount < 2) {
        console.log(`Password must have at least 2 digits`);
        isValid = false;
    }
    if (isValid) {
        console.log(`Password is valid`);
    }
}

solve('logIn');
solve('MyPass123');
solve('Pa$s$s');
