//Avoir le patient séléctionné
function Patient(nb) {
    var freqmala = document.getElementsByTagName('TR')[nb].cells[0].textContent;
    var nom = document.getElementsByTagName('TR')[nb].cells[2].textContent;
    var age = document.getElementsByTagName('TR')[nb].cells[3].textContent;
    var sexe = document.getElementsByTagName('TR')[nb].cells[4].textContent;
    var prest = document.getElementsByTagName('TR')[nb].cells[6].textContent;
    document.getElementById('freqmala').value = freqmala;
    document.getElementById('nom').value = nom;
    document.getElementById('age').value = age;
    document.getElementById('sexe').value = sexe;
    document.getElementById('prest').value = prest;
}