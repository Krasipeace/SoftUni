function filterSongs(input) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let numberOfSongs = input.shift();
    let type = input.pop();

    let songs = input.slice(0, numberOfSongs).map(i => {
        let [typeList, name, time] = i.split('_');
        return new Song(typeList, name, time);
    });

    songs.filter(i => type === 'all' || i.typeList === type).forEach(i => console.log(i.name));
}

filterSongs([3, 'favourite_DownTown_3:14', 'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01', 'favourite']);  // DownTown Kiss Smooth Criminal