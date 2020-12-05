const app = Sammy('#root', router);

const userModel = firebase.auth();
const db = firebase.firestore();


// const elements = {
//     successBox: () => document.querySelector('#successBox'),
//     errorBox: () => document.querySelector('#errorBox'),
// };

function router() {
    this.use('Handlebars', 'hbs');


    // GET 

    this.get('#/home', function (context) {
        validateLoggedIn(context);

        db.collection('articles')
            .get()
            .then(res => {
                const data = res.docs.map(doc => { return { id: doc.id, ...doc.data() } });

                if (data.length > 0) {
                    const jsArticlesArr = data.filter(a => a.category == 'JavaScript');
                    const CSharpArticlesArr = data.filter(a => a.category == 'C#');
                    const javaArticlesArr = data.filter(a => a.category == 'Java');
                    const pythonArticlesArr = data.filter(a => a.category == 'Python');

                    if (jsArticlesArr) {
                        context.jsArticles = jsArticlesArr.sort((a, b) => b.title.localeCompare(a.title));
                    }
                    if (CSharpArticlesArr) {
                        context.CSharpArticles = CSharpArticlesArr.sort((a, b) => b.title.localeCompare(a.title));
                    }
                    if (javaArticlesArr) {
                        context.javaArticles = javaArticlesArr.sort((a, b) => b.title.localeCompare(a.title));
                    }
                    if (pythonArticlesArr) {
                        context.pythonArticles = pythonArticlesArr.sort((a, b) => b.title.localeCompare(a.title));
                    }
                }

                this.loadPartials({
                    'header': '../templates/partials/header.hbs',
                    'footer': '../templates/partials/footer.hbs',
                    'article': '../templates/partials/article.hbs',
                }).then(function () {
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

    this.get('#/create-article', function (context) {
        validateLoggedIn(context);

        loadHeaderAndFooter(context).then(function () {
            this.partial('../templates/create.hbs');
        })
    })

    this.get('#/details/:id', function (context) {
        validateLoggedIn(context);

        const articleId = getContextId(context);
        const { email } = getUserData();

        db.collection('articles')
            .doc(articleId)
            .get()
            .then(article => {
                context.article = { id: articleId, ...article.data() };

                if (article.data().creator == email) {
                    context.author = true;
                }

                loadHeaderAndFooter(context).then(function () {
                    this.partial('../templates/details.hbs');
                })
            })
            .catch(err => errorHandler(err));
    })

    this.get('#/edit-article/:id', function (context) {
        validateLoggedIn(context);

        const articleId = getContextId(context);

        db.collection('articles')
            .doc(articleId)
            .get()
            .then(article => {
                context.article = { id: articleId, ...article.data() };

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

                context.redirect('#/login');
            })
    })

    this.get('#/delete/:id', function (context) {
        const articleId = getContextId(context);

        db.collection('articles')
            .doc(articleId)
            .delete()
            .then(() => context.redirect('#/home'))
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
                    context.redirect('#/home');
                })
                .catch(err => alert(err.message));
        } else {
            console.log('Passwords should match!');
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

    this.post('#/create-article', function (context) {
        const { title, category, content } = context.params;
        const { email } = getUserData();

        db.collection('articles')
            .add({
                title,
                category,
                content,
                creator: email,
            })
            .then(() => context.redirect('#/home'))
            .catch(err => errorHandler(err));
    })

    this.post('#/edit-article/:id', function (context) {
        const { title, category, content } = context.params;
        const articleId = getContextId(context);

        db.collection('articles')
            .doc(articleId)
            .update({
                title,
                category,
                content,
            })
            .then(() => context.redirect('#/home'))
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
    }, 1000)
}

app.run('#/home');