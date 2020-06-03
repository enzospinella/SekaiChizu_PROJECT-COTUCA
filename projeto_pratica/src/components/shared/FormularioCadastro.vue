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
            <button v-on:click="cadastrar" type="button">Cadastrar</button>
          </p>
           
          <p class="link">  
            Já tem conta?
            <router-link :to="'/usuario/login'" class="router" exact>Ir para Login</router-link>
          </p>
        </form>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import Menu from './Menu.vue';
import {mapGetters, mapState, mapMutations, mapActions} from 'vuex';
export default {
    data() {
        return{
        usuarios: [],
        usuario: [],
        entrou: false,
        email: "",
        senha: "",
        nome: "",
        sobreNome: "",
        erroNoCadastro: ""
        }
    },
    components: {
      'meuMenu': Menu
    },
    /*computed: {
      ... mapGetters([
        'usuarios'
      ])
    },*/
    async mounted() {
      try 
      {  
        const response = await axios.get('http://localhost:5000/usuario');  
        console.log(response);
        this.usuarios = response.data;    
      }
      catch (err) { 
        console.log(err) 
      }

      console.log(this.usuarios);
      this.$store.commit('setUsuarios', this.usuarios);
      console.log(this.$store.commit('getUsuarios'));
    },
    methods: {
      ... mapActions([
        'getUsuarios'
      ]),
      cadastrar: function() 
      {
        var certo = true;
        for(var usuario of this.usuarios)
        {
         
          if(usuario.email == this.email)
          {
            this.erroNoCadastro = "Este E-mail já foi cadastrado, insira outro";
            certo = false;
            return;
          }
          
          if(usuario.nome == this.nome && usuario.sobreNome == this.sobreNome)
          {
            this.erroNoCadastro = "Este Nome já está em uso, escolha outro";
            certo = false;
            return;
          }
        }
        if(certo)
        {
          this.$http.post("http://localhost:5000/usuario/cadastroUsuario", 
          {
            nome: this.nome,
            sobreNome: this.sobreNome,
            senha: this.senha,
            email: this.email
          })
          .then(res => res.json()).then(response => {this.$router.push('/usuario/'+response.id)}, err => console.log(err));
        }
      }
    },
}
</script>

