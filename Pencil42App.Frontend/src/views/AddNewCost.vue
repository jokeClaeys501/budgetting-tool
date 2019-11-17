<template>
<div>
  <h1> Add new cost </h1>
<AddNewCost />
</div>
</template>

<script lang="ts">
import Vue from 'vue';
import AddNewCost from '../components/AddNewCost.vue';

export default Vue.extend({
  components: {
    AddNewCost
  },
});
</script>