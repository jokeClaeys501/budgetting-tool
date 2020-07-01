<template>
<div>
  <h1> Add stock purchase </h1>
<AddStockPurchase />
</div>
</template>

<script lang="ts">
import Vue from 'vue';
import AddStockPurchase from '../components/AddStockPurchase.vue';

export default Vue.extend({
  components: {
    AddStockPurchase
  },
});
</script>