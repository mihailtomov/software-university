function solve() {
   const shoppingCartDiv = document.querySelector('.shopping-cart');
   const textarea = shoppingCartDiv.querySelector('textarea');

   let boughtItems = [];
   let totalPrice = 0;

   shoppingCartDiv.addEventListener('click', onButtonClick);

   function onButtonClick(e) {
      if (e.target.tagName == 'BUTTON') {

         if (e.target.classList.contains('add-product')) {
            const productDiv = e.target.parentElement.parentElement;

            const productTitle = productDiv.querySelector('.product-title').innerText;
            const productPrice = productDiv.querySelector('.product-line-price').innerText;

            textarea.innerHTML += `Added ${productTitle} for ${productPrice} to the cart.\n`;

            if (!boughtItems.includes(productTitle)) {
               boughtItems.push(productTitle);
            }

            totalPrice += Number(productPrice);
         } else {
            textarea.innerHTML += `You bought ${boughtItems.join(', ')} for ${totalPrice.toFixed(2)}.`;

            const addAndCheckoutButtons = shoppingCartDiv.querySelectorAll('.add-product, .checkout');

            Array.from(addAndCheckoutButtons).forEach(button => button.disabled = true);
         }
      }
   }
}