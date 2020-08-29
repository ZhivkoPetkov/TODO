<template>
  <div class="container" style="margin-top:25px">
    <button class="button is-success is-rounded" @click="showModalScreen">Add Task</button>
    <aside class="menu">
      <div class="is-divider" />
      <ul class="menu-list">
        <li>
          <a @click="updateFilter('Today')">Today</a>
        </li>
        <li>
          <a @click="updateFilter('Important')">Important</a>
        </li>
      </ul>
      <div class="divider is-danger">----------------</div>
      <ul class="menu-list">
        <li v-for="cat in categories" :key="cat.id">
          <a a @click="updateFilter(cat.name)">{{ cat.name }}</a>
        </li>
      </ul>
    </aside>
    <AddTaskModal
      v-if="showModal"
      :isOpen="showModal"
      :categories="this.categories"
      @cancel="hideModalScreen()"
    />
    <div class="divider is-danger">----------------</div>
    <label class="checkbox">
      <input type="checkbox" :checked=showFinished  @change="updateFinishedFilter()" />
      Show finished?
    </label>
  </div>
</template>

<script>
name: "NavBar";
import AddTaskModal from "../components/AddTaskModal.vue";
import dataservice from "../services/dataservice";
import { MapState, mapState } from "vuex";

export default {
  components: { AddTaskModal },
  data() {
    return {
      showModal: false,
    };
  },
  methods: {
    async loadCategories() {
      await this.$store.dispatch("getCategoriesAction");
    },
    showModalScreen() {
      this.showModal = true;
    },
    hideModalScreen() {
      this.showModal = false;
    },
    async updateFilter(filter) {
      await this.$store.dispatch("updateTaskFilterAction", filter);
    },
    async updateFinishedFilter() {
       this.$store.dispatch("updateShowFinishedAction");
        this.$store.dispatch("getTasksAction");

    },
  },
  async created() {
    await this.loadCategories();
  },
  computed: {
    ...mapState(["categories", "showFinished", "tasks"]),
  },
};
</script>