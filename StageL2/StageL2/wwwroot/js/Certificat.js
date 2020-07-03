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

function storing(data) {
    var element = document.getElementById("zonetext");
    element.innerHTML = data;
}
//----------------------------------------------------------------------------------------------------------------------------------------

//Ajout certificat
function Ajoutcert() {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                alert("Formulaire prête ! ");
                storing(xhr.responseText);
            }
            else {
                document.getElementById("zonetext").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Certificat/Addcertificat", true);
    xhr.send();
}
//-----------------------------------------------------------------------------------------------------------------------------------------

//Mise à jour certificat
function ModifierCert() {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                alert("Formulaire prête ! ");
                storing(xhr.responseText);
            }
            else {
                document.getElementById("zonetext").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Certificat/UpdateCert", true);
    xhr.send();
}
//--------------------------------------------------------------------------------------------------------------------------------------

//Afficher Agent (recherche)
function getAgent(data) {
    var element = document.getElementById("affichage1");
    element.innerHTML = data;
}

function ListeFamilleJDE(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getAgent(xhr.responseText);
            }
            else {
                document.getElementById("affichage1").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Certificat/AfficheFamille?agent=" + str, true);
    xhr.send();
}