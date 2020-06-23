
import Vue from 'vue'
import Vuex from 'vuex'
import App from './App.vue'
import VueRouter from 'vue-router'
//import VueResource from 'vue-resource'
import {store} from './vuex';
import axios from 'axios'
import VueAxios from 'vue-axios'
import Unicon from 'vue-unicons'
import { uniArrowToRight, uniAngleRightB, uniAngleLeftB, uniUserCircle, uniUserSquare, uniPaypal, uniBackward, uniTrashAlt, uniCopyright  } from 'vue-unicons/src/icons'



//Esse e o import do sistema que nos gerou o mapa
import { MapsPlugin } from '@syncfusion/ej2-vue-maps';

import { routes } from './Routes.js'

//Vue.use(VueResource);
Vue.use(VueRouter);
Vue.use(VueAxios, axios)
Vue.use(MapsPlugin);

Unicon.add([uniArrowToRight, uniAngleRightB, uniAngleLeftB, uniUserCircle, uniUserSquare, uniPaypal, uniBackward, uniTrashAlt, uniCopyright ])
Vue.use(Unicon)


const router = new VueRouter({
  mode: 'history',
  routes: routes
});

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})
