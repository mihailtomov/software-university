//да се допълни

Информация за проекта:

npm install инсталира всички нужни библиотеки и пакети, заедно с nodemon в devDependencies 
npm start стартира сървъра + локална mongoDB база данни + nodemon на порт 5000 (порта и db connection string се намират в config/init.js)

Адресът на базата данни е mongodb://localhost:27017/databaseName (чест проблем да не тръгне е ако в services не е стартиран mongoDB сървъра)

Добавен е css за fadeout анимация на съобщенията при грешка, тоест след 3 секунди съобщенията изчезват

Информация за route-овете:

guest:
home -> /
login -> /auth/login
register -> /auth/register

authenticated:
home -> /
create -> /model/create
details -> /model/details/:id
like -> /model/like/:id
edit -> /model/edit/:id
delete -> /model/delete/:id
logout -> /auth/logout