import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Tasks from '../views/Tasks.vue'
import AddTask from '../components/AddTask.vue'

Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Tasks
  },
  {
    path: '/add',
    name: 'addTask',
    props: true,
    component: AddTask
  },
  {
    path: '/tasks',
    name: 'tasks',
    component: Tasks
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
