import Vue from "vue"
import Vuex from "vuex"
import axios from "axios"
import router from "../router"

Vue.use(Vuex)
const CONTROLLER_ROUTE = "api/vaultkeeps"
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
    vaultkeeps: []
  },
  mutations: {
    setVaultKeeps(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps;
    }

  },
  actions: {
    async createVaultKeep({ dispatch }, vaultkeep) {
      try {
        let axiosRES = await api.post('', vaultkeep)
        let newVaultKeep = axiosRES.data
        dispatch('getVaultKeeps')
      } catch (error) {
        console.error(err('actions', 'createVaultKeep'))
      }
    },

    async getVaultKeeps({ commit, rootState }) {
      try {
        let endpoint = `${rootState.Vaults.activevault.id}`;
        let axiosRES = await api.get(endpoint)
        let vaultkeeps = axiosRES.data
        commit('setVaultKeeps', vaultkeeps)
      } catch (error) {
        console.error(err('actions', 'getVaultKeeps'))
      }
    },
    async saveKeep({ commit, dispatch }, vaultkeep) {
      try {
        let endpoint = `${vaultkeep.vaultId}`;
        let axiosRES = await api.get(endpoint);
        let vaultkeeps = axiosRES.data;
        let keep = vaultkeeps.find(vk => {
          return vk.keepId == vaultkeep.keepId
        });
        if (keep) {
          return
        }

        endpoint = "";
        await api.post(endpoint, vaultkeep);
        await dispatch('getVaultKeeps')

      } catch (error) {
        alert('store-module vaultkeep.js actions saveKeep()')
      }
    },

    async deleteVaultKeep({ commit, dispatch }, vaultkeep) {
      try {
        let vaultkeepId = vaultkeep
        let endPoint = `${vaultkeepId}`;
        await api.delete(endPoint);
        dispatch('getVaultKeeps')
      } catch (error) {
        alert('store-module vaultkeep.js actions deleteKeep()')
      }
    }
  }
}