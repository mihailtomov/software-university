function pressHouse() {

    class Article {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            let output = `Title: ${this.title}\n`;
            output += `Content: ${this.content}`;

            return output;
        }
    }

    class ShortReports extends Article {
        comments = [];

        constructor(title, content, originalResearch) {
            super(title);
            this.contentSet = content;
            this.originalResearchSet = originalResearch;
        }

        set contentSet(value) {
            if (value.length >= 150) {
                throw new Error(`Short reports content should be less then 150 symbols.`);
            }

            this.content = value;
        }

        set originalResearchSet(value) {
            if (!value.title || !value.author) {
                throw new Error(`The original research should have author and title.`);
            }

            this.originalResearch = value;
        }

        addComment(comment) {
            this.comments.push(comment);
            return 'The comment is added.';
        }

        toString() {
            let output = super.toString() + '\n';
            output += `Original Research: ${this.originalResearch.title} by ${this.originalResearch.author}`;

            if (this.comments.length > 0) {
                output += '\nComments:\n';
                output += `${this.comments.join('\n')}`;
            }

            return output;
        }
    }

    class BookReview extends Article {
        clients = [];

        constructor(title, content, book) {
            super(title, content);
            this.book = book;
        }

        addClient(clientName, orderDescription) {
            if (this.clients.some(c => c.clientName == clientName && c.orderDescription == orderDescription)) {
                throw new Error('This client has already ordered this review.');
            }

            this.clients.push({ clientName, orderDescription });

            return `${clientName} has ordered a review for ${this.book.name}`;
        }

        toString() {
            let output = super.toString() + '\n';
            output += `Book: ${this.book.name}`;

            if (this.clients.length > 0) {
                output += '\nOrders:\n';

                this.clients.forEach(client => {
                    output += `${client.clientName} - ${client.orderDescription}\n`;
                });
            }

            return output.trim();
        }
    }

    return {
        Article,
        ShortReports,
        BookReview,
    }
}

let classes = solveClasses();
let lorem = new classes.Article("Lorem", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce non tortor finibus, facilisis mauris vel…");
console.log(lorem.toString()); 

let short = new classes.ShortReports("SpaceX and Javascript", "Yes, its damn true.SpaceX in its recent launch Dragon 2 Flight has used a technology based on Chromium and Javascript. What are your views on this ?", { title: "Dragon 2", author: "wikipedia.org" });
console.log(short.addComment("Thank god they didn't use java."))
short.addComment("In the end JavaScript's features are executed in C++ — the underlying language.")
console.log(short.toString()); 

let book = new classes.BookReview("The Great Gatsby is so much more than a love story", "The Great Gatsby is in many ways similar to Romeo and Juliet, yet I believe that it is so much more than just a love story. It is also a reflection on the hollowness of a life of leisure. ...", { name: "The Great Gatsby", author: "F Scott Fitzgerald" });
console.log(book.addClient("The Guardian", "100 symbols"));
console.log(book.addClient("Goodreads", "30 symbols"));
console.log(book.toString()); 