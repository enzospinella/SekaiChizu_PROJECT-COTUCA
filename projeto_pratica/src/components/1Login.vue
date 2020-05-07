<template>
  <div class="container" >
    <a class="links" id="paracadastro"></a>
    <a class="links" id="paralogin"></a>
   
     
    <div class="content">      
      <!--FORMULÁRIO DE LOGIN-->
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
            <a href="#paracadastro">Cadastre-se</a>
          </p>
        </form>
      </div>

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
            <a href="#paralogin"> Ir para Login </a>
          </p>
        </form>
      </div>

    </div>
  </div> 
</template>

<script>
import Login from './shared/Formulario.vue'
import Menu from './shared/Menu.vue'
export default {
    components: {
        'login': Login,
        'meuMenu': Menu,
    },
    data() {
      return {
        usuarios: [],
        entrou: false,
        email: "",
        senha: "",
        nome: "",
        sobreNome: "",
        codUsuario: 0,
        erroNoCadastro: ""
      }
    },
    created() {
      this.$http.get("http://localhost:5000/usuario")
                  .then(res => res.json())
                  .then (
                    dadosRetornados => (this.usuarios = dadosRetornados),
                    err => console.log(err),
                  );
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
      },
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
          usuarioCriado => (usuarioCreated = usuarioCriado),
          err => console.log(err)
        );
        //this.$router.push('/usuario/'+usuarioCreated.id);
      }

    }
}
</script>

<style>
*, *:before, *:after { 
  margin:0;
  padding:0;
  font-family: Arial,sans-serif;
}

 
/* remove a linha dos links */
a{
  text-decoration: none;
}
 
/* esconde as ancoras da tela */
a.links{
  display: none;
}
.container {
    height: 100%;
    width: 100%;
}

.content{
    max-width:500px;
    width: 100%;
    height:100%; 
    position: relative;
    top: (50% - 400px);
    left: (50% - 250px);
}

h1{
  font-size: 48px;
  color:yellowgreen;
  padding: 2px 0 10px 0;
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
  margin-bottom:15px;
}
 
.content p:first-child{
  margin: 0px;
}
 
label{
  color: #405c60;
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
input:not([type="checkbox"]), select{
  width: 95%;
  margin-top: 4px;
  padding: 10px;    
  border: 1px solid #b2b2b2;
 
  -webkit-border-radius: 3px;
  border-radius: 3px;
 
  -webkit-box-shadow: 0px 1px 4px 0px rgba(168, 168, 168, 0.6) inset;
  box-shadow: 0px 1px 4px 0px rgba(168, 168, 168, 0.6) inset;
 
  -webkit-transition: all 0.2s linear;
  transition: all 0.2s linear;
}
 
/*estilo do botão submit */
button{
  width: 100%!important;
  cursor: pointer;  
  background: yellowgreen;
  padding: 8px 5px;
  color: #fff;
  font-size: 20px;  
  border: 1px solid #fff;   
  margin-bottom: 10px;  
  text-shadow: 0 1px 1px #333;
 
  -webkit-border-radius: 5px;
  border-radius: 5px;
 
  transition: all 0.2s linear;
}
 
/*estilo do botão submit no hover */
button:hover{
  background: green;
}

.link{
  position: absolute;
  background: #e1eaeb;
  color: #7f7c7c;
  left: 0px;
  height: 20px;
  width: 88%;
  padding: 17px 30px 20px 30px;
  font-size: 16px;
  text-align: right;
  border-top: 1px solid #dbe5e8;
 
  -webkit-border-radius: 0 0  5px 5px;
  border-radius: 0 0  5px 5px;
}
 
.link a {
  font-weight: bold;
  background: #7f7c7c;
  padding: 6px;
  color: greenyellow;
  margin-left: 10px;
  border: 0,5px solid  #7f7c7c;
 
  -webkit-border-radius: 4px;
  border-radius: 4px;  
 
  -webkit-transition: all 0.4s linear;
  transition: all 0.4s  linear;
}
 
.link a:hover {
  color: #39bfd7;
  background: #f7f7f7;
  border: 1px solid #4ab3c6;
}

#cadastro, 
#login{
  position: absolute;
  padding: 18px 6% 60px 6%;
  width: 88%;
  margin: 90px 0 90px 400px;
  background: #f7f7f7;
  border: 1px solid rgba(147, 184, 189,0.8);

  -webkit-box-shadow: 5px;
  border-radius: 5px;
   
  -webkit-animation-duration: 0.2s;
  -webkit-animation-timing-function: ease;
  -webkit-animation-fill-mode: both;
 
  animation-duration: 0.5s;
  animation-timing-function: ease;
  animation-fill-mode: both;
}
#cadastro {
  margin: 50px 0px 50px 400px;
}

/* Efeito ao clicar no botão ( Ir para Login ) */
#paracadastro:target ~ .content #cadastro,
#paralogin:target ~ .content #login{
  z-index: 2;
  -webkit-animation-name: fadeInLeft;
  animation-name: fadeInLeft;
 
  -webkit-animation-delay: .1s;
  animation-delay: .1s;
}
 
/* Efeito ao clicar no botão ( Cadastre-se ) */
#registro:target ~ .content #login,
#paralogin:target ~ .content #cadastro{
  -webkit-animation-name: fadeOutLeft;
  animation-name: fadeOutLeft;
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
</style>