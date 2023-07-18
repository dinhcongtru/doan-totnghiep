<template>
    <div class="content">
        <div class="container">
            <form id="formCheckOut" @submit.prevent="getValueForm">
                <div class="sidebar">
                    <div class="sidebar-content">
                        <div class="order-summary order-summary-is-collapsed">
                            <h2 class="visually-hidden tp_title">Thông tin đơn hàng</h2>
                            <div class="order-summary-sections">
                                <div class="order-summary-section order-summary-section-product-list">
                                    <table class="product-table">
                                        <thead>
                                            <tr>
                                                <th><span class="visually-hidden">Hình ảnh</span></th>
                                                <th><span class="visually-hidden">Mô tả</span></th>
                                                <th><span class="visually-hidden">Số lượng</span></th>
                                                <th><span class="visually-hidden">Giá</span></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="product" v-for="(item,index) in productAddtoCarts" :key="index">
                                                <td class="product-image">
                                                    <div class="product-thumbnail">
                                                        <div class="product-thumbnail-wrapper">
                                                            <img :src="require('@/assets/img/' + item.img)" class="product-thumbnail-image" alt="">
                                                        </div>
                                                        <span class="product-thumbnail-quantity" aria-hidden="true">{{ item.qty }}</span>
                                                    </div>
                                                </td>
                                                <td class="product-description">
                                                    <span class="product-description-name order-summary-emphasis tp_product_name">{{ item.namePro }} - {{ item.color }} - {{ item.size }}</span>
                                                </td>
                                                <td class="product-quantity visually-hidden">{{ item.qty }}</td>
                                                <td class="product-price">
                                                    <span class="order-summary-emphasis">
                                                        <span class="tp_product_price">{{ item.price.toLocaleString('en-US', {minimumFractionDigits: 0}) }} ₫</span>
                                                    </span>
                                                </td>
                                            </tr>
                                            
                                           
                                        </tbody>
                                    </table>
                                </div>
                                <div class="order-summary-section order-summary-section-discount">
                                    <div id="form_discount_add">
                                        <div class="fieldset">
                                            <div class="field">
                                                <div id="txtCode" style="padding: 0 0 5px 0"></div>
                                                <div class="field-input-btn-wrapper">
                                                    <div class="field-input-wrapper">
                                                        <label class="field-label">Mã giảm giá</label>
                                                        <input placeholder="Mã giảm giá" v-model="couponCode" class="field-input" id="discount_code">
                                                    </div>
                                                    <button type="button" id="getCoupon" class="field-input-btn btn btn-default btn-disabled tp_button">
                                                        <span class="btn-content">Sử dụng</span>
                                                        <i class="btn-spinner icon icon-button-spinner"></i>
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="order-summary-section order-summary-section-total-lines">
                                    <table class="total-line-table">
                                        <thead>
                                            <tr>
                                                <th scope="col"><span class="visually-hidden">Mô tả</span></th>
                                                <th scope="col"><span class="visually-hidden">GiáGiá</span></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="total-line total-line-shipping shipFeeCheckHost">
                                                <td class="total-line-name">Phí vận chuyển</td>
                                                <td class="total-line-price">
                                                    <span class="order-summary-emphasis" value="0" id="shipFee">—</span>
                                                    <span id="showCarrier"></span>
                                                    
                                                </td>
                                            </tr>
                                        </tbody>
                                        <tfoot class="total-line-table-footer">
                                            <tr class="total-line" id="orderDiscount" style="display:none;">
                                                <td class="total-line-name payment-due-label">
                                                    <span class="payment-due-label-total">Giảm giá</span>
                                                </td>
                                                <td class="total-line-name payment-due">
                                                    <span class="payment-due-currency">VND</span>
                                                    <span id="totalDiscount" value="0" data-value="0"></span>
                                                </td>
                                            </tr>
                                            <tr class="total-line">
                                                <td class="total-line-name payment-due-label">
                                                    <span class="payment-due-label-total">Tổng cộng</span>
                                                </td>
                                                <td class="total-line-name payment-due">
                                                    <span class="payment-due-currency">VND</span>
                                                    <span class="payment-due-price" id="showTotalMoney">{{ totalPrice.toLocaleString('en-US', {minimumFractionDigits: 0}) }}₫</span>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                            <h3 class="notice-checkout" style="font-weight: 400; padding: 10px; border: 1px solid #f77705; line-height: 18px; margin: 0;">
                                <p>Krik sẽ xác nhận đơn hàng bằng cách gọi điện thoại. Bạn vui lòng để ý điện thoại khi đặt hàng thành công và chờ nhận hàng. Cảm ơn bạn !</p>
                            </h3>
                        </div>
                    </div>
                    <div class="sidebar-footer">
                        <button class="step-footer-continue-btn btn checkout-accept">
                            <span class="btn-content">Hoàn tất đơn hàng</span>
                            <i class="btn-spinner icon icon-button-spinner"></i>
                        </button>
                    </div>
                </div>
                <div class="main">
                    <div class="main-header">
                        <div>
                            <ul class="breadcrumb">
                                <li class="breadcrumb-item">
                                    <a href="/cart">Giỏ hàng</a>
                                </li>
                                <li class="breadcrumb-item">Thông tin giao hàng</li>
                            </ul>
                        </div>
                    </div>
                    <div class="main-content">
                        <div class="step">
                            <div class="step-sections steps-onepage">
                                <div class="section">
                                    <div class="section-header">
                                        <h2 class="section-title tp_title">Thông tin giao hàng</h2>
                                    </div>
                                    <div class="section-content section-customer-information no-mb">
                                        <p class="section-content-text">
                                            Bạn đã có tài khoản?
                                            <a href="/user/signin">Đăng nhập</a>
                                        </p>
                                        <div class="fieldset">
                                            <div class="field">
                                                <div class="field-input-wrapper">
                                                    <label class="field-label" for="billing_address_full_name">Họ và tên</label>
                                                    <input placeholder="Họ và tên" type="text" class="field-input" v-model="name">
                                                </div>
                                            </div>
                                            <div class="field  field-two-thirds">
                                                <div class="field-input-wrapper">
                                                    <label class="field-label" for="checkout_user_email">Email</label>
                                                    <input placeholder="Email"  type="text" class="field-input " v-model="email">
                                                </div>
                                            </div>
                                            <div class="field field-required field-third">
                                                <div class="field-input-wrapper">
                                                    <label class="field-label" for="billing_address_phone">Số điện thoại</label>
                                                    <input placeholder="Số điện thoại" type="text" class="field-input customerPointCheck" v-model="phoneNumber">
                                                </div>
                                            </div>
                                            <div class="field">
                                                <div class="field-input-wrapper">
                                                    <label class="field-label" for="billing_address_address1">Địa chỉ</label>
                                                    <input placeholder="Địa chỉ"  type="text" class="field-input" v-model="address">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="section-content">
                                        <div class="fieldset">
                                            <div id="form_update_location" class="clearfix">
                                                <div class="field field-show-floating-label  field-half ">
                                                    <DxSelectBox
                                                        v-model="city"
                                                        placeholder=""
                                                        :acceptCustomValue="true"
                                                        :value="dataChooseCity[0]"
                                                        label="Tỉnh/ Thành phố"
                                                        :searchEnabled=true
                                                        :items="simpleProducts"
                                                        :dataSource= "dataChooseCity"
                                                        :input-attr="{ 'aria-label': 'Simple Product' }"
                                                    />
                                                </div>
                                                <div class="field field-show-floating-label  field-half ">
                                                    <DxSelectBox
                                                        v-model="quan"
                                                        placeholder=""
                                                        :acceptCustomValue="true"
                                                        :value="dataChooseQuan[0]"
                                                        label="Quận/ Huyện"
                                                        :searchEnabled=true
                                                        :items="simpleProducts"
                                                        :dataSource= "dataChooseQuan"
                                                        :input-attr="{ 'aria-label': 'Simple Product' }"
                                                    />
                                                </div>
                                                <div class="field field-show-floating-label  field-half ">
                                                    <DxSelectBox
                                                        v-model="phuong"
                                                        placeholder=""
                                                        :acceptCustomValue="true"
                                                        :value="dataChoosePhuong[0]"
                                                        label="Phường/ Xã"
                                                        :searchEnabled=true
                                                        :items="simpleProducts"
                                                        :dataSource= "dataChoosePhuong"
                                                        :input-attr="{ 'aria-label': 'Simple Product' }"
                                                    />
                                                </div>
                                            </div>
                                            <div class="field description-order">
                                                <div class="field-input-wrapper">
                                                    <div class="descriptionCustomer">
                                                        <textarea class="input" v-model="note" placeholder="Ghi chú" rows="3" style="width: 100%;padding: 5px;box-shadow: 0 0 0 1px #d9d9d9;border-radius: 4px;transition: all .2s ease-out;"></textarea>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- phương thức thanh toán -->
                                    <section class="section">
                                        <div class="section__header">
                                            <div class="layout-flex">
                                                <h2 class="section__title layout-flex__item layout-flex__item--stretch">
                                                    <i class="fa fa-credit-card fa-lg section__title--icon hide-on-desktop"></i>
                                                    Thanh toán
                                                </h2>
                                            </div>
                                        </div>
                                        <div class="section__content">
                                            <div class="content-box">
                                                <div class="content-box__row" @click="onOpenDesMethod(item)" v-for="(item,index) in methodPayments" :key="index">
                                                    <div class="radio-wrapper">
                                                        <div class="radio__input">
                                                            <input name="paymentMethod" id="paymentMethod-516910" type="radio" class="input-radio" value="516910">
                                                        </div>
                                                        <label for="paymentMethod-516910" class="radio__label">
                                                            <span class="radio__label__primary">{{ item.description }}</span>
                                                            <span class="radio__label__accessory">
                                                                <span class="radio__label__icon">
                                                                    <i class="payment-icon" :class="item.img"></i>
                                                                </span>
                                                            </span>
                                                        </label>
                                                    </div>
                                                    <div class="content-box__row__desc" v-show="item.selected && item.choose">
                                                        <p>Bạn chỉ phải thanh toán khi nhận được hàng</p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>
