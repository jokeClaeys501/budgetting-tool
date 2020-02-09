<template>
    <div>
        <p>Here comes an input form to add a new cost, this is written in</p>
        <b-button @click="testmethod()">test</b-button>
    </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
axios.defaults.baseURL = 'https://localhost:5001/api/TodoItems/';
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
 

@Component
export default class AddNewCost extends Vue {
 
    


    created() {
        
        }

    public addCost() {
        //TODO code to write cost to database
    }

    public testmethod() {
        axios.get('/', {
        params: {
        }
        })
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        })
        .then(function () {
            // always executed
        }); 
    }
}
</script>