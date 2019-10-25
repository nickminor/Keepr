<template>
  <div class="keeps container-fluid">
    <div class="row">
      <div class="col-4">
        <img class="keep-img" :src="keep.img" />
        <br />
        {{keep.name}}
        <br />
        {{keep.description}}
        <br />
        <button type="button" class="btn btn-primary">View Keep</button>
        <select @change="saveKeep()" v-model="newVaultId">
          <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{vault.name}}</option>
        </select>
      </div>
    </div>
    <br />
  </div>
</template>


<script>
export default {
  name: "keep",
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      newVaultId: "",
      newKeep: {
        description: ""
      }
    };
  },
  computed: {
    vaults() {
      return this.$store.state.Vaults.vaults;
    }
  },
  methods: {
    saveKeep() {
      let keepData = {
        keepId: this.keep.id,
        vaultId: this.newVaultId,
        userId: ""
      };
      this.$store.dispatch("saveKeep", keepData);
    }
  }
};
</script>


<style scoped>
.keep-img {
  max-width: 2in;
}
</style>