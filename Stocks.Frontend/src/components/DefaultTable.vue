<template>
  <div>
    <b-table striped hover :items="items"></b-table>
  </div>
</template>

<script lang="ts">
import TodoItemsDataService from "../services/TodoItemsDataService";
import axios from 'axios';
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class AddNewCost extends Vue {

  public items: Person[] = [];

  public async created(){
    TodoItemsDataService.getAll()
      .then((response) => {
        this.items = response.data as Person[];
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  }
}

export interface Person {
  age: number;
  first_name: string;
  last_name: string;
}

</script>