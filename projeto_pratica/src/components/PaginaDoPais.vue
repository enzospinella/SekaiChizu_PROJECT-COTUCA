<template>
  <div class="paginaPais">
      <div class="mapaPais">
        <ejs-maps :zoomSettings='zoomSettings' :mapsAreaSettings='mapsAreaSettings' :markerClick="mudarCorMarker" :key="this.color">
                <e-layers>
                    <e-layer :shapeData='shapeData' :shapeSettings='shapeSettings' :zoomSettings='zoomSettings'>
                        <e-markerSettings>
                            <e-markerSetting visible=true :dataSource="dataMarkers" shape="Balloon" :tooltipSettings="tooltipSettings" width="20" height="20" colorValuePath='color' v-if="carregou"></e-markerSetting>
                        </e-markerSettings>
                    </e-layer>
                </e-layers>
        </ejs-maps>
        <div class="botao">
            <button @click="guardarHistorico" v-if="isConectado" id="btn">Guardar Histórico</button>
        </div>
      </div>
      <div class="dados">
        <div class="informacoesGeograficas">     
                <h2 @click='dropGeo'>Informações<br>Geográficas</h2>
            
                <div class="conteudo" v-if='visivelGeo'>
                    <p><b>PIB:</b><br> {{this.pib}}</p> 
                    <p><b>PIB per Capita:</b><br> {{this.pibPerCapita}}</p>
                    <p><b>IDH(Indíce de desenvolvimento Humano):</b><br> {{PaisG[0].idh.toFixed(3)}}</p>
                    <p><b>Moeda:</b><br> {{PaisG[0].moeda}}</p>
                    <p><b>FusoHorario:</b><br> {{PaisG[0].fusoHorario}}</p>
                    <p><b>Idioma:</b><br> {{PaisG[0].idioma}}</p>
                    <p><b>População:</b><br> {{this.populacao}}</p>
                    <p><b>Continente:</b><br> {{PaisG[0].continente}}</p>
                </div>
        </div>
        <div class="informacoesHistoricas">
            
                <h2 @click='dropHi'>Informações<br>Históricas</h2>
                <div class="conteudo" v-if='visivelHi'>
                    <p><b>Origem:</b><br> {{PaisH[0].origem}}</p>
                    <p><b>Governo:</b><br> {{PaisH[0].governo}}</p>
                    <p><b>Guerras:</b><br> {{PaisH[0].guerras}}</p>
                </div>
            
        </div>
       </div>
  </div>
</template>

<script>
import Vue from 'vue';
import axios from 'axios';
import {store} from '../vuex';
import { MapsPlugin, Zoom, MapsTooltip, MapsAreaSettings, Selection, Border, click, itemSelection, markerClick, Marker, Legend } from '@syncfusion/ej2-vue-maps';
Vue.use(MapsPlugin);

import mapas from '../map/AllCountries.js';

