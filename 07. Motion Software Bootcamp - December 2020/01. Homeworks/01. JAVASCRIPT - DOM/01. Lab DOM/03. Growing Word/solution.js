function growingWord() {
  const growingWord = document.querySelector('#exercise p');
  
  switch (growingWord.style.color) {
    case 'blue':
      growingWord.style.color = 'green';
      break;
    case 'green':
      growingWord.style.color = 'red';
      break;
    default:
      growingWord.style.color = 'blue';
      break;
  }

  if (!growingWord.style.fontSize) {
    growingWord.style.fontSize = '2px';
  } else {
    let pixelsNum = growingWord.style.fontSize.match(/\d+/g)[0];
    growingWord.style.fontSize = `${pixelsNum * 2}px`;
  }
}