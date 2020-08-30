import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Tasks from '../views/Tasks.vue'
import AddTaskModal from '../components/AddTaskModal.vue'

Vue.use(VueRouter)
const parseProps = r => ({ id: parseInt(r.params.id) });

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Tasks
  },
  {
    path: '/add',
    name: 'addTaskModal',
    props: parseProps,
    component: AddTaskModal
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
