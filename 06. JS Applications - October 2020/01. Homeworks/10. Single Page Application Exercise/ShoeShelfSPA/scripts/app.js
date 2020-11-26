const app = Sammy('#main', router);

const userModel = firebase.auth();
const db = firebase.firestore();

function router() {
    this.use('Handlebars', 'hbs');


    // GET
    this.get('#/home', function (context) {
        validateLoggedIn(context);

        db.collection('shoes')
            .get()
            .then(res => {
                context.shoes = [];

                res.forEach(shoe => {
                    context.shoes.push({ offerId: shoe.id, ...shoe.data() })
                })

                context.shoes.sort((a, b) => b.buyers.length - a.buyers.length);

                if (context.shoes.length > 0) {
                    context.offers = true;
                } else {
                    context.offers = false;
                }

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
    })

    this.get('#/register', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/register.hbs');
        })
    })

    this.get('#/login', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/login.hbs');
        })
    })

    this.get('#/logout', function (context) {
        userModel.signOut()
            .then(() => {
                localStorage.removeItem('userInfo');

                context.redirect('#/login');
            })
    })

    this.get('#/create-offer', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/create.hbs');
        })
    })

    this.get('#/details/:id', function (context) {
        validateLoggedIn(context);

        const offerId = context.params.id;
        const { uid } = getUserData();
        const { email } = getUserData();

        db.collection('shoes')
            .doc(offerId)
            .get()
            .then(shoe => {
                const shoeData = shoe.data();

                if (shoeData.creator == uid) {
                    context.isCreator = true;
                }

                if (shoeData.buyers.includes(email)) {
                    context.bought = true;
                }

                context.name = shoeData.name;
                context.imageUrl = shoeData.imageUrl;
                context.description = shoeData.description;
                context.price = shoeData.price;
                context.buyers = shoeData.buyers.length;
                context.offerId = offerId;

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/details.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/edit/:id', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/edit.hbs');
        })

        const offerId = context.params.id;
        context.offerId = offerId;

        db.collection('shoes')
            .doc(offerId)
            .get()
            .then(shoe => {
                const divElements = document.querySelector('#edit-form').children;

                const nameInput = divElements[0].firstElementChild;
                const priceInput = divElements[1].firstElementChild;
                const imageUrlInput = divElements[2].firstElementChild;
                const descriptionInput = divElements[3].firstElementChild;
                const brandInput = divElements[4].firstElementChild;

                const shoeData = shoe.data();

                nameInput.value = shoeData.name;
                priceInput.value = shoeData.price;
                imageUrlInput.value = shoeData.imageUrl;
                descriptionInput.value = shoeData.description;
                brandInput.value = shoeData.brand;
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/buy/:id', function (context) {
        const offerId = context.params.id;
        const { email } = getUserData();

        db.collection('shoes')
            .doc(offerId)
            .get()
            .then(shoe => {
                const shoeData = shoe.data();
                const { buyers } = shoeData;

                buyers.push(email);
                db.collection('shoes').doc(offerId).update({ buyers })
                    .then(() => context.redirect(`#/details/${offerId}`))
                    .catch(err => errorHandler(err));
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/delete/:id', function (context) {
        const offerId = context.params.id;

        db.collection('shoes')
            .doc(offerId)
            .delete()
            .then(() => context.redirect('#/home'))
            .catch(err => errorHandler(err));
    })
    
    
    //POST
    this.post('#/register', function (context) {
        let { email, password, rePassword } = context.params;

        const validatePasswords = password.length >= 6 && password == rePassword;

        if (email && validatePasswords) {
            userModel.createUserWithEmailAndPassword(email, password)
                .then(userData => {
                    let { email, uid } = userData.user;
                    let userInfo = { email, uid };

                    localStorage.setItem('userInfo', JSON.stringify(userInfo));
                    context.redirect('#/home');
                })
                .catch(err => alert(err.message));
        }
    })

    this.post('#/login', function (context) {
        let { email, password } = context.params;

        userModel.signInWithEmailAndPassword(email, password)
            .then(userData => {
                let { email, uid } = userData.user;
                let userInfo = { email, uid };

                localStorage.setItem('userInfo', JSON.stringify(userInfo));
                context.redirect('#/home');
            })
            .catch(err => alert(err.message));
    })

    this.post('#/create-offer', function (context) {
        let { name, price, imageUrl, description, brand } = context.params;

        const { uid } = getUserData();

        if (name && price && imageUrl && description && brand) {
            db.collection('shoes')
                .add({
                    name,
                    price,
                    imageUrl,
                    description,
                    brand,
                    creator: uid,
                    buyers: [],
                })
                .then(() => context.redirect('#/home'))
                .catch(err => errorHandler(err));
        } else {
            alert('All fields must be filled!');
        }
    })

    this.post('#/edit-offer/:id', function (context) {
        const offerId = context.params.id;

        let { name, price, imageUrl, description, brand } = context.params;

        if (name && price && imageUrl && description && brand) {
            db.collection('shoes')
                .doc(offerId)
                .update({
                    name,
                    price,
                    imageUrl,
                    description,
                    brand,
                })
                .then(() => context.redirect(`#/details/${offerId}`))
                .catch(err => errorHandler(err));
        } else {
            alert('All fields must be filled!');
        }
    })
};

function loadHeaderAndFooter(context) {
    return context.loadPartials({
        'header': '../templates/header.hbs',
        'footer': '../templates/footer.hbs',
    });
}

function validateLoggedIn(context) {
    if (localStorage['userInfo']) {
        const userInfo = JSON.parse(localStorage['userInfo']);

        context.loggedIn = true;
        context.email = userInfo.email;
    } else {
        context.loggedIn = false;
    }
}

function getUserData() {
    return JSON.parse(localStorage['userInfo']);
}

function errorHandler(err) {
    alert(err);
}

(() => {
    app.run('#/home');
})();