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
        path: "/product",
        name: "product",
        meta: {
            layout: "category",
            title: "Sale"
       },
        component: () => import("@/views/DetailtProduct")
    },
    {
        path: "/cart",
        name: "cart",
        meta: {
            layout: "category",
            title: "Giỏ hàng"
       },
        component: () => import("@/views/CartDetailt")
    },
    
    

]

const router = createRouter({
    history:createWebHistory(process.env.BASE_URL),
    routes,
})
    router.beforeEach((to, from, next) => {
        if (to.matched.length === 0) {
        next({ name: 'product' });
        setTimeout(() => {
            next({name: 'HomePage'})
           }, 1500);
        } else {
        next();
        }
    });
export default router;