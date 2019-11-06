import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../components/Home.vue'
import Team from '../components/Team.vue';
import Trainer from '../components/Trainer.vue';
import MonthView from '../components/MonthView.vue';
import WeeklyView from '../components/WeeklyView.vue';


Vue.use(VueRouter)

const routes = [
  {
    path: '/home',
    name: 'home',
    component: Home
  },
  {
    path: '/team',
    name: 'team',
    component: Team
  },
  {
    path: '/trainer',
    name: 'trainer',
    component: Trainer
  },
  {
    path: '/monthview',
    name: 'monthview',
    component: MonthView
  },

  {
    path: '/WeeklyView',
    name: 'WeeklyView',
    component: WeeklyView
  }
  // {
  //   path: '/about',
  //   name: 'about',
  //   // route level code-splitting
  //   // this generates a separate chunk (about.[hash].js) for this route
  //   // which is lazy-loaded when the route is visited.
  //   component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  // }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
