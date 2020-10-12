function solve() {
  let aElements = document.querySelectorAll('.link-1 a');
  for (const element of aElements) {
    element.addEventListener('click', clicksCounter);
  }

  function clicksCounter(e) {
    let paragraphElement = e.currentTarget.nextElementSibling;
    let counter = Number(paragraphElement.innerHTML.split(' ')[1]);
    counter++;
    paragraphElement.innerHTML = `visited ${counter} times`;
  }
}