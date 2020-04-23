<template>
  <div>
    <meuMenu></meuMenu>
    <meuForms id="login"></meuForms>
  </div>
</template>

<script>
import Form from './shared/Formulario.vue'
import Menu from './shared/Menu.vue'
export default {
    components: {
        'meuForms': Form,
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
#login{
  justify-content: center;
  align-items: center;
}
</style>