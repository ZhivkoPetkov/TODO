<template>
  <div class="container">
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
  </div>
</template>

<script>
name: "NavBar";
import dataservice from '../services/dataservice';
import {MapState, mapState} from 'vuex';

export default {
    methods:{
       async loadCategories(){
           await this.$store.dispatch('getCategoriesAction');
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

<style>
</style>