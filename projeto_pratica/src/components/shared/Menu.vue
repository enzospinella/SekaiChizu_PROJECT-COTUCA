<template>
  <div id="menu">
    <ul class="menu">
        <!--
          <li v-for="route in routes">

            route.path ? route.path : '/' é uma verificação, um if, 
            ele verifica se route.path é vazio e se for, ele apenas coloca /
            se não for, ele coloca o conteudo de route.path, para mais 
            informações consulte Routes.js 

          <router-link :to="route.path ? route.path : '/'">
            {{ route.titulo }}
          </router-link>
        -->
        <li class="menu-icon">世界<br>地図</li> <!--icone-->
        <li class="menu-item">Sekai<br>Chizu</li>

        <li class="menu-item"><router-link :to="'/cadastroUsuario'" class="button">Cadastro</router-link></li> <!---->

        <li class="menu-item"><router-link :to="'/contato'" class="button">Contato</router-link></li> <!---->


        <li class="menu-button"><router-link :to="'/mapa'" class="button">Abrir o Chizu</router-link></li>
      
    </ul>
  </div>
</template>

<script>

export default {
  name: 'Menu',
  data () { 
  }
}
</script>

<style>
  .menu {
    list-style-type: none;
    display: flex;
    font-size: 20px;
    background-color: rgba(800  , 780, 500, 0.8);
  }
  .menu-icon {
    align-items: flex-start;
    padding-right: 40px;
  }
  .menu-item {
    margin-left: 30px;
  }

  .menu-button { 
    width: 100%;
    max-width: 6em;
    margin-left: 60%;
    border-radius: 10px;
    background-color: blue;
    color: white;
  }
  .button {
    text-decoration: none;
    text-align: center;
  }
</style>