const express = require('express');
const config = require('./config/init');
const router = require('./routes');
const errorHandler = require('./middlewares/errorHandler');

const app = express();

require('./config/express')(app);
require('./config/mongoose');

app.use(router);
app.use(errorHandler);

app.listen(config.PORT, () => console.log(`Server is listening on port ${config.PORT}...`));