<script>
import DxSelectBox from 'devextreme-vue/select-box';
import{ dataChooseCity, dataChoosePhuong, dataChooseQuan} from '@/resource/TestData'
export default {
    name: "CheckOut",
    components:{DxSelectBox},
    computed:{
        productAddtoCarts() {
            return this.$store.state.product;
        },
        totalPrice(){
            return this.$store.getters.getTotalPrice;
        }
    },
    data(){
        return{
            couponCode:"",
            name:"",
            email:"",
            phoneNumber:"",
            address:"",
            note:"",
            phuong:"",
            quan:"",
            city:"",
            dataChooseCity : dataChooseCity,
            dataChoosePhuong: dataChoosePhuong,
            dataChooseQuan :dataChooseQuan, 
            inFoCustomer :{},
            methodPayments : [
                {
                    description : "Thanh toán qua thẻ thanh toán, ứng dụng ngân hàng VNPAY",
                    img:"payment-icon--16",
                    selected :false,
                    choose : false,
                },
                {
                    description : "Thanh toán qua mã QR - VNPAY",
                    img:"payment-icon--19",
                    selected :false,
                    choose : false,
                },
                {
                    description : "Thanh toán qua Ví MoMo",
                    img:"payment-icon--21",
                    selected :false,
                    choose : false,
                },
                {
                    description : "Thanh toán khi nhận hàng (COD)",
                    img:"payment-icon--4",
                    selected :false,
                    choose : true,
                },
            ]
        }
    },
    methods:{
        onOpenDesMethod(item){
            this.methodPayments.forEach(item => item.selected = false);
            item.selected = !item.selected;
        },
        getValueForm(){
            this.inFoCustomer = {
                name : this.name,
                email :this.email,
                phone : this.phoneNumber,
                address : this.address,
                note : this.note,
                couponCode : this.couponCode,
                phuong : this.phuong,
                quan : this.quan,
                city : this.city

            }
            console.log(this.inFoCustomer);
        }
    },
    created(){
        document.title = "Thanh Toán"
    }
}
</script>
<style scoped>
*,body{
    font-size: 14px;
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

   .content {
         overflow-x: hidden;
    }
    @media (min-width: 768px){
        .container {
            width: 750px;
        }
    }
    @media (min-width: 992px){
        .container {
            width: 970px;
        }
    }
    .container {
    padding-right: 15px;
    padding-left: 15px;
    margin-right: auto;
    margin-left: auto;
    }
    @media (min-width: 1000px){
        .main, .sidebar {
            padding-top: 4em;
        }
    }
    @media (min-width: 1000px){
        .sidebar {
            width: 38%;
            padding-left: 4%;
            background-position: left top;
            float: right;
        }
    }
    .sidebar {
        position: relative;
        color: #717171;
    }
    .sidebar h2 {
    color: #323232;
}

.visually-hidden {
    border: 0;
    clip: rect(0, 0, 0, 0);
    clip: rect(0 0 0 0);
    width: 2px;
    height: 2px;
    margin: -2px;
    overflow: hidden;
    padding: 0;
    position: absolute;
}
h2 {
    font-size: 1.28571em;
    line-height: 1em;
    font-weight: normal;
}
.sidebar .sidebar-content .order-summary .order-summary-sections .order-summary-section {
    border-top: 1px solid;
    padding-top: 1.5em;
    padding-bottom: 1.5em;
    border-color: #e1e1e1;
}
@media (min-width: 1000px){
.sidebar .sidebar-content .order-summary .order-summary-sections .order-summary-section:first-child {
    padding-top: 0;
}
}
.sidebar .sidebar-content .order-summary .order-summary-sections .order-summary-section:first-child {
    border-top: none;
}

table {
    width: 100%;
    border-collapse: collapse;
    border-spacing: 0;
    font-size: 1em;
}

table {
    background-color: transparent;
}
td, th {
    padding: 0;
    padding-left: 1em;
}
td:first-child, th:first-child {
    padding-left: 0;
    text-align: left;
}
.visually-hidden {
    border: 0;
    clip: rect(0, 0, 0, 0);
    clip: rect(0 0 0 0);
    width: 2px;
    height: 2px;
    margin: -2px;
    overflow: hidden;
    padding: 0;
    position: absolute;
}
th {
    text-align: left;
}
td:last-child, th:last-child {
    text-align: right;
}
td, th {
    padding: 0;
    padding-left: 1em;
}
td:first-child, th:first-child {
    padding-left: 0;
    text-align: left;
}
.sidebar .sidebar-content .order-summary .product:first-child td {
    padding-top: 0;
}
.sidebar .sidebar-content .order-summary .product .product-image .product-thumbnail {
    width: 5.6em;
    height: 5.6em;
    border-radius: 8px;
    background: #fff;
    position: relative;
}
.sidebar .sidebar-content .order-summary .product .product-image .product-thumbnail .product-thumbnail-wrapper {
    width: 100%;
    height: 100%;
    position: relative;
    overflow: hidden;
    border-radius: 8px;
}
img {
    border: 0;
    max-width: 100%;
}

img {
    vertical-align: middle;
}
.sidebar .sidebar-content .order-summary .product .product-image .product-thumbnail .product-thumbnail-wrapper .product-thumbnail-image {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    max-width: 100%;
    max-height: 100%;
    margin: auto;
}
.sidebar .sidebar-content .order-summary .product .product-image .product-thumbnail .product-thumbnail-quantity {
    font-size: 0.85714em;
    font-weight: 500;
    white-space: nowrap;
    padding: 0.15em 0.65em;
    border-radius: 2em;
    background-color: rgba(153,153,153,0.9);
    color: #fff;
    position: absolute;
    right: -0.75em;
    top: -0.75em;
    z-index: 2;
    font-family: "Quicksand-Bold";
}
.sidebar .sidebar-content .order-summary .product .product-image .product-thumbnail::after {
    content: '';
    display: block;
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    border-radius: 8px;
    box-shadow: 0 0 0 1px rgba(0,0,0,0.1) inset;
}
.sidebar .sidebar-content .order-summary .product:first-child td {
    padding-top: 0;
}

.sidebar .sidebar-content .order-summary .product .product-description {
    width: 100%;
}
.sidebar .sidebar-content .order-summary .product .product-description .product-description-name, .sidebar .sidebar-content .order-summary .product .product-description .product-description-variant, .sidebar .sidebar-content .order-summary .product .product-description .product-description-property {
    display: block;
}
.sidebar .sidebar-content .order-summary .order-summary-emphasis {
    font-weight: 600;
    color: #4b4b4b;
    font-size: 14px;
}
.sidebar .sidebar-content .order-summary .product:first-child td {
    padding-top: 0;
}
.sidebar .sidebar-content .order-summary .product:first-child td {
    padding-top: 0;
}

.sidebar .sidebar-content .order-summary .product .product-price {
    white-space: nowrap;
}
.sidebar .sidebar-content .order-summary .order-summary-emphasis {
    font-weight: 600;
    color: #4b4b4b;
}
.sidebar .sidebar-content .order-summary .order-summary-sections .order-summary-section {
    border-top: 1px solid;
    padding-top: 1.5em;
    padding-bottom: 1.5em;
    border-color: #e1e1e1;
}
.fieldset {
    margin: -0.45em;
    zoom: 1;
}
.fieldset:after, .fieldset:before {
    content: "";
    display: table;
}
.fieldset .field {
    width: 100%;
    float: left;
    padding: 0.45em;
    box-sizing: border-box;
}
.fieldset .field .field-input-btn-wrapper {
    display: -webkit-flex;
    display: -ms-flexbox;
    display: flex;
}
.fieldset .field .field-input-btn-wrapper .field-input-wrapper {
    -webkit-flex-grow: 1;
    -ms-flex-positive: 1;
    flex-grow: 1;
}

.fieldset .field .field-input-wrapper {
    position: relative;
}
label {
    display: inline-block;
    max-width: 100%;
    margin-bottom: 5px;
    /* font-weight: 700; */
}
.fieldset .field .field-input-wrapper .field-label {
    font-size: 0.85714em;
    font-weight: normal;
    position: absolute;
    top: 0;
    width: 100%;
    padding: 0 0.93333em;
    z-index: 1;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    -webkit-transform: translateY(3px);
    transform: translateY(3px);
    pointer-events: none;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
    box-sizing: border-box;
    opacity: 0;
    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=" 0 ")";
    filter: alpha(opacity=0);
    color: #999999;
    transition: all 0.2s ease-out;
    margin: 0.5em 0;
    margin-top: 0.3em;
    display: block;
}
button, input, optgroup, select, textarea {
    color: inherit;
    font: inherit;
    margin: 0;
    padding: 0;
    /* -webkit-appearance: none; */
    -webkit-font-smoothing: inherit;
    border: none;
    background: transparent;
    line-height: normal;
}
.fieldset .field .field-input-wrapper .field-input {
    box-shadow: 0 0 0 1px #d9d9d9;
    transition: all 0.2s ease-out;
    background-color: white;
    color: #333333;
    border-radius: 4px;
    display: block;
    box-sizing: border-box;
    width: 100%;
    padding: 0.94em 2.8em 0.94em 0.8em;
    word-break: normal;
}
button, select {
    text-transform: none;
}

