<template>
    <div class="paginaMapa">
          <div class='wrapper'>
            <ejs-maps :zoomSettings='zoomSettings' :height='height' :width='width' :mapsAreaSettings='mapsAreaSettings' :itemSelection='procurarPaisPeloClick'>
                <e-layers>
                    <e-layer :shapeData='shapeData' :shapeSettings='shapeSettings' :selectionSettings='selectionSettings'>
                        <e-markerSettings>
                            <e-markerSetting visible=true 
                            shape="Circle"></e-markerSetting>
                            <!--<e-markerSetting visible= true :template='contentTemplate' :dataSource ="dataSource1" animationDuration = 0 ></e-markerSetting>
                            <e-markerSetting visible= true :template='contentTemplate1' :dataSource ="dataSource2" animationDuration = 0 ></e-markerSetting>
                            <e-markerSetting visible= true :template='contentTemplate2' :dataSource ="dataSource3" animationDuration = 0 ></e-markerSetting>
                            :markerClusterSettings='markerClusterSettings' :markerSettings='markerSettings' -->
                        </e-markerSettings>
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
            /*markerClusterSettings: {
                allowClustering: true,
                allowClusterExpand: true,
                shape: 'Circle',
                height: 40,
                width: 40,
                labelStyle : { color: 'white'},
            },
            markerSettings: [
                {
                    dataSource: 
                    [
                        { latitude: 49.95121990866204, longitude: 87.468749999999998, name:'Europe' },
                        { latitude: 49.95121990866204, longitude: 45.468749999999998, name:'Europe' },
                        { latitude: 49.95121990866204, longitude: 32.468749999999998, name:'Europe' },
                        { latitude: 49.95121990866204, longitude: 99.468749999999998, name:'Europe' },
                        { latitude: 49.95121990866204, longitude: 17.468749999999998, name:'Europe' },
                        { latitude: 49.95121990866204, longitude: 18.468749999999998, name:'Europe' },
                        { latitude: 49.95121990866204, longitude: 19.468749999999998, name:'Europe' },
                        { latitude: 37.6276571, longitude: -122.4276688, name: 'San Bruno', color: 'black' },
                        { latitude: 33.5302186, longitude: -117.7418381, name: 'Laguna Niguel', color: 'black' },
                        { latitude: 40.7424509, longitude: -74.0081468, name: 'New York', color: 'black' },
                        { latitude: 49.95121990866204, longitude: 18.468749999999998, name:'Europe', color:'red', shape:'Triangle' },
                        { latitude: 59.88893689676585, longitude: -109.3359375, name:'North America', color:'blue', shape:'Pentagon' },
                        { latitude: -6.64607562172573, longitude: -55.54687499999999, name:'South America', color:'green', shape:'InvertedTriangle' }
                    ],
                    visible: true,
                    shapeValuePath:'shape',
                    colorValuePath:'color',
                },
            ],*/
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
    created() {
        /*this.$http.get("http://localhost:5000/mapa")
                  .then(res => res.json())
                  .then (
                    dadosRetornados => (this.paises = dadosRetornados),
                    err => console.log(err),
                  );*/
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