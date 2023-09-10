<template>
  <div class="col-xs-12 clearfix">
    <ul class="tabUlRelate">
      <li
        :class="[item.selected ? 'active' : '']"
        v-for="(item, index) in listTabAction"
        :key="index"
        @click="onselect(item, index)"
      >
        <a>{{ item.name }}</a>
      </li>
      <!-- <li>
        <a href="">Sản phẩm bán chạy</a>
      </li> -->
    </ul>
    <div class="contentRelateProduct styleArrowOwl">
      <div class="tabDetailProduct owlRelate2">
        <div class="owl-carousel owl-theme owl-loaded">
          <div class="owl-stage-outer">
            <div
            v-if="isDefaultCanLike"
              class="owl-stage"
              style="transition: all 0.5s ease 0s; width: 2056.25px"
              :style="[`transform: translate3d(${translate3d}px, 0px, 0px);`]"
            >
              <div
                class="owl-item active"
                style="width: 293.75px; margin-right: 0px"
                v-for="(product, index) in listProduct"
                :key="index"
              >
                <div class="itemslick pro-loop">
                  <div class="product-block recommend-block">
                    <div class="product-img">
                      <a class="p-img-box added">
                        <picture>
                          <img
                            :id="index"
                            class="img-loop lazyautosizes lazyloaded"
                            :src="
                              require('@/assets/img/' +
                                product.listColors[0].listImages[0].image)
                            "
                            :alt="product.productName"
                            sizes="264px"
                          />
                        </picture>
                        <picture>
                          <img
                            :id="'picture' + index"
                            class="img-loop img-hover lazyautosizes lazyloaded"
                            :src="
                              require('@/assets/img/' +
                                product.listColors[1].listImages[1].image)
                            "
                            :alt="product.productName"
                            sizes="264px"
                          />
                        </picture>
                      </a>
                    </div>
                    <div class="product-detail clearfix">
                      <div class="variantColor">
                        <ul>
                          <li
                            v-for="(color, indexColor) in product.listColors"
                            :key="indexColor"
                            @mouseover="mouseover(index, color)"
                          >
                            <a>
                              <img
                                class="lazyautosizes lazyloaded"
                                data-sizes="auto"
                                :src="
                                  require('@/assets/img/' +
                                    color.listImages[0].image)
                                "
                                alt="Áo Sơ Mi Cổ Đức Dài Tay Slim Polyster 3022 - Trắng - XL"
                                sizes="24px"
                              />
                            </a>
                          </li>
                        </ul>
                      </div>
                      <div class="box-pro-detail">
                        <h3 class="pro-name tp_product_name">
                          <a>{{ product.productName }}</a>
                        </h3>
                        <div class="box-pro-prices">
                          <p class="pro-price highlight tp_product_price">
                            {{
                              ((product.price * discount) / 100).toLocaleString(
                                "en-US",
                                {
                                  minimumFractionDigits: 0,
                                }
                              )
                            }}₫
                            <span class="pro-price-del">
                              <del class="compare-price tp_product_price_old"
                                >{{
                                  product.price.toLocaleString("en-US", {
                                    minimumFractionDigits: 0,
                                  })
                                }}₫</del
                              >
                            </span>
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="activeLabelStatus">
                      <div class="product-saleNew">Giảm {{ discount }}%</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div
              v-else
              class="owl-stage"
              style="transition: all 0.5s ease 0s; width: 2056.25px"
              :style="[`transform: translate3d(${translate3d}px, 0px, 0px);`]"
            >
              <div
                class="owl-item active"
                style="width: 293.75px; margin-right: 0px"
                v-for="(product, index) in listProduct"
                :key="index"
              >
                <div class="itemslick pro-loop">
                  <div class="product-block recommend-block">
                    <div class="product-img">
                      <a class="p-img-box added">
                        <picture>
                          <img
                            :id="index"
                            class="img-loop lazyautosizes lazyloaded"
                            :src="
                              require('@/assets/img/' +
                                product.listColors[0].listImages[0].image)
                            "
                            :alt="product.productName"
                            sizes="264px"
                          />
                        </picture>
                        <picture>
                          <img
                            :id="'picture' + index"
                            class="img-loop img-hover lazyautosizes lazyloaded"
                            :src="
                              require('@/assets/img/' +
                                product.listColors[1].listImages[1].image)
                            "
                            :alt="product.productName"
                            sizes="264px"
                          />
                        </picture>
                      </a>
                    </div>
                    <div class="product-detail clearfix">
                      <div class="variantColor">
                        <ul>
                          <li
                            v-for="(color, indexColor) in product.listColors"
                            :key="indexColor"
                            @mouseover="mouseover(index, color)"
                          >
                            <a>
                              <img
                                class="lazyautosizes lazyloaded"
                                data-sizes="auto"
                                :src="
                                  require('@/assets/img/' +
                                    color.listImages[0].image)
                                "
                                alt="Áo Sơ Mi Cổ Đức Dài Tay Slim Polyster 3022 - Trắng - XL"
                                sizes="24px"
                              />
                            </a>
                          </li>
                        </ul>
                      </div>
                      <div class="box-pro-detail">
                        <h3 class="pro-name tp_product_name">
                          <a>{{ product.productName }}</a>
                        </h3>
                        <div class="box-pro-prices">
                          <p class="pro-price highlight tp_product_price">
                            {{
                              ((product.price * discount) / 100).toLocaleString(
                                "en-US",
                                {
                                  minimumFractionDigits: 0,
                                }
                              )
                            }}₫
                            <span class="pro-price-del">
                              <del class="compare-price tp_product_price_old"
                                >{{
                                  product.price.toLocaleString("en-US", {
                                    minimumFractionDigits: 0,
                                  })
                                }}₫</del
                              >
                            </span>
                          </p>
                        </div>
                      </div>
                    </div>
                    <div class="activeLabelStatus">
                      <div class="product-saleNew">Giảm {{ discount }}%</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="owl-controls">
            <div class="owl-nav">
              <div class="owl-prev" style="" @click="onPrevSlide">prev</div>
              <div class="owl-next" style="" @click="onNextSlide">next</div>
            </div>
            <div class="owl-dots" style="">
              <div class="owl-dot active"><span></span></div>
              <div class="owl-dot"><span></span></div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { listNewProducts, productLIst } from "@/resource/TestData";
