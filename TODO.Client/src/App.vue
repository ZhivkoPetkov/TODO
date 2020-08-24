<template>
<div class="container">
<div v-for="cat in categories" :key="cat.id">
  {{ cat.name }}
</div>
</div>
 

</template>

<script>
import {dataservice} from '../src/services/dataservice'

export default {
  created(){   
   this.loadCategories();
    console.log('created:' + this.categories);
  },
 data() {
   return {
     categories: []
 }
}, methods: {
 async loadCategories(){
    this.categories = await dataservice.getCategories();
  }
}
}
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