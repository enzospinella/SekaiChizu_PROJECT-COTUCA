<template>
    <div>
        <meuMenu :key="this.usuarioConectado"></meuMenu>
        <div class="containerPagUsuario">
            <div class="center">
                <div class="miniMenu">
                    <div class="menuInfo" @click="mudarParaInfo">
                        <h4 class="h4">SUA CONTA</h4>
                        <unicon name="user-square" fill="black"/>
                        <h1 class="h1"><i>Informações pessoais</i></h1>
                    </div>
                    <div class="menuHist" @click="mudarParaHist">
                        <h4 class="h4">SUA CONTA</h4>
                        <unicon name="backward" fill="black"/>
                        <h1 class="h1"><i>Histórico</i></h1>
                    </div>
                </div>
                <div class="normal">
                    <div class="informacoes" v-if="infoOuHist">
                        <div class="informacoesTitulo">
                            <unicon name="user-square" fill="black"/>
                            <h3 class="h3"><i>Informações pessoais</i></h3>
                        </div>
                        <form class="form">
                            <div class="primeiraLinha">
                                <div class="divLabel">
                                    <label for="" class="labels">NOME</label>
                                    <label for="" class="labels">SOBRENOME</label>
                                </div>

                                <div class="divInput">
                                    <input type="text" v-model="nome" class="texts">
                                    <input type="text" v-model="sobreNome" class="texts">
                                </div>
                            </div>
                            <div class="segundaLinha">
                                <div class="divLabel">
                                    <label for="" class="labels">E-MAIL</label>
                                    <label for="" class="labels">SENHA</label>
                                </div>

                                <div class="divInput">
                                    <input type="text" v-model="email" class="texts">
                                    <input type="password" v-model="senha" class="texts">
                                </div>
                            </div>
                            <div class="botao">
                                <button type="button" id="botao" @click="atualizarInfo">
                                    <i>ATUALIZAR INFORMAÇÕES</i>
                                </button>
                            </div>
                        </form>
                    </div>


                    <div class="historico" v-if="!infoOuHist">
                        <div class="historicoTitulo">
                            <unicon name="backward" fill="black"/>
                            <h3 class="h3"><i>Histórico</i></h3>
                        </div>
                        <div class="aviso" v-if="!temResposta">
                            <h1><i>Histórico Vazio :(</i></h1>
                        </div>
                        <div class="historicos">
                            <div class="umHistorico" v-for="historico in this.historicos" :key="historico.id">
                                <div class="lixo">
                                    <unicon name="trash-alt" fill="black" @click="excluirHistorico(historico.id)" style="cursor: pointer"/>
                                </div>
                                <p><b>Informações Procuradas: <br></b>{{historico.infoProcuradas}}</p>
                                <p><b>Lugar Marcado: <br></b>{{historico.lugarMarcado}}</p>
                                <p><b>País Visitado: <br></b>{{historico.paisVisitado}}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Menu from './shared/Menu.vue'
import {store} from '../vuex'
import axios from 'axios'
export default {
    components: {
        'meuMenu': Menu,
    },
    data() {
        return {
            infoOuHist: true,
            usuarioConectado: store.getters["getUsuarioConectado"],
            historicos: [],
            carregou: false,
            temResposta: false, 
            nome: "",
            sobreNome: "",
            email: "",
            senha: ""
        }
    },
    mounted() {
        axios.get("http://localhost:5000/historico/"+this.usuarioConectado.id)
             .then(response => {
                 this.historicos = response.data;
                 if(response.data.length!=0)
                    this.temResposta = true;
             });
        this.carregou = true;
        this.nome = this.usuarioConectado.nome;
        this.sobreNome = this.usuarioConectado.sobreNome;
        this.email = this.usuarioConectado.email;
        this.senha = this.usuarioConectado.senha
    },
    methods: {
        mudarParaInfo: function() {
            if(!this.infoOuHist)
                this.infoOuHist = true;
        },
        mudarParaHist: function() {
            if(this.infoOuHist)
                this.infoOuHist = false;
        },
        excluirHistorico: function(index) {
            if(confirm("Vamos Excluir este histórico"))
            {
                this.historicos.splice(index, 1);
                axios.delete("http://localhost:5000/historico/"+index);
            }
        },
        atualizarInfo: function() {
            if(!(this.usuarioConectado.nome != this.nome || this.usuarioConectado.sobreNome != this.sobreNome || this.usuarioConectado.email != this.email || this.usuarioConectado.senha != this.senha))
                alert("Você não Alterou nenhuma Informação");
            else {
                if(confirm("Vamos alterar seus dados")) {
                    let obj = {
                        Id: this.usuarioConectado.id,
                        nome: this.nome,
                        sobreNome: this.sobreNome,
                        senha: this.senha,
                        email: this.email
                    }
                    axios.put("http://localhost:5000/usuario/"+this.usuarioConectado.id, 
                    {
                        nome: this.nome,
                        sobreNome: this.sobreNome,
                        senha: this.senha,
                        email: this.email
                    });
                    this.usuarioConectado = obj;
                    store.dispatch("setUsuarioConectado", this.usuarioConectado);
                    alert("ALTERADO!")
                }
            }
        },
        
    },

}
</script>

<style scoped>
    .containerPagUsuario {
        height: 100%;
        width: 100%;
        display: flex;
        justify-content: center;
        box-sizing: border-box;
    }
    .miniMenu {
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: row;
        width: 100%;
        border: 1px solid blue;
        border-radius: 10px;
        margin: 3% 0 5% 0;
        padding: 1% 0 1% 0;
    }
    .normal {
        display: flex;
        width: 100%;
        border: 1px solid blue;
        border-radius: 10px;
        margin-block-end: 5%;
    }
    .informacoes {
        width: 100%;
    }
    .informacoesTitulo {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        flex-wrap: nowrap;
        padding-left: 2%;
        width: 98%;

        border-block-end: 1px solid blue;
    }
    .historico {
        width: 100%;
        min-height: 500px;
    }
    .historicoTitulo {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        flex-wrap: nowrap;
        padding-left: 2%;
        width: 98%;

        border-block-end: 1px solid blue;
    }
    .center {
        display: flex;
        justify-content: flex-start;
        align-items: flex-start;
        flex-direction: column;
        width: 80%;
    }
    .menuInfo {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        flex-wrap: wrap;
        padding-left: 1%;
        border-inline-end: 1px solid blue;
        width: 100%;
        cursor: pointer;

        transition: 1s;
    }
    .menuInfo:hover {
        color: white;
    }
    .menuHist {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        flex-wrap: wrap;
        padding-left: 1%;
        width: 100%;
        cursor: pointer;

        transition: 1s;
    }
    .menuHist:hover {
        color: white;
    }
    .form {
        margin-block-end: 5%;
        display: flex;
        flex-wrap: wrap;
    }
    .primeiraLinha {
        width: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
        flex-wrap: wrap;
    }
    .segundaLinha {
        width: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
        flex-wrap: wrap;
    }
    .h1 {
        font-size: 12pt;
        margin: 2%;
    }
    .h3 {
        font-size: 20pt;
        font-weight: bold;
        margin: 2%;
    }
    .h4 {
        font-size: 8pt;
        width: 100%;
        padding: 0;
        margin: 0;
    }
    .divLabel {
        width: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
        margin-top: 4%;
    }
    .labels {
        width: 50%;
        text-align: left;
        margin-left: 2%;
        padding-block-end: 2%;
        padding-block-start: 2%;
    }
    .divInput {
        width: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .texts {
        width: 50%;
        margin-left: 2%;
        margin-right: 2%;
        text-align: left;
        background-color: transparent;
        border-radius: 20px;
        font-size: 12pt;
        padding: 1.5% 2% 1.5% 2%;
    }
    .botao {
        display: flex;
        justify-content: center;
        align-content: center;
        margin-top: 5%;
        width: 100%;
    }
    #botao {
        background-color: yellowgreen;
        padding: 2%;
        width: 33%;
        border-radius: 20px;
        color: white;
        border: none;
        cursor: pointer;

        transition: 1s;
    }
    #botao:hover {
        color: black;
        background-color: green;
    }
    #botao:focus {
        outline: 0px auto;
        outline-offset: 0px;
    }
    .historicos {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(20%, auto));
        width: 100%;

        justify-content: center;
    }
    .umHistorico {
        margin: 8% 2% 8% 2%;
        border: 1px solid black;
        border-radius: 20px;
        padding: 4%;
        word-wrap: break-word;
    }
    .lixo {
        display: flex;
        justify-content: flex-end;
        width: 100%;
    }
    .aviso {
        width: 100%;
        height: 88%;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .outroBotao {
        display: flex;
        justify-content: flex-end;
        align-items: center;
        width: 100%;
        margin-inline-end: 5%;
    }
    #outroBotao {
        display: flex;
        align-items: center;
        justify-content: center;
        background-color: red;
        border: none;
        border-radius: 20px;
        padding: 1%;
        cursor: pointer;
        width: 20%;
    }
</style>