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
                                            <tr class="product" v-for="(item, index) in productAddtoCarts" :key="index">
                                                <td class="product-image">
                                                    <div class="product-thumbnail">
                                                        <div class="product-thumbnail-wrapper">
                                                            <img :src="require('@/assets/img/' + item.img)"
                                                                class="product-thumbnail-image" alt="" />
                                                        </div>
                                                        <span class="product-thumbnail-quantity" aria-hidden="true">{{
                                                            item.qty }}</span>
                                                    </div>
                                                </td>
                                                <td class="product-description">
                                                    <span
                                                        class="product-description-name order-summary-emphasis tp_product_name">{{
                                                            item.namePro }} - {{ item.color }} -
                                                        {{ item.size }}</span>
                                                </td>
                                                <td class="product-quantity visually-hidden">
                                                    {{ item.qty }}
                                                </td>
                                                <td class="product-price">
                                                    <span class="order-summary-emphasis">
                                                        <span class="tp_product_price" v-if="item.price > 0" >{{
                                                            item.price.toLocaleString("en-US", {
                                                                minimumFractionDigits: 0,
                                                            })
                                                        }}
                                                            ₫</span>
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
                                                        <input placeholder="Mã giảm giá" v-model="couponCode"
                                                            class="field-input" id="discount_code" />
                                                    </div>
                                                    <button type="button" id="getCoupon"
                                                        class="field-input-btn btn btn-default btn-disabled tp_button">
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
                                                <th scope="col">
                                                    <span class="visually-hidden">Mô tả</span>
                                                </th>
                                                <th scope="col">
                                                    <span class="visually-hidden">GiáGiá</span>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="total-line total-line-shipping shipFeeCheckHost">
                                                <td class="total-line-name">Phí vận chuyển</td>
                                                <td class="total-line-price" v-if="this.selectedWard == null &&
                                                    this.selectedWard != 999
                                                    ">
                                                    <span class="order-summary-emphasis" value="0" id="shipFee">—</span>
                                                    <span id="showCarrier"></span>
                                                </td>
                                                <td class="total-line-price" v-else>
                                                    <span class="order-summary-emphasis" style="
                                font-family: Helvetica Neue, sans-serif;
                                color: #737373;
                              " value="22000" id="shipFee" codfee="0" data-curentvalue="22000" v-if="shipping.price > 0">{{
                                  shipping.price.toLocaleString("en-US", {
                                      minimumFractionDigits: 0,
                                  })
                              }}
                                                        đ</span>
                                                    <span id="showCarrier">
                                                        <img src="../assets/img/shipper.png" style="margin-right: 2px" />{{
                                                            shipping.name }}({{ shipping.description }})
                                                        <i class="changeOrtherShipFee" style="
                                  display: block;
                                  cursor: pointer;
                                  font-weight: normal;
                                  font-size: 11px;
                                  font-family: Helvetica Neue, sans-serif;
                                " @click="onShowShipping">(Chọn hãng vận chuyển khác)</i>
                                                        <input type="hidden" name="serviceType" class="serviceType"
                                                            value="undefined" />
                                                        <input type="hidden" name="serviceCode" class="serviceCode"
                                                            value="undefined" />
                                                        <input type="hidden" name="shippingValue" class="shippingValue"
                                                            value="27" />
                                                        <input type="hidden" name="carrierServiceId"
                                                            class="carrierServiceId" value="156" />
                                                    </span>
                                                </td>
                                            </tr>
                                        </tbody>
                                        <tfoot class="total-line-table-footer">
                                            <tr class="total-line" id="orderDiscount" style="display: none">
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
                                                    <span class="payment-due-price" id="showTotalMoney" v-if="totalPrice > 0">{{
                                                        totalPrice.toLocaleString("en-US", {
                                                            minimumFractionDigits: 0,
                                                        })
                                                    }}₫</span>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                            <h3 class="notice-checkout" style="
                    font-weight: 400;
                    padding: 10px;
                    border: 1px solid #f77705;
                    line-height: 18px;
                    margin: 0;
                  ">
                                <p>
                                    Krik sẽ xác nhận đơn hàng bằng cách gọi điện thoại. Bạn vui
                                    lòng để ý điện thoại khi đặt hàng thành công và chờ nhận hàng.
                                    Cảm ơn bạn !
                                </p>
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
                                        <p class="section-content-text"
                                            v-if="Object.keys(this.$store.state.customer).length == 0">
                                            Bạn đã có tài khoản?
                                            <a href="/user/signin">Đăng nhập</a>
                                        </p>
                                        <div class="fieldset">
                                            <div class="field">
                                                <div class="field-input-wrapper">
                                                    <label class="field-label" for="billing_address_full_name">Họ và
                                                        tên</label>
                                                    <erorr-validate :isErorr="erorrUser" />
                                                    <input placeholder="Họ và tên" type="text" class="field-input"
                                                        v-model="name" @blur="onBlurName" @input="onKeypressName" />
                                                </div>
                                            </div>
                                            <div class="field field-two-thirds">
                                                <div class="field-input-wrapper">
                                                    <label class="field-label" for="checkout_user_email">Email</label>
                                                    <erorr-validate :isErorr="erorrEmail" :text="textErorrEmail"
                                                        :right="right" />
                                                    <input placeholder="Email" type="text" class="field-input"
                                                        v-model="email" @blur="onBlurEmail" @input="onKeypressEmail" />
                                                </div>
                                            </div>
                                            <div class="field field-required field-third">
                                                <div class="field-input-wrapper">
                                                    <label class="field-label" for="billing_address_phone">Số điện
                                                        thoại</label>
                                                    <erorr-validate :isErorr="erorrMobile" :text="textErorrMobile" />
                                                    <input placeholder="Số điện thoại" type="text"
                                                        class="field-input customerPointCheck" v-model="phoneNumber"
                                                        @blur="onBlurMobile" @input="onKeypressMobile" />
                                                </div>
                                            </div>
                                            <div class="field">
                                                <div class="field-input-wrapper">
                                                    <label class="field-label" for="billing_address_address1">Địa
                                                        chỉ</label>
                                                    <erorr-validate :isErorr="erorrAddress" />
                                                    <input placeholder="Địa chỉ" type="text" class="field-input"
                                                        v-model="address" @blur="onBlurAddress"
                                                        @input="onKeypressAddress" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="section-content">
                                        <div class="fieldset">
                                            <div id="form_update_location" class="clearfix">
                                                <div class="field field-show-floating-label field-half">
                                                    <erorr-validate :isErorr="erorrProvince" />
                                                    <DxSelectBox v-model="selectedProvince" placeholder=""
                                                        label="Tỉnh/ Thành phố" :searchEnabled="true"
                                                        :acceptCustomValue="true" :value="provinces[0]"
                                                        :dataSource="provinces" displayExpr="name" valueExpr="code"
                                                        :input-attr="{ 'aria-label': 'Simple Product' }"
                                                        @ValueChanged="onProvinceChange" />
                                                </div>
                                                <div class="field field-show-floating-label field-half">
                                                    <erorr-validate :isErorr="erorrDistrict" />
                                                    <DxSelectBox v-model="selectedDistrict" placeholder=""
                                                        label="Quận/ Huyện" :searchEnabled="true" :acceptCustomValue="true"
                                                        :value="districts[0]" :dataSource="districts" displayExpr="name"
                                                        valueExpr="code" :input-attr="{ 'aria-label': 'Simple Product' }"
                                                        noDataText="Chọn Quận/ huyện" @ValueChanged="onDistrictChange" />
                                                </div>
                                                <div class="field field-show-floating-label field-half refInput">
                                                    <erorr-validate :isErorr="erorrWard" />
                                                    <DxSelectBox v-model="selectedWard" placeholder="" label="Phường/ Xã"
                                                        ref="refWard" :searchEnabled="true" :acceptCustomValue="true"
                                                        :value="wards[0]" displayExpr="name" :dataSource="wards"
                                                        :input-attr="{ 'aria-label': 'Simple Product' }"
                                                        noDataText="Chọn Phường/ xã" @ValueChanged="onWardChange" />
                                                </div>
                                            </div>
                                            <div class="field description-order">
                                                <div class="field-input-wrapper">
                                                    <div class="descriptionCustomer">
                                                        <textarea class="input" v-model="note" placeholder="Ghi chú"
                                                            rows="3" style="
                                  width: 100%;
                                  padding: 5px;
                                  box-shadow: 0 0 0 1px #d9d9d9;
                                  border-radius: 4px;
                                  transition: all 0.2s ease-out;
                                "></textarea>
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
                                                    <i
                                                        class="fa fa-credit-card fa-lg section__title--icon hide-on-desktop"></i>
                                                    Thanh toán
                                                </h2>
                                            </div>
                                        </div>
                                        <div class="section__content">
                                            <div class="content-box">
                                                <div class="content-box__row" v-for="(item, index) in methodPayments"
                                                    :key="index">
                                                    <div class="radio-wrapper">
                                                        <div class="radio__input">
                                                            <input name="paymentMethod" id="paymentMethod-516910"
                                                                type="radio" class="input-radio" value="516910"
                                                                @click="onOpenDesMethod(item)" />
                                                        </div>
                                                        <label for="paymentMethod-516910" class="radio__label">
                                                            <span class="radio__label__primary">{{
                                                                item.description
                                                            }}</span>
                                                            <span class="radio__label__accessory">
                                                                <span class="radio__label__icon">
                                                                    <i class="payment-icon" :class="item.img"></i>
                                                                </span>
                                                            </span>
                                                        </label>
                                                    </div>
                                                    <div class="content-box__row__desc"
                                                        v-show="item.selected && item.choose">
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
                <div id="tableShipFee" v-show="showShipping" data-aos="fade-up" data-aos-duration="500">
                    <div>
                        <p style="margin: 10px 0; color: #737373; font-family: sans-serif">
                            Chọn hãng vận chuyển
                        </p>
                        <table class="table table-striped tableCarrier" style="font-size: 13px">
                            <thead>
                                <tr style="background: #f5f5f5">
                                    <th style="
                        vertical-align: middle;
                        border-bottom: 1px solid #b7b7b7;
                        text-align: center;
                      ">
                                        Hãng
                                    </th>
                                    <th style="
                        vertical-align: middle;
                        border-bottom: 1px solid #b7b7b7;
                        text-align: center;
                      " colspan="2">
                                        Cước phí
                                    </th>
                                </tr>
                            </thead>
                            <tbody class="bg-white">
                                <tr class="rowTableFee rowCarrier27 rowCheck00" rowspan="1"
                                    v-for="(item, index) in listShipping" :key="index">
                                    <td v-if="item.isImg" style="
                        padding: 6px;
                        text-align: center;
                        vertical-align: middle !important;
                      " class="logoCarrier pl-1 pr-t0 pb p-1-0 text-center" :rowspan="[item.rowspan ? '2' : '1']">
                                        <img style="
                          max-width: 120px;
                          vertical-align: middle !important;
                        " :title="item.title" alt="Ninja Van" :src="item.src" />
                                    </td>
                                    <td style="padding: 6px; text-align: left" class="service">
                                        <label class="wrapService m-0 cursor-pointer" style="
                          vertical-align: middle;
                          font-weight: 600;
                          display: flex;
                          align-items: center;
                        ">
                                            <input style="margin-right: 5px; vertical-align: text-top" type="radio"
                                                id="contentundefined" class="cusShipFeeChange nhanhInput0"
                                                :checked="item.selected" @click="onselect(item)" />
                                            <span class="serviceDes" style="
                            font-family: Helvetica Neue, sans-serif;
                            color: #737373;
                          ">{{ item.content }}</span>
                                            <span>
                                                <small class="text-secondary font-size-sm" style="
                              font-family: Helvetica Neue, sans-serif;
                              color: #737373;
                            ">
                                                    ({{ item.description }})</small>
                                            </span>
                                        </label>
                                    </td>
                                    <td class="itemFeeNhanh text-right" style="vertical-align: top; padding: 6px">
                                        <span class="totalFee text-success-600 font-weight-semibold"
                                            title="Phí vận chuyển: 22000 - Phí thu tiền hộ: 0" v-if="item.priceShip > 0">{{
                                                item.priceShip.toLocaleString("en-US", {
                                                    minimumFractionDigits: 0,
                                                })
                                            }}</span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>
