<template>
  
<div class="home">
        <h1 align="center">Stocks</h1>
        <DefaultTable />
</div>


</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import VueResource from 'vue-resource';
import MonthlyIncome from '../components/MonthlyIncome.vue'
import DefaultTable from '../components/DefaultTable.vue'

    export default Vue.extend({
    components: {
        DefaultTable
    },
    
    });




</script>
