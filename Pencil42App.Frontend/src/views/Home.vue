<template>
  
<div class="home">
        <h1 align="center">Welcome to Sepski's budgetting tool</h1>
        <MonthlyIncome />
    </div>


</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import VueResource from 'vue-resource';
import MonthlyIncome from '../components/MonthlyIncome.vue'

    export default Vue.extend({
    components: {
        MonthlyIncome
    },
    
    });




</script>
