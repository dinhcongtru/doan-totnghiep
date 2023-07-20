import 'devextreme/dist/css/dx.light.css';
import * as Vue from 'vue'
// import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { registerGlobalComponents } from './untils/import'
import 'devextreme/dist/css/dx.light.css';
import { store } from './store';
import axios from 'axios'
import VueAxios from 'vue-axios'
const app = Vue.createApp(App);
registerGlobalComponents(app);
app.use(VueAxios, axios)
app.use(router);
app.use(store)
app.mount('#app');
