<template>
  <div>
    <div v-for="task in tasks" :key="task.id">{{ task.title }}</div>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";

export default {
    props: {
        query: {
            type: String,
        },
    },
  async created() {
    await this.loadTasks();
  },

  methods: {
    async loadTasks() {
      await this.$store.dispatch("getTasksAction");
    },
  },
  computed: {
    ...mapState(["tasks", "taskFilter"]),
  },
};
</script>