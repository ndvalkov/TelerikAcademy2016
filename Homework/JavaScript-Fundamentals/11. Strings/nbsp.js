function solve(args) {
    let str = args[0];

    let split = str.split(' ');

    split.forEach(function (st) {
        st = st.trim();
    });

    console.log(split.join('&nbsp;'));
}