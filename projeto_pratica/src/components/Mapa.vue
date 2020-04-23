<template>
    <div id="app">
          <div class='wrapper'>
            <ejs-maps :zoomSettings='zoomSettings' :height='height' :width='width' :mapsAreaSettings='mapsAreaSettings'>
                <e-layers>
                    <e-layer :shapeData='shapeData' :shapeSettings='shapeSettings' :selectionSettings='selectionSettings'>
                        <e-markerSettings>
                            <e-markerSetting visible=true :dataSource="dataSource"
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
import { MapsPlugin, Zoom, MapsTooltip, MapsAreaSettings, Selection, Border } from '@syncfusion/ej2-vue-maps';
import { worldMap } from '../map/world-map.js';
Vue.use(MapsPlugin);
export default 
{
    data () 
    {
        return {
            
            ShaeselectionMap:
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
            height: '652',
            width: '1350',
            shapeSettings: {
                fill: 'brown',
            },
        }
    },
        /*
        contentTemplate: function () {
            return {
            template: Vue.component('MapsComponent', {
                template: '<div id="marker4" class="markerTemplate">Europe</div>',
                data() { return {  }; }
            })
            }
        },
        contentTemplate1: function () {
            return {
            template: Vue.component('MapsComponent', {
                template: '<div id="marker5" class="markerTemplate" style="width:50px">NorthAmerica</div>',
                data() { return {  }; }
            })
            }
        },
        contentTemplate2: function () {
            return {
            template: Vue.component('MapsComponent', {
                template: '<div id="marker6" class="markerTemplate" style="width:50px">South America </div>',
                data() { return {  }; }
            })
            }
        },*/
    provide: {
        maps: [ Zoom, Selection ]
    },
    methods: {
        mapsOnClick:function(e){
            
        },

        
        mapsOnDoubleClick: function(e){
        }
    }
}

</script>
<style>
    .wrapper {
    width: 100%;
    height: 100%;
  }
  #app {
    width: 100%;
    height: 100%;
  }
</style>