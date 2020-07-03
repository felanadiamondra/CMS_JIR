//Affiche type société
function gettype(data) {
    var element = document.getElementById("afficheType");
    element.innerHTML = data;
}

function AfficheType(str){
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                gettype(xhr.responseText);
            }
            else {
                document.getElementById("afficheType").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherTypeSTE?codeSte=" + str, true);
    xhr.send();
}
//-------------------------------------------------------------------------------------------------------------------------------------

//Calcul Numero patient
function getNum(data) {
    var element = document.getElementById("affichageNum");
    element.innerHTML = data;
}

function CompteNum(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getNum(xhr.responseText);
            }
            else {
                document.getElementById("affichageNum").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherNumero?codeMed=" + str, true);
    xhr.send();
}
//--------------------------------------------------------------------------------------------------------------------------------------

//Afficher numero modifier fréquentation
function getNumero(data) {
    var element = document.getElementById("afficherNumero");
    element.innerHTML = data;
}

function CompteNumero(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getNumero(xhr.responseText);
            }
            else {
                document.getElementById("afficherNumero").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherNum?codeMed=" + str, true);
    xhr.send();
}

//------------------------------------------------------------------------------------------------------------------------------------

//Verifie la remise des certificats
function getCert(data) {
    var element = document.getElementById("certificat");
    element.innerHTML = data;
}

function AfficheCert() {
    var xhr = creerInstance();
    var str = document.frequentation.nomPat.value;
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getCert(xhr.responseText);
            }
            else {
                document.getElementById("certificat").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherCert?nom=" + str, true);
    xhr.send();
}
//--------------------------------------------------------------------------------------------------------------------------------------------

//Affiche famille JDE (table)
function getJDE(data) {
    var element = document.getElementById("afficheJDE");
    element.innerHTML = data;
}

function AfficheJDE(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                alert("Liste prête !")
                getJDE(xhr.responseText);
            }
            else {
                document.getElementById("afficheJDE").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherJDE?matricule=" + str, true);
    xhr.send();
}
//---------------------------------------------------------------------------------------------------------------------------------------

//Afficher Agent (recherche)
function get(data) {
    var element = document.getElementById("affichage1");
    element.innerHTML = data;
}

function RechercheAgent(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                get(xhr.responseText);
            }
            else {
                document.getElementById("affichage1").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherAgent?agent=" + str, true);
    xhr.send();
}
//-----------------------------------------------------------------------------------------------------------------------------------

//Afficher Médecin (recherche)
function get2(data) {
    var element = document.getElementById("affichage2");
    element.innerHTML = data;
}

function RechercheMedecin(str2) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                get2(xhr.responseText);
            }
            else {
                document.getElementById("affichage2").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherMedecin?med=" + str2, true);
    xhr.send();
}
//------------------------------------------------------------------------------------------------------------------------------------

//Calcul Age
function dude(data) {
    var element = document.getElementById("afficheAge");
    element.innerHTML = data;
}

function GetAge() {
    var xhr = creerInstance();
    var str = document.frequentation.dateNais.value;
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                dude(xhr.responseText);
            }
            else {
                document.getElementById("afficheAge").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherAge?datenais=" + str, true);
    xhr.send();
}
//----------------------------------------------------------------------------------------------------------------------------------------------

//Affiche liste prestation (select)
function getPrest(data) {
    var element = document.getElementById("affichePrest");
    element.innerHTML = data;
}

function ListePrest(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getPrest(xhr.responseText);
            }
            else {
                document.getElementById("affichePrest").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherPrest?codeAct=" + str, true);
    xhr.send();
}
//-------------------------------------------------------------------------------------------------------------------------------------

//Affiche liste medecin (select)
function getMed(data) {
    var element = document.getElementById("afficheMed");
    element.innerHTML = data;
}

function ListeMed(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getMed(xhr.responseText);
            }
            else {
                document.getElementById("afficheMed").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherMed?codePrest=" + str, true);
    xhr.send();
}
//------------------------------------------------------------------------------------------------------------------------------------

//Avoir la fréquentation à modifier
function UpdateFreq(data) {
    var element = document.getElementById("Update");
    element.innerHTML = data;
}

function GetID(nb) {
    var xhr = creerInstance();
    var id = document.getElementsByTagName('TR')[nb].cells[0].textContent;
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                UpdateFreq(xhr.responseText);
            }
            else {
                document.getElementById("Update").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/GetFreq?ID=" + id, true);
    xhr.send();
}
//-----------------------------------------------------------------------------------------------------------------------------------------------------------

//Remplir formulaire acceuil
function Famille(nb) {
    var nom = document.getElementsByTagName('TR')[nb].cells[4].textContent;
    var sa = document.getElementsByTagName('TR')[nb].cells[6].textContent;
    var datenais = document.getElementsByTagName('TR')[nb].cells[7].textContent;
    document.getElementById('nom').value = nom;
    document.getElementById('sa').value = sa;
    document.getElementById('datenais').value = datenais;
}

//Remplir formulaire (Medecin)
function PatientMed(nb) {
    var num = document.getElementsByTagName('TR')[nb].cells[0].textContent;
    var nom = document.getElementsByTagName('TR')[nb].cells[1].textContent;
    var age = document.getElementsByTagName('TR')[nb].cells[2].textContent;
    var prest = document.getElementsByTagName('TR')[nb].cells[3].textContent;
    var nat = document.getElementsByTagName('TR')[nb].cells[4].textContent;
    var temp = document.getElementsByTagName('TR')[nb].cells[5].textContent;
    var tamax = document.getElementsByTagName('TR')[nb].cells[6].textContent;
    var tamin = document.getElementsByTagName('TR')[nb].cells[7].textContent;
    var puls = document.getElementsByTagName('TR')[nb].cells[8].textContent;
    var poids = document.getElementsByTagName('TR')[nb].cells[9].textContent;
    var pc = document.getElementsByTagName('TR')[nb].cells[10].textContent;
    var alb = document.getElementsByTagName('TR')[nb].cells[11].textContent;
    var gly = document.getElementsByTagName('TR')[nb].cells[12].textContent;
    document.getElementById('num').value = num;
    document.getElementById('nom').value = nom;
    document.getElementById('age').value = age;
    document.getElementById('nat').value = nat;
    document.getElementById('prest').value = prest;
    document.getElementById('temp').value = temp;
    document.getElementById('tamin').value = tamin;
    document.getElementById('tamax').value = tamax;
    document.getElementById('puls').value = puls;
    document.getElementById('poids').value = poids;
    document.getElementById('pc').value = pc;
    document.getElementById('alb').value = alb;
    document.getElementById('gly').value = gly;
}

//Modifier freq
function UpdateFreq(data) {

    var element = document.getElementById("Update");
    element.innerHTML = data;
}

function GetID() {
    var xhr = creerInstance();
    var id = document.ajx.id.value;
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                UpdateFreq(xhr.responseText);
            }
            else {
                document.getElementById("Update").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/GetFreq?ID=" + id, true);
    xhr.send();
}


//Recherche patient
function getpat(data) {
    var element = document.getElementById("affichagePat");
    element.innerHTML = data;

}

function RecherchePatient(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getpat(xhr.responseText);
            }
            else {
                document.getElementById("affichagePat").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherPat?pat=" + str, true);
    xhr.send();
}