db.collection('nameOfCollection')
    .add({
        objectData
    })
    .then(() => context.redirect('Route'))
    .catch(err => errorHandler(err));