function splitWordsByUpperCase(text) {
    const words = text.split(/(?=[A-Z])/);
    console.log(words.join(', '));
}

splitWordsByUpperCase('SplitMeIfYouCanHaHaYouCantOrYouCan') // Split, Me, If, You, Can, Ha, Ha, You, Cant, Or, You, Can
splitWordsByUpperCase('HoldTheDoor') // Hold, The, Door
splitWordsByUpperCase('ThisIsSoAnnoyingToDo') // This, Is, So, Annoying, To, Do