button {
    overflow: visible;
}
button, input, optgroup, select, textarea {
    color: inherit;
    font: inherit;
    margin: 0;
    padding: 0;
    /* -webkit-appearance: none; */
    -webkit-font-smoothing: inherit;
    border: none;
    background: transparent;
    line-height: normal;
}
button, input[type="button"], input[type="reset"], input[type="submit"] {
    /* -webkit-appearance: button; */
    cursor: pointer;
}
.btn {
    display: inline-block;
    padding: 6px 12px;
    margin-bottom: 0;
    font-size: 14px;
    font-weight: 400;
    line-height: 1.42857143;
    text-align: center;
    white-space: nowrap;
    vertical-align: middle;
    -ms-touch-action: manipulation;
    touch-action: manipulation;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    background-image: none;
    border: 1px solid transparent;
    border-radius: 4px;
}
.btn-default {
    color: #333;
    background-color: #fff;
    border-color: #ccc;
}
.btn {
    display: inline-block;
    border-radius: 4px;
    font-weight: 500;
    padding: 1.4em 1.7em;
    box-sizing: border-box;
    text-align: center;
    cursor: pointer;
    transition: background-color 0.2s ease-in-out, color 0.2s ease-in-out;
    position: relative;
    background: #338dbc;
    color: white;
}
.btn, .btn:hover {
    background: #000;
}
.sidebar .btn-disabled {
    cursor: pointer;
    background: #338dbc;
    box-shadow: none;
}
.fieldset .field .field-input-btn-wrapper .field-input-btn {
    width: auto;
    margin-left: 0.9em;
    white-space: nowrap;
    padding-top: 0;
    padding-bottom: 0;
}
.btn-spinner {
    position: absolute;
    top: 50%;
    left: 50%;
    margin-top: -10px;
    margin-left: -10px;
    /* transition: opacity 0.3s ease-in-out; */
    opacity: 0;
    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=" 0 ")";
    filter: alpha(opacity=0);
}
.fieldset:after {
    clear: both;
}

