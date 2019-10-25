<template>
  <div class="vault">
    <div class="row m-5">
      {{propvault.name}}
      <button
        type="button"
        @click="viewVault()"
        class="btn btn-secondary"
      >View Vault</button>
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
    }
  }
};
</script>


<style scoped>
</style>