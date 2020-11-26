db.collection('nameOfCollection')
    .doc(itemId)
    .delete()
    .then(() => context.redirect('Route'))
    .catch(err => errorHandler(err));