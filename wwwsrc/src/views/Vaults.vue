<template>
  <div class="vaults" v-if="vaultkeeps">
    <h1>{{activevault.name}}</h1>
    <div v-for="keep in vaultkeeps" :key="'vault-keep-'+keep.id">
      <h3>{{keep.name}}</h3>
      <img class="keep-img" :src="keep.img" alt />
      <h4>{{keep.description}}</h4>
      <div>keep count: {{keep.keeps}}</div>
      <div>keep views: {{keep.views}}</div>
    </div>
  </div>
</template>


<script>
export default {
  name: "activevault",
  data() {
    return {};
  },
  computed: {
    activevault() {
      return this.$store.state.Vaults.activevault;
    },
    vaultkeeps() {
      return this.$store.state.Vaults.vaultkeeps;
    }
  },
  async mounted() {
    await this.$store.dispatch("getVaultById", this.$route.params.id);
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
  }
};
</script>


<style scoped>
.keep-img {
  max-width: 2in;
}
</style>