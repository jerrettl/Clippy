// function mobileNavToggle() {
//   let nav = document.querySelector("navbar");
//   if (nav.className === "mobile-nav") nav.className += " responsive";
//   else nav.className = "mobile-nav";
// }

let navLinks = document.querySelectorAll("nav-links");

function handleClick() {
  mobileNavBarClick = !mobileNavBarClick;
  console.log("11");

  if (mobileNavBarClick) {
    navLinks.className = "nav-links active";
  } else {
    navLinks.className = "nav-links";
  }

  for (element of navLinks) {
    element.className = "nav-links active";
    console.log("22");
  }

  console.log("33");
  console.log(mobileNavBarClick);
  console.log(navLinks.className);
}

function closeMobileMenu() {
  mobileNavBarClick = false;
  console.log(mobileNavBarClick);
}

let mobileNavBarClick = true;
