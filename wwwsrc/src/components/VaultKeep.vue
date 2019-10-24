<template>
  <div class="vaultkeep">
    <div class="row">
      {{vaultkeep.name}}
    </div>


  </div>
</template>


<script>
export default {
  name: 'vaultkeep',
  props: {
    vaultkeep: {
      type: Object,
      required: true
    }
  }
};
</script>


<style scoped>

</style>