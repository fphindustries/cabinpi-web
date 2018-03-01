const express = require('express');
const config = require('config');

const app = express();
const routes = require('./routes');


// const indexHTML = (() => {
//   return fs.readFileSync(path.resolve(__dirname, './index.html'), 'utf-8');
// })();

// app.use('/dist', express.static(path.resolve(__dirname, './dist')));

routes(app);

app.use(express.static('client'));
// app.get('*', (req, res) => {
//   res.write(indexHTML);
//   res.end();
// });

const port = config.get('server.port') || process.env.PORT || 3000;
app.listen(port, () => {
  console.log(`server started at http://localhost:${port}`);
});
