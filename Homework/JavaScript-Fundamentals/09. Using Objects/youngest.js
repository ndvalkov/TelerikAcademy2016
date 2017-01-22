function solve(args) {
    var people = [];

    for (var i = 0, len = args.length; i < len; i += 3) {
        people.push({
            firstname: args[i],
            lastname: args[i + 1],
            age: +args[i + 2]
        });
    }

    findYoungest(people);

    function findYoungest(people) {
        people = people || [];

        var youngestName = '';
        var youngestAge = 108;
        for (var i = 0, len = people.length; i < len; i += 1) {
            if (people[i].age < youngestAge) {
                youngestAge = people[i].age;
                youngestName = people[i].firstname + ' ' + people[i].lastname;
            }
        }

        console.log(youngestName);
    }
}