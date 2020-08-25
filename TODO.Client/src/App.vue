<template>
<NavBar />
</template>

<script>
import { dataservice } from "../src/services/dataservice";
import { mapActions, mapState } from "vuex";
import NavBar from './components/NavBar.vue'

export default {
  components: {NavBar},
  async created() {
    await this.loadCats();
  },

  methods: {
    async loadCats() {
      await this.$store.dispatch("getCategoriesAction");
    },
  },
  computed: {
    ...mapState(["categories"]),
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