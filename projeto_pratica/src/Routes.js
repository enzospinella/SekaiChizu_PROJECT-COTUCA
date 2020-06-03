/*
    O objetivo do routes.js é
    Servir como o lugar contendo todos os caminhos e rotas para todas as paginas 
*/

import Home from './components/Home.vue';
import Login from './components/shared/FormularioLogin.vue'
import Cadastro from './components/shared/FormularioCadastro.vue'
import Contato from './components/Contato.vue'
import Mapa from './components/Mapa1.vue'
import pagPais from './components/PaginaDoPais.vue';
/*

A propriedade path sera usada para determinar o lugar de cada pagina (caminho na url)
A propriedade component sera usada para indicar 
A propriedade titulo sera exibida na pagina principal

*/
export const routes = [

    { path: '/', redirect: '/home'},
    { path: '/home', component: Home, titulo: 'Home' },
    { path: '/mapa', component: Mapa, titulo: 'Mapa'},
    { path: '/mapa/paises/:id/:nome', component: pagPais, titulo: 'PaginaPais'},
    { path: '/usuario/login', component: Login, titulo: 'Login'},
    { path: '/usuario/cadastro', component: Cadastro, titulo: 'Cadastro'},
    { path: '/contato', component: Contato, titulo: 'Contato' },
    
]
