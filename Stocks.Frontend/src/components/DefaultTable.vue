<template>
  <div>
    <b-table striped hover :items="items"></b-table>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class AddNewCost extends Vue {

  public items: Person[] = [];

  created(){
    let list: Person[] = [
            { age: 40, first_name: 'Jane', last_name: 'Macdonald' },
            { age: 21, first_name: 'Larsen', last_name: 'Shaw' },
            { age: 89, first_name: 'Geneva', last_name: 'Wilson' },
            { age: 38, first_name: 'Jami', last_name: 'Carney' }
          ];
    this.items = list;
  }
}

export class Person {
  age: number;
  first_name: string;
  last_name: string;
}
</script>