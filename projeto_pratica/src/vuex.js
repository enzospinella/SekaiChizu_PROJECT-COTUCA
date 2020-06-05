import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

const store = new Vuex.Store ({
    state: {
        usuarios: [],
        usuarioConectado: {},
        isConectado: false,
    },
    mutations: {
        setUsuarios(state, payload) {
            state.usuarios = payload;
        },
        setUsuarioConectado(state, payload) {
            state.usuarioConectado = payload;
        },
        setConexao(state, payload) {
            state.isConectado = payload;
        }
    },
    getters: {
        getUsuarios(state) {
            return state.usuarios;
        },
        getUsuarioConectado(state) {
            return state.usuarioConectado;
        },
        getConexao(state) {
            return state.isConectado;
        }
    },
    actions: {
        setUsuarios({commit}, usuarios){commit('setUsuarios', usuarios)},
        setUsuarioConectado({commit}, usuarioConectado){commit('setUsuarioConectado', usuarioConectado)},
        setConexao({commit}, conexao){commit('setConexao', conexao)},
    }
})

export {store};