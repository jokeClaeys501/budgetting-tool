/* Main File
This is a standard main file
An interceptor has been created to automaticaly give the token in the header

TODO
The token is now hard coded in the interceptor, the token is defined in 'Home' and has to come automatically in the interceptor
The interceptor is not intercepting yet, logs don't ever show
 */

import Vue from 'vue';
import App from './App.vue';
import router from './router';
import vuetify from './plugins/vuetify';
//import VueResource from 'vue-resource';
import fetchIntercept from 'fetch-intercept';
//import {access_token} from './views/Home.vue';
import Home from './views/Home.vue';

//Vue.use(VueResource);

Vue.config.productionTip = false;
//var access_token=Home.access_token();

//const access_token: String = ""


var vm = new Vue({
//   data:{
//    access_token
// },
  router,
  vuetify,
  render: (h) => h(App)
}).$mount('#app');

const unregister = fetchIntercept.register({
  request: function (url, config) {
      // Modify the url or config here
      console.log('interceptor request')
      console.log('config: ' + config.toString());
      console.log('access token: '+localStorage.getItem("accessToken"))
      config.headers.Authorization = `Bearer `+localStorage.getItem("accessToken");
      
      return [url, config];
    },
  requestError: function (error) {
    console.log('interceptor requesterror')
    // Called when an error occured during another 'request' interceptor call
    return Promise.reject(error);
},

response: function (response) {
  console.log('interceptor response')
    // Modify the reponse object
    return response;
},

responseError: function (error) {
  console.log('interceptor responseerror')
    // Handle an fetch error
    return Promise.reject(error);
}
});


// (Vue as any).http.interceptors.push((request: any, next: any) => {
//   console.log('in the interceptor')
//   if(true) {
//     console.log('header will now be set');
//     request.headers['Authorization'] = 'Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IkMzRDk2MEFCMzdENjZFQTBGRDY2OTdGM0QwMzYxMzkzOEFDMDU3N0YiLCJ0eXAiOiJKV1QiLCJ4NXQiOiJ3OWxncXpmV2JxRDlacGZ6MERZVGs0ckFWMzgifQ.eyJuYmYiOjE1Njk1MDM1MDcsImV4cCI6MTU2OTUwNzEwNywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NjEwMyIsImF1ZCI6WyJodHRwczovL2xvY2FsaG9zdDo2MTAzL3Jlc291cmNlcyIsImJvb2tzdG9yZSJdLCJjbGllbnRfaWQiOiJib29rc3RvcmUiLCJzdWIiOiI0Mzc4MjYzOEQ2OEU0RUJBOEIzMDNGMDZEQkQyNDZGNSIsImF1dGhfdGltZSI6MTU2OTUwMzUwNiwiaWRwIjoibG9jYWwiLCJuYW1lIjoiSm9rZSIsInJvbGUiOiJVc2VyIiwiZW1haWwiOiJlbWFpbCIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJlbWFpbCIsImJvb2tzdG9yZSJdLCJhbXIiOlsicHdkIl19.gQrS2VfpWY8W22i4ADcJFNinv0VCX67yyhXn3c-AyEuIJ5EDwjGx_o_xr5Dcqp_TgBNu1hsydkD2eEqpwVfyDMwZu6ab1azKi6MA3d7EQirmpFKCGMvOLp0z0os8K28lMY2aSlLtgyqgBLx95x_Pfl6NMD1oYH6nDrpf1BLW6V2OaFjglr6t28AWl0jOPyHLFTdcLPM2-Lyijv__8WZlGbeiU_Xn-LPW35L058yxvKpXPoB7fjck_3-iONdlfcBJMhysmAVV5a1MFB5f_Zw6Nzo6hi1hmdlUM4zzO8yoX6HzItrxj3seUF6CC4xzegaTVwiIsUlkMgFBi_-RGiiCHA'
//   }
  
//   next((response: any) => {
//     console.log('in the next')
//     // if(response.status == 401 ) {
//     //   localStorage.removeItem('auth_token');
//     //   router.push({ name: 'login'});
//     // }
//   });
// });
