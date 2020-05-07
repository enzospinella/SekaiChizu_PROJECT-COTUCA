<template>
  <div class="paginaPais">
      <div class="mapaPais">
        <ejs-maps :height='height' :width='width' :zoomSettings='zoomSettings' :mapsAreaSettings='mapsAreaSettings'>
                <e-layers>
                    <e-layer :shapeData='shapeData' :shapeSettings='shapeSettings'>
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
                <h2>Informações Geográficas</h2>
            
                <div class="conteudo">
                    <p>PIB: {{PaisG[0].pib}}</p>
                    <p>PIB per Capita: {{PaisG[0].pibPerCapita}}</p>
                    <p>IDH(Indíce de desenvolvimento Humano): {{PaisG[0].idh}}</p>
                    <p>Moeda: {{PaisG[0].moeda}}</p>
                    <p>FusoHorario: {{PaisG[0].fusoHorario}}</p>
                    <p>Idioma: {{PaisG[0].idioma}}</p>
                    <p>População: {{PaisG[0].populacao}}</p>
                    <p>Continente: {{PaisG[0].continente}}</p>
                </div>
        </div>
        <div class="informacoesHistoricas">
            
                <h2 @click=drop>Informações Históricas</h2>
                <div class="conteudo">
                    <p>Origem: {{PaisH[0].origem}}</p>
                    <p>Governo: {{PaisH[0].governo}}</p>
                    <p>Guerras: {{PaisH[0].guerras}}</p>
                </div>
            
        </div>
       </div>
  </div>
</template>

<script>
import Vue from 'vue';
import { MapsPlugin, Zoom, MapsTooltip, MapsAreaSettings, Selection, Border, click, itemSelection } from '@syncfusion/ej2-vue-maps';
Vue.use(MapsPlugin);

import mapas from '../map/AllCountries.js';

export default {
    data() {
        return {
            height: '500',
            width: '650',
            display: 'none',
            pais: [],
            PaisH: [],
            PaisG: [],
            shapeSettings: {
                fill: 'blue',
                border: 'black',
            },
            mapsAreaSettings: {
                background: 'black',
            },
            zoomSettings: {
                enable: true,
                horizontalAlignment:'Near',
                mouseWheelZoom : true,
            },
            shapeData: mapas.filter(t => t.name === this.$route.params.nome)[0],
        }
    },
    created() {
        this.$http.get("http://localhost:5000/mapa/"+this.$route.params.id)
              .then(res => res.json())
              .then (
                dadosRetornados => (this.pais = dadosRetornados),
                err => console.log(err),
          );
        this.$http.get("http://localhost:5000/mapa/dadosH/"+this.$route.params.id)
                .then(res => res.json())
                .then (
                    dadosRetornados => (this.PaisH = dadosRetornados),
                    err => (console.log(err))
        );
        this.$http.get("http://localhost:5000/mapa/dadosG/"+this.$route.params.id)
                .then(res => res.json())
                .then(
                    dadosRetornados => (this.PaisG = dadosRetornados),
                    err => (console.log(err))
        );
        console.log(PaisH[0].origem);
    },
    methods: {
        drop: function(){
            
        }
    },
}
</script>

<style>
    .paginaPais {
        width: 100%;
        height: 100%;
        display: flex;
        justify-content: space-between;
        align-items: center;
        background-color: blueviolet;
    }
    .mapaPais{
        width: 45%;
        height:100%;
        float: left;
    }
    .dados{
        float: right;
        width: 50%;
        height: 100%;
    }
    #maps_control_1_MapBorder{
        fill: goldenrod;
    }
    #maps_control_1_MapAreaBorder{
        fill: rgb(95, 93, 93);
    }
    .dados h2{
        background-color: blue;
        color: white;
        padding: 16px;
        border: none;
        cursor: pointer;
    }
    .informacoesGeograficas, .informacoeshistoricas{
        position: relative;
        display: inline-block;
        width: 90%;
    }
    .conteudo{
        display: none;
        position: absolute;
        background-color: #f9f9f9;
        box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        z-index: 1;
    }
    .dados p {
        color: red;
        padding: 12px 16px;
        text-decoration: none;
        display: block;
    }
    .dados p:hover {background-color: #f1f1f1}

    .informacoesGeograficas:hover .conteudo {
        display:block;
    }
    .informacoesHistoricas:hover .conteudo {
        display:block;
    }
</style>