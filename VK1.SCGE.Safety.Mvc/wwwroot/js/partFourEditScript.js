window.addEventListener('load', () => {
    //1 radio company
    const _incidentRoad = $('#_radioIncidentRoad').val();
    const elementIncidentRoad = document.getElementsByName('radioIncidentRoad');
    for (var i = 0; i < elementIncidentRoad.length; i++) {
        if (elementIncidentRoad[i].value === _incidentRoad) {
            elementIncidentRoad[i].checked = true;
        }

    };

   

})