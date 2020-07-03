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

function store(data) {
    var element = document.getElementById("textHint");
    element.innerHTML = data;
}
//-----------------------------------------------------------------------------------------------------------------------------------------------

//Affiche Modifier Société
function FonctionGetSte() {
    var xhr = creerInstance();
    var str = document.ajax2.code.value;
    if (str == "") {
        alert('Veuillez-remplir ce champ pour pouvoir faire une modification !');
    } else {
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    alert("Formulaire prête !");
                    store(xhr.responseText);
                }
                else {
                    document.getElementById("textHint").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
                }
            }
        };
        xhr.open("GET", "/Societe/AfficheSte?identifiant=" + str, true);
        xhr.send();
    }
}
//----------------------------------------------------------------------------------------------------------------------------------------------

//Affiche Supprimer Société
function FonctionDeleteSte() {
    var xhr = creerInstance();
    var str = document.ajax2.code.value;
    if (str == "") {
        alert('Veuillez-remplir ce champ pour pouvoir faire une modification');
    } else {
        if (confirm("Voulez-vous supprimer la prestation < " + str + " > ?")) {
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4) {
                    if (xhr.status == 200) {
                        store(xhr.responseText);
                    }
                    else {
                        document.getElementById("textHint").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
                    }
                }
            };
            xhr.open("GET", "/Societe/DeleteSte?identifiant=" + str, true);
            xhr.send();
        }
        else {
            alert("Supression annulée !");
        }
    }
}
//-----------------------------------------------------------------------------------------------------------------------------------------------

//Affiche Ajouter Société
function AjoutSte() {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                alert("Formulaire prête !");
                store(xhr.responseText);           
            }
            else {
                document.getElementById("textHint").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Societe/AddSte", true);
    xhr.send();
}
//---------------------------------------------------------------------------------------------------------------------------------------------