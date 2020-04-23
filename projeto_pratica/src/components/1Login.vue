<template>
  <div class="container" >
    <a class="links" id="paracadastro"></a>
    <a class="links" id="paralogin"></a>
     
    <div class="content">      
      <!--FORMULÁRIO DE LOGIN-->
      <div id="login">
        <form method="post" action=""> 
          <h1>Login</h1> 
          <p> 
            <label for="nome_login">Seu nome</label>
            <input id="nome_login" name="nome_login" required="required" type="text" placeholder="ex. mateus.vazquez@gmail.com"/>
          </p>
           
          <p> 
            <label for="email_login">Seu e-mail</label>
            <input id="email_login" name="email_login" required="required" type="password" placeholder="ex. senha" /> 
          </p>
           
          <p> 
            <input type="checkbox" name="manterlogado" id="manterlogado" value="" /> 
            <label for="manterlogado">Manter-me logado</label>
          </p>
           
          <p> 
            <input type="submit" value="Logar" /> 
          </p>
           
          <p class="link">
            Ainda não tem conta?
            <a href="#paracadastro">Cadastre-se</a>
          </p>
        </form>
      </div>

      <div id="cadastro">
        <form method="post" action=""> 
          <h1>Cadastro</h1> 
           
          <p> 
            <label for="nome_cad">Seu nome</label>
            <input id="nome_cad" name="nome_cad" required="required" type="text" placeholder="nome" />
          </p>
           
          <p> 
            <label for="email_cad">Seu e-mail</label>
            <input id="email_cad" name="email_cad" required="required" type="email" placeholder="contato@htmlecsspro.com"/> 
          </p>
           
          <p> 
            <label for="senha_cad">Sua senha</label>
            <input id="senha_cad" name="senha_cad" required="required" type="password" placeholder="ex. 1234"/>
          </p>
           
          <p> 
            <input type="submit" value="Cadastrar"/> 
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
        'meuMenu': Menu
    },
    data() {

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

.content{
    width:500px;
    max-height: 800px;
    height:100%;    
    margin: 0px auto;
    position: relative; 
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
input:not([type="checkbox"]){
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
input[type="submit"]{
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
input[type="submit"]:hover{
  background: green;
}

.link{
  position: absolute;
  background: #e1eaeb;
  color: #7f7c7c;
  left: 0px;
  height: 20px;
  width: 440px;
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
  width: 88%;
  padding: 18px 6% 60px 6%;
  margin: 0 0 35px 0;
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