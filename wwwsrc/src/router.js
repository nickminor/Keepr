import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'
// @ts-ignore
import ViewKeep from './views/ViewKeep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults/id',
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/viewkeep',
      name: 'viewkeep',
      component: ViewKeep
    }
  ]
})