<style scoped>
    *, *:before, *:after { 
    margin:0;
    padding:0;
    box-sizing: border-box;
  }
  /* remove a linha dos links */
  router-link{
    text-decoration: none;
  }
  /* esconde as ancoras da tela */
  router-link.link{
    display: none;
  }
  .container{
    width: 100vmax;
    height: 100vmin;
    /*background: #0000FF;
    background: -webkit-linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);
    background: linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);*/
    background-color: transparent;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .content{
    width: 30%;
    display: flex;
    justify-content: center;
    align-items: center;
    position: relative;
  }
  .content p:first-child{
    margin: 0px;
  }
  h1{
    font-size: 48px;
    color: #006400;
    padding: 10px;
    font-family: Arial,sans-serif;
    font-weight: bold;
    text-align: center;
    padding-bottom: 30px;
  }
  h1:after{
    content: ' ';
    display: block;
    width: 100%;
    height: 2px;
    margin-top: 10px;
    background: -webkit-linear-gradient(left, rgba(147,184,189,0) 0%,rgba(147,184,189,0.8) 20%,rgba(147,184,189,1) 53%,rgba(147,184,189,0.8) 79%,rgba(147,184,189,0) 100%); 
    background: linear-gradient(left, rgba(147,184,189,0) 0%,rgba(147,184,189,0.8) 20%,rgba(147,184,189,1) 53%,rgba(147,184,189,0.8) 79%,rgba(147,184,189,0) 100%); 
  }
p{
    margin-bottom: 6%;
  }
   
  .content p:first-child{
    margin: 0px;
  }
   
  label{
    color: #7CFC00;
    position: relative;
  }
  /* placeholder */
::-webkit-input-placeholder  {
    color: #bebcbc; 
    font-style: italic;
  }
   
  input:-moz-placeholder,
  textarea:-moz-placeholder{
    color: #bebcbc;
    font-style: italic;
  }
  input {
    outline: none;
  }
   
  /*estilo dos input,  menos o checkbox */
  input:not([type="checkbox"]){
    width: 100%;
    padding: 10px;    
    border: 1px solid #b2b2b2;
    border-radius: 3px;
    box-shadow: 0px 1px 4px 0px rgba(168, 168, 168, 0.6) inset;
    transition: all 0.2s linear;
  }
   
  /*estilo do botão submit */
  button{
    width: 100%;
    cursor: pointer;  
    background: #006400;
    background-image: linear-gradient(to bottom, #90EE90, #4CBB17, #228B22, #008000, #006400);
    padding: 10px;
    color: #fff;
    font-size: 20px;  
    border: 1px solid #fff;   
    text-shadow: 0 1px 1px #333;
    border-radius: 5px;
    transition: all 0.2s linear;
  }
   
  /*estilo do botão submit no hover */
  button:hover{
    background: #4ab3c6;background: #006400;
    background-image: linear-gradient(to top, #90EE90, #4CBB17, #228B22, #008000, #006400);
  }
  .link{
    background: #006400;
    background-image: linear-gradient(to top, #90EE90, #4CBB17, #228B22, #008000, #006400);
    color: #7CFC00;
    width: 100%;
    padding: 6%;
    font-size: 16px;
    text-align: center;
    border-top: 1px solid #dbe5e8;
    border-radius: 5px;
  }
   
  .router {
    font-weight: bold;
    text-decoration: none;
    color: #00FF00;
    transition: all 0.4s  linear;
  }
   
  .router:hover {
    color: #90EE90;
    border: 1px solid #4ab3c6;
  }
#cadastro, 
#login{
  width: 100%;
  padding: 6%;
  margin-bottom: auto;
  margin-top: auto;
  /*background: #f7f7f7;
  background-color: #0093E9;
  background-image: linear-gradient(160deg, #0093E9 0%, #80D0C7 100%);*/
  background: #006400;
  background-image: linear-gradient(to bottom, #90EE90, #4CBB17, #228B22, #008000, #006400);

  border: 1px solid rgba(147, 184, 189,0.8);
  border-radius: 5px;
  animation-duration: 0.5s;
  animation-timing-function: ease;
  animation-fill-mode: both;
}

/*fadeInLeft*/
@-webkit-keyframes fadeInLeft {
  0% {
    opacity: 0;
    -webkit-transform: translateX(-20px);
  }
  100% {
    opacity: 1;
    -webkit-transform: translateX(0);
  }
}
 
@keyframes fadeInLeft {
  0% {
    opacity: 0;
    transform: translateX(-20px);
  }
  100% {
    opacity: 1;
    transform: translateX(0);
  }
}
 
/*fadeOutLeft*/
@-webkit-keyframes fadeOutLeft {
  0% {
    opacity: 1;
    -webkit-transform: translateX(0);
  }
  100% {
    opacity: 0;
    -webkit-transform: translateX(-20px);
  }
}
 
@keyframes fadeOutLeft {
  0% {
    opacity: 1;
    transform: translateX(0);
  }
  100% {
    opacity: 0;
    transform: translateX(-20px);
  }
}
  /* Efeito ao clicar no botão ( Ir para Login ) */
  #paracadastro:target ~ .content #cadastro,
  #paralogin:target ~ .content #login{
    z-index: 2;
    animation-name: fadeInLeft;
    animation-delay: .1s;
  }
   
  /* Efeito ao clicar no botão ( Cadastre-se ) */
  #registro:target ~ .content #login,
  #paralogin:target ~ .content #cadastro{
    animation-name: fadeOutLeft;
  }
</style>