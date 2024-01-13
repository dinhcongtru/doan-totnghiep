<template>
    <!-- main category -->
  <main class="tp_product_category">
    <!-- main content -->
    <div class="main-content">
      <div class="breadcrumb-shop">
        <div class="padding-lf-40">
          <div class="head-left">
            <a href="/">
              <i class="fa-sharp fa-solid fa-house-chimney"></i>
              <span>Trang chủ</span>
            </a>
            <span>Giỏ hàng</span>
          </div>
        </div>
      </div>
     <div class="container-fluid">
        <div class="pd-page">
            <div class="container">
                <div class="heading-pageNew">
                    <div class="header-pageCart">
                        <h1>Giỏ hàng của bạn</h1>
                        <span class="count-cart">(Có <b>{{ getTotalProAddToCart }}</b> sản phẩm trong giỏ hàng)</span>
                    </div>
                </div>
                <div class="row">
                    <form action="/cart" @submit="getInfo" id="cartformpage">
                        <div class="col-xs-12 col-sm-8">
                            <div class="cart-container" v-show="this.productAddtoCarts.length > 0">
                                <div class="cart-col-left">
                                    <div class="main-content-cart">
                                        <table class="table-cart">
                                            <thead>
                                                <tr>
                                                    <th width="20%" class="image">&nbsp;</th>
                                                    <th width="40%" class="item">Tên sản phẩm</th>
                                                    <th width="20%" class="quantity">Số lượng</th>
                                                    <th width="20%" class="remove">&nbsp;</th>
                                                </tr>
                                            </thead>
                                            <tbody class="updateItem">
                                                <tr class="clearfix line-item-container" v-for="(item,index) in productAddtoCarts" :key="index">
                                                    <td class="image imageVariantCart">
                                                        <div class="product_image">
                                                            <a :href="`product?category=${dynamicUrlProduct(item.productCategoryName)}&name=${dynamicUrlProduct(item.productName)}`">
                                                                <img :src="item.productImageUrl" alt="">
                                                            </a>
                                                        </div>
                                                    </td>
                                                    <td class="item itemVariantCart">
                                                        <p>
                                                            <a href=""></a>
                                                        </p>
                                                        <h3>
                                                            <a :href="`product?category=${dynamicUrlProduct(item.productCategoryName)}&name=${dynamicUrlProduct(item.productName)}`">
                                                                {{ item.productName }} - {{ item.selectedColor.productColorName }} - {{ item.selectedSize.productSizeName }}
                                                            </a>
                                                        </h3>
                                                        <p></p>
                                                        <div class="visible-xs showInMobileCart clearfix">
                                                            <div class="qty quantity-partent qty-click clearfix">
                                                                <span class="add-down add-action" @click="onTru(item.quantity,item.productID,item.selectedColor,item.selectedSize)">-</span>
                                                                <input type="text" size="4" min="1" id="" max="15" ref="quantity" :value="item.quantity" data-id="37883750" class="tc line-item-qty item-quantity" readonly="">
                                                                <span class="add-up add-action" @click="onCong(item.quantity,item.productID,item.selectedColor,item.selectedSize)">+</span>
                                                            </div>
                                                            <span class="line-item-total" v-if="item.productPrice > 0">{{ item.productPrice.toLocaleString('en-US', {minimumFractionDigits: 0}) }}₫</span>
                                                        </div>
                                                        <a class="deleteItem cart_remove cart_remove_index" @click="removeProAddToCart(item.productID,item.selectedSize,item.selectedColor)">Xóa</a>
                                                    </td>
                                                    <td class="hidden-xs quantity quantityVariantCart">
                                                        <div class="qty quantity-partent qty-click clearfix">
                                                            <span class="add-down add-action" @click="onTru(item.quantity,item.productID,item.selectedColor,item.selectedSize)">-</span>
                                                            <input type="text" size="4" min="1" max="15" ref="quantity" :value="item.quantity" class="tc line-item-qty item-quantity" readonly="">
                                                            <span class="add-up add-action" @click="onCong(item.quantity,item.productID,item.selectedColor,item.selectedSize)">+</span>
                                                        </div>
                                                    </td>
                                                    <td class="hidden-xs totalLinePriceVariantCart">
                                                        <p class="price price-flex">
                                                            <span class="line-item-total" v-if="item.productPrice > 0">{{ item.productPrice.toLocaleString('en-US', {minimumFractionDigits: 0}) }}₫</span>
                                                        </p>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="span12 expanded-message text-center" v-show="this.productAddtoCarts.length == 0">Giỏ hàng của bạn trống.</div>
                        </div>
                        <div class="col-xs-12 col-sm-4">
                            <div class="boxRightCart clearfix">
                                <div class="titleInfoCart">TÓM TẮT ĐƠN HÀNG</div>
                                <div class="summary-subtotal clearfix">
                                    <p class="order-infor">
                                        <span class="titleOrder">Chưa bao gồm phí vận chuyển:</span>
                                    </p>
                                    <p class="order-infor boldPrice">
                                        <span class="titleOrder"><b>Tổng tiền:</b></span>
                                        <span class="valOrder total_price"><b v-if="getTotalPrice > 0">{{ getTotalPrice.toLocaleString('en-US', {minimumFractionDigits: 0}) }}₫</b></span>
                                    </p>
                                </div>
                                <div class="note-subtotal clearfix">
                                    <i>Bạn có thể nhập mã giảm giá ở trang thanh toán</i>
                                </div>
                                <div class="cart-buttons">
                                    <a href="/cart/checkout" id="checkout" name="checkout" class="checkLimitCart">Tiến hành đặt hàng</a>
                                    <a href="/" class="link-continue" title="Tiếp tục mua hàng">Mua thêm sản phẩm</a>
                                </div>
                            </div>
                        </div>
                    </form>
                    <list-products 
                    :labelText="labelTextProductNew"
                    :listProducts = "listNewProducts"
                    styleSection="convert"
                    h1Title="convertH1"
                    />
                </div>
            </div>
        </div>
     </div>
    </div>
  </main>
