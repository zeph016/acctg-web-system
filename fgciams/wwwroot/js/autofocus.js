function AutoFocusElement(element) {
    // if (element instanceof HTMLElement) {
    //     
    // }
    element.focus();
}

function Focus(className) { 
    var element = document.getElementById(className); 
    console.log(element.innerHTML);
    element.focus(); 
}

function FocusNextElement(elementId) {
    var element = document.getElementById(elementId);
    element.focus();
}

function FocusNextElementClass(className) {
    var element = document.getElementById(className);
    element.focus();
}

function SelectText(elementId) {
    var text = document.querySelector("#" + elementId);
    if (text.select) {
        text.select();
    }
}

//NOT USED FOR FUTURE REFERENCE ONLY