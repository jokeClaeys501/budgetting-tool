import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';
import AddNewCostView from './views/AddNewCost.vue';


Vue.use(Router);

let router = new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: true
      },
    },
    {
      path:'/new-cost',
      name:'new-cost',
      component: AddNewCostView
    },
  ],
});

export default router;

