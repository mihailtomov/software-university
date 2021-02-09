const config = {
    development: {
        PORT: 5007,
        DB_CONNECTION: 'mongodb://localhost:27017/BookingUni',
        SALT_ROUNDS: 1,
        SECRET: 'exercise',
    },
    production: {
        PORT: 80,
        DB_CONNECTION: 'production connection string',
        SALT_ROUNDS: 10,
        SECRET: 'exercise',
    }
}

module.exports = config[process.env.NODE_ENV];