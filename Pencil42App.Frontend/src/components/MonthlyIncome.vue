<template>
  
<b-button @click="getUser">Button</b-button>

</template>

<script>
import { Line } from 'vue-chartjs';

export default {
  extends: Line,
  data: () => ({
     chartdata: {
       labels: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'],
       datasets: [
         {
           label: 'Milestone 1',
           backgroundColor: '#0eacbd',
           data: [2, 0, 8, 6, 3]
         },
         {label: 'Milestone 2',
          backgroundColor: '#1F2F63',
          data : [6, 8, 0, 2, 5]
         }
       ]
     },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      scales: {
        yAxes: [{
          stacked: true,
          ticks: {
            beginAtZero: true,
          },
        }],
        xAxes: [{
          stacked: true,
          ticks: {
            beginAtZero: true,
          },
        }],
      },
    },
  }),

  mounted() {
    this.renderChart(this.chartdata, this.options);
  },
};


import axios from 'axios';


</script>