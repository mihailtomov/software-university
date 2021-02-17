module.exports = (error) => {
    return { message: Object.keys(error.errors).map(x => error.errors[x].properties.message)[0] };
}