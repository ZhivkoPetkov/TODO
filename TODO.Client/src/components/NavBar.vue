<template>
  <div class="container" style="margin-top:25px">
    <router-link tag="button"
            class="button add-button is-success" :to="{ name: 'addTask' }">Add Task</router-link>

    <aside class="menu">
      <div class="is-divider" />
      <ul class="menu-list">
        <li>
          <a :class="checkFilterState('Today')" @click="updateFilter('Today')">Today</a>
        </li>
        <li>
          <a :class="checkFilterState('Important')" @click="updateFilter('Important')">Important</a>
        </li>
      </ul>
      <div class="divider is-danger">----------------</div>
      <ul class="menu-list">
        <li v-for="cat in categories" :key="cat.id">
          <a :class="checkFilterState(cat.name)" @click="updateFilter(cat.name)">{{ cat.name }}</a>
        </li>
      </ul>
    </aside>
    <div class="divider is-danger">----------------</div>
    <label class="checkbox">
      <input type="checkbox" :checked="showFinished" @change="updateFinishedFilter()" />
      Show finished?
    </label>
  </div>
</template>

<script>
name: "NavBar";
import AddTask from "../components/AddTask.vue";
import dataservice from "../services/dataservice";
import { MapState, mapState } from "vuex";

export default {
  components: { AddTask },
  data() {
    return {
      showModal: false,
    };
  },
  methods: {
    async loadCategories() {
      await this.$store.dispatch("getCategoriesAction");
    },
    async updateFilter(filter) {
      await this.$store.dispatch("updateTaskFilterAction", filter);
    },
    async updateFinishedFilter() {
      this.$store.dispatch("updateShowFinishedAction");
      this.$store.dispatch("getTasksAction");
    },
    checkFilterState(filter){
      return this.taskFilter === filter ? "has-text-weight-bold	" : ''
    }
  },
  async created() {
    await this.loadCategories();
  },
  computed: {
    ...mapState(["categories", "showFinished", "tasks", "taskFilter"]),
  },
};
</script>