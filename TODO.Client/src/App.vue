<template>
  <div class="container">
    <div class="columns">
      <div class="column is-one-quarter">
        <NavBar />
      </div>
      <div class="column is-half"  style="margin-top:20px">
        <router-view />
      </div>
    </div>
  </div>
</template>

<script>
import { dataservice } from "../src/services/dataservice";
import { mapActions, mapState } from "vuex";
import NavBar from "./components/NavBar.vue";
import Tasks from "./views/Tasks.vue";
export default {
  components: { NavBar, Tasks },
  async created() {
    await this.loadCats();
    await this.loadTasks();
  },

  methods: {
    async loadCats() {
      await this.$store.dispatch("getCategoriesAction");
    },
    async loadTasks() {
      await this.$store.dispatch("getTasksAction");
    },
  },
  computed: {
    ...mapState(["categories", "tasks", "taskFilter", "showFinished"]),
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

body,
html {
  padding: 0;
  margin: 0;
  width: 100%;
  min-height: 100vh;
  background-color: #ebecf0;
}
#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>