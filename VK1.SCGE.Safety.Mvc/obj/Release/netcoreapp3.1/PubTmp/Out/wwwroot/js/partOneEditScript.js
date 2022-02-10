window.addEventListener('load', () => {

    //Get carrier list to autocomplete
    const urlTest = `/Investigates/GetCarrierList`;
    $.get(urlTest).then(res => {
        $('#form-autocomplete').mdbAutocomplete({
            data: res
        });
    })

    //1 radio company
    const issub = $('#_isSub').val();
    const _radiocompany = $('#_radioCompay').val();
    const elementRadioCompany = document.getElementsByName('radioCompany');
    let _isOther = true;
    for (var i = 0; i < elementRadioCompany.length; i++) {
        if (elementRadioCompany[i].value === _radiocompany) {
            elementRadioCompany[i].checked = true;
            $('#form-autocomplete').prop('required', false);
            $('#form-autocomplete').prop('disabled', true);
            $('#form-autocomplete').removeClass('was-validated');
            _isOther = false;
        }
        if (issub === 'True') {
            elementRadioCompany[2].checked = true;
            $('#form-autocomplete').prop('required', true);
            $('#form-autocomplete').prop('disabled', false);
            $('#form-autocomplete').addClass('was-validated');
            _isOther = false;
        }
        if (_isOther) {
            elementRadioCompany[3].checked = true;
            $('#materialInline4').prop('required', true);
            $('#materialInline4').prop('disabled', false);
            $('#materialInline4').addClass('was-validated');
        }

    };

    //2 radio Shift
    const _radioshift = $('#_radioShift').val();
    const elementRadioShift = document.getElementsByName('radioShift');
    for (var s = 0; s < elementRadioShift.length; s++) {
        if (elementRadioShift[s].value === _radioshift) {
            elementRadioShift[s].checked = true;
        }

    };

    //3 radio CaseType
    const _radiocase = $('#_radioCaseType').val();
    const elementCase = document.getElementsByName('radioCase');
    for (var c = 0; c < elementCase.length; c++) {
        if (elementCase[c].value === _radiocase) {
            elementCase[c].checked = true;
        }

    };

    //4 radio Accident Mode
    const _radioaccident = $('#_radioAccidentMode').val();
    const elementAccident = document.getElementsByName('radioAccident');
    for (var a = 0; a < elementAccident.length; a++) {
        if (elementAccident[a].value === _radioaccident) {
            elementAccident[a].checked = true;
        }

    };

    //5 radio Transport
    const _transport = $('#_radioTransport').val();
    const elementTransport = document.getElementsByName('radioTransport');
    for (var t = 0; t < elementTransport.length; t++) {
        if (elementTransport[t].value === _transport) {
            elementTransport[t].checked = true;
        }
    };

    //6 radio Other
    const _other = $('#_radioOther').val();
    const elementOther = document.getElementsByName('radioOther');
    for (var o = 0; o < elementOther.length; o++) {
        if (elementOther[o].value === _other) {
            elementOther[o].checked = true;
        }
    };

    const _rank = $('#_radioRank').val();
    const elementRank = document.getElementsByName('radioRank');
    for (var e = 0; e < elementRank.length; e++) {
        if (elementRank[e].value === _rank) {
            elementRank[e].checked = true;
        }
    };

})