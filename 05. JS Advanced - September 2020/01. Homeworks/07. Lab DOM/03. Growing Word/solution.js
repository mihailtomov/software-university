function growingWord() {
  let parent = document.getElementById('exercise');
  let growingWordElement = parent.lastElementChild;

  if (!growingWordElement.hasAttribute('style')) {
    growingWordElement.style.fontSize = '2px';
    growingWordElement.style.color = 'blue';
  } else {
    growingWordElement.style.fontSize = `${parseInt(growingWordElement.style.fontSize) * 2}px`;
    switch (growingWordElement.style.color) {
      case 'blue':
        growingWordElement.style.color = 'green';
        break;
      case 'green':
        growingWordElement.style.color = 'red';
        break;
      case 'red':
        growingWordElement.style.color = 'blue';
        break;
    }
  }
}