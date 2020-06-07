<template>
    <div id="contato">
        <meuMenu></meuMenu>
        <div class="containerContato">
            <div class="avaliacoes">
                <h1 class="titulo">Avalie sua experiência</h1>
                <div class="estrelas">
                    <div v-for="estrela in estrelas">
                        <button @click="mudarEstadoEstrela(estrela.id)" class="btnStar"><img :src="estrela.url" :id="estrela.id"></button>
                    </div>
                </div>
                <form class="mensagem" v-if="conexao">
                    <div id="label">
                        <label>Deixe a sua Mensagem: </label>
                    </div>
                    <div class="inputs">
                        <p v-if="this.status != '' " class="status">{{this.status}}</p>
                        <p v-if="this.status == '' "></p>
                        <textarea placeholder="digite sua mensagem" class="texto" v-model="mensagem"></textarea>
                        <button class="botao" type="button" @click="enviarMsg">ENVIAR</button>
                    </div>
                </form>
                <div class="mensagem2" v-if="!conexao">
                    <h2>Cadastre-se ou Logue-se para poder avaliar</h2>
                </div>
            </div>
            <div class="histograma">
                <hist :chart-data="data" :data="data" :options="opcoesHist" v-if="carregou" :styles="cssHist"></hist>
            </div>
        </div>
    </div>
</template>

<script>
import Menu from '../components/shared/Menu.vue';
import Histograma from '../components/shared/Histograma.vue';

import axios from 'axios';
import {store} from '../vuex'
export default {
    data() {
        return{
            estrelas: [
                { url: '../src/assets/001-star.png', id: 1 },
                { url: '../src/assets/001-star.png', id: 2 },
                { url: '../src/assets/001-star.png', id: 3 },
                { url: '../src/assets/001-star.png', id: 4 },
                { url: '../src/assets/001-star.png', id: 5 },
            ],
            estrelaVazia: '../src/assets/001-star.png',
            estrelaCheia: '../src/assets/002-star-1.png',
            meiaEstrela:  '../src/assets/003-rating.png',

            conexao: store.getters['getConexao'],
            carregou: false,
            data: {
                labels: ['0.5 Estrela', '1 Estrela', '1.5 Estrelas', '2 Estrelas', '2.5 Estrelas', '3 Estrelas', '3.5 Estrelas', '4 Estrelas', '4.5 Estrelas','5 Estrelas'],
                datasets: 
                [
                    {
                        label: 'Quantidade de Estrelas dadas pelos Usuários do Sekai Chizu',
                        backgroundColor: 'green',
                        borderColor: 'red',
                        data: []
                    }
                ],
            },
            opcoesHist: {
                responsive: true,
                maintainAspectRatio: false
            },
            estrelinhas: [
                {id:1, qtd:0},
                {id:2, qtd:0},
                {id:3, qtd:0},
                {id:4, qtd:0},
                {id:5, qtd:0},
                {id:6, qtd:0},
                {id:7, qtd:0},
                {id:8, qtd:0},
                {id:9, qtd:0},
                {id:10, qtd:0}
            ],
            mensagem: "",
            dataDaMensagem: "",
            qtdEstrelas: 0,
            status: '',
        }
    },
    components: {
        'meuMenu': Menu,
        'hist': Histograma
    },
    mounted() {
        axios.get("http://localhost:5000/avaliacoes")
             .then(response => {
                for (var avaliacao of response.data)
                {
                    var qtd = avaliacao.qtdEstrelas;
                    if(qtd==0.5)
                        this.estrelinhas[0].qtd++;
                    else if(qtd==1)
                        this.estrelinhas[1].qtd++;
                    else if(qtd==1.5)
                        this.estrelinhas[2].qtd++;
                    else if(qtd==2)
                        this.estrelinhas[3].qtd++;
                    else if(qtd==2.5)
                        this.estrelinhas[4].qtd++;
                    else if(qtd==3)
                        this.estrelinhas[5].qtd++;
                    else if(qtd==3.5)
                        this.estrelinhas[6].qtd++;
                    else if(qtd==4)
                        this.estrelinhas[7].qtd++;
                    else if(qtd==4.5)
                        this.estrelinhas[8].qtd++;
                    else 
                        this.estrelinhas[9].qtd++;
                }
                this.data.datasets[0].data = this.getAvaliacoes();
                this.carregou = true;
             });
    },
    computed: {
        cssHist () {
            return {
                width: "80%",
                height: "80%"
            }
        }
    },
    methods: {
        mudarEstadoEstrela: function(id) {
            this.qtdEstrelas = 0;
            for (var estrela of this.estrelas)
            {
                if(estrela.id < id || (estrela.id == id && estrela.url == this.meiaEstrela)){
                    estrela.url = this.estrelaCheia;
                    this.qtdEstrelas++;
                }
                else if (estrela.id == id){
                    estrela.url = this.meiaEstrela;
                    this.qtdEstrelas += 0.5;
                }
                else{
                    estrela.url = this.estrelaVazia;
                }
            }
            console.log(this.qtdEstrelas);
        },
        enviarMsg: function() {
            this.dataDaMensagem = new Date();
            var dd = String(this.dataDaMensagem.getDate()).padStart(2, '0');
            var mm = String(this.dataDaMensagem.getMonth() + 1).padStart(2, '0');
            var yyyy = this.dataDaMensagem.getFullYear();
            this.dataDaMensagem = dd + '-' + mm + '-' + yyyy;

            axios.post("http://localhost:5000/avaliacoes", 
            {
                qtdEstrelas: this.qtdEstrelas,
                mensagem: this.mensagem,
                dataAvaliacao: this.dataDaMensagem,
                IdUsuario: store.getters['getUsuarioConectado'].id,
            });
            this.mensagem = "";
            this.status = "ENVIADO!";
        }, 
        getAvaliacoes: function() {
            return [
                this.estrelinhas[0].qtd,
                this.estrelinhas[1].qtd,
                this.estrelinhas[2].qtd,
                this.estrelinhas[3].qtd,
                this.estrelinhas[4].qtd,
                this.estrelinhas[5].qtd,
                this.estrelinhas[6].qtd,
                this.estrelinhas[7].qtd,
                this.estrelinhas[8].qtd,
                this.estrelinhas[9].qtd
            ];
        }
    }
}
</script>

