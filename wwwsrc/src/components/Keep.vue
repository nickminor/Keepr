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
        <button type="button" class="btn btn-secondary">Save</button>
        <div class="div"></div>
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
  }
};
</script>


<style scoped>
.keep-img {
  max-width: 2in;
}

</style>