let navLinks = document.querySelector(".nav-links");
var dd_parent = document.querySelector(".dd-parent");
var dd_menu = document.querySelector(".dd-menu");

dd_parent.addEventListener("click", function(){
    dd_menu.classList.toggle("active");
})

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