class Bank {
    allCustomers = [];

    constructor (bankName) {
        this._bankName = bankName;
    }

    newCustomer (customer) {
        if (this.allCustomers.some(c => c.personalId == customer.personalId)) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney (personalId, amount) {
        this.validateID(personalId);

        let customer = this.getCustomerByID(personalId);

        if (!customer.totalMoney) {
            customer.totalMoney = 0;
            customer.transactionHistory = [];
        }

        customer.totalMoney += amount;
        customer.transactionHistory.push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);

        return `${customer.totalMoney}$`;
    }

    withdrawMoney (personalId, amount) {
        this.validateID(personalId);

        let customer = this.getCustomerByID(personalId);

        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;
        customer.transactionHistory.push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`)

        return `${customer.totalMoney}$`;
    }

    customerInfo (personalId) {
        this.validateID(personalId);

        let customer = this.getCustomerByID(personalId);

        let output = `Bank name: ${this._bankName}\n`;
        output += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
        output += `Customer ID: ${customer.personalId}\n`;
        output += `Total Money: ${customer.totalMoney}$\n`;
        output += 'Transactions:\n';

        let transactions = customer.transactionHistory;
        let line = transactions.length;

        transactions.reverse();

        transactions.forEach(transaction => {
            output += `${line}. ` + transaction;
            output += '\n';
            line--;
        });

        return output.trim();
    }

    validateID (personalId) {
        if (!this.allCustomers.some(c => c.personalId == personalId)) {
            throw new Error('We have no customer with this ID!');
        }
    }

    getCustomerByID(personalId) {
        return this.allCustomers.find(c => c.personalId == personalId);
    }
}

let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 6233267}));
console.log(bank.newCustomer({firstName: "Mihaela", lastName: "Mileva", personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));