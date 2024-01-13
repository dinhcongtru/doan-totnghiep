import { store } from "@/store";
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
        component: () => import("@/views/CategoryPage"),
        
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
    {
        path: "/cart/checkout",
        name: "checkout",
        meta: {
            layout: "checkout",
            title: "Thanh toán"
       },
        component: () => import("@/views/CheckOut"),
        beforeEnter: (to, from, next) => {
            if(Object.keys(store.state.customer).length == 0){
                    // Check if the cart has any items
                if (store.state.product.length > 0) {
                    // Redirect to the home page if the cart is empty
                    next();
                } else {
                    // Proceed to the checkout page if the cart has items
                    next({ name: 'HomePage'});
                }
            }else{
                // Check if the cart has any items
                if (store.state.customer.product.length > 0) {
                    // Redirect to the home page if the cart is empty
                    next();
                } else {
                    // Proceed to the checkout page if the cart has items
                    next({ name: 'HomePage'});
                }
            }
            
          }
    },
    {
        path: "/cart/checkout/payment",
        name: "payment",
        meta: {
            layout: "checkout",
            title: "Thanh toán"
        },
        component: () => import("@/views/PayMent"),
        beforeEnter: (to, from, next) => {
            // Check if the cart has any items
            if (store.state.product.length === 0 || store.state.customer.product.length === 0) {
                // Redirect to the home page if the cart is empty
                next({ name: 'HomePage'})
            } else {
                // Proceed to the checkout page if the cart has items
                next()
            }
            }
    },
    {
        path : "/user/signin",
        name : "singin",
        meta :{
            layout :"category",
            title : "Đăng nhập"
        },
        component : () => import("@/views/SingIn")
    },
    
    {
        path : "/user/getpassword",
        name : "getpassword",
        meta :{
            layout :"category",
            title : "Reset Password tài khoản"
        },
        component : () => import("@/views/getPassWord")
    },
    {
        path : "/album",
        name : "album",
        meta :{
            layout :"category",
            title : "album"
        },
        component : () => import("@/views/AlBum")
    },
    {
        path : "/news",
        name : "news",
        meta :{
            layout :"category",
            title : "Tin Tức"
        },
        component : () => import("@/views/TinTuc")
    },
    {
        path : "/new",
        name : "newsDetailt",
        meta :{
            layout :"category",
            title : "Tin Tức"
        },
        component : () => import("@/views/DetailtNew")
    },
    {
        path : "/look-book",
        name : "lookbook",
        meta :{
            layout :"category",
            title : "Look Book"
        },
        component : () => import("@/views/LookBook")
    },
    {
        path : "/profile",
        name : "profile",
        meta :{
            layout :"category",
            title : "Trang Cá Nhân"
        },
        component : () => import("@/views/ProFile"),
    },
    {
        path: '/profile/edit',
        name : "edit",
        meta : {
          layout: "category",
          title: "Thông Tin Cá Nhân"
        },
        component: () => import("@/views/FormCustomer"),
      },
      {
        path: '/profile/changepassword',
        name : "changePassword",
        meta : {
          layout: "category",
          title: "Trang Sửa Mật Khẩu Tài Khoản"
        },
        component: () => import("@/views/FormCustomer"),
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