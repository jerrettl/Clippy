// function mobileNavToggle() {
//   let nav = document.querySelector("navbar");
//   if (nav.className === "mobile-nav") nav.className += " responsive";
//   else nav.className = "mobile-nav";
// }

let navLinks = document.querySelector(".nav-links");

function handleClick() {

  if (mobileNavBarClick) {
      navLinks.className = "nav-links active";
  } else {
      navLinks.className = "nav-links";
  }

  mobileNavBarClick = !mobileNavBarClick;
}

function closeMobileMenu() {
  mobileNavBarClick = false;
  console.log(mobileNavBarClick);
}

let mobileNavBarClick = true;
