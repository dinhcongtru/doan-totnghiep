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
    {
        path: "/quan-jeans-pc6415.html",
        name: "Category-quanJeans",
        meta: {
            layout: "category",
            title: "Quần Jeans"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/quan-short-pc6416.html",
        name: "Category-quanShort",
        meta: {
            layout: "category",
            title: "Quần Short"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/quan-au-pc119402.html",
        name: "Category-quanAu",
        meta: {
            layout: "category",
            title: "Quần Âu"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/quan-jogger-pc123044.html",
        name: "Category-quanJogger",
        meta: {
            layout: "category",
            title: "Quần Jogger"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/quan-kaki-pc123044.html",
        name: "Category-quanKaki",
        meta: {
            layout: "category",
            title: "Quần Kaki"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/day-lung-pc501329.html",
        name: "Category-dayLung",
        meta: {
            layout: "category",
            title: "Dây Lưng"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/phu-kien-pc501328.html",
        name: "Category-Pk",
        meta: {
            layout: "category",
            title: "Phụ Kiện"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/balo-cap-xach-pc501330.html",
        name: "Category-baloCapxach",
        meta: {
            layout: "category",
            title: "Ba Lô + Cặp Xách"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/giay-dep-pc501330.html",
        name: "Category-giayDep",
        meta: {
            layout: "category",
            title: "Giày Dép"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/mu-nam-pc501330.html",
        name: "Category-muNam",
        meta: {
            layout: "category",
            title: "Mũ Nam"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/tat-nam-pc501330.html",
        name: "Category-tatNam",
        meta: {
            layout: "category",
            title: "Tất Nam"
       },
        component: () => import("@/views/CategoryPage")
    },
    {
        path: "/quan-lot-pc501330.html",
        name: "Category-quanLot",
        meta: {
            layout: "category",
            title: "Quần Lót"
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