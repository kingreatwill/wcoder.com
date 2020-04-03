import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App'

import routes from './config/routes'
//import store from './store/'

import './assets/css/common.css'
//import './less/common.less'

Vue.config.productionTip = false

Vue.use(VueRouter)


const router = new VueRouter({
  routes
})
// router.beforeEach(({meta, path}, from, next) => {
//     var { auth = true } = meta
//     var isLogin = Boolean(store.state.user.id) //true用户已登录， false用户未登录

//     if (auth && !isLogin && path !== '/login') {
//         return next({ path: '/login' })
//     }
//     next()
// })
// new Vue({ store, router }).$mount('#app')
new Vue({ 
  router,
  render: h => h(App)
 }).$mount('#app')