import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate'
import router from '../router'

Vue.use(Vuex)

export default new Vuex.Store({
  state: { user: {}, access_token: undefined },
  getters: {
  },
  mutations: {
    UpdateUser(state, payload) {
      state.user = payload;
    },
    UpdateToken(state, payload) {
      state.access_token = payload;
    },
    Logout(state, payload) {
      state.user = {};
      state.access_token = undefined;
      router.push("/sign-in");
    }
  },
  actions: {
  },
  modules: {
  },
  plugins: [createPersistedState({
    storage: window.sessionStorage,
  })],
})
