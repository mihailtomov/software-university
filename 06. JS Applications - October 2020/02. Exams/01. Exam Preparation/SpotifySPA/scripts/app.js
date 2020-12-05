const app = Sammy('#container', router);

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

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/home.hbs');
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

    this.get('#/all-songs', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('songs')
            .get()
            .then(res => {
                const songsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                const otherSongs = songsData.filter(s => s.creator != uid).sort((a, b) => b.likes - a.likes);
                const userSongs = songsData.filter(s => s.creator == uid).sort((a, b) => b.likes - a.likes || b.listenCount - a.listenCount);

                context.otherSongs = otherSongs;
                context.userSongs = userSongs;

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/allSongs.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/my-songs', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('songs')
            .get()
            .then(res => {
                const songsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                const mySongs = songsData.filter(s => s.creator == uid).sort((a, b) => b.likes - a.likes || b.listenCount - a.listenCount);

                context.mySongs = mySongs;

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/mySongs.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/create', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/create.hbs');
        })
    })
  
    this.get('#/like/:id', function (context) {
        const songId = getContextId(context);

        db.collection('songs')
            .doc(songId)
            .get()
            .then(song => {
                let { likes } = song.data();
                likes++;

                db.collection('songs')
                    .doc(songId)
                    .update({
                        likes,
                    })
                    .then(() => {
                        logSuccessMessage('Liked!');

                        context.redirect('#/all-songs');
                    })
                    .catch(err => errorHandler(err));
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/listen/:id', function (context) {
        const songId = getContextId(context);

        db.collection('songs')
            .doc(songId)
            .get()
            .then(song => {
                let { title, listenCount } = song.data();
                listenCount++;

                db.collection('songs')
                    .doc(songId)
                    .update({
                        listenCount,
                    })
                    .then(() => {
                        logSuccessMessage(`You just listened to ${title}`);

                        context.redirect('#/all-songs');
                    })
                    .catch(err => errorHandler(err));
            })
            .catch(err => errorHandler(err));
    })

    
    //SEMI-GET


    this.get('#/logout', function (context) {
        userModel.signOut()
            .then(() => {
                sessionStorage.removeItem('userInfo');

                logSuccessMessage('Logout successful.');

                context.redirect('#/login');
            })
    })

    this.get('#/delete/:id', function (context) {
        const songId = getContextId(context);

        db.collection('songs')
            .doc(songId)
            .delete()
            .then(() => {
                logSuccessMessage('Song removed successfully!');

                context.redirect('#/all-songs');
            })
            .catch(err => errorHandler(err));
    })


    //POST

    this.post('#/register', function (context) {
        let { email, password } = context.params;

        userModel.createUserWithEmailAndPassword(email, password)
            .then(userData => {
                let { email, uid } = userData.user;
                let userInfo = { email, uid };

                sessionStorage.setItem('userInfo', JSON.stringify(userInfo));

                logSuccessMessage('User registration successful.');

                context.redirect('#/home');
            })
            .catch(err => logErrorMessage(err.message));
    })

    this.post('#/login', function (context) {
        let { email, password } = context.params;

        userModel.signInWithEmailAndPassword(email, password)
            .then(userData => {
                let { email, uid } = userData.user;
                let userInfo = { email, uid };

                sessionStorage.setItem('userInfo', JSON.stringify(userInfo));

                logSuccessMessage('Login successful.');

                context.redirect('#/home');
            })
            .catch(err => logErrorMessage(err.message));
    })

    this.post('#/create-song', function (context) {
        const { title, artist, imageURL } = context.params;
        const { uid } = getUserData();

        const validateTitle = title.length >= 6;
        const validateArtist = artist.length >= 3;
        const validateImageURL = imageURL.startsWith('http://') || imageURL.startsWith('https://');

        if (validateTitle && validateArtist && validateImageURL) {
            db.collection('songs')
                .add({
                    title,
                    artist,
                    imageURL,
                    creator: uid,
                    likes: 0,
                    listenCount: 0,
                })
                .then(() => {
                    logSuccessMessage('Song created successfully.');

                    context.redirect('#/all-songs');
                })
                .catch(err => errorHandler(err));
        } else {
            if (!validateTitle) {
                logErrorMessage('Title must be at least 6 characters long!');
            } else if (!validateArtist) {
                logErrorMessage('Artist must be at least 3 characters long!');
            } else {
                logErrorMessage('Image URL must start with http:// or https://');
            }
        }
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
    if (sessionStorage['userInfo']) {
        const userInfo = JSON.parse(sessionStorage['userInfo']);

        context.loggedIn = true;
        context.email = userInfo.email;
    } else {
        context.loggedIn = false;
    }
}
//GET UserInfo OBJECT
function getUserData() {
    return sessionStorage['userInfo'] ? JSON.parse(sessionStorage['userInfo']) : '';
}
//GET ID
function getContextId(context) {
    return context.params.id;
}

function errorHandler(err) {
    alert(err);
}

//NOTIFICATION BOXES
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
    }, 2000)
}

app.run('#/home');