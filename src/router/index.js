import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../components/Home.vue';
import Environment from '../components/Environment.vue';
import Forecast from '../components/Forecast.vue';
import NotFound from '../components/NotFound.vue';
import Power from '../components/Power.vue';

// const Category = () => import('./theme/Category.vue')
// const Login = () => import('./theme/Login.vue')
// const NotFound = () => import('./theme/NotFound.vue')

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  linkActiveClass: 'is-active',
  scrollBehavior: () => ({ y: 0 }),
  routes: [
    { path: '/', component: Home },
    { path: '/forecast', component: Forecast },
    { path: '/environment', component: Environment },
    { path: '/power', component: Power },
    { path: '*', component: NotFound },
  ],
});

export default router;
