//1
db.collection('nameOfCollection')
    .get()
    .then(res => {
        res.forEach(item => {
            console.log(`${item.id} => ${item.data()}`);
        })
    })
    .catch(err => errorHandler(err));

//2
db.collection('nameOfCollection')
    .get()
    .then(res => {
        const data = res.docs.map(doc => { return { id: doc.id, ...doc.data() } }); // masiv ot obektite s kliucha vutre
        const data2 = res.docs.map(doc => doc.data()); // masiv ot obektite bez kliucha vutre
    })
    .catch(err => errorHandler(err));