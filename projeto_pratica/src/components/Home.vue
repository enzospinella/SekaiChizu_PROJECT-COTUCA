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
          <p>ACHO MUITO LEGAL (DESCRIÇÃO DO PROJEEJ)</p>
        </div>
        <div class="homeImagens">
          <div class="imagem">
            <p>FAZER AQUELE NEGÓCIO DE IR PASSANDO IMAGENS</p>
            <img src="https://cdn.pixabay.com/photo/2014/04/02/16/28/map-307405_960_720.png">
          </div>
        </div>
      </div>
      <div>Icons made by <a href="https://www.flaticon.com/authors/pixel-perfect" title="Pixel perfect">Pixel perfect</a> from <a href="https://www.flaticon.com/"     title="Flaticon">www.flaticon.com</a></div>
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
      return {}
    }
}
</script>

<style scoped>
  .container {
    height: fit-content;
    width: 100%;
  }
  .tentativa2 {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
  }
  .homeTextos {
    display: flex;
    justify-content: center;
    align-items: flex-start;
    flex-direction: column;
    width: 80%;
  }
  .homeImagens {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    width: 80%;
  }
  .titulo {
    text-align: center;
    margin: 5% 5% 1% 5%;
  }
  .imagem {
    
  }
  h1 {
    margin: 0;
  }
</style>