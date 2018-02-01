module.exports = {
  root: true,
  parser: 'babel-eslint',
  parserOptions: {
    sourceType: "module"
  },
  extends: "standard",
  rules: {
    semi: [2, "always"]
  },
  // required to lint *.vue files
  plugins: ["html"]
};
