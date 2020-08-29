<template>
  <div>
    <div class="card" v-for="task in tasks" :key="task.id">
      <header class="card-header">
        <p class="card-header-title">{{task.title}}, id: {{task.id}}</p>
        <p class="card-header-title" style="color:red" v-if="task.isImportant">! IMPORTANT</p>
        <a href="#" class="card-header-icon" aria-label="more options">
          <span class="icon">
            <i class="fas fa-angle-down" aria-hidden="true"></i>
          </span>
        </a>
      </header>
      <div class="card-content">
        <div class="content">
          Category: {{task.category.name}}
          <br />
          <time
            datetime="2016-1-1"
          >Finish date: {{new Date(task.endDate).toLocaleDateString("en-US")}}</time>
        </div>
      </div>
      <footer class="card-footer" style="margin-bottom:10px">
        <a @click="deleteTask(task.id)" class="card-footer-item">Save</a>
        <a href="#" class="card-footer-item">Edit</a>
        <a @click="deleteTask(task.id)" class="card-footer-item">Delete</a>
      </footer>
    </div>
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
    async deleteTask(id) {
      console.log(id);
      await this.$store.dispatch("deleteTaskAction", id);
    },
  },
  computed: {
    ...mapState(["tasks", "taskFilter"]),
  },
};
</script>