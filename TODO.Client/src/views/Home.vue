<template>
  <div>
    <h1>Taks:</h1>
    <div v-for="task in tasks" :key="task.id">{{ task.title }}</div>
  </div>
</template>

<script>
import { mapState } from "vuex";
import {dataservice} from "../services/dataservice";

export default {
  name: "Home",
  async created() {
    await this.loadTasks();
  },
  methods: {
    async loadTasks() {
      await dataservice.getTasks();
    },
  },
  computed: {
    ...mapState(["tasks"]),
  },
};
</script>
