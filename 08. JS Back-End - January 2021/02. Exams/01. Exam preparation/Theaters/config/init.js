// TODO: Enter databaseName, choose PORT
const config = {
    development: {
        PORT: 5000,
        DB_CONNECTION: 'mongodb://localhost:27017/Theaters',
        SALT_ROUNDS: 1,
        SECRET: 'exercise',
        AUTH_COOKIE: 'AUTH',
    },
    production: {
        PORT: 80,
        DB_CONNECTION: 'production connection string',
        SALT_ROUNDS: 10,
        SECRET: 'exercise',
        AUTH_COOKIE: 'AUTH',
    }
}

module.exports = config[process.env.NODE_ENV];