<style scoped>
    .containerContato {
        width: 100%; 
        height: 100vmin;
        display: flex;
    }
    .avaliacoes {
        display: flex;
        align-items: center;
        flex-direction: column;
        text-align: center;
        flex: 50%;
    }
    .histograma {
        flex: 50%;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .estrelas {
        display: inline-flex;
        height: auto;
    }
    .btnStar {
        background-color: transparent;
        text-decoration: none;
        border: none;
        border-radius: 10px;

        transition: 1s;
    }
    .btnStar:hover {
        background-color: white;
        cursor: pointer;
    }
    .btnStar:focus {
        outline: 0px auto;
        outline-offset: 0px;
    }
    .mensagem {
        font-size: 16pt;
        font-family: 'Times New Roman', Times, serif;
        background-color: transparent;
        margin-top: 5%;
        padding: 2%;
        border: 1px solid black;
        border-radius: 10px;
        width: 60%;
        height: 60%;
    }
    .mensagem2 {
        display: flex;
        align-items: center;
        font-size: 16pt;
        font-family: 'Times New Roman', Times, serif;
        margin-top: 5%;
        background-color: transparent;
        width: 60%;
        height: 60%;
    }
    .texto {
        font-size: 18pt;
        font-family: 'Times New Roman', Times, serif;
        font-weight: bold;
        border: 1px solid black;
        border-radius: 10px;
        width: 100%;
        height: 65%;
    }
    .botao {
        font-size: 16pt;
        font-family: 'Times New Roman', Times, serif;
        height: 10%;
        width: 30%;
    }
    .inputs {
        padding: 2% 0 2% 0;
        width: 100%;
        height: 100%;
    }
    #label {
        text-align: left;
    }
    .status {
        color: red;
        height: 5%;
    }
</style>