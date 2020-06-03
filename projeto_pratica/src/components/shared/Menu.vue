<template>
  <div class="containerMenu">
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
          <li class="menu-icon">世界<br> 地図</li> <!--icone-->
          <li class="menu-nome">Sekai<br> Chizu</li>


          
          <router-link :to="'/home'" class="button" exact>Home</router-link>

          <router-link :to="'/usuario/login'" class="button" exact>Login</router-link> <!---->

          <router-link :to="'/contato'" class="button" exact>Contato</router-link> <!---->
      
      </ul>
      <div>
        <router-link :to="'/mapa'" class="menu-buttom" exact>Abrir o Chizu</router-link>
        
      </div>
  </div>
</template>

<script>

export default {
  name: 'Menu',
  data () { 
    return {}
  },
  props: ['logado'],
}
</script>

<style scoped>
  .containerMenu {
    display: flex;
    align-items: center;
    box-sizing: border-box;
    font-size: 14pt;
    width: 100%;
    height: auto;
    /*background: #0CAFFF;
    background: -webkit-linear-gradient(to right, #00FFFF, #B2FFFF, #00BFFF, #0CAFFF);
    background: linear-gradient(to right, #00FFFF, #B2FFFF, #00BFFF, #0CAFFF); */
    background-color: transparent;
  }
  .menu {
    list-style-type: none;
    display: inline-flex;
    justify-content: flex-start;
    align-items: center;
    flex: 80%;
    margin-bottom: 1%;
    margin-top: 1%;
  }
  .menu-icon, .menu-nome{
    color: gold;
  }
  .menu-icon {
    margin-left: 6%;
  }
  .menu-nome {
    margin-right: 6%;
  }
  .menu-buttom { 
    flex: 15%;
    background-color: transparent;
    color: black;
    margin-right: 5%;
    text-decoration: none;
    text-align: center;
    padding: 1%;
    border: 1px solid black;

    transition: 0.5s;
  }
  .menu-buttom:hover{
    background-color: black!important;
    color: white!important;
  }
  .button {
    text-decoration: none;
    width: 15%;
    text-align: center;
    padding: 0 4% 0 4%;
    margin-left: 3%;
    color: black;

    transition: 0.5s;
  }
  .button:hover {
    color: white;
  }

  @media screen and (max-width: 700px) {
    .containerMenu {
        flex-direction: column;
    };
    .menu {
      flex-direction: column;
    };
  }
</style>