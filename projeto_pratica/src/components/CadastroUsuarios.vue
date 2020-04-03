<template>
  <div>
      <meuMenu></meuMenu>
      <login></login>
  </div>
</template>

<script>
import Login from './shared/Login.vue'
import Menu from './shared/Menu.vue'
export default {
    components: {
        'login': Login,
        'meuMenu': Menu
    },
    data() {

    }
}
</script>

<style>
div {
    margin: 0;
    padding: 0;
    justify-content: center;
    align-items: center;
    max-height: 800px;
    height:100%;
}
</style>