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

//NOT USED FOR FUTURE REFERENCE ONLY