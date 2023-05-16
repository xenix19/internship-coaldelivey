import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'MainWindow',
    component: () => import('../views/Main.vue')
  },
  {
    path: '/sign-in',
    name: 'Signin',
    component: () => import('../views/Signin.vue')
  },
  {
    path: '/sign-up',
    name: 'Signup',
    component: () => import('../views/Signup.vue')
  },
  {
    path: '/test',
    name: 'test',
    component: () => import('../views/Test.vue')
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
