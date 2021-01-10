function solve() {
  const state = {
    'SoftUni': 1,
    'Google': 2,
    'YouTube': 4,
    'Wikipedia': 4,
    'Gmail': 7,
    'stackoverflow': 6,
  }

  const divElements = document.querySelectorAll('.link-1');

  Array.from(divElements).forEach(div => {
    div.firstElementChild.addEventListener('click', onAnchorClick);
  })

  function onAnchorClick(e) {
    const anchorLink = e.currentTarget;
    const visitCountParagraph = anchorLink.nextElementSibling;

    const site = anchorLink.textContent.trim();
    state[site]++;
    visitCountParagraph.innerHTML = `visited ${state[site]} times`;
  }
}