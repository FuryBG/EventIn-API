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
})()