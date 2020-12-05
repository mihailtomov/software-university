const app = Sammy('#container', router);

const userModel = firebase.auth();
const db = firebase.firestore();

const elements = {
    successBox: () => document.querySelector('#successBox'),
    errorBox: () => document.querySelector('#errorBox'),
};

function router() {
    this.use('Handlebars', 'hbs');


    // GET 

    this.get('#/home', function (context) {
        validateLoggedIn(context);

        db.collection('movies')
            .get()
            .then(res => {
                const moviesData = res.docs.map(doc => { return { movieId: doc.id, ...doc.data() } });

                if (moviesData.length > 0) {
                    context.movies = moviesData;
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

    this.get('#/create-movie', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/create.hbs');
        })
    })


    this.get('#/details/:id', function (context) {
        validateLoggedIn(context);

        const movieId = getContextId(context);
        const { email, uid } = getUserData();

        db.collection('movies')
            .doc(movieId)
            .get()
            .then(movie => {
                const movieData = movie.data();

                context.movie = movieData;
                context.movieId = movieId;

                if (movieData.creator == uid) {
                    context.isCreator = true;
                }

                if (movieData.likes.includes(email)) {
                    context.hasLiked = true;
                    context.likesCount = movieData.likes.length;
                }

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/details.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/edit/:id', function (context) {
        validateLoggedIn(context);

        const movieId = getContextId(context);

        db.collection('movies')
            .doc(movieId)
            .get()
            .then(movie => {
                const movieData = movie.data();

                context.movie = movieData;
                context.movieId = movieId;

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/edit.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/like/:id', function (context) {
        const movieId = getContextId(context);
        const { email } = getUserData();

        db.collection('movies')
            .doc(movieId)
            .get()
            .then(movie => {
                const { likes } = movie.data();
                likes.push(email);

                db.collection('movies')
                    .doc(movieId)
                    .update({
                        likes,
                    })
                    .then(() => {
                        logSuccessMessage('Liked successfully', context, `#/details/${movieId}`);
                    })
                    .catch(err => errorHandler(err));
            })
            .catch(err => errorHandler(err));
    })


    //SEMI-GET 

    this.get('#/logout', function (context) {
        userModel.signOut()
            .then(() => {
                localStorage.removeItem('userInfo');

                logSuccessMessage('Successful logout', context, '#/login');
            })
    })

    this.get('#/delete/:id', function (context) {
        const movieId = getContextId(context);

        db.collection('movies')
            .doc(movieId)
            .delete()
            .then(() => {
                logSuccessMessage('Deleted successfully', context, '#/home');
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/search-movie', function (context) {
        validateLoggedIn(context);

        const { searchedMovie } = context.params;

        db.collection('movies')
            .get()
            .then(res => {
                const moviesData = res.docs.map(doc => { return { movieId: doc.id, ...doc.data() } });

                if (moviesData.length > 0) {
                    context.movies = moviesData.filter(m => m.title.toLowerCase().includes(searchedMovie.toLowerCase()));
                }

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/home.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })


    //POST 

    this.post('#/register', function (context) {
        let { email, password, repeatPassword } = context.params;

        const validatePassword = password.length >= 6 && password == repeatPassword;

        if (email != '' && validatePassword) {
            userModel.createUserWithEmailAndPassword(email, password)
                .then(userData => {
                    const { email, uid } = userData.user;
                    let userInfo = { email, uid };

                    localStorage.setItem('userInfo', JSON.stringify(userInfo));

                    logSuccessMessage('Successful registration!', context, '#/home');
                })
                .catch(err => logErrorMessage(err.message));
        } else {
            if (password.length < 6) {
                logErrorMessage('Password must be at least 6 characters long!')
            } else {
                logErrorMessage('Password and Repeat Password should match!');
            }
        }
    })

    this.post('#/login', function (context) {
        let { email, password } = context.params;

        userModel.signInWithEmailAndPassword(email, password)
            .then(userData => {
                let { email, uid } = userData.user;
                let userInfo = { email, uid };

                localStorage.setItem('userInfo', JSON.stringify(userInfo));

                logSuccessMessage('Login successful.', context, '#/home');
            })
            .catch(err => logErrorMessage(err.message));
    })

    this.post('#/create-movie', function (context) {
        const { uid } = getUserData();

        const { title, description, imageUrl } = context.params;

        if (title && description && imageUrl) {
            db.collection('movies')
                .add({
                    title,
                    description,
                    imageUrl,
                    creator: uid,
                    likes: [],
                })
                .then(() => {
                    logSuccessMessage('Created successfully!', context, '#/home');
                })
                .catch(err => errorHandler(err));
        } else {
            logErrorMessage('Invalid inputs!');
        }
    })

    this.post('#/edit/:id', function (context) {
        const { title, description, imageUrl } = context.params;

        const movieId = getContextId(context);

        if (title && description && imageUrl) {
            db.collection('movies')
                .doc(movieId)
                .update({
                    title,
                    description,
                    imageUrl,
                })
                .then(() => {
                    logSuccessMessage('Eddited successfully', context, `#/details/${movieId}`);
                })
                .catch(err => errorHandler(err));
        } else {
            logErrorMessage('Fields cannot be empty!');
        }
    })
};

function loadHeaderAndFooter(context) {
    return context.loadPartials({
        'header': '../templates/partials/header.hbs',
        'footer': '../templates/partials/footer.hbs',
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
    return localStorage['userInfo'] ? JSON.parse(localStorage['userInfo']) : '';
}

function getContextId(context) {
    return context.params.id;
}

function logSuccessMessage(message, context, redirectPath) {
    const successBox = elements.successBox();

    successBox.textContent = message;
    successBox.parentElement.style.display = 'block';

    timeoutSuccessRedirect(context, redirectPath);
}

function logErrorMessage(message) {
    const errorBox = elements.errorBox();

    errorBox.textContent = message;
    errorBox.parentElement.style.display = 'block';

    timeoutErrorMessage(errorBox);
}

function timeoutErrorMessage(element) {
    setTimeout(() => {
        element.parentElement.style.display = 'none';
    }, 1000)
}

function timeoutSuccessRedirect(context, path) {
    setTimeout(() => {
        context.redirect(path);
    }, 1000)
}

function errorHandler(err) {
    console.log(err);
}

(() => {
    app.run('#/home');
})();