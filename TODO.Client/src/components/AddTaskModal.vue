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
            <label class="label">Name</label>
            <div class="control">
              <input class="input" v-model="task.name" type="text" placeholder="Task name" />
            </div>
          </div>

          <div class="field">
            <label class="label">Category</label>
            <div class="control">
              <label  v-for="cat in categories" :key="cat.id">
                <input type="radio" 
                name="category"
                :value="cat.name"
                v-model="task.category"
                 />
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
          <button class="button is-success">Save</button>
          <button class="button" @click="dismissModal()">Cancel</button>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
name: "AddTaskModal";
category: "";
export default {
  data() {
    return {
      task: {
        name: "",
        isimportant: false,
        enddate: "",
        category: "",
      },
    };
  },
  props: {
    isOpen: {
      type: Boolean,
      default: false,
    },
    categories: {
      type: [],
      require: true,
    },
  },
  methods: {
    dismissModal() {
      this.isOpen = false;
      this.$emit("cancel");
    },
  },
};
</script>

<style>
</style>