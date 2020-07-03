// ACTIVITE --------------

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

function storing(data) {
    var element = document.getElementById("zonetext");
    element.innerHTML = data;
}

//Ajouter activité
function FonctionAjoutAct() {
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
    xhr.open("GET", "/Activite/AjouterAct", true);
    xhr.send();
}

//Update activité
function UpdateAct() {
    var xhr = creerInstance();
    var str = document.ajax.code.value;
    if (str == "") {
        alert('Champ vide!');
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
        xhr.open("GET", "/Activite/AfficheAct?code=" + str, true);
        xhr.send();
    }
}

//Supprimer activité
function DeleteAct() {
    var xhr = creerInstance();
    var str = document.ajax.code.value;
    if (str == "") {
        alert('Champ vide!');
    } else {
        if (confirm("Voulez-vous supprimer l'activité < "+ str +" > ?")) {
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4) {
                    if (xhr.status == 200) {
                        storing(xhr.responseText);
                    }
                    else {
                        document.getElementById("zonetext").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
                    }
                }
            };
            xhr.open("GET", "/Activite/DeleteAct?code=" + str, true);
            xhr.send();
        } else {
            alert('Supression annulée !');
        }
    }
}
//----------------------------------------------------- FIN PRESTATION ---------------------------------------------------------------------------