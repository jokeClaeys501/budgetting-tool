<template>
    <div>
        <p>Here comes an input form to add a new cost, this is written in</p>
    </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
//import { Translator } from '../services/Translator';
// import { currentWeekNumber } from 'current-week-number';
// npm i --save current-week-number


@Component
export default class AddNewCost extends Vue {
 
    
    created() {
        
        }

    public addCost() {
        //TODO code to write cost to database
    }
}
</script>