<template>
  <div class="vault">
    <div class="row m-5">
      {{propvault.name}}
      <button
        type="button"
        @click="viewVault()"
        class="btn btn-secondary"
      >View Vault</button>
      <button @click="deleteVault(propvault)" type="button" class="btn btn-danger">Delete Vault</button>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  props: ["propvault"],
  methods: {
    viewVault() {
      this.$router.push({
        name: "vaults",
        params: { id: this.propvault.id }
      });
    },
    deleteVault(propvault) {
      this.$store.dispatch("deleteVault", propvault);
    }
  }
};
</script>


<style scoped>
</style>