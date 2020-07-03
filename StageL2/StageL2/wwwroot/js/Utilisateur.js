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

//Ajout Utilisateur
function AjoutUser() {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                alert("Formulaire prête !");
                storing(xhr.responseText);
            }
            else {
                document.getElementById("zonetext").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Utilisateur/AddUser", true);
    xhr.send();
}

//Affiche Utilisateur à modifier
function GetCutomerName() {
    var xhr = creerInstance();
    var str = document.ajax.id.value;
    if (str == "") {
        alert('Veuillez-remplir ce champ pour pouvoir faire une modification');
    } else {
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    alert("Formulaire prête !");
                    storing(xhr.responseText);
                }
                else {
                    document.getElementById("zonetext").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
                }
            }
        };
        xhr.open("GET", "/Utilisateur/AfficheUser?identifiant=" + str, true);
        xhr.send();
    }
}

//Affiche prestation (select)
function GetPrestuser(data) {
    var element = document.getElementById("AffichePrestation");
    element.innerHTML = data;
}

function GetPrestation(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                GetPrestuser(xhr.responseText);
            }
            else {
                document.getElementById("AffichePrestation").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Utilisateur/AfficherPrestUser?CodeAct=" + str, true);
    xhr.send();
}