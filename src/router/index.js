import {createRouter, createWebHistory} from "vue-router";
const routes = [
    {
        path: "/",
        name: "HomePage",
        meta:{
            title:"Krik.vn"
        },
        component: () => import("@/views/HomePage")
    },
    {
        path: "/category/:name",
        name: "CategoryName",
        meta: {
            layout: "category",
            title: "Category"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/product/:name",
        name: "product",
        meta: {
            layout: "category",
            title: "Sale"
       },
        component: () => import("@/views/DetailtProduct")
    },
    
    

]

const router = createRouter({
    history:createWebHistory(process.env.BASE_URL),
    routes,
    
})
export default router;