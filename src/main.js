import 'devextreme/dist/css/dx.light.css';
import * as Vue from 'vue'
import vue3GoogleLogin from 'vue3-google-login'
// import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { registerGlobalComponents } from './untils/import'
import 'devextreme/dist/css/dx.light.css';
import { store } from './store';
import axios from 'axios'
import VueAxios from 'vue-axios'
import AOS from 'aos';
import "aos/dist/aos.css";
const CLIENT_ID = "295266839484-74np3o6toi1j9lobfnhv6lu3qjsn0tgs.apps.googleusercontent.com";
const app = Vue.createApp(App);
app.use(AOS);
registerGlobalComponents(app);
app.use(vue3GoogleLogin,{clientId : CLIENT_ID})
app.use(VueAxios, axios)
app.use(router);
app.use(store)
app.mount('#app');
AOS.init();
