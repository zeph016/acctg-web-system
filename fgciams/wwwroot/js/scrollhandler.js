function ScrollToRight(id) {
  const element = document.getElementById(id);
  element.scrollLeft += 25;
}

function ScrollToLeft(id) {
  const element = document.getElementById(id);
  element.scrollLeft -= 25;
}

function ScrollToBottom(id) {
  const element = document.getElementById(id);
  element.scrollTop = element.scrollHeight;
}

function ScrollToTop(id) {
  const element = document.getElementById(id);
  element.scrollTop = 0;
}

function ScrollToLocation(id, valueX, valueY) {
  const element = document.getElementById(id);
  element.scrollTo(valueX, valueY);
}

function CheckScrollbar(id) {
  var div = document.getElementsByClassName(id);
  var hasHorizontalScrollbar = div.scrollWidth > div.clientWidth;
  var hasVerticalScrollbar = div.scrollHeight > div.clientHeight;
  if (hasHorizontalScrollbar || hasVerticalScrollbar)
    return true;
  else
    return false;
}