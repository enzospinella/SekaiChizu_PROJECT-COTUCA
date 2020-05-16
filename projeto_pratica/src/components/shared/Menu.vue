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
            <li class="menu-icon">世界<br> 地図</li> <!--icone-->
            <li class="menu-nome">Sekai<br> Chizu</li>
          </div>

          
          <router-link :to="'/home'" class="button" exact><li class="menu-item">Home</li></router-link>

          <router-link :to="'/usuario/login'" class="button" exact><li class="menu-item">Login</li></router-link> <!---->

          <router-link :to="'/contato'" class="button" exact><li class="menu-item">Contato</li></router-link> <!---->

          <router-link :to="'/mapa'" class="button" exact> <li class="menu-button">Abrir o Chizu </li></router-link>
      
      </ul>
    </nav>
  </div>
</template>

<script>

export default {
  name: 'Menu',
  data () { 
    return {}
  }
}
</script>

<style>
  #itens {
    display: flex;
    justify-content: space-between;
    background-color: #0061a3;
    padding: 4px 23px 4px 23px;
    margin: 0;
    margin-right: 25px;
  }
  .menu {
    list-style-type: none;
    display: flex;
    font-size: 18px;
    height:100%;
    max-height: 50px;
    background-color: rgba(800  , 780, 500, 0.8);
    margin: 0;
    padding: 0;
    align-items: center;
    background-color: #006db8;
  }
  .menu-icon {
    color: gold;
    margin-right: 20px;
  }
  .menu-item {
    margin-left: 30px;
    margin-right: 60px;
    color: #74f700;
    font-family: Arial,sans-serif;
    font-weight:bold;
  }
  .menu-nome{
    font-family:Arial,sans-serif;
    color: #008c05;
    font-weight:bold;
  }
  .menu-button { 
    font-weight: bold;
    color: #74f700;
    width:100%;
    border-radius: 4px;
    background-color: #0061a3;
    padding: 0.8em;
    margin-left: 300%;
    font-family: Arial,sans-serif;
  }
  .menu-button:hover{
    color: #39bfd7;
    background: #f7f7f7;
  }
  .button {
    text-decoration: none;
    text-align: center;
  }
</style>