import Vue from 'vue'
import Vuex from 'vuex'
import { dataservice } from '../services/dataservice'
import { GET_CATEGORIES, ADD_TASK, GET_TASKS } from '../store/mutation-types';
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex)

const state = () => {
  categories: [];
  tasks: [];
};

const actions = {
    async getCategoriesAction({commit}) {
      const categories = await dataservice.getCategories();
      commit(GET_CATEGORIES, categories);
    },
    async getTasksAction({commit}) {
      const tasks = await dataservice.getTasks();
      commit(GET_TASKS, tasks);
    },
    async addTaskAction({commit}, task){
      console.log(task);
      var result = await dataservice.addTask(task);
      commit(ADD_TASK, task);
    }
};

const mutations = {
    [GET_CATEGORIES](state, categories){
      state.categories = categories;
    },
    [GET_TASKS](state, tasks){
      state.tasks = tasks;
    },
    [ADD_TASK](state, task){
      if(state.tasks == undefined){
        state.tasks = []
      }
      state.tasks.push(task);
    }
};

const getters = {
  getCategories(){
    return this.$store.state.categories;
  },
}

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  state,
  mutations,
  actions,
  getters,
  plugins: [createPersistedState()]
})
