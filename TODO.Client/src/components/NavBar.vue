<template>
  <div class="container" style="margin-top:25px">
<button class="button is-success is-rounded" @click=showModalScreen>Add Task</button>
    <aside class="menu">
      <div class="is-divider"/>
      <ul class="menu-list">
        <li>
          <a>Today</a>
        </li>
        <li>
          <a>Important</a>
        </li>
      </ul>
    <div class="divider is-danger">----------------</div>
   <ul class="menu-list">
        <li v-for="cat in categories" :key="cat.id">
           <a> {{ cat.name }}</a>
        </li>
      </ul>
    </aside>
     <AddTaskModal :isOpen="showModal" :categories="this.categories"
     @cancel="hideModalScreen()" />
  </div>
</template>

<script>
name: "NavBar";
import AddTaskModal from '../components/AddTaskModal.vue'
import dataservice from '../services/dataservice';
import {MapState, mapState} from 'vuex';

export default {
    components: {AddTaskModal},
    data() {
        return {
            showModal: false
        }
    },
    methods:{
       async loadCategories(){
           await this.$store.dispatch('getCategoriesAction');
       },
       showModalScreen(){
           this.showModal = true;
       },
       hideModalScreen()
       {
        this.showModal = false;
       }
    },
   async created(){
       await this.loadCategories()
    },
    computed:{
        ...mapState(['categories'])
    }
};
</script>