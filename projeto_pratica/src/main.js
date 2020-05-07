
import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import VueResource from 'vue-resource'

//Esse e o import do sistema que nos gerou o mapa
import { MapsPlugin } from '@syncfusion/ej2-vue-maps';

import { routes } from './Routes.js'

Vue.use(VueResource);
Vue.use(VueRouter);
Vue.use(MapsPlugin);

const router = new VueRouter({
  mode: 'history',
  routes: routes
});

new Vue({
  el: '#app',
  router,
  render: h => h(App)
})