<script>
import { validateEmail, validatePhoneNumber } from '@/methods/index'
import { mapState, mapActions } from "vuex";
import DxSelectBox from "devextreme-vue/select-box";
import {
    dataChooseCity,
    dataChoosePhuong,
    dataChooseQuan,
    listShipping,
    methodPayments,
    ngoaiThanh,
    tinhLe,
} from "@/resource/TestData";
import { store } from "@/store";
import AOS from 'aos';
import 'aos/dist/aos.css';
export default {
    name: "CheckOut",
    components: { DxSelectBox },
    computed: {
        ...mapState(["provinces", "districts", "wards"]),
        productAddtoCarts() {
            return this.$store.getters.getProduct;
        },
        totalPrice() {
            return this.selectedWard && this.selectedWard != 999
                ? this.$store.getters.getTotalPrice + this.shipping.price
                : this.$store.getters.getTotalPrice;
        },
    },
    watch: {
        selectedWard(newvalue) {
            if (newvalue && newvalue != 999) {
                this.shipping = {
                    name: "Ninja Van",
                    description: "Giao tiêu chuẩn 22k",
                    price: 22000,
                };

                if (
                    this.selectedProvince == 1 &&
                    this.selectedDistrict &&
                    this.selectedDistrict != 999
                ) {
                    const dir = this.districts.find(
                        (item) => item.code == this.selectedDistrict
                    );
                    if (dir.division_type !== "quận") {
                        this.listShipping = ngoaiThanh;
                    } else this.listShipping = listShipping;
                } else {
                    this.listShipping = tinhLe;
                }
                this.listShipping.forEach(item => item.selected = false)
            }

        },
    },
    data() {
        return {
            right: -45,
            erorrAddress: false,
            erorrEmail: false,
            erorrMobile: false,
            erorrUser: false,
            erorrProvince: false,
            erorrDistrict: false,
            erorrWard: false,
            textErorrMobile: "Trường này bắt buộc",
            textErorrEmail: "Trường này bắt buộc",
            showShipping: false,
            selectedProvince: null, // Tỉnh được chọn
            selectedDistrict: null, // Quận được chọn
            selectedWard: null, // Phường được chọn
            couponCode: "",
            shipping: {
                name: "Ninja Van",
                description: "Giao tiêu chuẩn 22k",
                price: 22000,
            },
            customerID: "",
            name: "",
            email: "",
            phoneNumber: "",
            address: "",
            note: "",
            phuong: "Chọn Phường/ xã",
            quan: "Chọn Quận/ huyện",
            city: "Chọn Tỉnh/ thành phố",
            dataChooseCity: dataChooseCity,
            dataChoosePhuong: dataChoosePhuong,
            dataChooseQuan: dataChooseQuan,
            inFoCustomer: {},
            listShipping: listShipping,
            methodPayments: methodPayments,
            paymentOrder: false,
        };
    },
    methods: {
        ...mapActions(["fetchProvinces", "fetchDistricts", "fetchWards"]),
        async onProvinceChange() {
            if (this.selectedProvince && this.selectedProvince != 999) {
                // Lấy danh sách các quận/huyện của tỉnh được chọn
                await this.fetchDistricts(this.selectedProvince);
                // Reset lại giá trị quận/huyện và phường/xã được chọn
                this.selectedDistrict = null;
                this.selectedWard = null;
                const selectedObject = this.provinces.find(
                    (obj) => obj.code === this.selectedProvince
                );
                if (selectedObject) {
                    this.city = selectedObject.name;
                }
                this.erorrProvince = false;
            }

        },
        async onDistrictChange() {
            if (this.selectedDistrict && this.selectedDistrict != 999) {
                await this.fetchWards(this.selectedDistrict);
                // Reset lại giá trị phường/xã được chọn
                this.selectedWard = null;
                const selectedObject = this.districts.find(
                    (obj) => obj.code === this.selectedDistrict
                );
                if (selectedObject) {
                    this.quan = selectedObject.name;
                }
                this.erorrDistrict = false;
            }
        },
        onWardChange() {
            if (this.selectedWard && this.selectedWard != 999) {
                this.erorrWard = false;
            }
        },
        onOpenDesMethod(item) {
            this.methodPayments.forEach((item) => (item.selected = false));
            item.selected = !item.selected;
        },
        onselect(item) {
            this.listShipping.forEach((item) => (item.selected = false));
            item.selected = !item.selected;
            this.shipping = {
                name: item.title,
                description: item.content,
                price: item.priceShip,
            };
            setTimeout(() => {
                window.scroll({
                    top: 0,
                    behavior: "smooth",
                });
            }, 200);
            
            
    
        },
        onShowShipping() {
            this.showShipping = true;
            setTimeout(() => {
                window.scrollTo({ 
                    left: 0, 
                    top: document.body.scrollHeight, 
                    behavior: "smooth" 
                });
            }, 500);
            // const windowHeight = window.innerHeight;
            // const documentHeight = document.documentElement.scrollHeight;
            // const scrollDistance = documentHeight - windowHeight;

            // window.scrollTo({
            //     top: scrollDistance,
            //     behavior: 'smooth'
            // });

            // AOS.refresh();
            
        },
        getValueForm() {
            let warrdSelecet = document.querySelector(".refInput input[type=hidden]");
            methodPayments.forEach(i => {
                if(i.selected){
                    this.paymentOrder = true;
                }
            })
            if (this.selectedWard && this.selectedWard != 999 && validateEmail(this.email) && validatePhoneNumber(this.phoneNumber) && this.name != "" && this.address != "" && warrdSelecet.value !== "Chọn Phường/ xã" && this.paymentOrder == true) {
                this.erorrUser = false;
                this.erorrEmail = false;
                this.erorrMobile = false;
                this.erorrAddress = false;
                this.inFoCustomer = {
                    customerID: this.customerID,
                    name: this.name,
                    email: this.email,
                    phone: this.phoneNumber,
                    address: this.address,
                    note: this.note,
                    couponCode: this.couponCode,
                    phuong: this.selectedWard.name,
                    quan: this.quan,
                    city: this.city,
                    products : this.productAddtoCarts,
                    shiping : this.shipping.price,
                    totalPrice: this.totalPrice,
                };

                console.log(this.inFoCustomer);
            } else if (this.name == "") this.erorrUser = true;

            else if (!validateEmail(this.email)) this.erorrEmail = true;
            else if (!validatePhoneNumber(this.phoneNumber)) this.erorrMobile = true;
            else if (this.address == "") this.erorrAddress = true;
            else if (this.selectedProvince == null || this.selectedProvince == 999) this.erorrProvince = true;
            else if (this.selectedDistrict == null || this.selectedDistrict == 999) this.erorrDistrict = true;
            else if (this.selectedWard == null || this.selectedWard == 999) this.erorrWard = true;
            else if (warrdSelecet.value == "Chọn Phường/ xã") {
                this.erorrWard = true;
            }
        },
        onBlurName() {
            if (this.name == "") this.erorrUser = true;
            else this.erorrUser = false;
        },
        onBlurEmail() {
            if (this.email == "") {
                this.erorrEmail = true;
                this.textErorrEmail = "Trường này bắt buộc";
            } else {
                if (validateEmail(this.email)) {
                    this.erorrEmail = false;
                } else {
                    this.erorrEmail = true;
                    this.textErorrEmail = "Email không hợp lệ";
                }
            }
        },
        onBlurMobile() {
            if (this.phoneNumber == "") {
                this.erorrMobile = true;
                this.textErorrMobile = "Trường này bắt buộc";
            } else {
                if (validatePhoneNumber(this.phoneNumber)) {
                    this.erorrMobile = false;
                } else {
                    this.erorrMobile = true;
                    this.textErorrMobile = "Số điện thoại không hợp lệ";
                }
            }
        },
        onBlurAddress() {
            if (this.address == "") this.erorrAddress = true;
            else this.erorrAddress = false;
        },
        onKeypressEmail() {
            setTimeout(() => {
                if (this.email == "") {
                    this.erorrEmail = true;
                    this.textErorrEmail = "Trường này bắt buộc";
                } else {
                    if (validateEmail(this.email)) {
                        this.erorrEmail = false;
                    } else {
                        this.erorrEmail = true;
                        this.textErorrEmail = "Email không hợp lệ";
                    }
                }
            }, 500)
        },
        onKeypressMobile() {
            setTimeout(() => {
                if (this.phoneNumber == "") {
                    this.erorrMobile = true;
                    this.textErorrMobile = "Trường này bắt buộc";
                } else {
                    if (validatePhoneNumber(this.phoneNumber)) {
                        this.erorrMobile = false;
                    } else {
                        this.erorrMobile = true;
                        this.textErorrMobile = "Số điện thoại không hợp lệ";
                    }
                }
            }, 500)
        },
        onKeypressName() {
            setTimeout(() => {
                if (this.name == "") this.erorrUser = true;
                else this.erorrUser = false;
            }, 500)
        },
        onKeypressAddress() {
            setTimeout(() => {
                if (this.address == "") this.erorrAddress = true;
                else this.erorrAddress = false;
            }, 500)
        }
    },
    created() {
        this.fetchProvinces();
        document.title = "Thanh Toán";
        if (Object.keys(this.$store.state.customer).length > 0) {
            this.name = store.state.customer.fullName;
            this.email = store.state.customer.email;
            this.phoneNumber = store.state.customer.phone;
            this.customerID = store.state.customer.customer_id;
        }
    },
    mounted() { 
        // window.addEventListener("scroll", this.scrollListener);
        AOS.init();
    
    },
};
</script>
<style scoped>
*,
body {
    font-size: 14px;
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

.content {
    overflow-x: hidden;
}

@media (min-width: 768px) {
    .container {
        width: 750px;
    }
}

@media (min-width: 992px) {
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

@media (min-width: 1000px) {

    .main,
    .sidebar {
        padding-top: 4em;
    }
}

@media (min-width: 1000px) {
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

@media (min-width: 1000px) {
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

td,
th {
    padding: 0;
    padding-left: 1em;
}

td:first-child,
th:first-child {
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

td:last-child,
th:last-child {
    text-align: right;
}

td,
th {
    padding: 0;
    padding-left: 1em;
}

td:first-child,
th:first-child {
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
    background-color: rgba(153, 153, 153, 0.9);
    color: #fff;
    position: absolute;
    right: -0.75em;
    top: -0.75em;
    z-index: 2;
    font-family: "Quicksand-Bold";
}

.sidebar .sidebar-content .order-summary .product .product-image .product-thumbnail::after {
    content: "";
    display: block;
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    border-radius: 8px;
    box-shadow: 0 0 0 1px rgba(0, 0, 0, 0.1) inset;
}

.sidebar .sidebar-content .order-summary .product:first-child td {
    padding-top: 0;
}

.sidebar .sidebar-content .order-summary .product .product-description {
    width: 100%;
}

.sidebar .sidebar-content .order-summary .product .product-description .product-description-name,
.sidebar .sidebar-content .order-summary .product .product-description .product-description-variant,
.sidebar .sidebar-content .order-summary .product .product-description .product-description-property {
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

.fieldset:after,
.fieldset:before {
    content: "";
    display: table;
}

.fieldset .field {
    width: 100%;
    float: left;
    padding: 0.45em;
    box-sizing: border-box;
    position: relative;
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

button,
input,
optgroup,
select,
textarea {
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

button,
select {
    text-transform: none;
}

button {
    overflow: visible;
}

button,
input,
optgroup,
select,
textarea {
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

button,
input[type="button"],
input[type="reset"],
input[type="submit"] {
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

.btn,
.btn:hover {
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

.fieldset:after,
.fieldset:before {
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
    font-family: Helvetica Neue, sans-serif;
    color: #737373;
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
    content: "";
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

h3 {
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

@media (min-width: 1000px) {
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

.btn-content {
    color: white;
    font-size: 14px;
    font-weight: 600;
}

.btn:hover {
    background: #286f94;
    color: white;
}

/* thông tin giao hàng */

@media (min-width: 1000px) {
    .main {
        width: 52%;
        width: 52%;
        padding-right: 6%;
        float: left;
    }
}

@media (min-width: 750px) {
    .main {
        padding-top: 1.5em;
    }
}

@media (min-width: 1000px) {

    .main,
    .sidebar {
        padding-top: 4em;
    }
}

@media (min-width: 1000px) {
    .main .main-header {
        padding-bottom: 2em;
        max-height: 46px;
    }
}

ol,
ul {
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

@media (min-width: 1000px) {
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

.main .main-header .breadcrumb .breadcrumb-item:first-child:after,
.main-header-custom .breadcrumb .breadcrumb-item:first-child:after {
    content: "";
    display: inline-block;
    width: 6px;
    height: 11px;
    vertical-align: middle;
    margin: 0 0.5em;
    background-image: url("data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI2IiBoZWlnaHQ9IjExIiBvcGFjaXR5PSIuNCIgZmlsbD0iIzAwMCI+PHBhdGggZD0iTS41MjYgMS40MDhsNCA0LjY0NS4wMTQtLjgzLTQgNC4zNTQuOTIuODQ2IDQtNC4zNTYuMzc2LS40MS0uMzYyLS40Mi00LTQuNjQ1LS45NDguODE2eiIvPjwvc3ZnPg=="),
        none;
    background-image: url("data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI2IiBoZWlnaHQ9IjExIiBvcGFjaXR5PSIuNCIgZmlsbD0iIzAwMCI+PHBhdGggZD0iTS41MjYgMS40MDhsNCA0LjY0NS4wMTQtLjgzLTQgNC4zNTQuOTIuODQ2IDQtNC4zNTYuMzc2LS40MS0uMzYyLS40Mi00LTQuNjQ1LS45NDguODE2eiIvPjwvc3ZnPg=="),
        none;
}

.main .main-header .breadcrumb .breadcrumb-item {
    display: inline-block;
    font-size: 0.85714em;
    color: #999999;
}

@media (min-width: 750px) {
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

@media (min-width: 750px) {
    .section .section-header {
        margin-bottom: 1.5em;
    }
}

.section .section-header {
    position: relative;
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

.h2,
h2 {
    font-size: 30px;
}

h1,
h2,
h3,
h4,
h5,
h6 {
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

.section .section-content.no-mb,
.section .section-content:last-child {
    margin-bottom: inherit;
}

.section .section-content:after,
.section .section-content:before {
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

@media (min-width: 750px) {
    .field-two-thirds {
        width: 66.66667% !important;
    }
}

@media (min-width: 750px) {
    .field-third {
        width: 33.33333% !important;
    }
}

.fieldset:after {
    clear: both;
}

.fieldset:after,
.fieldset:before {
    content: "";
    display: table;
}

.section .section-content:after,
.section .section-content:before {
    content: "";
    display: table;
}

@media (min-width: 750px) {
    .field-half {
        width: 50% !important;
    }
}

@media (min-width: 1200px) {
    .container {
        width: 1180px;
        display: flow-root;
    }
}

ul li:nth-child(2) {
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

.section__title {
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
    transform: translate(0, 0);
}

.fa-lg {
    font-size: 1.33333333em;
    line-height: 0.75em;
    vertical-align: -15%;
}

.section__title--icon {
    margin: 0 3px;
    vertical-align: top;
}

@media (min-width: 1000px) {
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

.radio-wrapper:after,
.radio-wrapper:before,
.checkbox-wrapper:after,
.checkbox-wrapper:before {
    content: "";
    display: table;
}

.radio__input,
.checkbox__input {
    display: table-cell;
}

.radio__input,
.checkbox__input {
    white-space: nowrap;
    padding-right: 0.75em;
}

.field__input,
.input-checkbox,
.input-radio,
button,
textarea {
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

.input-checkbox,
.input-radio {
    width: 18px;
    height: 18px;
    -webkit-box-shadow: 0 0 0 0 #197bbd inset;
    box-shadow: 0 0 0 0 #197bbd inset;
    -webkit-transition: all 0.2s ease-in-out;
    transition: all 0.2s ease-in-out;
    position: relative;
    cursor: pointer;
    vertical-align: -4px;
    border: 1px solid;
}

.input-radio {
    border-radius: 50%;
}

input[type="checkbox"],
input[type="radio"] {
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    padding: 0;
}

.main .input-checkbox,
.main .input-radio {
    border-color: #d9d9d9;
    background-color: #fff;
}

.content-box .input-checkbox,
.content-box .input-radio {
    border-color: #d9d9d9;
    background-color: #fff;
}

.input-checkbox::after,
.input-radio::after {
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

.radio__label,
.checkbox__label {
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
    transition: opacity 0.5s cubic-bezier(0.3, 0, 0, 1);
    backface-visibility: hidden;
    -webkit-backface-visibility: hidden;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    transform: translate(0, 0);
}

.payment-icon--16 {
    background: url(../assets/img/payment_icon_vnpay.webp) no-repeat center center;
}

.payment-icon--19 {
    background: url(../assets/img/vnpayqr-icon.webp) no-repeat center center;
}

.input-checkbox:checked,
.input-radio:checked {
    border: none;
    -webkit-box-shadow: 0 0 0 10px #337ab7 inset;
    box-shadow: 0 0 0 10px #337ab7 inset;
}

.input-radio:checked::after {
    -webkit-transform: scale(1);
    transform: scale(1);
    opacity: 1;
    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=" 100 ")";
    filter: alpha(opacity=100);
}

.payment-icon--18,
.payment-icon--21 {
    background: url(../assets/img/logomm1.webp) no-repeat center center;
    background-size: 28px 28px;
}

.payment-icon--8::before,
.payment-icon--3::before,
.payment-icon--5::before,
.payment-icon--4::before {
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
    border-color: rgba(175, 175, 175, 0.34);
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

a:focus,
a:hover {
    color: #2b78a0;
    text-decoration: underline;
}

#showCarrier {
    display: block;
    text-align: right;
    width: 100%;
    font-size: 11px;
    font-family: Helvetica Neue, sans-serif;
    color: #737373;
}

.changeOrtherShipFee:hover {
    color: darkred;
    text-decoration: underline;
}

#tableShipFee {
    /* display: none; */
    clear: both;
}

.table {
    width: 100%;
    max-width: 100%;
    margin-bottom: 20px;
}

.table>tbody>tr>td,
.table>tbody>tr>th,
.table>tfoot>tr>td,
.table>tfoot>tr>th,
.table>thead>tr>td,
.table>thead>tr>th {
    padding: 8px;
    line-height: 1.42857143;
    vertical-align: top;
    border-top: 1px solid #ddd;
    font-family: sans-serif;
    color: #737373;
}

.table>caption+thead>tr:first-child>td,
.table>caption+thead>tr:first-child>th,
.table>colgroup+thead>tr:first-child>td,
.table>colgroup+thead>tr:first-child>th,
.table>thead:first-child>tr:first-child>td,
.table>thead:first-child>tr:first-child>th {
    border-top: 0;
}

.table-striped>tbody>tr:nth-of-type(odd) {
    background-color: #f9f9f9;
}

#tableShipFee input {
    appearance: auto;
    -webkit-appearance: revert;
    width: 18px;
    height: 18px;
}

.small,
small {
    font-size: 88%;
}

.clearfix:after {
    visibility: hidden;
    display: block;
    font-size: 0;
    content: " ";
    clear: both;
    height: 0;
}

.wrap:after,
.wrap:before {
    content: "";
    display: table;
}

.wrap:after {
    clear: both;
}

.wrap:after,
.wrap:before {
    content: "";
    display: table;
}

.changeOrtherShipFee:hover {
    color: darkred;
    text-decoration: underline;
}
</style>
  