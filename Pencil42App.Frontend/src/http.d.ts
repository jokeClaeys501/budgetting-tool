/* This is needed to do 'Vue.http' in 'main.ts'
 */

import Vue from 'vue'

declare module 'vue/types/vue' {
  interface VueConstructor {
    http: any
  }
}