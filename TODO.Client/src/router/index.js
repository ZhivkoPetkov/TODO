import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import AddTaskModal from '../components/AddTaskModal.vue'

Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
  },
  {
    path: '/add',
    name: 'AddTaskModal',
    component: AddTaskModal
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
