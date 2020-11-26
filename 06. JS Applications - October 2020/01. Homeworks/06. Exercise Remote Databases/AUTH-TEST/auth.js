const elements = {
    registerBtn: () => document.getElementById('reg-btn'),
    registerEmail: () => document.getElementById('reg-email'),
    registerPassword: () => document.getElementById('reg-psw'),
    registerMessage: () => document.getElementById('reg-message'),
    registerPasswordError: () => document.getElementById('reg-error'),
    loginBtn: () => document.getElementById('login-btn'),
    loginEmail: () => document.getElementById('login-email'),
    loginPassword: () => document.getElementById('login-psw'),
    loginMessage: () => document.getElementById('login-message'),
    loginPasswordError: () => document.getElementById('login-error'),
}

elements.registerBtn().addEventListener('click', registerUser);
elements.loginBtn().addEventListener('click', loginUser);

function registerUser(e) {
    e.preventDefault();

    let emailInput = elements.registerEmail();
    let passwordInput = elements.registerPassword();

    if (emailInput.value && passwordInput.value.length >= 6) {
        firebase.auth().createUserWithEmailAndPassword(emailInput.value, passwordInput.value)
            .then(res => {
                let message = elements.registerMessage();
                message.textContent = `${res.user.email} registered successfully!`;
                message.style.display = 'block';

                timeoutMessage(message);
            })
            .catch(console.error);
    } else {
        elements.registerPasswordError().style.display = 'block';

        timeoutMessage(elements.registerPasswordError());
    }

    emailInput.value = '';
    passwordInput.value = '';
}

function loginUser(e) {
    e.preventDefault();

    let emailInput = elements.loginEmail();
    let passwordInput = elements.loginPassword();
    let message = elements.loginMessage();

    firebase.auth().signInWithEmailAndPassword(emailInput.value, passwordInput.value)
        .then(res => {
            message.textContent = `Welcome back ${res.user.email}!`;
            message.style.display = 'block';

            let logoutBtn = document.createElement('button');
            logoutBtn.textContent = 'Logout';

            logoutBtn.addEventListener('click', logoutUser);

            document.body.appendChild(logoutBtn);

            timeoutMessage(message);
        })
        .catch(err => {
            message.textContent = `${err.message}`;
            message.style.display = 'block';

            timeoutMessage(message);
        })

    emailInput.value = '';
    passwordInput.value = '';
}

function logoutUser() {
    firebase.auth().signOut()
        .then(() => {
            let message = elements.loginMessage();
                message.textContent = `Logged out successfully!`;
                message.style.display = 'block';

                timeoutMessage(message);
        })

    this.remove();
}

function timeoutMessage(element) {
    setTimeout(() => {
        element.style.display = 'none';
    }, 3000);
}