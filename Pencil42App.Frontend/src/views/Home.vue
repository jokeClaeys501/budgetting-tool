<template>
  
<div class="home">
        <h1 align="center">Welcome to Sepski's budgetting tool</h1>
        <b-button>Button</b-button>

    </div>


</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import VueResource from 'vue-resource';
Vue.use(VueResource);
 
    import axios, { AxiosRequestConfig, AxiosPromise, AxiosResponse } from 'axios';
 
    //const auth = new AuthService();
 
    @Component({
        components: {
        },
    })
 
    export default class Home extends Vue {


       public async created(){
           
       }
 
        public async mounted() {
            
        }
 
       
    }
</script>