</template>
<script>
import {store} from '@/store/index'
import { listNewProductHomePages } from '@/resource/TestData';
import { dynamicUrlProduct } from '@/methods';
export default {
    name:"CartDetailt",
    created(){
        document.title = "Giỏ hàng"
    },
    data(){
        return{
            labelTextProductNew : "SẢN PHẨM CÓ THỂ BẠN THÍCH",
            listNewProducts :listNewProductHomePages,
            dynamicUrlProduct:dynamicUrlProduct,
        }
    },
    mounted(){
        // console.log(this.productAddtoCarts);
    },
    computed:{
        getTotalProAddToCart(){
           return this.$store.getters.getTotalProduct;
        },
        getTotalPrice(){
            return this.$store.getters.getTotalPrice;
        },
        productAddtoCarts(){
            return this.$store.getters.getProduct
        }
    },
    methods:{
        onTru(quantity,id,color,size){     
            if(quantity > 1){
                store.commit("handleMinusQuantity",{id,color,size})
                
            }
        },
        onCong(quantity,id,color,size){
            if(quantity < 40){
                store.commit("handlePlusQuantity",{id,color,size})
            }
        },
        removeProAddToCart(id,size,color){
            if(confirm("Bạn có muốn xóa sản phẩm trong giỏ hàng hay không?")){
                store.commit("handleRemoveProductToCart",{id,size,color});
                store.commit("handleOpenAddtoCart");
            }    
        },

    }
}
</script>
<style scoped>
    *,body {
    line-height: 1.4; 
    }
    .padding0{
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
    .head-left > a {
    display: flex;
    justify-content: center;
    align-items: center;
    }
    .head-left > a > i > .fa-solid{
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
    .heading-collection {
    display: flex;
    padding: 50px 0 0;
    }
    .fa, .fa-brands, .fa-classic, .fa-regular, .fa-sharp, .fa-solid, .fab, .far, .fas{
        line-height: 1.4;
    }
    .container-fluid {
        padding: 0 40px;
    }

    .container-fluid {
        padding-right: 15px;
        padding-left: 15px;
        margin-right: auto;
        margin-left: auto;
    }
    .btn-group-vertical > .btn-group:after, .btn-group-vertical > .btn-group:before, .btn-toolbar:after, .btn-toolbar:before, .clearfix:after, .clearfix:before, .container-fluid:after, .container-fluid:before, .container:after, .container:before, .dl-horizontal dd:after, .dl-horizontal dd:before, .form-horizontal .form-group:after, .form-horizontal .form-group:before, .modal-footer:after, .modal-footer:before, .nav:after, .nav:before, .navbar-collapse:after, .navbar-collapse:before, .navbar-header:after, .navbar-header:before, .navbar:after, .navbar:before, .pager:after, .pager:before, .panel-body:after, .panel-body:before, .row:after, .row:before {
        display: table;
        content: " ";
    }

    :after, :before {
        -webkit-box-sizing: border-box;
        -moz-box-sizing: border-box;
        box-sizing: border-box;
    }
    .pd-page {
        padding-top: 30px;
    }

    @media (min-width: 1200px){
    .container {
        width: 1170px;
    }
    }
    @media (min-width: 992px){
    .container {
        width: 970px;
    }
    }
    @media (min-width: 768px){
    .container {
        width: 750px;
    }
    @media (min-width: 1200px){
    .container {
        max-width: 1175px;
        width: auto;
        padding: 0;
    }
    }
    .container {
        padding-right: 0;
        padding-left: 0;
        margin-right: auto;
        margin-left: auto;
    }
    }
    .heading-pageNew {
        margin: 0 0 15px 0;
    }
    .heading-pageNew {
        margin: 0 0 15px 0;
    }
    .header-pageCart h1 {
        display: inline-block;
        margin: 0;
        font-size: 25px;
        text-transform: uppercase;
        font-weight: bold;
        color: #252a2b;
        line-height: 1.2;
        font-family: 'Quicksand-Bold';
    }
    b, strong {
        font-weight: 700;
        font-size: 14px;
        font-family: 'Quicksand-Bold';
    }
    .titleOrder{
        font-size: 14px;
    }
    .row {
        margin-right: -15px;
        display: flow-root;
        margin-left: -15px;
    }
    @media (min-width: 768px){
    .col-sm-8 {
        width: 66.66666667%;
    }
    }
    @media (min-width: 768px){
    .col-sm-1, .col-sm-10, .col-sm-11, .col-sm-12, .col-sm-2, .col-sm-3, .col-sm-4, .col-sm-5, .col-sm-6, .col-sm-7, .col-sm-8, .col-sm-9, col-sm-15 {
        float: left;
    }
    }
    /* .col-xs-12 {
        width: 100%;
    } */
    .col-xs-1, .col-xs-10, .col-xs-11, .col-xs-12, .col-xs-2, .col-xs-3, .col-xs-4, .col-xs-5, .col-xs-6, .col-xs-7, .col-xs-8, .col-xs-9, .col-xs-15 {
        float: left;
    }
    .col-lg-1, .col-lg-10, .col-lg-11, .col-lg-12, .col-lg-2, .col-lg-3, .col-lg-4, .col-lg-5, .col-lg-6, .col-lg-7, .col-lg-8, .col-lg-9, .col-md-1, .col-md-10, .col-md-11, .col-md-12, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-sm-1, .col-sm-10, .col-sm-11, .col-sm-12, .col-sm-2, .col-sm-3, .col-sm-4, .col-sm-5, .col-sm-6, .col-sm-7, .col-sm-8, .col-sm-9, .col-xs-1, .col-xs-10, .col-xs-11, .col-xs-12, .col-xs-2, .col-xs-3, .col-xs-4, .col-xs-5, .col-xs-6, .col-xs-7, .col-xs-8, .col-xs-9, .col-xs-15, .col-sm-15, .col-md-15, .col-lg-15 {
        position: relative;
        min-height: 1px;
        padding-right: 15px;
        padding-left: 15px;
    }
    table.table-cart {
        margin-bottom: 30px;
    }

    table {
        width: 100%;
        border-spacing: 0;
    }
    table {
        background-color: transparent;
    }
    table {
        border-spacing: 0;
        border-collapse: collapse;
    }
    table.table-cart thead {
        display: none;
    }
    th {
        text-align: left;
    }

    td, th {
        padding: 0;
    }
    table tr td:first-child, table tr th:first-child {
        padding-left: 0;
    }

    table tr td, table tr th {
        padding: 10px;
        text-align: left;
    }
    table tr td:last-child, table tr th:last-child {
        padding-right: 0;
    }
    table tr td:first-child, table tr th:first-child {
        padding-left: 0;
    }
    .imageVariantCart, .quantityVariantCart, .totalLinePriceVariantCart {
        width: 20%;
    }
    table tr td, table tr th {
        padding: 10px;
        text-align: left;
    }
    table tr td {
        border-top: 1px solid #dddddd;
    }
    td, th {
        padding: 0;
    }
    table.table-cart tr td.image {
        text-align: center;
        width: 110px;
    }


    table.table-cart tr td {
        padding: 20px 0;
        border-top: 1px solid #ededed;
        vertical-align: middle;
    }
    table.table-cart tr:first-child td {
        border-top: 0;
    }
    table.table-cart tr td.image .product_image {
        position: relative;
    }
    .line-item-total{
        font-size: 14px;
    }
    .count-cart{
        margin-left: 3px;
        font-size: 14px;
    }
    table.table-cart tr td.image img {
        max-width: 100px;
        width: 100%;
        height: auto;
        vertical-align: middle;
        border: 0;
        cursor: pointer;
    }
    table tr td, table tr th {
        padding: 10px;
        text-align: left;
    }
    table.table-cart tr td {
        padding: 20px 0;
        border-top: 1px solid #ededed;
        vertical-align: middle;
    }
    .itemVariantCart {
        width: 40%;
    }
    table.table-cart tr td.item {
        padding-left: 15px;
    }
    table.table-cart tr:first-child td {
        border-top: 0;
    }
    table.table-cart tr td.item p {
        margin-bottom: 5px;
    }

    p {
        margin: 0 0 10px 0;
        line-height: 21px;
    }
    table.table-cart tr td.item h3 {
        margin: 0 0 5px;
        font-size: 13px;
        font-weight: normal;
        display: inline;
        color: #252a2b;
        line-height: 1.2;
        font-family: inherit;
        
    }
    h1 a, h2 a, h3 a, h4 a, h5 a, h6 a {
        color: #252a2b;
        line-height: 1.1;
        cursor: pointer;
    }
    table.table-cart tr td.item p {
        margin-bottom: 5px;
    }

    p {
        margin: 0 0 10px 0;
        line-height: 21px;
    }
    .visible-lg, .visible-md, .visible-sm, .visible-xs {
        display: none!important;
    }
    .qty-click {
        float: left;
    }
    .add-action {
        font-weight: bold;
        font-size: 18px;
        width: 20px;
        text-align: center;
        cursor: pointer;
        float: left;
    }
    button, input, select, textarea {
        font-family: inherit;
        font-size: inherit;
        line-height: inherit;
    }
    button, input, optgroup, select, textarea {
        margin: 0;
        font: inherit;
        color: inherit;
    }
    .qty-click input.item-quantity {
        background: #ededed;
        font-weight: 500;
        font-size: 15px;
        height: 25px;
        padding: 0;
        text-align: center;
        width: 35px;
        border: 1px solid #dadbdd;
        border-left: none;
        border-right: none;
        border-radius: 0;
        float: left;
        /* -webkit-appearance: none; */
    }
    .add-action {
        font-weight: bold;
        font-size: 18px;
        width: 20px;
        text-align: center;
        cursor: pointer;
        float: left;
    }
    .deleteItem {
        border: 1px solid #ededed;
        padding: 5px;
        float: left;
        font-size: 12px;
        cursor: pointer;
        color:#252a2b;
    }
    table.table-cart tr td {
        padding: 20px 0;
        border-top: 1px solid #ededed;
        vertical-align: middle;
    }
    .imageVariantCart, .quantityVariantCart, .totalLinePriceVariantCart {
        width: 20%;
    }
    table.table-cart tr:first-child td {
        border-top: 0;
    }   
    @media (min-width: 768px){
    .col-sm-4 {
        width: 33.33333333%;
    }
    }
    .boxRightCart {
        float: left;
        width: 100%;
        background: #f2f2f2;
        padding: 15px;
    }
    .titleInfoCart {
        font-weight: bold;
        margin: 0 0 10px 0;
        font-size: 14px;
        font-family: 'Quicksand-Bold';
    }
    form{
        display: flow-root;
    }
    .summary-subtotal {
        font-size: 14px;
        border-bottom: 1px dotted #bcbcbc;
    }
    .boldPrice .total_price {
        font-weight: bold;
    }
    .valOrder {
        float: right;
    }
    .note-subtotal {
        font-size: 13px;
        float: left;
        width: 100%;
        margin: 10px 0;
    }
    #checkout {
        padding: 10px 30px;
        position: relative;
        width: 100%;
        white-space: nowrap;
        float: left;
        background: black;
        color: white;
        text-align: center;
        text-transform: uppercase;
        font-weight: bold;
        border: none;
        transition: opacity 150ms linear, color 150ms linear, background 150ms linear;
        margin: 0;
        font: inherit;
        overflow: visible;
        /* -webkit-appearance: button; */
        cursor: pointer;
        font-family: 'Quicksand-Bold';
        font-size: 14px;
        line-height: inherit;
    }
    .cart-buttons .link-continue {
        margin: 15px 0 0 0;
        padding: 10px 30px;
        position: relative;
        width: 100%;
        white-space: nowrap;
        display: inline-block;
        color: black;
        text-align: center;
        text-transform: uppercase;
        font-weight: bold;
        border: 1px solid black;
        background: white;
        border-bottom: 2px solid black;
        font-size: 14px;
        vertical-align: top;
    }
    .expanded-message {
    margin: 20px 0;
    }

    .text-center {
        text-align: center;
    }
</style>