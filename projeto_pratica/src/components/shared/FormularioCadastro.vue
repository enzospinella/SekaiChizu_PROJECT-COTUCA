<template>
<div class="aa">
  <meuMenu></meuMenu>
  <div class="container" > 
    <div class="content">      
      <div id="cadastro">
        <form> 
          <h1>Cadastro</h1> 
          
          <p style="color: red">
            {{ erroNoCadastro }}
          </p>

          <p> 
            <label for="nome_cad">Seu nome</label>
            <input id="nome_cad" v-model="nome" required="required" type="text" placeholder="nome" />
          </p>

          <p> 
            <label for="sobreNome_cad">Seu sobrenome</label>
            <input id="sobreNome_cad" v-model="sobreNome" required="required" type="text" placeholder="Sobrenome" />
          </p>
           
          <p> 
            <label for="email_cad">Seu e-mail</label>
            <input id="email_cad" v-model="email" required="required" type="email" placeholder="enzo.spinella@gmail.com"/> 
          </p>
           
          <p> 
            <label for="senha_cad">Sua senha</label>
            <input id="senha_cad" v-model="senha" required="required" type="password" placeholder="ex. 1234"/>
          </p>
           
          <p> 
            <button v-on:click="cadastrar">Cadastrar</button>
          </p>
           
          <p class="link">  
            Já tem conta?
            <router-link :to="'/usuario/login'" exact>Ir para Login</router-link>
          </p>
        </form>
      </div>
    </div>
  </div> 
</div>
</template>

<script>
import Menu from './Menu.vue';
import formulario from '../styles/Formularios.css'
export default {
    data() {
        return{
        usuarios: [],
        usuarioCadastrado: [],
        entrou: false,
        email: "",
        senha: "",
        nome: "",
        sobreNome: "",
        codUsuario: 0,
        erroNoCadastro: ""
        }
    },
    components: {
      'meuMenu': Menu
    },
    methods: {
      cadastrar: function() 
      {
        alert(this.email);
        alert(this.senha);
        alert(this.nome);
        alert(this.sobreNome);
        var usuarioCreated;
        for(var usuario of this.usuarios)
        {
         
          if(usuario.email == this.email)
          {
            this.erroNoCadastro = "Este E-mail já foi cadastrado, insira outro";
            return;
          }
          
          if(usuario.nome == this.nome && usuario.sobreNome == this.sobreNome)
          {
            this.erroNoCadastro = "Este Nome já está em uso, escolha outro";
            return;
          }
        }

        this.$http.post("http://localhost:5000/usuario/cadastroUsuario", 
        {
          nome: this.nome,
          sobreNome: this.sobreNome,
          senha: this.senha,
          email: this.email
        })
        .then (
          usuarioCriado => (this.usuario = usuarioCriado),
          err => console.log(err)
        );
        this.$router.push('/usuario/'+this.usuario.id);
      }
    },
}
</script>

<style>
    
</style>