const app = Sammy('#main', router);

const userModel = firebase.auth();

const elements = {
    infoBox: () => document.querySelector('#infoBox'),
    errorBox: () => document.querySelector('#errorBox'),
}

function router() {
    // USE
    this.use('Handlebars', 'hbs');
    // GET
    this.get('/home', function (context) {
        validateLoggedInUser(context);
        let userEmail = '';

        if (localStorage['userInfo']) {
            userEmail = JSON.parse(localStorage['userInfo']).email;
        }

        fetch('https://routing-exercise-6b980.firebaseio.com/teams.json')
            .then(res => res.json())
            .then(teams => {
                if (teams) {
                    Object.values(teams).forEach(team => {
                        if (team.members) {
                            if (team.members.some(m => m.username == userEmail)) {
                                context.hasTeam = true;
                                context.teamId = team.teamId;
                                return;
                            }
                        }
                    })
                }
                loadFrame(context).then(function () {
                    this.partial('../templates/home/home.hbs');
                })
            })
    })

    this.get('/about', function (context) {
        validateLoggedInUser(context);

        loadFrame(context).then(function () {
            this.partial('../templates/about/about.hbs');
        })
    })

    this.get('/catalog', function (context) {
        validateLoggedInUser(context);
        const userEmail = JSON.parse(localStorage['userInfo']).email;
        context.hasNoTeam = true;

        fetch('https://routing-exercise-6b980.firebaseio.com/teams.json')
            .then(res => res.json())
            .then(teams => {
                if (teams) {
                    context.teams = Object.values(teams);
                    Object.values(teams).forEach(team => {
                        if (team.members) {
                            if (team.members.some(m => m.username == userEmail)) {
                                context.hasNoTeam = false;
                                return;
                            }
                        }
                    })
                }
                loadFrame(context)
                    .then(function () {
                        this.loadPartials({ 'team': '../templates/catalog/team.hbs' })
                    }).then(function () {
                        this.partial('../templates/catalog/teamCatalog.hbs');
                    })
            })
    })

    this.get('/catalog/:id', function (context) {
        validateLoggedInUser(context);
        const key = context.params.id;
        const currUid = JSON.parse(localStorage['userInfo']).uid;
        const currEmail = JSON.parse(localStorage['userInfo']).email;

        fetch(`https://routing-exercise-6b980.firebaseio.com/teams/${key}.json`)
            .then(res => res.json())
            .then(team => {
                context.name = team.name;
                context.comment = team.comment;
                context.members = team.members;
                context.teamId = team.teamId;

                if (team.members) {
                    if (team.members.some(m => m.username == currEmail)) {
                        context.isOnTeam = true;
                    }
                }

                if (team.author == currUid) {
                    context.isAuthor = true;
                }

                loadFrame(context)
                    .then(function () {
                        this.loadPartials({
                            'teamControls': '../templates/catalog/teamControls.hbs',
                            'teamMember': '../templates/catalog/teamMember.hbs'
                        })
                    }).then(function () {
                        this.partial('../templates/catalog/details.hbs');
                    })
            })
    })

    this.get('/edit/:id', function (context) {
        validateLoggedInUser(context);
        const key = context.params.id;

        fetch(`https://routing-exercise-6b980.firebaseio.com/teams/${key}.json`)
            .then(res => res.json())
            .then(team => {
                context.name = team.name;
                context.comment = team.comment;
                context.teamId = team.teamId;

                loadFrame(context)
                    .then(function () {
                        this.loadPartials({ 'editForm': '../templates/edit/editForm.hbs' })
                    }).then(function () {
                        this.partial('../templates/edit/editPage.hbs');
                    })
            })
    })

    this.get('/join/:id', function (context) {
        validateLoggedInUser(context);
        const key = context.params.id;
        const username = JSON.parse(localStorage['userInfo']).email;

        fetch(`https://routing-exercise-6b980.firebaseio.com/teams/${key}.json`)
            .then(res => res.json())
            .then(team => {
                let members = [];

                if (team.members) {
                    members = team.members;
                }

                members.push({ username });

                fetch(`https://routing-exercise-6b980.firebaseio.com/teams/${key}.json`, 
                { method: 'PATCH', body: JSON.stringify({ members }) })
                    .then(() => this.redirect('/catalog'))
            })
    })

    this.get('/leave/:id', function (context) {
        validateLoggedInUser(context);
        const userEmail = JSON.parse(localStorage['userInfo']).email;
        const key = context.params.id;

        fetch(`https://routing-exercise-6b980.firebaseio.com/teams/${key}.json`)
            .then(res => res.json())
            .then(team => {
                let members = team.members;

                const membership = members.find(m => m.username == userEmail);
                const index = members.indexOf(membership);
                members.splice(index, 1);

                fetch(`https://routing-exercise-6b980.firebaseio.com/teams/${key}.json`, 
                { method: 'PATCH', body: JSON.stringify({ members }) })
                    .then(() => this.redirect('/catalog'))
            })
    })

    this.get('/create', function (context) {
        validateLoggedInUser(context);

        loadFrame(context)
            .then(function () {
                this.loadPartials({ 'createForm': '../templates/create/createForm.hbs' })
            })
            .then(function () {
                this.partial('../templates/create/createPage.hbs');
            })
    })

    this.get('/register', function (context) {
        validateLoggedInUser(context);

        loadFrame(context)
            .then(function () {
                this.loadPartials({ 'registerForm': '../templates/register/registerForm.hbs' })
            })
            .then(function () {
                this.partial('../templates/register/registerPage.hbs');
            })
    })

    this.get('/login', function (context) {
        validateLoggedInUser(context);

        loadFrame(context)
            .then(function () {
                this.loadPartials({ 'loginForm': '../templates/login/loginForm.hbs' })
            })
            .then(function () {
                this.partial('../templates/login/loginPage.hbs');
            })
    })

    this.get('/logout', function () {
        userModel.signOut()
            .then(() => {
                localStorage.removeItem('userInfo');

                messageHandler('Logged out successfully');

                this.redirect('/home');
            })
            .catch(errorHandler);
    })

    // POST
    this.post('/register', function () {
        const { email, password, repeatPassword } = this.params;

        if (password == repeatPassword) {
            userModel.createUserWithEmailAndPassword(email, password)
                .then(userInfo => {
                    const { email } = userInfo.user;

                    messageHandler(`Successfully registered ${email}!`);

                    this.redirect('/login');
                })
                .catch(errorHandler)
        } else {
            errorHandler({ message: 'Passwords should match' });
        }
    })

    this.post('/login', function () {
        const { email, password } = this.params;

        userModel.signInWithEmailAndPassword(email, password)
            .then(userInfo => {
                const { uid, email } = userInfo.user;

                localStorage.setItem('userInfo', JSON.stringify({ uid, email }));

                messageHandler(`You are logged in as ${email}!`);

                this.redirect('/home');
            })
            .catch(errorHandler);
    })

    this.post('/create', function () {
        const username = JSON.parse(localStorage['userInfo']).email;
        const author = JSON.parse(localStorage['userInfo']).uid;

        const { name, comment } = this.params;

        let members = [{ username }];

        fetch('https://routing-exercise-6b980.firebaseio.com/teams.json', 
        { method: 'POST', body: JSON.stringify({ name, comment, members, author }) })
            .then(res => res.json())
            .then(data => {
                const key = data.name;
                fetch(`https://routing-exercise-6b980.firebaseio.com/teams/${key}.json`, 
                { method: 'PATCH', body: JSON.stringify({ teamId: key }) })
                    .then(() => this.redirect('/catalog'))
            })
    })

    this.post('/edit/:id', function (context) {
        validateLoggedInUser(context);
        const key = context.params.id;
        const name = context.params.name;
        const comment = context.params.comment;

        fetch(`https://routing-exercise-6b980.firebaseio.com/teams/${key}.json`, 
        { method: 'PATCH', body: JSON.stringify({ name, comment }) })
            .then(() => context.redirect('/catalog'))
    })
}

//run app
(() => {
    app.run('/home');
})()

function loadFrame(context) {
    return context.loadPartials({
        'footer': '../templates/common/footer.hbs',
        'header': '../templates/common/header.hbs',
    });
}

function validateLoggedInUser(context) {
    if (localStorage['userInfo']) {
        const loggedUserEmail = JSON.parse(localStorage.getItem('userInfo')).email;

        context.loggedIn = true;
        context.username = loggedUserEmail;
    }
}

function messageHandler(message) {
    const infoBox = elements.infoBox();
    displayMessage(infoBox, message);
    timeoutMessage(infoBox);
}

function errorHandler(err) {
    const errorBox = elements.errorBox();
    displayMessage(errorBox, err.message);
    timeoutMessage(errorBox);
}

function displayMessage(element, message) {
    element.style.display = 'block';
    element.textContent = message;
}

function timeoutMessage(element) {
    setTimeout(() => {
        element.style.display = 'none';
    }, 4000)
}