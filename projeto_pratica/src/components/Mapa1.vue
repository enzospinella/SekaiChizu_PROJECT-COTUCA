<template>
    <div class="paginaMapa">
          <div class='wrapper'>
            <ejs-maps :zoomSettings='zoomSettings' :height='height' :width='width' :mapsAreaSettings='mapsAreaSettings' :itemSelection='procurarPaisPeloClick'>
                <e-layers>
                    <e-layer :shapeData='shapeData' :shapeSettings='shapeSettings' :selectionSettings='selectionSettings'>
                    </e-layer>
                </e-layers>
            </ejs-maps>
        </div>
    </div>
</template>

<script>
import Vue from 'vue';
import { MapsPlugin, Zoom, MapsTooltip, MapsAreaSettings, Selection, Border, click, itemSelection } from '@syncfusion/ej2-vue-maps';
import { worldMap } from '../map/world-map.js';
import axios from 'axios'
Vue.use(MapsPlugin);
export default {
    data () 
    {
        return {
            
            shapeSelectionMap:
            {
                borderModel: {
                border: "red",
                width: 0
                }
            },
            borderSettings: {
                color: 'gray',
                width: 0
            },
            mapsAreaSettings: {
                background: 'black',
            },
            selectionSettings: {
                enable: true,
                fill: 'green',
                border: {color:'black', width: 1}
            },
            zoomSettings: {
                enable: true,
                horizontalAlignment:'Near',
                mouseWheelZoom : true,
            },
            shapeData: worldMap,
            markerClusterSettings: {
                allowClustering: true,
                allowClusterExpand: true,
                shape: 'Circle',
                height: 40,
                width: 40,
                labelStyle : { color: 'white'},
            },
            width: '100%',
            height: '100%',
            shapeSettings: {
                fill: '#74f700',
                border: { color: '#004211', width: 1}
            },
            paises: []
        }
    },
    provide: {
        maps: [ Zoom, Selection ]
    },
    methods: {
        procurarPaisPeloClick: function(e)
        {
            var codPaisEscolhido;
            for(var pais of this.paises)
            {
                if (pais.nome == e.shapeData.name)
                {
                    codPaisEscolhido = pais.id;
                    break;
                }
            }
            this.$router.push('/mapa/paises/'+codPaisEscolhido+'/'+e.shapeData.name);
        },
    },
    mounted() {
        axios.get("http://localhost:5000/mapa")
             .then(response => {
                 this.paises = response.data;
             })
             .catch(err => {
                 console.log(err);
             })
    }
}

</script>
<style>
    .paginaMapa{
        /*background: #0000FF;
        background: -webkit-linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6);
        background: linear-gradient(to right, #6CB4EE, #007FFF, #0000FF, #0039a6); */
        background: #005b96;
        background: -webkit-linear-gradient(to right, #dde8f0, #97cbdc, #018abd, #004581, #001b48);
        background: linear-gradient(to right, #dde8f0, #97cbdc, #018abd, #004581, #001b48);
        overflow: hidden;
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
</style>