.fieldset:after, .fieldset:before {
    content: "";
    display: table;
}
.sidebar .sidebar-content .order-summary .order-summary-sections .order-summary-section {
    border-top: 1px solid;
    padding-top: 1.5em;
    padding-bottom: 1.5em;
    border-color: #e1e1e1;
}
table {
    width: 100%;
    border-collapse: collapse;
    border-spacing: 0;
    font-size: 1em;
}

table {
    background-color: transparent;
}
.total-line td {
    padding-top: 0.75em;
    color: #717171;
    font-weight: 600;
}
.sidebar .sidebar-content .order-summary .order-summary-emphasis {
    font-weight: 600;
    color: #4b4b4b;
}
#showCarrier {
    display: block;
    text-align: right;
    width: 100%;
    font-size: 11px;
}
.total-line-table-footer {
    white-space: nowrap;
}
.total-line-table-footer .total-line td {
    padding-top: 3em;
    position: relative;
}
.payment-due-label .payment-due-label-total {
    font-size: 1.14286em;
    color: #4b4b4b;
}
.payment-due .payment-due-currency {
    font-size: 0.85714em;
    vertical-align: 0.2em;
    margin-right: 0.5em;
    color: #969696;
}
.total-line-table-footer .total-line td::before {
    background-color: #e1e1e1;
    content: '';
    position: absolute;
    top: 1.5em;
    left: 0;
    width: 100%;
    height: 1px;
}
.payment-due .payment-due-currency {
    font-size: 0.85714em;
    vertical-align: 0.2em;
    margin-right: 0.5em;
    color: #969696;
}
.payment-due .payment-due-price {
    font-size: 1.71429em;
    font-weight: 600;
    letter-spacing: -0.04em;
    color: #4b4b4b;
    line-height: 1em;
}
h3{
    font-size: 1em;
    font-family: inherit;
    color: inherit;
}
p {
    margin: 0;
    line-height: 1.5em;
}
.sidebar-footer {
    text-align: right;
    margin: 20px 0;
}
.checkout-accept {
    padding: 1.1em;
    font-weight: 600;
    font-size: 1.1em;
    z-index: 9;
    background: #338dbc;
}
.sidebar:after {
    content: "";
    display: block;
    width: 300%;
    position: absolute;
    top: 0;
    left: -100%;
    bottom: 0;
    background: #fafafa;
    z-index: -1;
    box-shadow: 0 -1px 0 #e1e1e1 inset;
}
@media (min-width: 1000px){
.sidebar:after {
    left: 0;
    background-position: left top;
    box-shadow: 1px 0 0 #e1e1e1 inset;
}
}
#showCarrier {
    display: block;
    text-align: right;
    width: 100%;
    font-size: 11px;
}

