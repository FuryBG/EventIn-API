// Nav section
(function () {
    let hamburger = document.querySelector(".hamburger");
    let exitNav = document.querySelector(".exit-button");

    hamburger.addEventListener("click", () => toggleMobileNav(true));
    exitNav.addEventListener("click", () => toggleMobileNav(false));
    function toggleMobileNav(show) {
        let mobileNav = document.querySelector(".mobile-nav");
        if (show) {
            mobileNav.style.right = 0;

        }
        else {
            mobileNav.style.right = "-100%";
        }
    }
})();

// Cookie Consent
(function () {
    let consentCookie = document.cookie.includes("consent");
    if (!consentCookie) {
        let consentSection = document.querySelector(".cookie-consent");
        consentSection.style.display = "flex";
        consentSection.querySelector(".c-button").addEventListener("click", () => {
            document.cookie += "consent=true;";
            consentSection.style.display = "none";
        });
    }
})();