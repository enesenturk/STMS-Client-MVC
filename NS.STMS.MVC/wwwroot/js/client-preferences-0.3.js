
function getPreferredLanguage() {

    var language = navigator.language || navigator.userLanguage;

    if (language == "tr-TR") {
        return language;
    }
    else {
        return "en-US";
    }
}
