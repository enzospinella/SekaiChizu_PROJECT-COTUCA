
import Vue from 'vue'
import Vuex from 'vuex'
import App from './App.vue'
import VueRouter from 'vue-router'
//import VueResource from 'vue-resource'
import {store} from './vuex';
import axios from 'axios'
import VueAxios from 'vue-axios'



//Esse e o import do sistema que nos gerou o mapa
import { MapsPlugin } from '@syncfusion/ej2-vue-maps';

import { routes } from './Routes.js'

//Vue.use(VueResource);
Vue.use(VueRouter);
Vue.use(VueAxios, axios)
Vue.use(MapsPlugin);

Vue.prototype.$http = axios

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
