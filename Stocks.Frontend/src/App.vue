<template>
<div>
  <NavigationBar />
  <v-app>


    <v-content>

      <router-view/>
    </v-content>

  </v-app>
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
