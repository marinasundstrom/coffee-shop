interface Window {
    anchorLink: {
        scrollIntoView: (elementId: string) => void;
    }
}

window.anchorLink = {
    scrollIntoView: function (elementId: string) {
        // This function is called from the AnchorLink component using JavaScript interop.
        // It will try to find an element using the ID given to the function, and scroll that
        // element into view, if an element is found.
        var elem = document.getElementById(elementId);
        if (elem) {
            elem.scrollIntoView({ behavior: "smooth" });
            window.location.hash = elementId;
        }
    }
}