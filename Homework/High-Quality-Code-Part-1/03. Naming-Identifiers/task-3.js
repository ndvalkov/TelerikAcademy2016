function onClick(ev, args) {
    var windowObject = window,
        codeName = windowObject.navigator.appCodeName,
        isMozilla = codeName == "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}