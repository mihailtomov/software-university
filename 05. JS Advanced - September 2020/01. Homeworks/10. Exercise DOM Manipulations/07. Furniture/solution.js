function solve() {
  let textAreaElements = document.querySelectorAll('textarea');
  let buttonElements = document.querySelectorAll('button');
  let tableElement = document.querySelector('tbody');
  let input = textAreaElements[0];
  let output = textAreaElements[1];
  let generateButton = buttonElements[0];
  let buyButton = buttonElements[1];

  generateButton.addEventListener('click', () => {
    let objArr = JSON.parse(input.value);

    objArr.forEach(obj => {
      let image = obj['img'];
      let name = obj['name'];
      let price = obj['price'];
      let decFactor = obj['decFactor'];

      document.querySelector('tbody tr').children[4].firstElementChild.disabled = false;

      let newTableRow = `<tr>
      <td><img src="${image}"></td>
      <td><p>${name}</p></td>
      <td><p>${price}</p></td>
      <td><p>${decFactor}</p></td>
      <td><input type="checkbox"/></td>
      </tr>`;
      tableElement.innerHTML += newTableRow;
    });
  });

  buyButton.addEventListener('click', () => {
    let tableElements = document.querySelectorAll('tbody tr');
    let checkedElements = Array.from(tableElements).filter(tr => tr.children[4].firstElementChild.checked == true);

    let boughtFurniture = [];
    let totalPrice = [];
    let averageDecFactor = [];

    checkedElements.forEach(tr => {
      let furnitureName = tr.children[1].firstElementChild.textContent;
      let furniturePrice = Number(tr.children[2].firstElementChild.textContent);
      let furnitureDecFactor = Number(tr.children[3].firstElementChild.textContent);
      boughtFurniture.push(furnitureName);
      totalPrice.push(furniturePrice);
      averageDecFactor.push(furnitureDecFactor);
    });

    let result = '';
    result += `Bought furniture: ${boughtFurniture.join(', ')}\n`;
    result += `Total price: ${totalPrice.reduce((a, b) => a + b, 0).toFixed(2)}\n`;
    result += `Average decoration factor: ${averageDecFactor.reduce((a, b) => a + b, 0) / averageDecFactor.length}`;

    output.value = result;
  });
}