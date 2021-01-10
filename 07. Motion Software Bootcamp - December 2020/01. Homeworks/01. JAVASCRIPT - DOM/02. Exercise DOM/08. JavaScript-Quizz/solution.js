function solve() {
  const quizAnswers = document.querySelectorAll('.quiz-answer');
  const sectionsArray = Array.from(document.querySelectorAll('section'));

  let rightAnswers = 0;
  let totalRightAnswers = sectionsArray.length;
  let displayedSection = sectionsArray.shift();

  const correctAnswers = {
    'onclick': 1,
    'JSON.stringify()': 1,
    'A programming API for HTML and XML documents': 1,
  }

  for (const quizAnswer of quizAnswers) {
    quizAnswer.addEventListener('click', onListItemClick)
  }
  
  function onListItemClick(e) {
    if (correctAnswers[e.currentTarget.querySelector('.answer-text').innerText]) {
      rightAnswers++;
    }
    if (sectionsArray.length > 0) {
      const currentSection = sectionsArray.shift();

      displayedSection.style.display = 'none';
      currentSection.style.display = 'block';

      displayedSection = currentSection;
    } else {
      displayedSection.style.display = 'none';

      const resultsUl = document.querySelector('#results');

      resultsUl.style.display = 'block';

      const result = resultsUl.querySelector('li h1');

      totalRightAnswers === rightAnswers 
      ? result.innerHTML = 'You are recognized as top JavaScript fan!'
      : result.innerHTML = `You have ${rightAnswers} right answers`
    }
  }
}