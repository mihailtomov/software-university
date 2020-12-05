const app = Sammy('#site-content', router);

const userModel = firebase.auth();
const db = firebase.firestore();


const elements = {
    successBox: () => document.querySelector('#successBox').firstElementChild,
    errorBox: () => document.querySelector('#errorBox').firstElementChild,
};

function router() {
    this.use('Handlebars', 'hbs');


    // GET 


    this.get('#/home', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('pets')
            .get()
            .then(res => {
                const petsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                context.otherPets = petsData.filter(p => p.creator != uid);

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
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

    this.get('#/create', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/create.hbs');
        })
    })

    this.get('#/my-pets', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('pets')
            .get()
            .then(res => {
                const petsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                context.myPets = petsData.filter(p => p.creator == uid);

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/myPets.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/details/:id', function (context) {
        validateLoggedIn(context);

        const petId = getContextId(context);

        db.collection('pets')
            .doc(petId)
            .get()
            .then(pet => {
                context.pet = { id: petId, ...pet.data() };

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/detailsOtherPet.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/pet/:id', function (context) {
        const petId = getContextId(context);

        db.collection('pets')
            .doc(petId)
            .get()
            .then(pet => {
                let { likes } = pet.data();
                likes++;

                db.collection('pets')
                    .doc(petId)
                    .update({
                        likes,
                    })
                    .then(() => {
                        history.back();
                    })
                    .catch(err => errorHandler(err));
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/edit/:id', function (context) {
        validateLoggedIn(context);

        const petId = getContextId(context);

        db.collection('pets')
            .doc(petId)
            .get()
            .then(pet => {
                context.pet = { id: petId, ...pet.data() };

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/detailsMyPet.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    //Pet sections

    this.get('#/cats', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('pets')
            .get()
            .then(res => {
                const petsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                context.otherPets = getSortedPets(petsData, uid, 'Cat');

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/dogs', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('pets')
            .get()
            .then(res => {
                const petsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                context.otherPets = getSortedPets(petsData, uid, 'Dog');

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/parrots', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('pets')
            .get()
            .then(res => {
                const petsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                context.otherPets = getSortedPets(petsData, uid, 'Parrot');

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/reptiles', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('pets')
            .get()
            .then(res => {
                const petsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                context.otherPets = getSortedPets(petsData, uid, 'Reptile');

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/other', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('pets')
            .get()
            .then(res => {
                const petsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                context.otherPets = getSortedPets(petsData, uid, 'Other');

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })


    //SEMI-GET


    this.get('#/logout', function (context) {
        userModel.signOut()
            .then(() => {
                localStorage.removeItem('userInfo');

                logSuccessMessage('Logout successful.');

                context.redirect('#/home');
            })
    })

    this.get('#/delete/:id', function (context) {
        validateLoggedIn(context);

        const petId = getContextId(context);

        db.collection('pets')
            .doc(petId)
            .get()
            .then(pet => {
                context.pet = { id: petId, ...pet.data() };

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/deleteMyPet.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })


    //POST


    this.post('#/register', function (context) {
        let { email, password } = context.params;

        if (email && password) {
            userModel.createUserWithEmailAndPassword(email, password)
                .then(userData => {
                    let { email, uid } = userData.user;
                    let userInfo = { email, uid };

                    localStorage.setItem('userInfo', JSON.stringify(userInfo));

                    logSuccessMessage('User registration successful.');

                    context.redirect('#/home');
                })
                .catch(err => logErrorMessage(err.message));
        } else {
            logErrorMessage('Fields cannot be empty!');
        }
    })

    this.post('#/login', function (context) {
        let { email, password } = context.params;

        if (email && password) {
            userModel.signInWithEmailAndPassword(email, password)
                .then(userData => {
                    let { email, uid } = userData.user;
                    let userInfo = { email, uid };

                    localStorage.setItem('userInfo', JSON.stringify(userInfo));

                    logSuccessMessage('Login successful.');

                    context.redirect('#/home');
                })
                .catch(err => logErrorMessage(err.message));
        } else {
            logErrorMessage('Fields cannot be empty!');
        }
    })

    this.post('#/create', function (context) {
        const { name, description, imageURL, category } = context.params;
        const { uid } = getUserData();

        if (name && description && imageURL && category) {
            db.collection('pets')
                .add({
                    name,
                    description,
                    imageURL,
                    category,
                    likes: 0,
                    creator: uid,
                })
                .then(() => {
                    logSuccessMessage('Pet created.');

                    context.redirect('#/my-pets');
                })
                .catch(err => errorHandler(err));
        }
    })

    this.post('#/edit/:id', function (context) {
        const petId = getContextId(context);

        const { description } = context.params;

        db.collection('pets')
            .doc(petId)
            .update({
                description,
            })
            .then(() => {
                logSuccessMessage('Updated successfully!');

                context.redirect('#/my-pets');
            })
            .catch(err => errorHandler(err));
    })

    this.post('#/delete/:id', function (context) {
        const petId = getContextId(context);

        db.collection('pets')
            .doc(petId)
            .delete()
            .then(() => {
                logSuccessMessage('Pet removed successfully!');

                context.redirect('#/my-pets');
            })
            .catch(err => errorHandler(err));
    })
};

//LOADS HEADER AND FOOTER (double-check path)
function loadHeaderAndFooter(context) {
    return context.loadPartials({
        'header': '../templates/partials/header.hbs',
        'footer': '../templates/partials/footer.hbs',
    });
}
//VALIDATE LOGGED-IN USER
function validateLoggedIn(context) {
    if (localStorage['userInfo']) {
        const userInfo = JSON.parse(localStorage['userInfo']);

        context.loggedIn = true;
        context.email = userInfo.email;
    } else {
        context.loggedIn = false;
    }
}
//GET UserInfo OBJECT
function getUserData() {
    return localStorage['userInfo'] ? JSON.parse(localStorage['userInfo']) : '';
}
//GET ID
function getContextId(context) {
    return context.params.id;
}

function getSortedPets(pets, uid, category) {
    return pets
        .filter(p => p.creator != uid && p.category == category)
        .sort((a, b) => b.likes - a.likes);
}

function errorHandler(err) {
    alert(err);
}

//NOTIFICATION BOXES(UNCOMMENT ELEMENTS)
function logSuccessMessage(message) {
    const successBox = elements.successBox();

    successBox.textContent = message;
    successBox.parentElement.style.display = 'block';

    timeoutMessage(successBox);
}

function logErrorMessage(message) {
    const errorBox = elements.errorBox();

    errorBox.textContent = message;
    errorBox.parentElement.style.display = 'block';

    timeoutMessage(errorBox);
}

function timeoutMessage(element) {
    setTimeout(() => {
        element.parentElement.style.display = 'none';
    }, 3000)
}

app.run('#/home');