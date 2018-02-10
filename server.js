const express = require('express');
const app = express();
const fs = require('fs');
const path = require('path');
const config = require('config');

const indexHTML = (() => {
  return fs.readFileSync(path.resolve(__dirname, './index.html'), 'utf-8');
})();

app.use('/dist', express.static(path.resolve(__dirname, './dist')));

require('./build/dev-server')(app);

var routes = require('./src/server/routes/sensorsRoutes');
routes(app);

app.get('*', (req, res) => {
  res.write(indexHTML);
  res.end();
});

const port = config.get('server.port') || process.env.PORT || 3000;
app.listen(port, () => {
  console.log(`server started at http://localhost:${port}`);
});
