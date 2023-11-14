function extractHashtags(text) {
    const words = text.split(' ');
    const specialWords = words.filter(w => w.startsWith('#'));

    for (const word of specialWords) {
        const isValid = validateWord(word);

        if (isValid) {
            console.log(`${word.substring(1)}`);
        }
    }

    function validateWord(word) {
        const pattern = /#[A-Za-z]+/g;
        const match = word.match(pattern);

        return match !== null && match[0] === word;
    }
}

extractHashtags('Nowadays everyone uses # to tag a #special word in #socialMedia'); // #special #socialMedia
extractHashtags('The symbol # is known #variously in English-speaking #regions as the #number sign'); // #variously #regions #number