window.addEventListener('load', () => {
    //1 radio route
    const _radioroute = $('#_radioRoute').val();
    const elementRoute = document.getElementsByName('radioRoute');
    for (var i = 0; i < elementRoute.length; i++) {
        if (elementRoute[i].value === _radioroute) {
            elementRoute[i].checked = true;
        }
    };

    //2 radio IsProduct
    const _isproduct = $('#_radioIsProduct').val();
    const elementProduct = document.getElementsByName('radioIsProduct');
    for (var p = 0; p < elementProduct.length; p++) {
        if (elementProduct[p].value === _isproduct) {
            elementProduct[p].checked = true;
        }
    };

    //3 radio IsProductDamage
    const _isproductdamage = $('#_radioIsDamage').val();
    const elementProductDamage = document.getElementsByName('radioIsDamage');
    for (var pd = 0; pd < elementProductDamage.length; pd++) {
        if (elementProductDamage[pd].value === _isproductdamage) {
            elementProductDamage[pd].checked = true;
        }
    };

    //4 radio effect
    const _effect = $('#_radioEffect').val();
    const elementEffect = document.getElementsByName('radioEffect');
    for (var f = 0; f < elementEffect.length; f++) {
        if (elementEffect[f].value === _effect) {
            elementEffect[f].checked = true;
        }
    };

    //5 radio empInjure
    const _empinjure = $('#_radioEmpInjure').val();
    const elementEmpInjure = document.getElementsByName('radioEmpInjure');
    for (var emp = 0; emp < elementEmpInjure.length; emp++) {
        if (elementEmpInjure[emp].value === _empinjure) {
            elementEmpInjure[emp].checked = true;
        }
    };

    //6 radio partiesInjure
    const _partiesInjure = $('#_radioPartiesInjure').val();
    const elementParitesInjure = document.getElementsByName('radioPartiesInjure');
    for (var pa = 0; pa < elementParitesInjure.length;pa++) {
        if (elementParitesInjure[pa].value === _partiesInjure) {
            elementParitesInjure[pa].checked = true;
        }
    };

    //7 radio thirdPartiesInjure
    const _thirdPartyInjure = $('#_radioThirdParty').val();
    const elementThirdParitesInjure = document.getElementsByName('radioThirdParty');
    for (var th = 0; th < elementParitesInjure.length; th++) {
        if (elementThirdParitesInjure[th].value === _thirdPartyInjure) {
            elementThirdParitesInjure[th].checked = true;
        }
    };

    //8 radio truckDamage
    const _truckDamage = $('#_radioTruckDamage').val();
    const elementTruckDamage = document.getElementsByName('radioTruckDamage');
    for (var td = 0; td < elementTruckDamage.length; td++) {
        if (elementTruckDamage[td].value === _truckDamage) {
            elementTruckDamage[td].checked = true;
        }
    };

    //9 radio partiesDamage
    const _partiesdamage = $('#_radioPartyDamage').val();
    const elementPartiesDamage = document.getElementsByName('radioPartyDamage');
    for (var pt = 0; pt < elementPartiesDamage.length; pt++) {
        if (elementPartiesDamage[pt].value === _partiesdamage) {
            elementPartiesDamage[pt].checked = true;
        }
    };

    //10 radio equipmentDamage
    const _equipmentdamage = $('#_radioEquipmentDamage').val();
    const elementEquipDamage = document.getElementsByName('radioEquipmentDamage');
    for (var eq = 0; eq < elementEquipDamage.length; eq++) {
        if (elementEquipDamage[eq].value === _equipmentdamage) {
            elementEquipDamage[eq].checked = true;
        }
    };

    //11 radio camera
    const _camera = $('#_radioCamera').val();
    const elementCamera = document.getElementsByName('radioCamera');
    for (var ca = 0; ca < elementCamera.length; ca++) {
        if (elementCamera[ca].value === _camera) {
            elementCamera[ca].checked = true;
        }
    };

    //12 radio truckInspection
    const _istruckinspection = $('#_radioIsNormal').val();
    const elementIsTruckInspection = document.getElementsByName('radioIsNormal');
    for (var ti = 0; ti < elementIsTruckInspection.length; ti++) {
        if (elementIsTruckInspection[ti].value === _istruckinspection) {
            elementIsTruckInspection[ti].checked = true;
        }
    };

    //13 radio isGps
    const _gps = $('#_radioIsGps').val();
    const elementIsGps = document.getElementsByName('radioIsGps');
    for (var gps = 0; gps < elementIsGps.length; gps++) {
        if (elementIsGps[gps].value === _gps) {
            elementIsGps[gps].checked = true;
        }
    };

    //14 radio isCCTV
    const _cctv = $('#_radioIsCctv').val();
    const elementIsCCtv = document.getElementsByName('radioIsCctv');
    for (var cctv = 0; cctv < elementIsCCtv.length; cctv++) {
        if (elementIsCCtv[cctv].value === _cctv) {
            elementIsCCtv[cctv].checked = true;
        }
    };

    //15 radio issafetycourse
    const _safety = $('#_radioIsPassSafety').val();
    const elementIsSafety = document.getElementsByName('radioIsPassSafety');
    for (var safety = 0; safety < elementIsSafety.length; safety++) {
        if (elementIsSafety[safety].value === _safety) {
            elementIsSafety[safety].checked = true;
        }
    };

    //16 radio isSDC
    const _sdc = $('#_radioIsPassSDC').val();
    const elementIsSDC = document.getElementsByName('radioIsPassSDC');
    for (var sdc = 0; sdc < elementIsSDC.length; sdc++) {
        if (elementIsSDC[sdc].value === _sdc) {
            elementIsSDC[sdc].checked = true;
        }
    };

    //17 radio isAlcohol
    const _alcohol = $('#_radioIsAlcohol').val();
    const elementIsAlcohol = document.getElementsByName('radioIsAlcohol');
    for (var al = 0; al < elementIsAlcohol.length; al++) {
        if (elementIsAlcohol[al].value === _alcohol) {
            elementIsAlcohol[al].checked = true;
        }
    };
})