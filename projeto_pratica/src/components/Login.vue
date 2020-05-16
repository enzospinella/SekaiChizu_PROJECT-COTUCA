<template>
  
</template>

<script>
export default {
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

</style>