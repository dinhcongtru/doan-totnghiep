import 'devextreme/dist/css/dx.light.css';
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { registerGlobalComponents } from './untils/import'
import 'devextreme/dist/css/dx.light.css';
import { store } from './store';
const app = createApp(App);
registerGlobalComponents(app);
app.use(router);
app.use(store)
app.mount('#app');
