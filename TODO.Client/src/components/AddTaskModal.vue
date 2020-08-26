<template>
  <div style="font-size: 50px">
    <div class="modal" :class="{'is-active': this.isOpen}">
      <div class="modal-background"></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">Add task to your TODO list</p>
          <button class="delete" aria-label="close" @click="dismissModal()"></button>
        </header>
        <section class="modal-card-body">
          <div class="field">
            <h3 class="has-text-danger is-size-6" v-if="errors.length">
              <h3>Please correct the following error(s):</h3>
              <ul>
                <li v-for="error in errors" :key="error">{{ error }}</li>
              </ul>
            </h3>
          </div>
          <div class="field">
            <label class="label">Title</label>
            <div class="control">
              <input class="input" v-model="task.title" type="text" placeholder="Task title" />
            </div>
          </div>

          <div class="field">
            <label class="label">Category</label>
            <div class="control">
              <label v-for="cat in categories" :key="cat.id">
                <input type="radio" name="category" :value="cat.id" v-model="task.category" />
                {{cat.name}}
              </label>
            </div>
          </div>
          <div class="row">
            <div class="field">
              <div class="control">
                <label class="checkbox">
                  <input type="checkbox" v-model="task.isimportant" />
                  Important task?
                </label>
              </div>
            </div>

            <div class="field">
              <label class="label">Finish date:</label>
              <div class="control">
                <input type="date" id="enddate" name="enddate" v-model="task.enddate" checked />
              </div>
            </div>
          </div>
        </section>
        <footer class="modal-card-foot">
          <button class="button is-success" @click="addTask()">Save</button>
          <button class="button" @click="dismissModal()">Cancel</button>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";
name: "AddTaskModal";
category: "";
export default {
  data() {
    return {
      task: {
        title: null,
        isimportant: false,
        enddate: null,
        category: null,
      },
      errors: [],
    };
  },
  props: {
    isOpen: {
      type: Boolean,
      default: false,
    },
    categories: {
      type: Array,
      required: true,
    },
  },
  methods: {
    ...mapActions(["addTaskAction"]),
    dismissModal() {
      this.isOpen = false;
      this.$emit("cancel");
    },

    async addTask() {
      if (this.checkForm()) {
        await this.addTaskAction(this.task);
        this.dismissModal();
      }
    },

    checkForm() {
      if (
        this.task.title &&
        this.task.category &&
        this.task.enddate &&
        this.task.isimportant
      ) {
        return true;
      }
      this.errors = [];
      if (!this.task.title) {
        this.errors.push("- Title required!");
      }
      if (!this.task.category) {
        this.errors.push("- Category required!");
      }
      if (!this.task.enddate) {
        this.errors.push("- End date required!");
      }
      if (!this.task.isimportant) {
        this.errors.push("- Is important check required!");
      }
    },
  },
};
</script>

<style>
</style>