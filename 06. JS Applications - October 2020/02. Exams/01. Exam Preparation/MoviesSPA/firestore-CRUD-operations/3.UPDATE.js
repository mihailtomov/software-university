db.collection('nameOfCollection')
    .doc(itemId)
    .update({
        objectData
    })
    .then(() => context.redirect('Route'))
    .catch(err => errorHandler(err));