export default {
  name: "WhistList",
  computed: {
    listProduct() {
      return this.isDefaultCanLike ? listNewProducts : productLIst;
    },
  },
  data() {
    return {
      translate3d: 0,
      isDefaultCanLike: true,
      listTabAction: [
        {
          name: "có thể bạn thích",
          selected: true,
        },
        {
          name: "sản phẩm bán chạy",
          selected: false,
        },
      ],
      discount: 60,
      listProCanLike: listNewProducts,
    };
  },
  methods: {
    onselect(item, index) {
      this.listTabAction.forEach((item) => (item.selected = false));
      item.selected = true;
      if (index == 0) this.isDefaultCanLike = true;
      else this.isDefaultCanLike = false;
    },
    onNextSlide() {
      if (this.listProduct.length > 4) {
        this.translate3d -= 294;
      }
    },
    onPrevSlide() {
      if (this.translate3d < 0) {
        this.translate3d += 294;
      }
    },
    mouseover(index, color) {
      let image = document.getElementById(index);
      let secondImgae = document.getElementById("picture" + index);
      secondImgae.setAttribute(
        "src",
        require("@/assets/img/" + color.listImages[0].image)
      );
      image.setAttribute(
        "src",
        require("@/assets/img/" + color.listImages[0].image)
      );
    },
  },
};
</script>
<style scoped>
body.tp_background,
div,
dl,
dt,
dd,
ul,
ol,
li,
h1,
h2,
h3,
h4,
h5,
h6,
pre,
code,
form,
fieldset,
legend,
input,
button,
textarea,
select,
span,
a,
p,
sub,
blockquote,
th,
td {
  font-family: Roboto;
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
.col-xs-12 {
  width: 100%;
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
ol,
ul {
  margin-top: 0;
  margin-bottom: 10px;
}
ul {
  padding: 0;
  list-style-type: none;
}
.tabUlRelate {
  padding: 0;
  margin: 0;
  display: inline-block;
  width: 100%;
}
.tabUlRelate li {
  float: left;
  width: calc(100% / 3);
  margin: 0 0 50px 0;
  border-bottom: 1px solid #ececec;
  padding-bottom: 10px;
  text-transform: uppercase;
  font-size: 16px;
  font-weight: bold;
}
.tabUlRelate li.active {
  border-bottom: 2px solid black;
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
.tabUlRelate li.active {
  border-bottom: 2px solid black;
}

.owl-carousel,
.owl-carousel .owl-item {
  -webkit-tap-highlight-color: transparent;
  position: relative;
}
.owl-carousel {
  display: none;
  width: 100%;
  z-index: 1;
}
.owl-carousel.owl-loaded {
  display: block;
}
.owl-carousel .owl-stage-outer {
  position: relative;
  overflow: hidden;
  -webkit-transform: translate3d(0, 0, 0);
}
.owl-carousel .owl-stage {
  position: relative;
  -ms-touch-action: pan-Y;
}
.owl-carousel .owl-item {
  min-height: 1px;
  float: left;
  -webkit-backface-visibility: hidden;
  -webkit-touch-callout: none;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}
.tabDetailProduct .itemslick {
  padding: 0 15px;
}

.pro-loop {
  display: block;
  position: relative;
  height: 100%;
  background: #fff;
}
.pro-loop .product-img {
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
img.lazyloaded {
  opacity: 1;
  transition: 0.3s;
}

img {
  max-width: 100%;
}
.owl-carousel .owl-item img {
  display: block;
  width: 100%;
  -webkit-transform-style: preserve-3d;
  transform-style: preserve-3d;
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
.pro-loop .product-detail h3 {
  margin: 0;
  font-size: 14px;
  position: relative;
  font-weight: normal;
  min-height: 20px;
  line-height: 1.2;
}
.pro-loop .product-detail h3 a {
  line-height: 20px;
  overflow: hidden;
  -webkit-line-clamp: 1;
  -webkit-box-orient: vertical;
  display: -webkit-box;
  font-size: 14px;
}
p.pro-price.highlight {
  font-weight: bold;
  line-height: 21px;
}

p.pro-price {
  color: #000000;
  font-size: 14px;
  margin: 0;
}
p.pro-price span.pro-price-del {
  color: #939393;
  margin-left: 15px;
  font-weight: normal;
}
.btn-group-vertical > .btn-group:after,
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
.activeLabelStatus {
  text-align: center;
}
.product-saleNew {
  color: #e01b22;
  font-weight: bold;
}
.styleArrowOwl .owl-nav > div {
  position: absolute;
  z-index: 999;
  top: 40%;
  border: none;
  background: transparent;
  font-size: 0;
  width: 35px;
  height: 40px;
  background-repeat: no-repeat;
  background-size: contain;
}
.styleArrowOwl .owl-nav > .owl-prev {
  background-image: url(../assets/img/left_arrow_fix1.png);
  left: 0;
}

.styleArrowOwl .owl-nav > div {
  width: 15px;
  height: 22px;
}
.owl-carousel .owl-controls .owl-dot,
.owl-carousel .owl-controls .owl-nav .owl-next,
.owl-carousel .owl-controls .owl-nav .owl-prev {
  cursor: pointer;
  cursor: hand;
  -webkit-user-select: none;
  -khtml-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}
.styleArrowOwl .owl-nav > .owl-next {
  background-image: url(../assets/img/right_arrow_fix1.png);
  right: -3px;
}
.tabUlRelate > li > a {
  text-transform: uppercase;
  font-size: 16px;
  font-weight: bold;
  font-family: roboto;
}
del {
  text-decoration: line-through;
}
.product-img:hover .added > picture:nth-child(2) {
  opacity: 1;
  visibility: visible;
}
.product-block:hover .actionLoop.visible-lg {
  opacity: 1;
  visibility: visible;
}
</style>
