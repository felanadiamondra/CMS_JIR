// PRESTATION --------------

//Update Prestation
function UpdatePrestation() {
    var xhr = creerInstance();
    var str = document.ajax.code.value;
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
        xhr.open("GET", "/Prestation/AffichePrest?code=" + str, true);
        xhr.send();
    }
}
//----------------------------------------------------------------------------------------------------------------------------------------------

//Affiche Supprimer Prestation
function DeletePrestation() {
    var xhr = creerInstance();
    var str = document.ajax.code.value;
    if (str == "") {
        alert('Le champ doit etre nremplis pour pouvoir faire une supression');
    } else {
        if (confirm("Voulez-vous supprimer la prestation < " + str + " > ?")) {
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
            xhr.open("GET", "/Prestation/DeletePrest?code=" + str, true);
            xhr.send();
        } else {
            alert("Supression annulée !");
        }
    }
}
//---------------------------------------------------------------------------------------------------------------------------------------------

//Affiche Ajout Prestation
function FonctionAjoutPrest() {
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
    xhr.open("GET", "/Prestation/AjouterPrest", true);
    xhr.send();
}
//----------------------------------------------------- FIN PRESTATION ---------------------------------------------------------------------------