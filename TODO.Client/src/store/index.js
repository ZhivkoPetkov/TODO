import Vue from 'vue'
import Vuex from 'vuex'
import { dataservice } from '../services/dataservice'
import { GET_CATEGORIES } from '../store/mutation-types';
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex)

const state = () => {
  categories: [];
};

const actions = {
    async getCategoriesAction({commit}) {
      const categories = await dataservice.getCategories();
      commit(GET_CATEGORIES, categories);
    }
};

const mutations = {
    [GET_CATEGORIES](state, categories){
      state.categories = categories;
    }
};

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  state,
  mutations,
  actions,
  plugins: [createPersistedState()]
})
