<template>
  <section class="" :class="styleSection">
    <div class="sec-head" v-show="isHasLabel">
      <h1 :class="h1Title">{{ labelText }}</h1>
      <div class="mert-row" v-show="isHasChildText">
        <span class="text" v-for="(textItem, index) in optionText" :key="index" @click="onClickMenu(textItem)">{{
          textItem.productCategoryName }}</span>
      </div>
    </div>
    <div class="clearfix filter-here" v-if="listProduct.length > 0">
      <div class="content-product-list product-list filter clearfix fixBox">
        <div class="product-resize col-md-3 col-sm-3 col-xs-6 pro-loop" v-for="(product, index) in listProduct"
          :key="index">
          <div class="product-block">
            <div class="product-img image-resize">
              <a @click="onProductDetail(product)" :href="`/product?category=${dynamicUrlProduct(product.productCategoryName)}&name=${dynamicUrlProduct(product.productName)}`" class="p-img-box p-37689115 added">
                <picture>
                  <img :id="index" :src="product.listColors[0].imageItem[0].productImageUrl" class="img-loop lazyautosizes lazyloaded" :alt="product.productName" sizes="231px" />
                </picture>
                <picture v-if="product.listColors.length > 1">
                  <img :src="product.listColors[1].imageItem[0].productImageUrl" :class="{ transition: isTransition }" class="img-loop img-hover lazyautosizes lazyloaded"
                    sizes="231px" :alt="product.productName" />
                </picture>
              </a>
            </div>
            <div class="product-info">
              <div class="product-detail clearfix">
                <div class="variantColor">
                  <ul>
                    <li class="colorItem" v-for="(color, indexColor) in product.listColors"
                      :key="indexColor" @mouseover="mouseover(index, color)">
                      <a :href="`/product?category=${dynamicUrlProduct(product.productCategoryName)}&name=${dynamicUrlProduct(product.productName)}`">
                        <img :src="color.imageItem[0].productImageUrl" class="lazyautosizes lazyloaded" :alt="product.productName" sizes="24px" />
                      </a>
                    </li>
                  </ul>
                </div>
                <div class="box-pro-detail">
                  <h3 class="pro-name">
                    <a :href="`/product?category=${dynamicUrlProduct(product.productCategoryName)}&name=${dynamicUrlProduct(product.productName)}`" class="tp_product_name">{{
                      product.productName
                    }}</a>
                  </h3>
                  <div class="box-pro-prices">
                    <p class="pro-price highlight tp_product_price">
                      <span style="font-size: 14px; color: #000" class="" v-if="product.productPrice > 0" >{{
                        product.productPrice.toLocaleString("en-US", {
                          minimumFractionDigits: 0,
                        })
                      }}₫</span>
                      <span style="font-size: 14px; color: #000" v-else>0</span>
                    </p>
                  </div>
                </div>
              </div>
              <div class="frameSale"></div>
            </div>
            <div class="actionLoop visible-lg">
              <a class="quickView styleBtnBuy notClick" @click="onQuickView(product)">
                <i class="fa fa-shopping-cart" style="margin-right: 3px"></i>Mua
                nhanh
              </a>
              <a :href="`/product?category=${dynamicUrlProduct(product.productCategoryName)}&name=${dynamicUrlProduct(product.productName)}`" class="styleBtnBuy">
                <i class="fa fa-eye"></i> Xem chi tiết
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
  <quick-view :ismodal="isOpenModal" :product="productCurrent" @closeModel="oncloseModal" @reSetSelected="reSetSelected"
    @reSetSelectColor="reSetSelectColor" @reSetFistItem="reSetFistItem" @prevSlide="prevSlide" />
