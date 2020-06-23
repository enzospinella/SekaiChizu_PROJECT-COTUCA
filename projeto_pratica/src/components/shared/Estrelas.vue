<template>
  <div class="estrelasDasMensagens">
      <div v-for="estrela in this.estrelas" :key="estrela.id">
          <img :src="estrela.url">
      </div>
  </div>
</template>

<script>
export default {
    props: ['qtdEstrelas'],
    data() {
        return {
            estrelas: [
                { url: '', id: 1 },
                { url: '', id: 2 },
                { url: '', id: 3 },
                { url: '', id: 4 },
                { url: '', id: 5 },
            ],
        }
    },
    created() {
        for(var estrela of this.estrelas)
        {
            var qtd = this.qtdEstrelas;
            if(qtd >= estrela.id)
                estrela.url = "../../src/assets/002-star-1.png";
            else if(qtd == (estrela.id+0.5) || qtd == (estrela.id-0.5))
                estrela.url = "../../src/assets/003-rating.png";
            else
                estrela.url = "../../src/assets/001-star.png";
        }
    },
    methods: {
    
    },
}
</script>

<style>
    .estrelasDasMensagens {
        display: flex;
    }
</style>