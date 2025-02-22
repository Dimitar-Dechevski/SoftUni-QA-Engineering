function solve(input) {
    let tokens = input.split(' ');
    let count = 0;
    let array = [];

    while (tokens.length > 0) {
        let element = tokens[0];
        count++;

        for (let i = 1; i < tokens.length; i++) {
            let component = tokens[i];
            
            if (element.toLowerCase() === component.toLowerCase()) {
                count++;
            }
        }

        if (count % 2 !== 0) {
            if (!array.includes(element.toLowerCase())) {
                array.push(element.toLowerCase());
            }
        }

        for (let k = 0; k < tokens.length; k++) {
            if (tokens[k].toLowerCase() === element.toLowerCase()) {
                tokens.splice(k, 1);
                k--;
            }
        }

        count = 0;
    }

    console.log(array.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
solve('Cake IS SWEET is Soft CAKE sweet Food');