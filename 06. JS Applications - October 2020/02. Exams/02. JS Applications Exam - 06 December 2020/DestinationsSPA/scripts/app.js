const app = Sammy('#container', router);

const userModel = firebase.auth();
const db = firebase.firestore();

const elements = {
    successBox: () => document.querySelector('.infoBox'),
    errorBox: () => document.querySelector('.errorBox'),
};

$(document).ajaxStart(function(){
    $('#loading').show();
});
$(document).ajaxComplete(function(){
    $('#loading').hide();
});
$(document).ajaxError(function(){
    $('#loading').hide();
});

function router() {
    this.use('Handlebars', 'hbs');

    // GET

    this.get('#/home', function (context) {
        validateLoggedIn(context);

        db.collection('destinations')
            .get()
            .then(res => {
                const destinationsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                if (destinationsData.length > 0) {
                    context.destinations = destinationsData;
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


    this.get('#/create-destination', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/create.hbs');
        })
    })

    this.get('#/my-destinations', function (context) {
        validateLoggedIn(context);

        const { uid } = getUserData();

        db.collection('destinations')
            .get()
            .then(res => {
                const destinationsData = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                context.myDestinations = destinationsData.filter(d => d.creator === uid);

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/myDestinations.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/details/:id', function (context) {
        validateLoggedIn(context);

        const destinationId = getContextId(context);
        const { uid } = getUserData();

        db.collection('destinations')
            .doc(destinationId)
            .get()
            .then(destination => {
                let { departureDate } = destination.data();
                let dateArgs = departureDate.split('-');

                let day = dateArgs[2];
                let month = dateArgs[1];
                let year = dateArgs[0];

                let monthsMap = {
                    '01': 'January',
                    '02': 'February',
                    '03': 'March',
                    '04': 'April',
                    '05': 'May',
                    '06': 'June',
                    '07': 'July',
                    '08': 'August',
                    '09': 'September',
                    '10': 'October',
                    '11': 'November',
                    '12': 'December',
                }

                const formattedDate = day + ' ' + monthsMap[month] + ' ' + year;

                let destinationObj = { id: destination.id, ...destination.data() };
                destinationObj.departureDate = formattedDate;

                context.destination = destinationObj;

                if (destinationObj.creator === uid) {
                    context.author = true;
                }

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/details.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/edit-destination/:id', function (context) {
        validateLoggedIn(context);

        const destinationId = getContextId(context);

        db.collection('destinations')
            .doc(destinationId)
            .get()
            .then(destination => {
                context.destination = { id: destination.id, ...destination.data() };

                loadHeaderAndFooter(context).then(function () {
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

                logSuccessMessage('Logout successful.', context, '#/login');
            })
    })

    this.get('#/delete/:id', function (context) {
        const destinationId = getContextId(context);

        db.collection('destinations')
            .doc(destinationId)
            .delete()
            .then(() => {
                logSuccessMessage('Destination deleted.', context, '#/my-destinations');
            })
            .catch(err => errorHandler(err));
    })

    //POST

    this.post('#/register', function (context) {
        let { email, password, rePassword } = context.params;

        const validateNotNull = password && rePassword;
        const validateEqual = password === rePassword;

        if (email && validateNotNull && validateEqual) {
            userModel.createUserWithEmailAndPassword(email, password)
                .then(userData => {
                    let { email, uid } = userData.user;
                    let userInfo = { email, uid };

                    localStorage.setItem('userInfo', JSON.stringify(userInfo));

                    logSuccessMessage('User registration successful.', context, '#/home');
                })
                .catch(err => logErrorMessage(err.message));
        } else {
            if (!email) {
                logErrorMessage('Email cannot be empty!');
            } else if (!validateNotNull) {
                logErrorMessage('Passwords cannot be null!');
            } else if (!validateEqual) {
                logErrorMessage('Passwords should match!');
            }
        }
    })

    this.post('#/login', function (context) {
        let { email, password } = context.params;

        if (password) {
            userModel.signInWithEmailAndPassword(email, password)
                .then(userData => {
                    let { email, uid } = userData.user;
                    let userInfo = { email, uid };

                    localStorage.setItem('userInfo', JSON.stringify(userInfo));

                    logSuccessMessage('Login successful.', context, '#/home');
                })
                .catch(err => logErrorMessage(err.message));
        } else {
            logErrorMessage('Password cannot be empty!');
        }
    })

    this.post('#/create-destination', function (context) {
        const { destination, city, duration, departureDate, imgUrl } = context.params;

        const { uid } = getUserData();

        const validateDuration = duration >= 1 && duration <= 100;

        if (destination && city && duration && departureDate && imgUrl && validateDuration) {
            db.collection('destinations')
                .add({
                    destination,
                    city,
                    duration: Number(duration),
                    departureDate: departureDate.toString(),
                    imgUrl,
                    creator: uid,
                })
                .then(() => {
                    logSuccessMessage('Destination created successfully!', context, '#/home');
                })
                .catch(err => errorHandler(err));
        } else {
            if (!(destination && city && duration && departureDate && imgUrl)) {
                logErrorMessage('Fields cannot be empty!');
            } else {
                logErrorMessage('Duration must be between 1 and 100 days!');
            }
        }
    })

    this.post('#/edit-destination/:id', function (context) {
        const { destination, city, duration, departureDate, imgUrl } = context.params;

        const destinationId = getContextId(context);

        const validateDuration = duration >= 1 && duration <= 100;

        if (destination && city && duration && departureDate && imgUrl && validateDuration) {
            db.collection('destinations')
                .doc(destinationId)
                .update({
                    destination,
                    city,
                    duration: Number(duration),
                    departureDate: departureDate.toString(),
                    imgUrl,
                })
                .then(() => {
                    logSuccessMessage('Successfully edited destination.', context, `#/details/${destinationId}`);
                })
                .catch(err => errorHandler(err));
        } else {
            if (!(destination && city && duration && departureDate && imgUrl)) {
                logErrorMessage('Fields cannot be empty!');
            } else {
                logErrorMessage('Duration must be between 1 and 100 days!');
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

function logSuccessMessage(message, context, redirectPath) {
    const successBox = elements.successBox();

    successBox.textContent = message;
    successBox.style.display = 'block';

    timeoutSuccessRedirect(context, redirectPath);
}

function timeoutSuccessRedirect(context, path) {
    setTimeout(() => {
        context.redirect(path);
    }, 3000)
}

function logErrorMessage(message) {
    const errorBox = elements.errorBox();

    errorBox.textContent = message;
    errorBox.style.display = 'block';
}

function hideNotification(e) {
    e.target.style.display = 'none';
}

app.run('#/home');