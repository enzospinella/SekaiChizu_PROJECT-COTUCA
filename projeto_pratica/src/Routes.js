/*
    O objetivo do routes.js é
    Servir como o lugar contendo todos os caminhos e rotas para todas as paginas 
*/

import Home from './components/Home.vue';
import Cadastro from './components/CadastroUsuarios.vue';
//import Contato from './components/Contato.vue'
import Mapa from './components/Mapa.vue'
/*

A propriedade path sera usada para determinar o lugar de cada pagina (caminho na url)
A propriedade component sera usada para indicar 
A propriedade titulo sera exibida na pagina principal

*/
export const routes = [

    { path: '/', component: Home, titulo: 'Home' },
    { path: '/mapa', component: Mapa, titulo: 'Mapa'},
    { path: '/cadastroUsuario', component: Cadastro, titulo: 'Cadastro'},
    //{ path: '/contato', component: Contato, titulo: 'Contato' },
    
]