.changeOrtherShipFee:hover {
    color: darkred;
    text-decoration: underline;
}
.btn-content{
    color: white;
    font-size: 14px;
    font-weight: 600;
}
.btn:hover {
    background: #286f94;
    color: white;
}


  /* thông tin giao hàng */

  @media (min-width: 1000px){
    .main {
        width: 52%;
        width: 52%;
        padding-right: 6%;
        float: left;
    }
  }
  @media (min-width: 750px){
    .main {
        padding-top: 1.5em;
    }
}
@media (min-width: 1000px){
    .main, .sidebar {
        padding-top: 4em;
    }
}

@media (min-width: 1000px){
    .main .main-header {
        padding-bottom: 2em;
        max-height: 46px;
    }
}
ol, ul {
    margin-top: 0;
    margin-bottom: 10px;
}

ul {
    margin: 0;
    padding: 0;
    list-style-type: none;
}
.breadcrumb {
    padding: 8px 15px;
    margin-bottom: 20px;
    list-style: none;
    background-color: #f5f5f5;
    border-radius: 4px;
}
.main .main-header .breadcrumb {
    background: transparent;
    padding: 8px 0;
}
@media (min-width: 1000px){
    .main .main-header .breadcrumb {
        margin-top: 1em;
    }
}
.main .main-header .breadcrumb .breadcrumb-item {
    display: inline-block;
    font-size: 0.85714em;
    color: #999999;
}
a {
    text-decoration: none;
    color: #338dbc;
    transition: color 0.2s ease-in-out;
    display: inline-block;
    font-family: Helvetica Neue, sans-serif;
}
.main .main-header .breadcrumb .breadcrumb-item:first-child:after, .main-header-custom .breadcrumb .breadcrumb-item:first-child:after {
    content: "";
    display: inline-block;
    width: 6px;
    height: 11px;
    vertical-align: middle;
    margin: 0 0.5em;
    background-image: url('data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI2IiBoZWlnaHQ9IjExIiBvcGFjaXR5PSIuNCIgZmlsbD0iIzAwMCI+PHBhdGggZD0iTS41MjYgMS40MDhsNCA0LjY0NS4wMTQtLjgzLTQgNC4zNTQuOTIuODQ2IDQtNC4zNTYuMzc2LS40MS0uMzYyLS40Mi00LTQuNjQ1LS45NDguODE2eiIvPjwvc3ZnPg=='),none;background-image: url('data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI2IiBoZWlnaHQ9IjExIiBvcGFjaXR5PSIuNCIgZmlsbD0iIzAwMCI+PHBhdGggZD0iTS41MjYgMS40MDhsNCA0LjY0NS4wMTQtLjgzLTQgNC4zNTQuOTIuODQ2IDQtNC4zNTYuMzc2LS40MS0uMzYyLS40Mi00LTQuNjQ1LS45NDguODE2eiIvPjwvc3ZnPg=='),none;
}
.main .main-header .breadcrumb .breadcrumb-item {
    display: inline-block;
    font-size: 0.85714em;
    color: #999999;
}
@media (min-width: 750px){
.main .main-content {
    padding-bottom: 4em;
}
}
.section {
    position: relative;
    /* padding-top: 2em; */
}
/* @media (min-width: 750px){
.section {
    padding-top: 3em;
}
} */
.section:first-child {
    padding-top: 0;
}
@media (min-width: 750px){
.section .section-header {
    margin-bottom: 1.5em;
}
}
.section .section-header {
    position: relative;
}
.h1, .h2, .h3, .h4, .h5, .h6, h1, h2, h3, h4, h5, h6 {
    font-family: inherit;
    font-weight: 500;
    line-height: 1.1;
    color: inherit;
}
.h1, .h2, .h3, h1, h2, h3 {
    margin-top: 20px;
    margin-bottom: 10px;
}
.h2, h2 {
    font-size: 30px;
}
h1, h2, h3, h4, h5, h6 {
    font-weight: normal;
    margin: 0;
    line-height: 1em;
}
h2 {
    font-size: 1.28571em;
}
.main h2 {
    color: #333333;
}
.section .section-title {
    color: #333333;
    font-weight: 600;
}
.section .section-content {
    zoom: 1;
    margin-bottom: 2em;
}
.section .section-content.no-mb, .section .section-content:last-child {
    margin-bottom: inherit;
}
.section .section-content:after, .section .section-content:before {
    content: "";
    display: table;
}
p {
    margin: 0 0 10px;
}
p {
    margin: 0;
    line-height: 1.5em;
}
.section .section-content .section-content-text {
    margin-bottom: 0.75em;
}
.fieldset .field .field-input-wrapper {
    position: relative;
}
@media (min-width: 750px){
.field-two-thirds {
    width: 66.66667% !important;
}
}
@media (min-width: 750px){
.field-third {
    width: 33.33333% !important;
}
}
.fieldset:after {
    clear: both;
}

