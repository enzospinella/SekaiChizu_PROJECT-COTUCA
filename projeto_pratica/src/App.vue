<!--
  O objetivo do App.vue é
  Esse será o primeiro arquivo a ser inicializado
-->

<template>
  <div id="app">
    <home></home>
  </div>
</template>

<script>
import Home from './components/Home.vue';

export default {
  components: {
    'home': Home
  },
  name: 'app',
  data () {
    
  }
}
</script>

<style>

</style>
