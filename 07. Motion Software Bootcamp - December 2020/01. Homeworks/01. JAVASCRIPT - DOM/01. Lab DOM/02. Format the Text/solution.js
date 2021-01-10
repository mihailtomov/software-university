function solve() {
  const input = document.querySelector('#input');
  const output = document.querySelector('#output');

  let sentences = input.innerText.split('.').filter(x => x != '');

  if (sentences.length <= 3) {
    const p = document.createElement('p');

    p.innerHTML = sentences.join('.') + '.';
    output.appendChild(p);
  } else {
    for (let i = 0; i < sentences.length; i += 3) {
      const p = document.createElement('p');
      let paragraphs;

      if (i + 2 < sentences.length) {
        paragraphs = sentences.slice(i, i + 3);
      } else {
        paragraphs = sentences.slice(i, sentences.length);
      }

      p.innerHTML = paragraphs.join('.') + '.';
      output.appendChild(p);
    }
  }
}