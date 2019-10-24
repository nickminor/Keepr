<template>
  <div class="home">
    <h1>Welcome To Keepr</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <br />
    <div class="row">
      <vault v-for="vault in vaults" :key="vault.id" :vault="vault"/>
      </div>
      <div class="row"> 
      <keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    //2.)access the data
    keeps() {
      return this.$store.state.Keeps.keeps;
    },
    vaults() {
      return this.$store.state.Vaults.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  mounted() {
    //1.)get data neccessary for home view
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  }
};
</script>