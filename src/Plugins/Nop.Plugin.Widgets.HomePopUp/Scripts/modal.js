//cookie values
var _cookieName = "cookiePopUpName";
var _cookieValue = "cookiePopUpValue";
var _daysToLive = 7;

document.getElementsByTagName("BODY")[0].onload = function () {
  modal.style.display = "block";
};
var modal = document.getElementById("myModal");
var acceptButton = document.getElementById("btnAcceptPopUp");
function closeModal() {
  modal.style.display = "none";
}
document.getElementsByTagName("BODY")[0].onload = function () {
  modal.style.display = "block";
};

function buttonFunction(button) {
  setCookie();
  if (button === "accept") {
    window.location.href = acceptButton.dataset.location;
  }
  closeModal();
}
function setCookie() {
  var cookie = _cookieName + "=" + encodeURIComponent(_cookieValue);

  if (typeof _daysToLive === "number") {
    /* Sets the max-age attribute so that the cookie expires
    after the specified number of days */
    cookie += "; max-age=" + (_daysToLive * 24 * 60 * 60);
    document.cookie = cookie;
  }
}
window.onload = function () {
  var checkCookiePopUp = false;
  if (document.cookie.length != 0) {
    cookiesArray = document.cookie.split("; ");
    for (var i = 0; i < cookiesArray.length; i++) {
      var nameValueArray = cookiesArray[i].split("=");
      if (nameValueArray[0] === _cookieName) {
        checkCookiePopUp = true;
        break;
      }
    }
  }
  console.log(checkCookiePopUp);
  if (!checkCookiePopUp) {
    modal.style.display = "block";
  }

}
