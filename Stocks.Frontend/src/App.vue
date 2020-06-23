<template>
<div>
  <NavigationBar />
  <v-app>


    <v-navigation-drawer app v-model="showMenu" right>
      <router-link to="/new-cost" >
        <h2><span class="mr-2">Add new cost</span></h2>
      </router-link>

      <router-link to="/overview">
        <h2><span class="mr-2">Week overview</span></h2>
      </router-link>
  </v-navigation-drawer>

    <v-content>

      <router-view/>
    </v-content>

  </v-app>
<Navbar />
</div>
</template>



<script lang="ts">
import Vue from 'vue';
import NavigationBar from '../src/components/NavigationBar.vue'
const showMenu: boolean = false;

export default Vue.extend({
  name: 'App',
  components: {
    NavigationBar
  },
  data: () => ({
    showMenu : false,
  }),
});
</script>

<style scoped>
.v-btn-toggle {
  flex-direction: column;
}
</style>
