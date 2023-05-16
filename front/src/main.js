import Vue from 'vue'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'
import api from './api.js'

import '@/components'

Vue.prototype.$API = api.rest;
Vue.config.productionTip = false

import YmapPlugin from 'vue-yandex-maps'
import store from './store'

Vue.use(YmapPlugin, {
  apiKey: '2c064dbf-9917-4ced-b5a3-0750aeb3af36',
  lang: 'ru_RU',
  coordorder: 'latlong',
  enterprise: false,
  version: '2.1'
})


new Vue({
  router,
  vuetify,
  store,
  render: h => h(App)
}).$mount('#app')
