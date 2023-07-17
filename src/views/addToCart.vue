<template>
    <div class="site-nav style--sidebar show-cart clickOutside" :class="{active : isAddToCart}" id="site-nav--mobile">
        <div id="site-cart" class="site-nav-container">
            <div class="site-nav-container-last">
                <input type="hidden" id="totalCartItems_hidden" value="1">
                <p class="title">Giỏ hàng</p>
                <span class="textCartSide">Bạn đang có <b>{{ totalProduct }}</b> sản phẩm trong giỏ hàng.</span>
                <div class="cart-view clearfix">
                    <table id="cart-view">
                        <tbody>
                            <tr  class="item_2" v-for="(item,index) in productAddtoCarts" :key="index" v-show="this.productAddtoCarts.length > 0">
                                <td class="img">
                                    <a href="#">
                                        <img class="lazyautosizes ls-is-cached lazyloaded" :src="require('@/assets/img/' + item.img)" alt="">
                                    </a>
                                </td>
                                <td>
                                    <a class="pro-title-view" href="">{{ item.namePro }} - {{ item.color }} - {{ item.size }}</a>
                                    <span class="pro-price-view">{{ item.price.toLocaleString('en-US', {minimumFractionDigits: 0}) }} ₫<i> x {{ item.qty }}</i></span>
                                    <!-- <span class="pro-quantity-view">1</span> -->
                                    <span class="remove_link remove-cart removePro">
                                         <a href="" class="cart_remove" @click.prevent="removeProduct(item.id,item.size,item.color)">Xóa</a>
                                    </span>
                                </td>
                            </tr>
                           
                            <tr v-show="this.productAddtoCarts.length == 0">
                                <td>Hiện chưa có sản phẩm</td>
                            </tr>
                        </tbody>
                    </table>
                    <span class="line"></span>
                    <table class="table-total">
                        <tbody>
                            <tr>
                                <td class="text-left">
                                    <b>TỔNG TIỀN TẠM TÍNH:</b>
                                </td>
                                <td class="text-right" id="total-view-cart">{{ totalPrice.toLocaleString('en-US', {minimumFractionDigits: 0}) }}₫</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <a href="#" class="checkLimitCart linktocheckout button dark">Tiến hành đặt hàng</a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <a href="/cart" class="linktocart button dark">Xem chi tiết giỏ hàng 
                                        <i class="fa-sharp fa-solid fa-arrow-right"></i>
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <button aria-label="close" id="site-close-handle" class="site-close-handle" title="Đóng" @click="onClose">
            <img width="20" height="20" src="../assets/img/iconclose.png" alt="Đóng">
        </button>
       
    </div>
    <div id="site-overlay" class="site-overlay" :class="{active : isAddToCart}"></div>
</template>
<script>
import { store } from '@/store';
export default {
    name: "addToCart",
    computed: {
        totalPrice() {
            return this.$store.getters.getTotalPrice
        },
        totalProduct(){
            return this.$store.getters.getTotalProduct
        },
        productAddtoCarts(){
            return this.$store.state.product
        }
    },
    props:{
        isAddToCart:{
            type: Boolean,
            default: false
        },
        
    },
    methods:{
        onClose(){
            this.$emit("onCloseModal")
        },
        
        removeProduct(id,size,color){
           console.log(size);
            if(confirm("Bạn có muốn xóa sản phẩm trong giỏ hàng hay không?")){
                store.commit("handleRemoveProductToCart",{id,size,color})
            }
        },
        clickOutSide(event){
            if(event.target.closest(`.clickOutside`)) return
            store.commit("handleOpenAddtoCart");
        }
        
    }
}
</script>
<style scoped>
.site-nav.style--sidebar.active {
    -ms-transform: translateX(0);
    -webkit-transform: translateX(0);
    transform: translateX(0);
}
.site-close-handle {
    position: absolute;
    top: 55px;
    right: 18px;
    width: 35px;
    height: 35px;
    z-index: 999;
    background: transparent;
    border: none;
    box-shadow: none;
    cursor: pointer;
    -ms-transition: transform 150ms linear;
    -webkit-transition: transform 150ms linear;
    transition: transform 150ms linear;
}
.site-close-handle:hover {
    -ms-transform: scale(1.1);
    -webkit-transform: scale(1.1);
    transform: scale(1.1);
}
button, input, select, textarea {
    font-family: inherit;
    font-size: inherit;
    line-height: inherit;
}
button, html input[type=button], input[type=reset], input[type=submit] {
    /* -webkit-appearance: button; */
    cursor: pointer;
}
button, select {
    text-transform: none;
}
button {
    overflow: visible;
}
button, input, optgroup, select, textarea {
    margin: 0;
    font: inherit;
    color: inherit;
}
.site-close-handle img {
    width: 20px;
}

