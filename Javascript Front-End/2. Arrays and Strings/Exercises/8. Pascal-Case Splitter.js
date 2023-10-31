function solve(text) {
    const words = text.split(/(?=[A-Z])/);
    console.log(words.join(', '));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan') // Split, Me, If, You, Can, Ha, Ha, You, Cant, Or, You, Can
solve('HoldTheDoor') // Hold, The, Door
solve('ThisIsSoAnnoyingToDo') // This, Is, So, Annoying, To, Do