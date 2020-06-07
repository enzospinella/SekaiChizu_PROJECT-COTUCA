<template>
  <div class="paginaPais">
      <div class="mapaPais">
        <ejs-maps :zoomSettings='zoomSettings' :height='height' :width='width' :mapsAreaSettings='mapsAreaSettings'>
                <e-layers>
                    <e-layer :shapeData='shapeData' :shapeSettings='shapeSettings' :zoomSettings='zoomSettings'>
                        <!--<e-markerSettings>
                            <e-markerSetting visible=true 
                            shape="Circle"></e-markerSetting>
                            kmm<e-markerSetting visible= true :template='contentTemplate' :dataSource ="dataSource1" animationDuration = 0 ></e-markerSetting>
                            <e-markerSetting visible= true :template='contentTemplate1' :dataSource ="dataSource2" animationDuration = 0 ></e-markerSetting>
                            <e-markerSetting visible= true :template='contentTemplate2' :dataSource ="dataSource3" animationDuration = 0 ></e-markerSetting>
                            :markerClusterSettings='markerClusterSettings' :markerSettings='markerSettings' 
                        </e-markerSettings>-->
                    </e-layer>
                </e-layers>
        </ejs-maps>
      </div>
      <div class="dados">
        <div class="informacoesGeograficas">     
                <h2 @click='dropGeo'>Informações<br>Geográficas</h2>
            
                <div class="conteudo" v-if='visivelGeo'>
                    <p><b>PIB:</b><br> {{PaisG[0].pib}}</p>
                    <p><b>PIB per Capita:</b><br> {{PaisG[0].pibPerCapita}}</p>
                    <p><b>IDH(Indíce de desenvolvimento Humano):</b><br> {{PaisG[0].idh}}</p>
                    <p><b>Moeda:</b><br> {{PaisG[0].moeda}}</p>
                    <p><b>FusoHorario:</b><br> {{PaisG[0].fusoHorario}}</p>
                    <p><b>Idioma:</b><br> {{PaisG[0].idioma}}</p>
                    <p><b>População:</b><br> {{PaisG[0].populacao}}</p>
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
import { MapsPlugin, Zoom, MapsTooltip, MapsAreaSettings, Selection, Border, click, itemSelection } from '@syncfusion/ej2-vue-maps';
Vue.use(MapsPlugin);

import mapas from '../map/AllCountries.js';

export default {
    data() {
        return {
            pais: [],
            PaisH: [],
            PaisG: [],
            visivelHi: false,
            visivelGeo: false,
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
            shapeData: mapas.filter(t => t.name === this.$route.params.nome)[0],
        }
    },
    mounted() {
        axios.get("http://localhost:5000/mapa/"+this.$router.params.id)
             .then(response => {
                 this.pais = response.data;
             })
             .catch(err => {
                 console.log(err);
             });
        axios.get("http://localhost:5000/mapa/dadosG/"+this.$router.params.id)
             .then(response => {
                 this.PaisG = response.data;
             })
             .catch(err => {
                 console.log(err);
             });
        axios.get("http://localhost:5000/mapa/dadosH/"+this.$router.params.id)
             .then(response => {
                 this.PaisH = response.data;
             })
             .catch(err => {
                 console.log(err);
             });
    },
    methods: {
        dropGeo: function(){
            this.visivelGeo = !this.visivelGeo;
        },
        dropHi: function(){
            this.visivelHi = !this.visivelHi;
        }
    },
}
</script>

<style>
    .paginaPais {
        overflow: hidden;
        display: flex;
        justify-content: space-between;
        align-items: center;
        /*background: #0000FF;
        background: -webkit-linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);
        background: linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);*/
        background: #005b96;
        background: -webkit-linear-gradient(to right, #dde8f0, #97cbdc, #018abd, #004581, #001b48);
        background: linear-gradient(to right, #dde8f0, #97cbdc, #018abd, #004581, #001b48);
        height: 100%;
    }
    .mapaPais{
        flex: 50%;
        float: left;
    }
    .dados{
        float: right;
        flex: 50%;
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
    @media screen and (max-width: 700px) {
    .paginaPais {
        flex-direction: column;
    }
}
</style>