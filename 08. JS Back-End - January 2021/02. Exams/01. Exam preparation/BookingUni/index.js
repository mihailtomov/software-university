const express = require('express');
const config = require('./config/init');
const router = require('./routes');

const app = express();

require('./config/express')(app);
require('./config/mongoose');

app.use(router);

app.listen(config.PORT, () => console.log(`Server is listening on port ${config.PORT}...`));