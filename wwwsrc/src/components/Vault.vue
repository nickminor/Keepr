<template>
  <div class="vault">
    <div class="row m-5">
      
      {{vault.name}}
    </div>


  </div>
</template>


<script>
export default {
  name: 'vault',
  props: {
    vault: {
      type: Object,
      required: true
    }
  }
};
</script>


<style scoped>

</style>