.fieldset:after, .fieldset:before {
    content: "";
    display: table;
}
.section .section-content:after, .section .section-content:before {
    content: "";
    display: table;
}
@media (min-width: 750px){
.field-half {
    width: 50% !important;
}
}
@media (min-width: 1200px){
.container {
    width: 1180px;
    display: flow-root;
}
}
ul li:nth-child(2){
    cursor: default;
}
.sidebar .sidebar-content .order-summary .product td {
    padding-top: 1em;
}

/* Method payment  */

.section__header {
    margin-bottom: 12px;
}
.layout-flex {
    display: flex;
    align-items: baseline;
}
.layout-flex__item--stretch {
    flex: 1 1 auto;
}
.section__title{
    color: #000000;
    font-weight: 600;
    /* font-size: 1.15rem; */
    margin: 0;
}
.fa {
    display: inline-block;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    transform: translate(0,0);
}
.fa-lg {
    font-size: 1.33333333em;
    line-height: .75em;
    vertical-align: -15%;
}
.section__title--icon {
    margin: 0 3px;
    vertical-align: top;
}
@media (min-width: 1000px){
    .hide-on-desktop {
        display: none !important;
    }
}
.content-box {
    border: 1px solid #cecdcd;
    background: #fff;
    background-clip: padding-box;
    border-radius: 5px;
    color: #545454;
}
.content-box__row {
    display: table;
    box-sizing: border-box;
    width: 100%;
    position: relative;
    padding: 1em;
}

