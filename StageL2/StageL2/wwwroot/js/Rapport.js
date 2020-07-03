//Créer instance
function creerInstance() {
    var req = null;
    if (window.XMLHttpRequest) {
        req = new XMLHttpRequest();
    } else if (window.ActiveXObject) {
        try {
            req = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                req = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {
                alert("XHR not created");
            }
        }
    }
    return req;
}

function avoirAnnee(data) {
    var element = document.getElementById("rapport");
    element.innerHTML = data;
}

function RapporterChart(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                alert("Rapport de l'année : " + str + " prêt !")
                avoirAnnee(xhr.responseText);
            }
            else {
                document.getElementById("rapport").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Rapport/AfficheRapport?anneeR=" + str, true);
    xhr.send();
}


