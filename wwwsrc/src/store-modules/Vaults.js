import Vue from "vue"
import Vuex from "vuex"
import axios from "axios"
Vue.use(Vuex)
const CONTROLLER_ROUTE = "api/vaults"
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
    vaults: [],
    activevault: {},
    vaultkeeps: []
  },
  mutations: {
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setactiveVault(state, activevault) {
      state.activevault = activevault;
    },
    setKeepsByVaultId(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps;
    }

  },
  actions: {
    async createVault({ dispatch }, vault) {
      try {
        let axiosRES = await api.post('', vault)
        let newVault = axiosRES.data
        dispatch('getVaults')
      } catch (error) {
        console.error(err('actions', 'createVault'))
      }
    },

    async getVaults({ commit }) {
      try {
        let axiosRES = await api.get('')
        let vaults = axiosRES.data
        commit('setVaults', vaults)
      } catch (error) {
        console.error(err('actions', 'getVaults'))
      }
    },
    async getVaultById({ commit, dispatch }, payload) {
      try {
        let endpoint = `${payload}`;
        let axiosRES = await api.get(endpoint)
        commit('setactiveVault', axiosRES.data)
      }
      catch (error) {
        console.error(error)
      }
    },
    async getKeepsByVaultId({ commit }, vaultId) {
      try {
        let endpoint = `${vaultId}/keeps`;
        let axiosRES = await api.get(endpoint);
        commit('setKeepsByVaultId', axiosRES.data);
      } catch (error) {
        console.error(error)

      }
    },

    async deleteVault({ commit, dispatch }, vault) {
      try {
        let vaultId = vault
        let endPoint = `${vaultId}`;
        await api.delete(endPoint);
        dispatch('getVaults')
      } catch (error) {
        alert('store-module keep.js actions deleteVault()')
      }
    }
  }
}