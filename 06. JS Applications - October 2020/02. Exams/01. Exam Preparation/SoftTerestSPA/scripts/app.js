const app = Sammy('#root', router);

const userModel = firebase.auth();
const db = firebase.firestore();

function router() {
    this.use('Handlebars', 'hbs');


    // GET 


    this.get('#/home', function (context) {
        validateLoggedIn(context);

        db.collection('ideas')
            .get()
            .then(res => {
                const data = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                if (data.length > 0) {
                    context.ideas = data.sort((a, b) => b.likes - a.likes);
                }

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

    this.get('#/details/:id', function (context) {
        validateLoggedIn(context);

        const ideaId = getContextId(context);
        const { uid } = getUserData();

        db.collection('ideas')
            .doc(ideaId)
            .get()
            .then(idea => {
                context.idea = { id: idea.id, ...idea.data() };

                if (idea.data().creator == uid) {
                    context.organizer = true;
                }

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/details.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/like/:id', function (context) {
        const ideaId = getContextId(context);

        db.collection('ideas')
            .doc(ideaId)
            .get()
            .then(idea => {
                let { likes } = idea.data();
                likes++;

                db.collection('ideas')
                    .doc(ideaId)
                    .update({
                        likes,
                    })
                    .then(() => context.redirect(`#/details/${ideaId}`))
                    .catch(err => errorHandler(err));
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/profile', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('ideas')
            .get()
            .then(res => {
                const data = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                const createdIdeas = data.filter(i => i.creator == uid);

                context.createdIdeas = createdIdeas;
                context.ideasCount = createdIdeas.length;

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/profile.hbs')
                })
            })
            .catch(err => errorHandler(err));
    })


    //SEMI-GET 


    this.get('#/logout', function (context) {
        userModel.signOut()
            .then(() => {
                localStorage.removeItem('userInfo');

                showSuccessMessage(context, 'Logged out', '#/login');
            })
    })

    this.get('#/delete/:id', function (context) {
        const ideaId = getContextId(context);

        db.collection('ideas')
            .doc(ideaId)
            .delete()
            .then(() => showSuccessMessage(context, 'Idea deleted successfully.', '#/home'))
            .catch(err => errorHandler(err));
    })


    //POST 


    this.post('#/register', function (context) {
        let { email, password, repeatPassword } = context.params;

        if (password === repeatPassword) {
            userModel.createUserWithEmailAndPassword(email, password)
                .then(userData => {
                    let { email, uid } = userData.user;
                    let userInfo = { email, uid };

                    localStorage.setItem('userInfo', JSON.stringify(userInfo));

                    showSuccessMessage(context, 'Successful registration!', '#/home');
                })
                .catch(err => showErrorMessage(context, err.message, '#/register'));
        } else {
            showErrorMessage(context, 'Passwords should match!', '#/register')
        }
    })

    this.post('#/login', function (context) {
        let { email, password } = context.params;

        userModel.signInWithEmailAndPassword(email, password)
            .then(userData => {
                let { email, uid } = userData.user;
                let userInfo = { email, uid };

                localStorage.setItem('userInfo', JSON.stringify(userInfo));

                showSuccessMessage(context, 'Successful login.', '#/home');
            })
            .catch(err => showErrorMessage(context, err.message, '#/login'));
    })

    this.post('#/create', function (context) {
        const { title, description, imageURL } = context.params;
        const { uid } = getUserData();

        db.collection('ideas')
            .add({
                title,
                description,
                imageURL,
                creator: uid,
                likes: 0,
                comments: [],
            })
            .then(() => {
                showSuccessMessage(context, 'Idea created successfully.', '#/home');
            })
            .catch(err => errorHandler(err));
    })

    this.post('#/comment', function (context) {
        const commentElement = document.querySelector('textarea.textarea-det');

        const ideaId = commentElement.getAttribute('data-key');
        const comment = commentElement.value;
        const { email } = getUserData();
        const user = email.split('@')[0];

        db.collection('ideas')
            .doc(ideaId)
            .get()
            .then(idea => {
                const { comments } = idea.data();
                comments.push({ user, comment });

                db.collection('ideas')
                    .doc(ideaId)
                    .update({
                        comments,
                    })
                    .then(() => context.redirect(`#/details/${ideaId}`))
                    .catch(err => errorHandler(err));
            })
            .catch(err => errorHandler(err));
    })
};

//LOADS HEADER AND FOOTER
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

function errorHandler(err) {
    alert(err);
}

//NOTIFICATION BOXES
function showSuccessMessage(context, message, redirectPath) {
    context.success = true;
    context.successMessage = message;
    context.partial('../templates/partials/header.hbs');

    setTimeout(() => {
        context.redirect(redirectPath);
    }, 2000)
}

function showErrorMessage(context, message, redirectPath) {
    context.error = true;
    context.errorMessage = message;
    context.partial('../templates/partials/header.hbs');

    setTimeout(() => {
        context.redirect(redirectPath);
    }, 2000)
}

app.run('#/home');