</template>
<script>
// import { itemSize } from "@/resource/TestData";
import { dynamicUrlProduct } from '@/methods/index';
import { store } from '@/store';
export default {
  name: "ProductList",
  props: {
    styleSection: {
      type: String,
      default: "",
    },
    isHasLabel: {
      type: Boolean,
      default: true,
    },
    // label h1
    labelText: {
      type: String,
      default: "default label", //mặc định label
    },
    // có child text hay không?
    isHasChildText: {
      type: Boolean,
      default: false, // mặc định là false
    },
    //optionText danh mục sản phẩm
    optionText: {
      type: Array,
      default: () => [
        {
          productCategoryID: "12306290-1d56-4bd5-923a-24fc4167ef29",
          productCategoryName: "Tất Nam",
          status: "kích hoạt",
          parent_category_id: "1949dae3-4d44-217e-9c66-a58ab8ff47ca",
          productCategoryCode: "DJSAFK",
          optionMenus: []
        },

      ],
    },
    // list-ListProducts
    listProduct: {
      type: Array,
      default: () => [],
    },
    h1Title: {
      type: String,
      default: "",
    },
  },
  watch: {
    isOpenModal(value) {
      if (value) {
        document.querySelector("body").style.overflowY = "hidden";
      } else {
        document.querySelector("body").style.overflowY = "auto";
      }
    },
  },
  data() {
    return {
      isTransition: false,
      isOpenModal: false,
      productCurrent: {},
      status: "Còn Hàng",
      componentKey: 0,
      dynamicUrlProduct: dynamicUrlProduct,
    };
  },
  methods: {
    onProductDetail(product){
      store.commit("handelSaveRouterProduct",product);
    },
    onClickMenu(item) {
      this.$emit("onclickMenu", item)
    },
    prevSlide(index, indexColor) {
      this.productCurrent.listColors[indexColor].imageItem.forEach(item => item.selected = false);
      this.productCurrent.listColors[indexColor].imageItem[index - 1].selected = true;
    },
    reSetFistItem(indexColor) {
      this.productCurrent.listColors[indexColor].imageItem.forEach(
        (element) => (element.selected = false)
      );
      this.productCurrent.listColors[indexColor].imageItem[0].selected = true;
    },
    reSetSelectColor(index, indexColor) {
      this.productCurrent.listColors[indexColor].imageItem.forEach(
        (element) => (element.selected = false)
      );
      this.productCurrent.listColors[indexColor].imageItem[
        index + 1
      ].selected = true;
    },
    reSetSelected(index) {
      this.productCurrent.listColors[index].imageItem[0].selected = true;
    },
    mouseover(index, color) {
      this.isTransition = true;
      let image = document.getElementById(index);
      image.setAttribute("src", color.imageItem[0].productImageUrl)
    },
    onQuickView(item) {
      this.isOpenModal = !this.isOpenModal;
      this.productCurrent = { ...item };
    },
    oncloseModal() {
      this.isOpenModal = !this.isOpenModal;
    },
  },
};
</script>
<style scoped>
* {
  font-family: "Quicksand", sans-serif;
  margin: 0;
  padding: 0;
}

.btn-group-vertical>.btn-group:after,
.btn-group-vertical>.btn-group:before,
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

.col-lg-1,
.col-lg-10,
.col-lg-11,
.col-lg-12,
.col-lg-2,
.col-lg-3,
.col-lg-4,
.col-lg-5,
.col-lg-6,
.col-lg-7,
.col-lg-8,
.col-lg-9,
.col-md-1,
.col-md-10,
.col-md-11,
.col-md-12,
.col-md-2,
.col-md-3,
.col-md-4,
.col-md-5,
.col-md-6,
.col-md-7,
.col-md-8,
.col-md-9,
.col-sm-1,
.col-sm-10,
.col-sm-11,
.col-sm-12,
.col-sm-2,
.col-sm-3,
.col-sm-4,
.col-sm-5,
.col-sm-6,
.col-sm-7,
.col-sm-8,
.col-sm-9,
.col-xs-1,
.col-xs-10,
.col-xs-11,
.col-xs-12,
.col-xs-2,
.col-xs-3,
.col-xs-4,
.col-xs-5,
.col-xs-6,
.col-xs-7,
.col-xs-8,
.col-xs-9,
.col-xs-15,
.col-sm-15,
.col-md-15,
.col-lg-15 {
  position: relative;
  min-height: 1px;
  padding-right: 15px;
  padding-left: 15px;
}

.col-xs-1,
.col-xs-10,
.col-xs-11,
.col-xs-12,
.col-xs-2,
.col-xs-3,
.col-xs-4,
.col-xs-5,
.col-xs-6,
.col-xs-7,
.col-xs-8,
.col-xs-9,
.col-xs-15 {
  float: left;
}

.col-xs-6 {
  width: 50%;
}

