import Vue from "vue"
import Vuex from "vuex"
import axios from "axios"
import router from "../router"

Vue.use(Vuex)
const CONTROLLER_ROUTE = "api/keeps"
let base = window.location.host.includes("localhost:8080")
  ? "https://localhost:5001/"
  : "/";

let api = axios.create({
  baseURL: base + CONTROLLER_ROUTE,
  timeout: 3000,
  withCredentials: true
})
function err(storeSection, functionName) {
  return `store-modules > projects > ${storeSection}: ${functionName}()`
}
export default {
  state: {
    keeps: []
  },
  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps;
    }

  },
  actions: {
    async createKeep({ dispatch }, newkeep) {
      try {
        let axiosRES = await api.post('', newkeep)
        let newKeep = axiosRES.data
        dispatch('getKeeps')
      } catch (error) {
        console.error(err('actions', 'createKeep'))
      }
    },

    async getKeeps({ commit }) {
      try {
        let axiosRES = await api.get('')
        let keeps = axiosRES.data
        commit('setKeeps', keeps)
      } catch (error) {
        console.error(err('actions', 'getKeeps'))
      }
    },

    async deleteKeep({ commit, dispatch }, keep) {
      try {
        let keepId = keep.id
        let endPoint = `${keepId}`;
        await api.delete(endPoint);
        dispatch('getKeeps')
      } catch (error) {
        alert('store-module keep.js actions deleteKeep()')
      }
    }
  }
}