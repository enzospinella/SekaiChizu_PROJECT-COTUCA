<template>
  <div id="menu">
    <nav>
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
          <div id="itens">
            <li class="menu-icon">世界<br>地図</li> <!--icone-->
            <li>Sekai<br>Chizu</li>
          </div>

          
          <li class="menu-item"><router-link :to="'/'" class="button">Home</router-link></li>

          <li class="menu-item"><router-link :to="'/cadastroUsuario'" class="button">Cadastro</router-link></li> <!---->

          <li class="menu-item"><router-link :to="'/contato'" class="button">Contato</router-link></li> <!---->


          <li class="menu-button"><router-link :to="'/mapa'" class="button">Abrir o Chizu</router-link></li>
      
      </ul>
    </nav>
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
  #itens {
    display: flex;
    justify-content: space-between;
    background-color: green;
    padding:25px;
    margin: 0;
    margin-right: 20px;
  }
  .menu {
    list-style-type: none;
    display: flex;
    font-size: 23px;
    height:100%;
    max-height: 6em;
    background-color: rgba(800  , 780, 500, 0.8);
    margin: 0;
    padding: 0;
    align-items: center;
    background-color: greenyellow;
  }
  .menu-icon {
    color: gold;
    margin-right: 20px;
  }
  .menu-item {
    margin-left: 30px;
    margin-right: 60px;
  }
  .menu-button { 
    color: white;
    width: 100%;
    max-width: 6em;
    margin-left: 35%;
    border-radius: 10px;
    background-color:lightgreen;
    opacity: 0.7;
    padding: 1em;
  }
  .button {
    text-decoration: none;
    text-align: center;
  }
</style>