import SchedulerPage from "../pages/Scheduler.vue";
export default[
    { path: '/', component: resolve => require(['../pages/Index.vue'], resolve) },
    { path: '/gantt', component: resolve => require(['../pages/Gantt.vue'], resolve) },
    { path: '/scheduler', component: SchedulerPage },
    { path: '*', redirect: '/' },
]



// import App from '../App'

// export default [
//     {
//         path: '/',
//         component: App,
//         children: [
//             {
//                 path: '/gantt',
//                 meta: { auth: false },
//                 component: resolve => require(['../pages/Gantt.vue'], resolve)
//             },
//             {
//                 path: '/scheduler',
//                 component: resolve => require(['../pages/Scheduler.vue'], resolve)
//             },           
//             {
//                 path: '/', //首页
//                 meta: { auth: false },
//                 component: resolve => require(['../pages/Index.vue'], resolve)
//             },
//             {
//                 path: '*', //其他页面，强制跳转到首页
//                 redirect: '/'
//             }
//         ]
//     }
// ]