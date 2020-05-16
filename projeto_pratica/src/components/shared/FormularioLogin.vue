<template>
<div>
  <meuMenu></meuMenu>
  <div class="container" >
    <div class="content">      
        <div id="login">
            <form> 
                <h1>Login</h1> 

                <p style="color: red">
                    
                </p>

                <p> 
                    <label for="email-login">Seu E-Mail</label>
                    <input id="email-login" v-model="email" required="required" type="text" placeholder="ex. mateus.vazquez@gmail.com"/>
                </p>
                
                <p> 
                    <label for="senha_login">Sua Senha</label>
                    <input id="senha_login" v-model="senha" required="required" type="password" placeholder="ex. senha" /> 
                </p>
                
                <p> 
                    <input type="checkbox" name="manterlogado" id="manterlogado" value="" /> 
                    <label for="manterlogado">Manter-me logado</label>
                </p>
                
                <p> 
                    <button v-on:click="logar">Logar</button>
                </p>
                
                <p class="link">
                    Ainda não tem conta?
                    <router-link :to="'/usuario/cadastro'" exact>Cadastre-se</router-link>
                </p>
            </form>
      </div>  
    </div>
  </div> 
</div>
</template>

<script>
import Menu from './Menu.vue';
import formularios from '../styles/Formularios.css';
export default {
    data() {
        return{
            usuarios: [],
            entrou: false,
            email: "",
            senha: "",
            nome: "",
            sobreNome: "",
            codUsuario: 0,
        }
    },
    components: {
      'meuMenu': Menu,
    },
    created() {
      this.$http.get("http://localhost:5000/usuario")
                  .then(res => res.json())
                  .then (
                    dadosRetornados => (this.usuarios = dadosRetornados),
                    err => console.log(err),);
    },
    methods: {
      logar: function() {
        //coleta a tabela de usuarios
        //compara o email de cada usuario com os usuarios da tabela 
        for (var usuario of this.usuarios)
        {
          if (usuario.email == this.email && usuario.senha == this.senha)
          {
            this.entrou = true;
            this.codUsuario = usuario.id;
          }
        }
        if (this.entrou)
        {
          this.$router.push('/usuario/'+ this.codUsuario);
          //redireciona para a janela do mapa
          //https://michaelnthiessen.com/redirect-in-vue/
        }
      }
    },
}
</script>

<style>

</style>