@media (min-width: 768px) {

  .col-sm-1,
  .col-sm-10,
  .col-sm-11,
  .col-sm-12,
  .col-sm-2,
  .col-sm-3,
  .col-sm-4,
  .col-sm-5,
  .col-sm-6,
  .col-sm-7,
  .col-sm-8,
  .col-sm-9,
  col-sm-15 {
    float: left;
  }
}

@media (min-width: 768px) {
  .col-sm-3 {
    width: 25%;
  }
}

@media (min-width: 992px) {

  .col-md-1,
  .col-md-10,
  .col-md-11,
  .col-md-12,
  .col-md-2,
  .col-md-3,
  .col-md-4,
  .col-md-5,
  .col-md-6,
  .col-md-7,
  .col-md-8,
  .col-md-9,
  .col-md-15 {
    float: left;
  }
}

@media (min-width: 992px) {
  .col-md-3 {
    width: 25%;
  }
}

.pro-loop {
  display: block;
  position: relative;
  height: 100%;
  background: #fff;
}

.content-product-list .pro-loop {
  margin: 0 0 40px 0;
}

@media (min-width: 768px) {
  .pro-loop.col-sm-3:nth-child(4n + 1) {
    clear: left;
  }
}

@media (min-width: 992px) {
  .pro-loop.col-md-3:nth-child(4n + 1) {
    clear: left;
  }
}

@media (min-width: 1025px) {
  .product-block:not(.recommend-block) {
    padding: 15px;
    transition: all 0.4s ease-in-out 0s;
    -moz-transition: all 0.4s ease-in-out 0s;
    -o-transition: all 0.4s ease-in-out 0s;
    -webkit-transition: all 0.4s ease-in-out 0s;
    -ms-transition: all 0.4s ease-in-out 0s;
    position: relative;
  }
}

@media (min-width: 1025px) {
  .product-block:not(.recommend-block) {
    padding: unset;
  }
}

.product-img {
  text-align: center;
  position: relative;
  overflow: hidden;
  padding: 0 10px;
}

@media (min-width: 1025px) {
  .pro-loop .product-img {
    min-height: 300px;
  }
}

.pro-loop .product-img {
  padding: unset;
}

a {
  color: #337ab7;
  text-decoration: none;
}

a {
  background-color: transparent;
}

a {
  color: #252a2b;
  text-decoration: none;
  outline: none;
  -moz-transition: all 0.2s ease-in-out;
  -o-transition: all 0.2s ease-in-out;
  -webkit-transition: all 0.2s ease-in-out;
  transition: all 0.2s ease-in-out;
}

a {
  transition: opacity 150ms linear, color 150ms linear, background 150ms linear;
}

.pro-loop a {
  display: block;
}

.pro-loop .product-img picture {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  transition: 0.7s;
}

img {
  vertical-align: middle;
}

img {
  border: 0;
}

img {
  max-width: 100%;
  width: 100%;
  height: auto;
}

img {
  max-width: 100%;
}

img.lazyloaded {
  opacity: 1;
  transition: 0.3s;
}

.pro-loop .product-img picture:nth-of-type(2) {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  opacity: 0;
  visibility: hidden;
}

.pro-loop .product-detail {
  padding: 0;
}

.variantColor {
  text-align: center;
  min-height: 41px;
  margin: 10px 0 0 0;
}

ol,
ul {
  margin-top: 0;
  margin-bottom: 10px;
}

ul {
  padding: 0;
  list-style-type: none;
}

.variantColor ul {
  margin: 0;
}

.variantColor li {
  display: inline-block;
  border-radius: 100%;
  border: 1px solid white;
  width: 30px !important;
  height: 30px;
  padding: 2px;
  text-align: center;
  position: relative;
  z-index: 9;
  overflow: hidden;
}

.variantColor li a {
  display: inherit;
}

.variantColor img {
  display: inline-block;
  border-radius: 100%;
}

.product-detail .box-pro-detail {
  z-index: 9;
  width: 100%;
  text-align: center;
}

.h1,
.h2,
.h3,
.h4,
.h5,
.h6,
h1,
h2,
h3,
h4,
h5,
h6 {
  font-family: inherit;
  font-weight: 500;
  line-height: 1.1;
  color: inherit;
}

