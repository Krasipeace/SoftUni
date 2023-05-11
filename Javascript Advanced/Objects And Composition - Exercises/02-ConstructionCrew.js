function constructionCrew(input) {

    const worker = {
        weight: Number(input.weight),
        experience: Number(input.experience),
        levelOfHydrated: Number(input.levelOfHydrated),
        dizziness: Boolean(input.dizziness)
    };

    if (worker.dizziness) {
        worker.levelOfHydrated += 0.1 * worker.weight * input.experience;
        worker.dizziness = false;
    }

    return worker;
}

console.log(constructionCrew({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}));