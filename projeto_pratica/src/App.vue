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
        /*background: #0000FF;
        background: -webkit-linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);
        background: linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);*/
        background: #0CAFFF;
        background: -webkit-linear-gradient(to top, #00FFFF 10%, #B2FFFF 50%, #00BFFF, #0CAFFF, #082567 108%);
        background: linear-gradient(to top, #00FFFF 10%, #B2FFFF 50%, #00BFFF, #0CAFFF, #082567 108%); 
        font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
    }
</style>