img {
    max-width: 100%;
}
img {
    max-width: 100%;
    width: 100%;
    height: auto;
}
img {
    vertical-align: middle;
}
img {
    border: 0;
}
.site-nav.style--sidebar {
    position: fixed;
    width: 480px;
    height: 100vh;
    right: 0;
    top: 0;
    background: #fff;
    z-index: 8888;
    overflow: hidden;
    -ms-transition: transform 500ms cubic-bezier(0.25, 0.46, 0.45, 0.94);
    -webkit-transition: transform 500ms cubic-bezier(0.25, 0.46, 0.45, 0.94);
    transition: transform 500ms cubic-bezier(0.25, 0.46, 0.45, 0.94);
    -ms-transform: translateX(100%);
    -webkit-transform: translateX(100%);
    transform: translateX(100%);
}
#site-nav--mobile.show-cart #site-cart {
    display: block;
}
.site-nav.style--sidebar .site-nav-container {
    width: calc(100% + 20px);
    height: 100%;
    overflow-y: scroll;
    -webkit-overflow-scrolling: touch;
}
.site-nav.style--sidebar.show-filters .site-nav-container-last, .site-nav.style--sidebar.show-cart .site-nav-container-last, .site-nav.style--sidebar.show-search .site-nav-container-last {
    padding-bottom: 100px;
}
.site-nav.style--sidebar .site-nav-container-last {
    width: calc(100% - 0px);
    position: relative;
    overflow: hidden;
    min-height: 100%;
    padding: 60px 20px 250px;
}
button, input, select, textarea {
    font-family: inherit;
    font-size: inherit;
    line-height: inherit;
}

input {
    line-height: normal;
}
button, input, optgroup, select, textarea {
    margin: 0;
    font: inherit;
    color: inherit;
}
.site-nav.style--sidebar .site-nav-container .title {
    font-size: 14px;
    text-transform: uppercase;
    margin: 3px 0 0 0;
    font-weight: 500;
}

p {
    margin: 0 0 10px 0;
    line-height: 21px;
}
.textCartSide {
    float: left;
    width: 100%;
    margin: 5px 0 0 0;
    border-bottom: 1px dotted #bcbcbc;
    padding: 0 0 15px 0;
    font-size: 14px;
}
b, strong {
    font-weight: 700;
    font-size: 14px;
    color: #000;
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
.cart-view table {
    width: 100%;
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
#cart-view tr:last-child {
    border: none;
}

table#cart-view tr {
    border-bottom: 1px dotted #bcbcbc;
}
table#cart-view tr td.img {
    position: relative;
}

table#cart-view tr td {
    border: none;
}
table#cart-view tr td {
    border-top: 0;
}
#cart-view tr td, .table-total tr td {
    border: none !important;
}
table tr td:first-child, table tr th:first-child {
    padding-left: 0;
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
.cart-view table td.img img {
    width: 100px;
    border: 1px solid #ededed;
    margin-right: 10px;
    max-width: none;
}

img.lazyloaded {
    opacity: 1;
    transition: 0.3s;
}
img {
    max-width: 100%;
}
img {
    max-width: 100%;
    width: 100%;
    height: auto;
}
img {
    vertical-align: middle;
}
#cart-view tr td:not(.img) {
    padding: 20px 20px 20px 0;
    position: relative;
    font-size: 14px;
}

table#cart-view tr td {
    border: none;
}
table#cart-view tr td {
    border-top: 0;
}
#cart-view tr td, .table-total tr td {
    border: none !important;
}
table tr td:last-child, table tr th:last-child {
    padding-right: 0;
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
.cart-view table td a.pro-title-view {
    float: left;
    width: 100%;
    font-size: 14px;
    /* font-weight: 600; */
}

a {
    transition: opacity 150ms linear, color 150ms linear, background 150ms linear;
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
    color: #337ab7;
    text-decoration: none;
}
a {
    background-color: transparent;
}
a{
    color: #252a2b;
    text-decoration: none;
    outline: none;
    transition: all 0.2s ease-in-out;
}
span.pro-price-view {
    display: block;
    text-align: center;
    float: left;
    line-height: 26px;
    font-size: 14px;
    font-weight: 600;
}
span.pro-quantity-view {
    display: none;
    float: left;
    width: auto;
    background: #ededed;
    text-align: center;
    padding: 6px 12px;
    font-size: 12px;
    line-height: 1;
    margin-right: 12px;
}

span.pro-quantity-view {
    position: relative;
    vertical-align: top;
    padding-right: 15px;
    display: inline-block;
    margin-right: 10px;
}
.remove-cart {
    float: left;
    width: 100%;
}
.remove-cart a {
    border: 1px solid #ededed;
    padding: 5px;
    display: inline-block;
    font-size: 12px;
}
.cart-view .line {
    float: left;
    width: 100%;
    border-top: 2px solid #000000;
    margin: 10px 0;
}
table tr td:first-child, table tr th:first-child {
    padding-left: 0;
}
table tr td:last-child, table tr th:last-child {
    padding-right: 0;
}
#cart-view tr td, .table-total tr td {
    border: none !important;
}

.text-left {
    text-align: left;
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
.text-right {
    text-align: right;
}
#total-view-cart {
    font-weight: bold;
    font-size: 14px;
    color: #000;
}
.cart-view a.linktocheckout {
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
    font-size: 14px;
}
.button.dark {
    color: #fff;
    border-color: #000000;
}
.cart-view a.linktocart {
    padding: 0;
    position: relative;
    width: 100%;
    white-space: nowrap;
    color: black;
    text-align: center;
    float: left;
    font-size: 14px;
}
.site-overlay.active {
    opacity: 1;
    visibility: visible;
}

.site-overlay {
    background:rgb(0 0 0 / 50%);
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    z-index: 7777;
    opacity: 0;
    visibility: hidden;
    transition: all 200ms linear;
}
</style>