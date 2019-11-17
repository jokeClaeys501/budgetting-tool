<template>
  <v-app>
    <v-app-bar app>
      <router-link to="/">
      <v-toolbar-title class="headline text-uppercase">
        <span style="color:#0eacbd">Sepski's Budgetting Tool</span>
      </v-toolbar-title>
      </router-link>
      <v-spacer></v-spacer>

      <v-app-bar-nav-icon v-on:click="showMenu = !showMenu" right>
      </v-app-bar-nav-icon>

    </v-app-bar>

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
</template>



<script lang="ts">
import Vue from 'vue';
const showMenu: boolean = false;

export default Vue.extend({
  name: 'App',
  components: {
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
