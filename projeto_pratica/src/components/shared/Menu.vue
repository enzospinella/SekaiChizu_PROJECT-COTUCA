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


          
          <router-link :to="'/home'" class="button" >Home</router-link>

          <router-link :to="'/usuario/login'" class="button"  v-if="!conexao">Login</router-link>

          <router-link :to="'/contato'" class="button" >Contato</router-link> <!---->
          <router-link :to="'/usuario'" class="button"  v-if="conexao"><unicon name="user-circle" fill="white"/></router-link>
      
      </ul>
      <div class="menuUltimo">
        <router-link :to="'/mapa'" class="menu-buttom" >Abrir o Chizu</router-link>
        <div class="usuario" v-if="conexao">
        
          {{usuario.nome}}
          {{usuario.sobreNome}}
          <button  class="icones" v-on:click="deslogar"><unicon name="arrow-to-right" fill="white"/></button>
        </div>
      </div>
  </div>
</template>

<script>
import {store} from '../../vuex'
export default {
  name: 'Menu',
  data () { 
    return {
      usuario: store.getters['getUsuarioConectado'],
      conexao: store.getters['getConexao'],
    }
  },
  methods: {
    deslogar: function() {
      if(confirm("Você será deslogado(a)")){
        store.dispatch('setUsuarioConectado', {});
        store.dispatch('setConexao', false);
        this.usuario = {};
        this.conexao = false;
        this.$router.push("/home");
      }
    }
  }
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
    background-color: transparent;
  }
  .menu {
    list-style-type: none;
    display: inline-flex;
    justify-content: flex-start;
    align-items: center;
    flex: 75%;
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
    color: black;
    padding: 3%;
    border: 1px solid black;
    text-decoration: none;
    text-align: center;
    transition: 0.5s;
  }
  .menuUltimo {
    flex: 35%;
    display: flex;
    height: 100%;
    width: 100%;
    justify-content: center;
    align-items: center;
    background-color: transparent;
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
    cursor: pointer;
  }
  .icones {
    background-color: transparent;
    margin-left: 3pt;
    transition: 1s;
  }
  .icones:hover {
    background-color: black;
    cursor: pointer;
  }
  .usuario {
    display: flex;
    width: auto;
    align-items: center;
    padding: 1%;
    margin-left: 2%;
    border: 2px solid black;
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