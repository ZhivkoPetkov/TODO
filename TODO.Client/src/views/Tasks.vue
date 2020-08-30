<template>
  <div  stlye="margin-top:40px">
    <h1 v-if="tasks.length === 0">You dont have any tasks now. Enjoy your beer :-) </h1>
    <div class="card" v-for="task in tasks" :key="task.id">
      <header class="card-header">
        <div class="row justify-content-center card-header-title">
          <p>{{task.title}}</p>

          <div style="margin-left:auto; margin-right:0;">
            <span class="tag is-danger" style="margin-right: 4px" v-if="task.isImportant">Important</span>
            <span v-if="isLateTask(task) && !task.isFinished" class="tag is-warning">Late</span>
            <span v-if="task.isFinished" class="tag is-success">FINISHED</span>
          </div>
        </div>
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
        <a @click="finishTask(task.id)" v-if="!task.isFinished" class="card-footer-item">Finish</a>
        <a @click="editTask(task.id)" v-if="!task.isFinished" class="card-footer-item">Edit</a>
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
      await this.$store.dispatch("deleteTaskAction", id);
    },
    async finishTask(id) {
      await this.$store.dispatch("finishTaskAction", id);
    },
    async editTask(id){
      this.$router.push({name: "addTaskModal", params: { taskId: id}})
    },
    isLateTask(task) {
      return (
        new Date(task.endDate).toLocaleDateString("en-US") <
        new Date().toLocaleDateString("en-US")
      );
    },
  },
  computed: {
    ...mapState(["tasks", "taskFilter"]),
  },
};
</script>