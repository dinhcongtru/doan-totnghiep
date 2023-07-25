<template>
  <main :class="{ 'sidebar-move': isOpenAddtoCart }">
    <!-- main content -->
    <div class="main-content">
      <div class="breadcrumb-shop clearfix">
        <div class="padding-lf-40 clearfix">
          <div class="head-left">
            <a href="/">
              <i class="fa-sharp fa-solid fa-house-chimney"></i>
              <span>Trang chủ</span>
            </a>
            <router-link
              :to="{
                name: 'CategoryName',
                params: { name: urlCate },
                query: { name: category },
              }"
            >
              <span>{{ category }}</span>
            </router-link>

            <span>{{ productName }}</span>
          </div>
        </div>
      </div>
      <div style="display: flex">
        <div class="container">
          <div class="row product-detail-wrapper">
            <div class="clearfix product-detail-main pr_style_01">
              <div class="row">
                <slider-pro
                  :imgSmallData="this.product.listColors"
                  owlStage="width-100"
                  owlItem="width-100"
                  @prevImg="prevImg"
                  @nextImg="nextImg"
                />
                <form-pro
                  ref="Form"
                  :isDetail="true"
                  :product="this.product"
                  @openAddtoCart="openAddtoCart"
                  @onToggleCheckout="onToggleCheckout"
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </main>
  <add-to-cart :isAddToCart="isOpenAddtoCart" @onCloseModal="openAddtoCart" />
</template>
<script>
import { convertNameSingin } from "@/methods/index";
import { store } from "@/store";
import { dynamicUrlProduct } from "@/methods/index";
import {
  chatlieu,
  kieudang,
  chitiet,
  itemSize,
  product,
} from "@/resource/TestData";
export default {
  name: "DetailtProduct",
  // watch: {
  //   $route: function () {
  //     location.reload();
  //   },
  // },
  data() {
    return {
      mainImage: "sp3.webp",
      urlCate: dynamicUrlProduct(product.categoryName),
      category: convertNameSingin(product.categoryName),
      productName: "",
      chatlieu: chatlieu,
      kieudang: kieudang,
      chitiet: chitiet,
      itemSize: itemSize,
      product: {},
    };
  },
  computed: {
    isOpenAddtoCart() {
      return this.$store.getters.getSatusOpenModal;
    },
  },
  methods: {
    prevImg(){
      // this.product.listColors[0].listImages[0] =  this.product.listColors[0].listImages[this.product.listColors[0].listImages.length - 1];
      // cắt phần tử cuối cùng
      let lastElement = this.product.listColors[0].listImages.pop();
      // đẩy lên đầu mảng 
      this.product.listColors[0].listImages.unshift(lastElement);
    },
    nextImg(){
       // cắt phần tử đầu tiên
       let firstElement = this.product.listColors[0].listImages.shift();
      // đẩy lên cuối mảng 
      this.product.listColors[0].listImages.push(firstElement);
    },
    async dynamicTitleName() {
      this.productName = this.product.productName;
      document.title = this.product.productName;
    },
    openAddtoCart() {
      store.commit("handleOpenAddtoCart");
    },
    onToggleCheckout() {
      window.location.href = "/cart/checkout";
    },
  },
  async created() {
    this.product = product;
    await this.dynamicTitleName();
  },
  mounted() {},
};
</script>
<style scoped>
main {
  display: block;
  position: relative;
  right: 0;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  text-rendering: optimizeLegibility;
  -ms-transition: right 500ms cubic-bezier(0.25, 0.46, 0.45, 0.94);
  -webkit-transition: right 500ms cubic-bezier(0.25, 0.46, 0.45, 0.94);
  transition: right 500ms cubic-bezier(0.25, 0.46, 0.45, 0.94);
}
.sidebar-move {
  right: 480px;
}
*,
body {
  line-height: 1.4;
}
.padding0 {
  padding: 0;
}
.breadcrumb-shop {
  box-shadow: inset 0 5px 7px 1px #e9e9e9;
}
.padding-lf-40 {
  padding: 0 40px;
}
.head-left {
  display: flex;
  padding: 10px 0;
}
.head-left > a:nth-child(2) > span {
  color: #777 !important;
  font-weight: 500;
}
.head-left > a:nth-child(2)::before {
  content: "|";
  padding: 0 10px;
  color: #ccc;
}
.head-left > a {
  display: flex;
  justify-content: center;
  align-items: center;
}
.head-left > a > i > .fa-solid {
  font-size: 10px;
  margin-right: 3px;
}
.head-left > a > span {
  font-weight: 600;
}
.head-left > span::before {
  content: "|";
  padding: 0 10px;
  color: #ccc;
}
.head-left > span {
  color: #777;
}
.container {
  max-width: 1175px;
  width: auto;
  padding: 0;
  margin-right: auto;
  margin-left: auto;
}
.product-detail-wrapper {
  padding: 30px 0 60px;
  display: flow-root;
}

.row {
  margin-right: -15px;
  margin-left: -15px;
}
.product-detail-main {
  margin-bottom: 80px;
  display: flow-root;
}
.btn-group-vertical > .btn-group:after,
.btn-group-vertical > .btn-group:before,
.btn-toolbar:after,
.btn-toolbar:before,
.clearfix:after,
.clearfix:before,
.container-fluid:after,
.container-fluid:before,
.container:after,
.container:before,
.dl-horizontal dd:after,
.dl-horizontal dd:before,
.form-horizontal .form-group:after,
.form-horizontal .form-group:before,
.modal-footer:after,
.modal-footer:before,
.nav:after,
.nav:before,
.navbar-collapse:after,
.navbar-collapse:before,
.navbar-header:after,
.navbar-header:before,
.navbar:after,
.navbar:before,
.pager:after,
.pager:before,
.panel-body:after,
.panel-body:before,
.row:after,
.row:before {
  display: table;
  content: " ";
}

:after,
:before {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
</style>
