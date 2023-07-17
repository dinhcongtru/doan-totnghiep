import { defineAsyncComponent } from "vue"


export function registerGlobalComponents(app){
    app.component(
        "TheHeader", 
        defineAsyncComponent(() => import("@/components/TheHeader"))
    );
    app.component(
        "HomePage", 
        defineAsyncComponent(() => import("@/views/HomePage"))
    );
    app.component(
        "ListProducts", 
        defineAsyncComponent(() => import("@/components/ListProducts"))
    );
    app.component(
        "AlBum", 
        defineAsyncComponent(() => import("@/components/AlBum"))
    );
    app.component(
        "PhiStory", 
        defineAsyncComponent(() => import("@/components/PhiStory"))
    );
    app.component(
        "CategoryPage", 
        defineAsyncComponent(() => import("@/views/CategoryPage"))
    );
    app.component(
        "category-layout", 
        defineAsyncComponent(() => import("@/layouts/CategoryLayout"))
    );
    app.component(
        "default-layout", 
        defineAsyncComponent(() => import("@/layouts/DefaultLayout"))
    );
    app.component(
        "checkout-layout", 
        defineAsyncComponent(() => import("@/layouts/CheckoutLayout"))
    );
    app.component(
        "TheDropdown", 
        defineAsyncComponent(() => import("@/components/TheDropdown"))
    );
    app.component(
        "FilterProduct", 
        defineAsyncComponent(() => import("@/components/FilterProduct"))
    );
    app.component(
        "SliderPro", 
        defineAsyncComponent(() => import("@/components/SliderPro"))
    );
    app.component(
        "QuickView", 
        defineAsyncComponent(() => import("@/views/QuickView"))
    );
    app.component(
        "FormPro", 
        defineAsyncComponent(() => import("@/components/FormPro"))
    );
    app.component(
        "ToolTip", 
        defineAsyncComponent(() => import("@/components/ToolTip"))
    );
    app.component(
        "TheFooter", 
        defineAsyncComponent(() => import("@/components/TheFooter"))
    );
    app.component(
        "addToCart", 
        defineAsyncComponent(() => import("@/views/addToCart"))
    );
 
    
}