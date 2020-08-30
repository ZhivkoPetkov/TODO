import Vue from 'vue'
import Vuex from 'vuex'
import { dataservice } from '../services/dataservice'
import {
  GET_CATEGORIES, ADD_TASK, GET_TASKS, UPDATE_TASK_FILTER, DELETE_TASK, FINISH_TASK, SHOW_FINISHED
} from '../store/mutation-types';
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex)

const state = () => {
  categories: [];
  tasks: [];
  taskFilter: 'Today';
  showFinished: false;
};

const actions = {
  async getCategoriesAction({ commit }) {
    const categories = await dataservice.getCategories();
    commit(GET_CATEGORIES, categories);
  },
  async getTasksAction({ commit }) {
    let tasks = await dataservice.getTasks(this.state.taskFilter);

    if (this.state.showFinished === false) {
      tasks = tasks.filter(p => p.isFinished !== true)
    }

    console.log('finished:' + this.state.showFinished)

    commit(GET_TASKS, tasks);
  },
  async addTaskAction({ commit }, task) {
    const response = await dataservice.addTask(task);
    commit(ADD_TASK, response);
  },
  async updateTaskFilterAction({ commit }, filter) {
    commit(UPDATE_TASK_FILTER, filter)
    let tasks = await dataservice.getTasks(this.state.taskFilter);
    if (this.state.showFinished === false) {
      tasks = tasks.filter(p => p.isFinished !== true)
    }
    commit(GET_TASKS, tasks);
  },
  async deleteTaskAction({ commit }, id) {
    const response = await dataservice.deleteTask(id);
    if (response === true) {
      commit(DELETE_TASK, id)
    }
  },
  async finishTaskAction({ commit }, id) {
    const response = await dataservice.finishTask(id);
    commit(FINISH_TASK, response)
  },
  async updateShowFinishedAction({ commit }) {
    if (!this.state.showFinished) {
      commit(SHOW_FINISHED, true)
    } else (
      commit(SHOW_FINISHED, false)
    )
  }
};

const mutations = {
  [GET_CATEGORIES](state, categories) {
    state.categories = categories;
  },
  [GET_TASKS](state, tasks) {
    state.tasks = tasks;
  },
  [ADD_TASK](state, task) {
    if (state.tasks == undefined) {
      state.tasks = []
    }
    state.tasks.push(task);
  },
  [UPDATE_TASK_FILTER](state, filter) {
    state.taskFilter = filter;
    state.tasks = state.tasks.filter(p => p.category.name === filter);
    var result = state.tasks;
  },
  [DELETE_TASK](state, id) {
    const index = state.tasks.findIndex(p => p.id == id);
    state.tasks = [...state.tasks.filter(t => t.id != id)];
  },
  [FINISH_TASK](state, task) {
    const index = state.tasks.findIndex(p => p.id == task.id);
    state.tasks.splice(index, 1, task);
    state.tasks = [...state.tasks];
  },
  [SHOW_FINISHED](state, status) {
    state.showFinished = status
  }
};

const getters = {
  getTaskById: state => id => state.tasks.find(p => p.Id = id)
};

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  state,
  mutations,
  actions,
  getters,
  plugins: [createPersistedState()]
})
