function solve() {
  let inputElement = document.getElementById('input');
  let outputElement = document.getElementById('output');
  let sentences = inputElement.innerHTML.split('.').filter(s => s != '');

  for (let i = 0; i <= sentences.length; i += 3) {
    let current3Sentences = sentences.slice(i, i + 3);
    let paragraphElement = document.createElement('p');

    for (const sentence of current3Sentences) {
      paragraphElement.innerHTML += sentence + '.';
    }
    outputElement.appendChild(paragraphElement);
  }
}