.h1,
.h2,
.h3,
h1,
h2,
h3 {
  margin-top: 20px;
  margin-bottom: 10px;
}

.h3,
h3 {
  font-size: 24px;
}

h1,
h2,
h3,
h4,
h5,
h6 {
  color: #252a2b;
  margin: 0 0 13px 0;
  font-weight: 500;
  line-height: 1.2;
}

h3 {
  font-size: 24px;
}

.pro-loop .product-detail h3 {
  margin: 0;
  font-size: 14px;
  position: relative;
  font-weight: normal;
  min-height: 20px;
}

h1 a,
h2 a,
h3 a,
h4 a,
h5 a,
h6 a {
  color: #252a2b;
  line-height: 1.1;
}

.pro-loop .product-detail h3 a {
  line-height: 20px;
  overflow: hidden;
  -webkit-line-clamp: 1;
  -webkit-box-orient: vertical;
  display: -webkit-box;
  font-size: 13px;
}

p {
  margin: 0 0 10px;
}

p {
  margin: 0 0 10px 0;
  line-height: 21px;
}

p.pro-price {
  color: #000000;
  font-size: 14px;
  margin: 0;
}

p.pro-price.highlight {
  font-weight: bold;
}

.btn-group-vertical>.btn-group:after,
.btn-toolbar:after,
.clearfix:after,
.container-fluid:after,
.container:after,
.dl-horizontal dd:after,
.form-horizontal .form-group:after,
.modal-footer:after,
.nav:after,
.navbar-collapse:after,
.navbar-header:after,
.navbar:after,
.pager:after,
.panel-body:after,
.row:after {
  clear: both;
}

a:hover,
a:focus {
  color: #000;
  text-decoration: none;
  outline: none;
}

@media (min-width: 1025px) {
  .product-block:not(.recommend-block):hover {
    box-shadow: 0 0 2px 0px #ccc;
    -webkit-box-shadow: 0 0 2px 0px #ccc;
    -moz-box-shadow: 0 0 2px 0px #ccc;
    -o-box-shadow: 0 0 2px 0px #ccc;
  }
}

.product-img:hover .actionLoop,
.product-img:hover {
  opacity: 1;
  visibility: visible;
}

.visible-lg,
.visible-md,
.visible-sm,
.visible-xs {
  display: none !important;
}

@media (min-width: 1200px) {
  .visible-lg {
    display: block !important;
  }
}

@media (min-width: 1025px) {
  .actionLoop {
    background: black;
    position: absolute;
    bottom: -38px;
    width: 100%;
    left: 0;
    opacity: 0;
    visibility: hidden;
    transition: all 0.4s ease-in-out 0s;
    -moz-transition: all 0.4s ease-in-out 0s;
    -o-transition: all 0.4s ease-in-out 0s;
    -webkit-transition: all 0.4s ease-in-out 0s;
    -ms-transition: all 0.4s ease-in-out 0s;
    padding: 7px 0;
    z-index: 9;
  }
}

.actionLoop a {
  font-size: 13px;
}

.pro-loop a {
  display: block;
}

.quickView {
  border-right: 1px solid white;
}

@media (min-width: 1025px) {
  .actionLoop a {
    float: left;
    width: 50%;
    color: white;
    text-align: center;
    padding: 3px 10px;
    cursor: pointer;
  }
}

.fa {
  display: inline-block;
  color: white;
  font: normal normal normal 14px/1 FontAwesome;
  font-size: inherit;
  text-rendering: auto;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

.product-img:hover .added>picture:nth-child(2) {
  opacity: 1;
  visibility: visible;
}

.product-block:hover .actionLoop.visible-lg {
  opacity: 1;
  visibility: visible;
}

.sec-pro {
  width: 100%;
  padding: 0 55px;
}

.sec-head>h1 {
  font-family: "Quicksand";
  font-weight: 700;
  font-size: 30px;
  margin: 0 0 30px;
}

.sec-head {
  display: flex;
  padding-right: 20px;
  align-items: baseline;
}

.mert-row {
  margin-left: 30px;
}

.mert-row span {
  text-transform: capitalize;
}

.text {
  margin-right: 30px;
  font-weight: 700;
  font-size: 15px;
  padding-bottom: 5px;
}

.text:hover {
  border-bottom: 2px solid;
  cursor: pointer;
}
</style>
