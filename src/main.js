import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { registerGlobalComponents } from './untils/import'
const app = createApp(App);
registerGlobalComponents(app);
app.use(router);
app.mount('#app');
