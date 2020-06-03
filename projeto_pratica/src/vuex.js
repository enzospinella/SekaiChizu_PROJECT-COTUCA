import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

const store = new Vuex.Store ({
    state: {
        usuarios: []
    },
    mutations: {
        /*getUsuarios: state => (this.$http.get("http://localhost:5000/usuario")
                                .then(res => res.json())
                                .then (
                                dadosRetornados => (state.usuarios = dadosRetornados, console.log(state.usuarios)),
                                err => console.log(err))),*/
        setUsuarios(state, usuario) {
            state.usuarios = usuario;
        },
        getUsuarios(state) {
            return state.usuarios;
        }
    },
    getters: {
    },
    actions: {
        getUsuarios: context => context.commit('getUsuarios'),
    }
})

export {store};