.radio-wrapper:last-child {
    margin-bottom: 0;
}

.radio-wrapper {
    display: table;
    box-sizing: border-box;
    width: 100%;
}
.radio-wrapper:after, .radio-wrapper:before, .checkbox-wrapper:after, .checkbox-wrapper:before {
    content: "";
    display: table;
}
.radio__input, .checkbox__input {
    display: table-cell;
}

.radio__input, .checkbox__input {
    white-space: nowrap;
    padding-right: 0.75em;
}
.field__input, .input-checkbox, .input-radio, button, textarea {
    color: inherit;
    font: inherit;
    margin: 0;
    padding: 0;
    appearance: auto;
    -webkit-appearance: none;
    -moz-appearance: none;
    -webkit-font-smoothing: inherit;
    border: none;
    background: transparent;
    line-height: normal;
}
.input-checkbox, .input-radio {
    width: 18px;
    height: 18px;
    -webkit-box-shadow: 0 0 0 0 #197bbd inset;
    box-shadow: 0 0 0 0 #197bbd inset;
    -webkit-transition: all .2s ease-in-out;
    transition: all .2s ease-in-out;
    position: relative;
    cursor: pointer;
    vertical-align: -4px;
    border: 1px solid;
}
.input-radio {
    border-radius: 50%;
}
input[type="checkbox"], input[type="radio"] {
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    padding: 0;
}
.main .input-checkbox, .main .input-radio {
    border-color: #d9d9d9;
    background-color: #fff;
}
.content-box .input-checkbox, .content-box .input-radio {
    border-color: #d9d9d9;
    background-color: #fff;
}
.input-checkbox::after, .input-radio::after {
    content: "";
    display: block;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: scale(0.2);
    opacity: 0;
    transition: all 0.2s ease-in-out 0.1s;
}
.input-radio:after {
    width: 4px;
    height: 4px;
    margin-left: -2px;
    margin-top: -2px;
    background-color: #fff;
    border-radius: 50%;
}
.radio__label, .checkbox__label {
    cursor: pointer;
    vertical-align: middle;
    display: table-cell;
    width: 100%;
}
.radio__label__primary {
    cursor: inherit;
    font-family: inherit;
    vertical-align: top;
    display: table-cell;
    width: 100%;
}
.radio__label__accessory {
    text-align: right;
    padding-left: 0.75em;
    white-space: nowrap;
    display: table-cell;
    vertical-align: middle;
}
.radio__label__icon {
    color: #1990c6;
    font-size: 1.5em;
    height: 100%;
    display: inline-block;
}
.payment-icon {
    display: flex;
    justify-content: center;
    align-content: center;
    width: 52px;
    height: 28px;
    transition: opacity .5s cubic-bezier(.3,0,0,1);
    backface-visibility: hidden;
    -webkit-backface-visibility: hidden;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    transform: translate(0,0);
}
.payment-icon--16 {
    background: url(../assets/img/payment_icon_vnpay.webp) no-repeat center center;
}
.payment-icon--19 {
    background: url(../assets/img/vnpayqr-icon.webp) no-repeat center center;
}
.input-checkbox:checked, .input-radio:checked {
    border: none;
    -webkit-box-shadow: 0 0 0 10px #337ab7 inset;
    box-shadow: 0 0 0 10px #337ab7 inset;
}
.input-radio:checked::after{
    -webkit-transform: scale(1);
    transform: scale(1);
    opacity: 1;
    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=" 100 ")";
    filter: alpha(opacity=100);
}
.payment-icon--18, .payment-icon--21 {
    background: url(../assets/img/logomm1.webp) no-repeat center center;
    background-size: 28px 28px;
}
.payment-icon--8::before, .payment-icon--3::before, .payment-icon--5::before, .payment-icon--4::before {
    content: "";
    color: #fcaf17;
}
.content-box__row:last-child .content-box__row__desc {
    border-bottom-left-radius: 4px;
    border-bottom-right-radius: 4px;
    border-bottom-width: 1px;
}

.content-box__row__desc {
    background-color: #f8f8f8;
    padding: 1.14em;
    margin: 1.14em -1.14em -1.14em -1.14em;
    border-color: rgba(175,175,175,.34);
    border-style: solid;
    border-width: 0 1px;
}
.hide {
    display: none !important;
    /* display: block; */
}
.fieldset .field .field-input-wrapper .field-input:focus {
    box-shadow: 0 0 0 2px #338dbc;
    outline: none;
}
a:focus, a:hover {
    color: #2b78a0;
    text-decoration: underline;
}
</style>