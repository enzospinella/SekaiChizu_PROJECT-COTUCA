<template>
  <div>
    <div class="container">
      <meuMenu></meuMenu>
      <div class="tentativa2">
        <div class="homeTextos">
          <div class="titulo">
            <h1>SEKAI CHIZU</h1>
            <h1>世界地図</h1>
          </div>
          <div class="descricao">
            <p><b>Sekai Chizu</b> é o mais novo site de consultas a informações Geográficas e Históricas de <b>todos</b> os países do mundo</p> <br>
            <p>Entre no nosso mapa em <b>"Abrir Chizu"</b> para experimentar! O Mapa é interativo e ainda temos uma página para cada país clicado no mapa, onde há suas informações e ainda vários pontos turísticos.
            Aproveite ainda mais cadastrando-se no <b>Sekai Chizu</b> e tenha acesso ao seu histórico de navegação! Além ainda de conseguir avaliar o projeto<p> <br>
            <p>Muito Obrigado(a) por entrar no nosso site!</p>
          </div>
        </div>
        <div class="homeImagens">
          <button @click="anterior" class="botoes"><unicon name="angle-left-b" fill="black"/></button>
          <div class="imagens" v-for="i in [indice]" :key="i">
            <img :src="imagemAtual" class="imagem">
          </div>
          <button @click="proxima" class="botoes"><unicon name="angle-right-b" fill="black"/></button>
        </div>
      </div>
      <div class="rodape">
        <p id="p"><unicon name="copyright" fill="green" />Alguns direitos reservados</p>
        <p>Maps made by @Syncfusion from <a href="https://ej2.syncfusion.com/vue/documentation/maps/getting-started/">https://ej2.syncfusion.com/vue/documentation/maps/getting-started/</a></p>
        <div>Icons made by <a href="https://www.flaticon.com/authors/pixel-perfect" title="Pixel perfect">Pixel perfect</a> from <a href="https://www.flaticon.com/"     title="Flaticon">www.flaticon.com</a></div>
      </div>
    </div>
  </div>
</template>

<script>
import Menu from './shared/Menu.vue'
export default {
    components: {
        'meuMenu': Menu
    },
    data() {
      return {
        arrayImages: [
          '../../src/assets/mapa.PNG',
          '../../src/assets/brazil.PNG',
          '../../src/assets/brazilComLugaresEHistorico.PNG',
          '../../src/assets/infoGeo.PNG',
          '../../src/assets/contato1.PNG',
          '../../src/assets/contato2.PNG',
          '../../src/assets/avaliacoes.PNG',
          '../../src/assets/informacoesPessoais.PNG',
          '../../src/assets/historico.PNG'
        ],
        indice: 0,
        qtdImagens: 6,
        temporizador: null,
      }
    },
    mounted() {
      this.comeca();
    },
    methods: {
      comeca: function() {
        this.timer = setInterval(this.proxima, 4000);
      },
      proxima: function() {
        this.indice++;
        if(this.indice==this.qtdImagens)
          this.indice = 0;
      },
      anterior: function() {
        this.indice--;
        if(this.indice < 0)
          this.indice = this.qtdImagens-1;
      }
    },
    computed: {
      imagemAtual: function() {
        return this.arrayImages[this.indice];
      }
    }
}
</script>

<style scoped>
  .container {
    height: 100%;
    width: 100%;
  }
  .tentativa2 {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
  }
  .homeTextos {
    flex: 20%;
    display: flex;
    justify-content: center;
    align-items: flex-start;
    flex-direction: column;
    width: 80%;
  }
  .homeImagens {
    flex: 75%;
    margin-block-start: 1%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: row;
    height: 100%;
    width: 100%;
    background-color: rgba(255, 255, 255, 0.2)
  }
  .titulo {
    text-align: center;
    margin: 2% 2% 0.5% 2%;
  }
  .imagens {
    display: flex;
    justify-content: center;
    height: 100%;
    width: 80%;
  }
  .imagem {
    height: 400px;
  }
  .botoes {
    background-color: transparent;
    text-decoration: none;
    border: none;
    height: 400px;
    border-radius: 10px;
    cursor: pointer;

    transition: 1s;
  }
  .botoes:hover {
    background-color: white;
  }
  .botoes:focus {
    outline: 0px auto;
    outline-offset: 0px;
  }
  .descricao {
    margin-top: 1%;
    text-align: justify;
    font-size: 12pt;
  }
  h1 {
    margin: 0;
  }
  p {
    margin: 0;
  }
  .rodape {
    text-align: center;
    width: 100%;
    margin-block-start: 1%;
    color: green;
    border-block-start: 1px solid blue;
    padding: 1%;
  }
  #p {
    display: flex;
    justify-content: center;
    align-items: center;
  }
  
</style>