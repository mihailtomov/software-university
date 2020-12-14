function solve() {
   const elements = {
      signMeUpBtn: () => document.querySelector('div.courseFoot button'),
      jsFundamentalsBox: () => document.querySelector('input[name="js-fundamentals"]'),
      jsAdvancedBox: () => document.querySelector('input[name="js-advanced"]'),
      jsApplicationsBox: () => document.querySelector('input[name="js-applications"]'),
      jsWebBox: () => document.querySelector('input[name="js-web"]'),
      onsiteBox: () => document.querySelector('input[value="onsite"]'),
      onlineBox: () => document.querySelector('input[value="online"]'),
      unorderedList: () => document.querySelector('div#myCourses div.courseBody ul'),
      priceBox: () => document.querySelector('div.courseFoot p'),
   }

   elements.signMeUpBtn().addEventListener('click', onButtonClick);

   function onButtonClick(e) {
      let jsFundamentalsBox = elements.jsFundamentalsBox();
      let jsAdvancedBox = elements.jsAdvancedBox();
      let jsApplicationsBox = elements.jsApplicationsBox();
      let jsWebBox = elements.jsWebBox();

      let onlineBox = elements.onlineBox();

      let jsFundamentalsPrice = 170;
      let jsAdvancedPrice = 180;
      let jsApplicationsPrice = 190;
      let jsWebPrice = 490;

      let modulePrice = jsFundamentalsPrice + jsAdvancedPrice + jsApplicationsPrice;

      let discount = 0;

      if (jsAdvancedBox.checked && jsFundamentalsBox.checked) {
         discount += 0.10 * jsAdvancedPrice;
      }
      if (jsFundamentalsBox.checked && jsAdvancedBox.checked && jsApplicationsBox.checked) {
         discount += 0.06 * modulePrice;
      }

      //6% from all courses

      if (onlineBox.checked && jsFundamentalsBox.checked) {
         discount += 0.06 * jsFundamentalsPrice;
      }

      if (onlineBox.checked && jsAdvancedBox.checked) {
         discount += (0.06 * 10 * jsAdvancedPrice * 10) / 100;
      }

      if (onlineBox.checked && jsApplicationsBox.checked) {
         discount += 0.06 * jsApplicationsPrice;
      }

      if (onlineBox.checked && jsWebBox.checked) {
         discount += 0.06 * jsWebPrice;
      }

      let courseList = elements.unorderedList();

      let allBoxes = document.querySelectorAll('input[type="checkbox"]');
      let checkedBoxes = Array.from(allBoxes).filter(b => b.checked);
      
      let totalPrice = 0.0;

      Array.from(checkedBoxes).forEach(box => {
         let liElement = document.createElement('li');

         if (box.value == 'js-fundamentals') {
            totalPrice += jsFundamentalsPrice;
            liElement.textContent = 'JS-Fundamentals';
         }
         if (box.value == 'js-advanced') {
            totalPrice += jsAdvancedPrice;
            liElement.textContent = 'JS-Advanced';
         }
         if (box.value == 'js-applications') {
            totalPrice += jsApplicationsPrice;
            liElement.textContent = 'JS-Applications';
         }
         if (box.value == 'js-web') {
            totalPrice += jsWebPrice;
            liElement.textContent = 'JS-Web';
         }

         courseList.appendChild(liElement);
      })

      if (Array.from(checkedBoxes).length == 4) {
         let liElement = document.createElement('li');
         liElement.textContent = 'HTML and CSS';
         courseList.appendChild(liElement);
      }

      let finalPrice = parseFloat(totalPrice - discount);
      finalPrice = Math.round(finalPrice).toFixed(2);
      
      let priceBox = elements.priceBox();
      priceBox.textContent = `Cost: ${finalPrice} BGN`;
   }
}

solve();