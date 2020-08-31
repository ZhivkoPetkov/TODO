<template>
  <div>
    <h3 class="has-text-danger is-size-6" v-if="errors.length">
      <h3>Please correct the following error(s):</h3>
      <ul>
        <li v-for="error in errors" :key="error">{{ error }}</li>
      </ul>
    </h3>

    <div class="field is-horizontal">
      <div class="field-label is-normal">
        <label class="label">Title</label>
      </div>
      <div class="field-body">
        <div class="field">
          <p class="control is-expanded has-icons-left">
            <input class="input" v-model="task.title" type="text" placeholder="Title" />
          </p>
        </div>
      </div>
    </div>

    <div class="field is-horizontal">
      <div class="field-label">
        <label class="label">Category</label>
      </div>
      <div class="field-body">
        <label v-for="cat in categories" :key="cat.id" style="margin-right: 10px">
          <input type="radio" name="category" :value="cat.id" v-model="task.categoryId" />
          {{cat.name}}
        </label>
      </div>
    </div>

    <div class="field is-horizontal">
      <div class="field-label is-normal">
        <label class="label">Important task</label>
      </div>
      <div class="field-body">
        <div class="field">
          <div class="control">
            <label class="checkbox">
              <input type="checkbox" :checked="task.isImportant" v-model="task.isImportant" />
            </label>
          </div>
        </div>
      </div>
    </div>

    <div class="field is-horizontal">
      <div class="field-label is-normal">
        <label class="label">End date</label>
      </div>
      <div class="field-body">
        <div class="field">
          <div class="control">
            <label>
              <datetime format="MM/DD/YYYY" width="300px" v-model="task.endDate">Date</datetime>
            </label>
          </div>
        </div>
      </div>
    </div>

    <div class="field is-horizontal">
      <div class="field-label"></div>
      <div class="field-body">
        <div class="field">
          <div class="control">
            <button style="margin-right: 20px" class="button is-success" @click="addTask()">Save</button>
            <button class="button" @click="cancel()">Cancel</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";
import datetime from "vuejs-datetimepicker";

name: "addTaskModal";
categoryId: "";

export default {
  components: { datetime },
  data() {
    return {
      task: {},
      errors: [],
    };
  },
  props: {
    taskId: {
      type: Number,
    },
  },
  async created() {
    if (this.taskId > 0) {
      this.task = this.$store.getters.getTaskById(this.taskId);
    } else {
      this.title = null;
      this.isImportant = false;
      this.endDate = null;
      this.category = null;
    }
    await this.$store.dispatch("getCategoriesAction");
  },
  computed: {
    ...mapState(["categories"]),
  },
  methods: {
    ...mapActions(["addTaskAction"]),
    cancel() {
      this.$router.push({ name: "tasks" });
    },
    async addTask() {
      if (this.checkForm()) {
        await this.addTaskAction(this.task);
        this.$router.push({ name: "tasks" });
      }
    },

    checkForm() {
      if (this.task.title && this.task.categoryId && this.task.endDate) {
        return true;
      }
      this.errors = [];
      if (!this.task.title) {
        this.errors.push("- Title required!");
      }
      if (!this.task.categoryId) {
        this.errors.push("- Category required!");
      }
      if (!this.task.endDate) {
        this.errors.push("- End date required!");
      }
    },
  },
};
</script>

<style>
</style>