export default {
    data() {
        return {
            pais: [],
            PaisH: [],
            pib: "",
            pibPerCapita: "",
            populacao: 0,
            PaisG: [],
            lugares: [],
            dataMarkers: [],
            color: "",
            carregou: false,
            visivelHi: false,
            visivelGeo: false,
            mandouHistorico: false,
            paisVisitado: this.$route.params.nome,
            infoProcuradas: "",
            lugarMarcado: "",
            usuarioConectado: store.getters["getUsuarioConectado"],
            isConectado: store.getters["getConexao"],
            shapeSettings: {
                fill: '#74f700',
                border: { color: '#004211', width: 1}
            },
            mapsAreaSettings: {
                background: { color: 'lightgray'},
            },
            zoomSettings: {
                enable: true,
                horizontalAlignment:'Near',
                mouseWheelZoom : true,
            },
            tooltipSettings: {visible: true, valuePath: 'name'},
            shapeData: mapas.filter(t => t.name === this.$route.params.nome)[0],
        }
    },
    mounted() {
        axios.get("http://localhost:5000/mapa/"+this.$route.params.id)
             .then(response => {
                 this.pais = response.data;
             })
             .catch(err => {
                 console.log(err);
             });
        axios.get("http://localhost:5000/mapa/dadosG/"+this.$route.params.id)
             .then(response => {
                 this.PaisG = response.data;
                 this.formatarValores();
             })
             .catch(err => {
                 console.log(err);
             });
        axios.get("http://localhost:5000/mapa/dadosH/"+this.$route.params.id)
             .then(response => {
                 this.PaisH = response.data;
             })
             .catch(err => {
                 console.log(err);
             });
        axios.get("http://localhost:5000/lugares/"+this.$route.params.id)
            .then(response => {
                for(var lugar of response.data)
                {
                    let obj = {
                        latitude: lugar.coordX,
                        longitude: lugar.coordY,
                        name: lugar.nomeLugar + " - " + lugar.nomeCidade,
                        color: 'blue'
                    }
                    this.dataMarkers.push(obj);
                }
                this.color = "blue";
                this.lugares = response.data;
                this.carregou = true;
            });
    },
    methods: {
        dropGeo: function(){
            this.visivelGeo = !this.visivelGeo;
            if(this.visivelGeo)
            {
                if(this.infoProcuradas== "Históricas")
                    this.infoProcuradas += " - ";
                this.infoProcuradas += "Geográficas";
            }
        },
        dropHi: function(){
            this.visivelHi = !this.visivelHi;
            if(this.visivelHi)
            {
                if(this.infoProcuradas== "Geográficas")
                    this.infoProcuradas += " - ";

                this.infoProcuradas += "Históricas";
            }
        },
        mudarCorMarker: function(e) {
            console.log(e.data)
            for(var data of this.dataMarkers)
            {
                console.log(data)
                if(data.name==e.data.name) {
                    if(data.color=="blue")
                        data.color = "red";
                    else
                        data.color = "blue";
                    this.lugarMarcado = data.name;
                }
                else
                    data.color = "blue";
            }
            if(this.color=="blue") {
                this.color = "red";
                e.data.color = "red";
            }
            else {
                this.color = "blue";
                e.data.color = "blue";
            }
        },
        guardarHistorico: function() {
            if(this.infoProcuradas=="" || this.lugarMarcado=="")
                alert("Você não procurou informações ou não marcou um lugar");
            else {
                console.log(this.paisVisitado + this.infoProcuradas + this.lugarMarcado + this.usuarioConectado.id)
                if(confirm("Guardaremos seu histórico de Hoje!")) {
                    axios.post("http://localhost:5000/historico", 
                    {
                        paisVisitado: this.paisVisitado,
                        infoProcuradas: this.infoProcuradas,
                        lugarMarcado: this.lugarMarcado,
                        IdUsuario: this.usuarioConectado.id,
                    });
                    this.lugarMarcado = "";
                    this.infoProcuradas = "";
                }
            }
        },
        formatarValores: function() {
            this.pib = this.PaisG[0].pib.toLocaleString('pt-br',{style: 'currency', currency: 'BRL'});
            this.pibPerCapita = this.PaisG[0].pibPerCapita.toLocaleString('pt-br',{style: 'currency', currency: 'BRL'});
            this.populacao = this.PaisG[0].populacao.toLocaleString('pt-BR');
        }
    },
    provide: {
        maps: [Marker, Legend, MapsTooltip, Zoom],
    }
}
</script>

<style scoped>
    .paginaPais {
        overflow: hidden;
        display: flex;
        justify-content: space-between;
        align-items: center;
        flex-direction: row;
        /*background: #0000FF;
        background: -webkit-linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);
        background: linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);*/
        background: #005b96;
        background: -webkit-linear-gradient(to right, #dde8f0, #97cbdc, #018abd, #004581, #001b48);
        background: linear-gradient(to right, #dde8f0, #97cbdc, #018abd, #004581, #001b48);
        height: 100%;
    }
    .mapaPais{
        flex: 45%;
        float: left;
    }
    .botao {
        display: flex;
        justify-content: center;
        position: relative;
        bottom: 100px;
        left: 20%;
        z-index: 2;
    }
    .dados{
        float: right;
        flex: 45%;
        padding: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        margin-left: 2%;
    }
    .informacoesHistoricas{
        float: right;
        flex: 60%;
        height: fit-content;
    }
    .informacoesHistoricas h2{
        text-align: center;
    }
    .informacoesGeograficas{
        float: left;
        flex: 40%;
        height: fit-content;
    }
    .informacoesGeograficas h2{
        text-align: center;
    }
    #maps_control_1{
        height: 100vh;
    }
    #maps_control_1_MapBorder{
        fill: transparent;
    }
    #maps_control_1_MapAreaBorder{
        fill: transparent;
    }
    .dados h2 {
        color: black;
        background-color: green;
        width: 200px;
        padding: 10px;
        cursor: pointer;
        border-radius: 15px;
        border: 1px solid black;
        transition: 0.5s;
    }
    .dados h2:hover{
        background-color: transparent;
        color: limegreen;
    }
    .dados p {
        color: lightgray;
        padding: 0px 12px 0px 12px;
        margin-top: 20px;
        text-decoration: none;
    }
    #btn {
        color: white;
        background-color: green;
        border-radius: 10px;
        font-size: 14pt;
        border: none;
        
    }
    #btn:focus {
        outline: 0px auto;
        outline-offset: 0px;
    }
    @media screen and (max-width: 700px) {
    .paginaPais {
        flex-direction: column;
    }
}
</style>