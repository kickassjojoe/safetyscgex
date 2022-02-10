
window.addEventListener('load', () => {

    const _accmode = $("#_accidentmode").val();
    const _actualUnsafeItem = $("#_actualUnsafeItem").val();
    const arrUnsafeItem = _actualUnsafeItem.split(',');

    //1 check if match actual unsafe item
    const element1 = document.getElementsByName('c100');
    for (var e1 = 0; e1 < element1.length; e1++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element1[e1].value === '100_' + item) {
                element1[e1].checked = true;
            }
        })
    }
    const element2 = document.getElementsByName('c200');
    for (var e2 = 0; e2 < element2.length; e2++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element2[e2].value === '200_' + item) {
                element2[e2].checked = true;
            }
        })
    }
    const element3 = document.getElementsByName('c300');
    for (var e3 = 0; e3 < element3.length; e3++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element3[e3].value === '300_' + item) {
                element3[e3].checked = true;
            }
        })
    }
    const element4 = document.getElementsByName('c400');
    for (var e4 = 0; e4 < element4.length; e4++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element4[e4].value === '400_' + item) {
                element4[e4].checked = true;
            }
        })
    }
    const element5 = document.getElementsByName('c500');
    for (var e5 = 0; e5 < element5.length; e5++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element5[e5].value === '500_' + item) {
                element5[e5].checked = true;
            }
        })
    }
    const element6 = document.getElementsByName('c600');
    for (var e6 = 0; e6 < element6.length; e6++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element6[e6].value === '600_' + item) {
                element6[e6].checked = true;
            }
        })
    }
    const element7 = document.getElementsByName('c700');
    for (var e7 = 0; e7 < element7.length; e7++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element7[e7].value === '700_' + item) {
                element7[e7].checked = true;
            }
        })
    }
    const element8 = document.getElementsByName('c800');
    for (var e8 = 0; e8 < element8.length; e8++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element8[e8].value === '800_' + item) {
                element8[e8].checked = true;
            }
        })
    }
    const element9 = document.getElementsByName('c900');
    for (var e9 = 0; e9 < element9.length; e9++) {
        arrUnsafeItem.forEach((item, index) => {
            if (element9[e9].value === '900_' + item) {
                element9[e9].checked = true;
            }
        })
    }
    const elementu = document.getElementsByName('u00');
    for (var eu = 0; eu < elementu.length; eu++) {
        arrUnsafeItem.forEach((item, index) => {
            if (elementu[eu].value === 'U00_' + item) {
                elementu[eu].checked = true;
            }
        })
    }
    const elementv = document.getElementsByName('v00');
    for (var ev = 0; ev < elementv.length; ev++) {
        arrUnsafeItem.forEach((item, index) => {
            if (elementv[ev].value === 'V00_' + item) {
                elementv[ev].checked = true;
            }
        })
    }
    //end 1 check if match actual unsafe item

    if (_accmode === 'Transport') {
        //ฝั่งขวาdisabled c500,c600,c700,c900,v00 => disabled
        const elementC500 = document.getElementsByName('c500');
        for (var c5 = 0; c5 < elementC500.length; c5++) {
            elementC500[c5].disabled = true;
        }
        const elementC600 = document.getElementsByName('c600');
        for (var c6 = 0; c6 < elementC600.length; c6++) {
            elementC600[c6].disabled = true;
        }
        const elementC700 = document.getElementsByName('c700');
        for (var c7 = 0; c7 < elementC700.length; c7++) {
            elementC700[c7].disabled = true;
        }
        const elementC900 = document.getElementsByName('c900');
        for (var c9 = 0; c9 < elementC900.length; c9++) {
            elementC900[c9].disabled = true;
        }
        const elementV00 = document.getElementsByName('v00');
        for (var v = 0; v < elementV00.length; v++) {
            elementV00[v].disabled = true;
        }

        //ฝั่งซ้ายEnable c100,c200,c300,c400,c800,u00 => enabled
        const elementC100 = document.getElementsByName('c100');
        for (var c1 = 0; c1 < elementC100.length; c1++) {
            elementC100[c1].disabled = false;
        }
        const elementC200 = document.getElementsByName('c200');
        for (var c2 = 0; c2 < elementC200.length; c2++) {
            elementC200[c2].disabled = false;
        }
        const elementC300 = document.getElementsByName('c300');
        for (var c3 = 0; c3 < elementC300.length; c3++) {
            elementC300[c3].disabled = false;
        }
        const elementC400 = document.getElementsByName('c400');
        for (var c4 = 0; c4 < elementC400.length; c4++) {
            elementC400[c4].disabled = false;
        }
        const elementC800 = document.getElementsByName('c800');
        for (var c8 = 0; c8 < elementC800.length; c8++) {
            elementC800[c8].disabled = false;
        }
        const elementU00 = document.getElementsByName('u00');
        for (var u = 0; u < elementU00.length; u++) {
            elementU00[u].disabled = false;
        }
    }
    else {
        //ฝั่งขวา enable c500,c600,c700,c900,v00 => enable
        const elementC500 = document.getElementsByName('c500');
        for (var cc5 = 0; cc5 < elementC500.length; cc5++) {
            elementC500[cc5].disabled = false;
        }

        const elementC600 = document.getElementsByName('c600');
        for (var cc6 = 0; cc6 < elementC600.length; cc6++) {
            elementC600[cc6].disabled = false;
        }

        const elementC700 = document.getElementsByName('c700');
        for (var cc7 = 0; cc7 < elementC700.length; cc7++) {
            elementC700[cc7].disabled = false;
        }

        const elementC900 = document.getElementsByName('c900');
        for (var cc9 = 0; cc9 < elementC900.length; cc9++) {
            elementC900[cc9].disabled = false;
        }

        const elementV00 = document.getElementsByName('v00');
        for (var vv = 0; vv < elementV00.length; vv++) {
            elementV00[vv].disabled = false;
        }

        //ฝั่งซ้ายdisable c100,c200,c300,c400,c800,u00 => disabled
        const elementC100 = document.getElementsByName('c100');
        for (var cc1 = 0; cc1 < elementC100.length; cc1++) {
            elementC100[cc1].disabled = true;
        }
        const elementC200 = document.getElementsByName('c200');
        for (var cc2 = 0; cc2 < elementC200.length; cc2++) {
            elementC200[cc2].disabled = true;
        }
        const elementC300 = document.getElementsByName('c300');
        for (var cc3 = 0; cc3 < elementC300.length; cc3++) {
            elementC300[cc3].disabled = true;
        }
        const elementC400 = document.getElementsByName('c400');
        for (var cc4 = 0; cc4 < elementC400.length; cc4++) {
            elementC400[cc4].disabled = true;
        }
        const elementC800 = document.getElementsByName('c800');
        for (var cc8 = 0; cc8 < elementC800.length; cc8++) {
            elementC800[cc8].disabled = true;
        }
        const elementU00 = document.getElementsByName('u00');
        for (var uu = 0; uu < elementU00.length; uu++) {
            elementU00[uu].disabled = true;
        }
    }
})