const app = Sammy('#root', router);

const userModel = firebase.auth();
const db = firebase.firestore();


const elements = {
    successBox: () => document.querySelector('#successBox'),
    errorBox: () => document.querySelector('#errorBox'),
};

function router() {
    this.use('Handlebars', 'hbs');


    // GET 

    this.get('#/', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('posts')
            .get()
            .then(res => {
                const data = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                if (data.length > 0) {
                    data.forEach(post => {
                        if (post.creator == uid) {
                            post.author = true;
                        } else {
                            post.author = false;
                        }
                    })
                    context.posts = data;
                }

                this.loadPartials({
                    'header': '../templates/header.hbs',
                    'post': '../templates/post.hbs',
                }).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/home', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('posts')
            .get()
            .then(res => {
                const data = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                if (data.length > 0) {
                    data.forEach(post => {
                        if (post.creator == uid) {
                            post.author = true;
                        } else {
                            post.author = false;
                        }
                    })
                    context.posts = data;
                }

                this.loadPartials({
                    'header': '../templates/header.hbs',
                    'post': '../templates/post.hbs',
                }).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/register', function (context) {
        validateLoggedIn(context);

        loadHeaderView(context).then(function () {
            this.partial('../templates/register.hbs');
        })
    })

    this.get('#/login', function (context) {
        validateLoggedIn(context);

        loadHeaderView(context).then(function () {
            this.partial('../templates/login.hbs');
        })
    })


    this.get('#/details/:id', function (context) {
        validateLoggedIn(context);

        const postId = getContextId(context);

        db.collection('posts')
            .doc(postId)
            .get()
            .then(post => {
                context.post = { ...post.data() };

                loadHeaderView(context).then(function () {
                    this.partial('../templates/details.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/edit/:id', function (context) {
        validateLoggedIn(context);

        const postId = getContextId(context);
        const { uid } = getUserData();

        db.collection('posts')
            .get()
            .then(res => {
                const data = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                if (data.length > 0) {
                    data.forEach(post => {
                        if (post.creator == uid) {
                            post.author = true;
                        } else {
                            post.author = false;
                        }
                    })
                    context.posts = data;
                }

                const post = data.find(p => p.id == postId);

                context.post = post;

                this.loadPartials({
                    'header': '../templates/header.hbs',
                    'post': '../templates/post.hbs',
                }).then(function () {
                    this.partial('../templates/edit.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })


    //SEMI-GET

    this.get('#/logout', function (context) {
        userModel.signOut()
            .then(() => {
                localStorage.removeItem('userInfo');

                logSuccessMessage('Logged out')

                context.redirect('#/home');
            })
    })

    this.get('#/delete/:id', function (context) {
        const postId = getContextId(context);

        db.collection('posts')
            .doc(postId)
            .delete()
            .then(() => {
                logSuccessMessage('Deleted successfully');

                context.redirect('#/home')
            })
            .catch(err => errorHandler(err));
    })


    //POST

    this.post('#/register', function (context) {
        let { email, password, repeatPassword } = context.params;

        if (password === repeatPassword) {
            userModel.createUserWithEmailAndPassword(email, password)
                .then(() => {
                    logSuccessMessage('Registered successfully!');

                    context.redirect('#/login');
                })
                .catch(err => logErrorMessage(err.message));
        } else {
            logErrorMessage('Passwords should match!');
        }
    })

    this.post('#/login', function (context) {
        let { email, password } = context.params;

        userModel.signInWithEmailAndPassword(email, password)
            .then(userData => {
                let { email, uid } = userData.user;
                let userInfo = { email, uid };

                localStorage.setItem('userInfo', JSON.stringify(userInfo));

                logSuccessMessage('Login successful!');

                context.redirect('#/home');
            })
            .catch(err => logErrorMessage(err.message));
    })

    this.post('#/create-post', function (context) {
        const { uid } = getUserData();
        const { title, category, content } = context.params;

        if (title && category && content) {
            db.collection('posts')
                .add({
                    title,
                    category,
                    content,
                    creator: uid,
                })
                .then(() => {
                    logSuccessMessage('Created successfully!');

                    context.redirect('#/home')
                })
                .catch(err => errorHandler(err));
        }
    })

    this.post('#/edit-post/:id', function (context) {
        const postId = getContextId(context);

        const { title, category, content } = context.params;

        if (title && category && content) {
            db.collection('posts')
                .doc(postId)
                .update({
                    title,
                    category,
                    content,
                })
                .then(() => {
                    logSuccessMessage('Edited successfully!');

                    context.redirect('#/home');
                })
                .catch(err => errorHandler(err));
        }
    })
};

//LOADS HEADER
function loadHeaderView(context) {
    return context.loadPartials({
        'header': '../templates/header.hbs',
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
    console.log(err);
}

//NOTIFICATION BOXES
function logSuccessMessage(message) {
    const successBox = elements.successBox();

    successBox.firstElementChild.textContent = message;
    successBox.style.display = 'block';

    timeoutMessage(successBox);
}

function logErrorMessage(message) {
    const errorBox = elements.errorBox();

    errorBox.firstElementChild.textContent = message;
    errorBox.style.display = 'block';

    timeoutMessage(errorBox);
}

function timeoutMessage(element) {
    setTimeout(() => {
        element.style.display = 'none';
    }, 2000)
}

app.run('#/');