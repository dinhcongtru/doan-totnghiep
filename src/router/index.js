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
        path: "/ao-nam-pc95934.html",
        name: "Category-menShort",
        meta: {
            layout: "category",
            title: "Áo Nam"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/sale-pc95934.html",
        name: "Category-sale",
        meta: {
            layout: "category",
            title: "Sale"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/sale-dong-gia-99k.html",
        name: "Category-sale99k",
        meta: {
            layout: "category",
            title: "Sale 99k"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/sale-dong-gia-149k.html",
        name: "Category-sale149k",
        meta: {
            layout: "category",
            title: "Sale 149k"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/sale-off-50.html",
        name: "Category-saleOff50%",
        meta: {
            layout: "category",
            title: "Sale-off 50%"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/ao-blazer-pc564635.html",
        name: "Category-blazer",
        meta: {
            layout: "category",
            title: "Áo Blazer"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/ao-phong-pc6379.html",
        name: "Category-phong",
        meta: {
            layout: "category",
            title: "Áo Phông"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/ao-so-mi-pc76944.html",
        name: "Category-somi",
        meta: {
            layout: "category",
            title: "Áo Sơ Mi"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/ao-tanktop-pc321491.html",
        name: "Category-tanktop",
        meta: {
            layout: "category",
            title: "Áo TankTop"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/ao-polo-pc490701.html",
        name: "Category-polo",
        meta: {
            layout: "category",
            title: "Áo Polo"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/so-mi-coc-tay-pc565515.html",
        name: "Category-somiCoc",
        meta: {
            layout: "category",
            title: "Áo Sơ Mi Cộc Tay"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/so-mi-dai-tay-pc565516.html",
        name: "Category-somidai",
        meta: {
            layout: "category",
            title: "Sơ Mi Dài Tay"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/quan-nam-pc6405.html",
        name: "Category-quan",
        meta: {
            layout: "category",
            title: "Quần Nam"
       },
        component: () => import("@/views/CategoryPage")
    },
]

const router = createRouter({
    history:createWebHistory(process.env.BASE_URL),
    routes,
    
})
router.beforeEach((to, from, next) => {
    document.title = to.meta.title;
    next();
  });
export default router;