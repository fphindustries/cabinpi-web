import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from './theme/Home.vue';
import Environment from './theme/Environment.vue';
import Forecast from './theme/Forecast.vue';
import NotFound from './theme/NotFound.vue';

// const Category = () => import('./theme/Category.vue')
// const Login = () => import('./theme/Login.vue')
// const NotFound = () => import('./theme/NotFound.vue')

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  linkActiveClass: 'is-active',
  scrollBehavior: (to, from, savedPosition) => ({ y: 0 }),
  routes: [
    { path: '/', component: Home },
    { path: '/forecast', component: Forecast },
    { path: '/environment', component: Environment },
    { path: '*', component: NotFound }
  ]
});

export default router;
