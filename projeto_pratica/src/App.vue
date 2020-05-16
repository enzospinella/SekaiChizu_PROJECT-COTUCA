<!--
  O objetivo do App.vue é inicializar o projeto.
  @authors Enzo Furegatti Spinella, Mateus Stolze Vasquez & Pedro Go Iqueda
  @since 2020
-->

<template>
  <div id="app">
    
    <router-view></router-view>
  </div>
</template>

<script>
import Menu from './components/shared/Menu.vue';
export default {
  name: 'app',
  data () {
    return{}
  }, 
  components: {
    'meuMenu': Menu
  }
}
</script>

<style>
body {
  margin: 0;
}
#app{
  
        height: 100%;
        width: 100vmax;
    }
</style>
