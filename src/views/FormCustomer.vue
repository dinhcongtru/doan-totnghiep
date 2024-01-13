<template>
      <main class="main-content main-pdd">
            <section id="page-wrapper">
                  <div class="container animated">
                        <div class="row">
                              <div class="section-content col-md-12" v-if="storeCustomerInfo">
                                    <h1 class="text-center col-md-12">Thông tin cá nhân</h1>
                                    <div class="clearfix"></div>
                                    <form @submit.prevent="submitForm" id="formAcount"
                                          class="formAcount validate col-sm-8 col-xs-12 clearfix">
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Họ tên: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrName" :text="textErorrName" />
                                                      <input type="text" placeholder="Họ tên" class="form-control input-sm"
                                                            v-model="name"
                                                            @blur="onBlurValidateTypeInput(name, 'text', 'inpName')"
                                                            @input="onKeypressTypeInput(name, 'text', 'inpName')" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Điện thoại: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrMobile" :text="textErorrMobile" />
                                                      <input type="text" placeholder="Điện Thoại"
                                                            class="form-control input-sm" v-model="phone"
                                                            @blur="onBlurValidateTypeInput(phone, 'mobile', 'inpMobile')"
                                                            @input="onKeypressTypeInput(phone, 'mobile', 'inpMobile')" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Email: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrEmail" :text="textErorrEmail" />
                                                      <input type="text" placeholder="Email" class="form-control input-sm"
                                                            v-model="email"
                                                            @blur="onBlurValidateTypeInput(email, 'email', 'inpEmail')"
                                                            @input="onKeypressTypeInput(email, 'email', 'inpEmail')" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Tỉnh/Thành phố: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrProvince" />

                                                      <DxSelectBox v-model="selectedProvince" placeholder=""
                                                            label="Tỉnh/ Thành phố" :searchEnabled="true"
                                                            :acceptCustomValue="true" :dataSource="provinces"
                                                            displayExpr="name" valueExpr="code"
                                                            :input-attr="{ 'aria-label': 'Simple Product' }"
                                                            @ValueChanged="onProvinceChange" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Quận/Huyện: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrDistrict" />

                                                      <DxSelectBox v-model="selectedDistrict" placeholder=""
                                                            label="Quận/ Huyện" :searchEnabled="true"
                                                            :acceptCustomValue="true" :dataSource="districts"
                                                            displayExpr="name" valueExpr="code"
                                                            :input-attr="{ 'aria-label': 'Simple Product' }"
                                                            noDataText="Chọn Quận/ huyện" @ValueChanged="onDistrictChange" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Phường/Xã: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrWard" />

                                                      <DxSelectBox v-model="selectedWard" placeholder="" label="Phường/ Xã"
                                                            ref="refWard" :searchEnabled="true" :acceptCustomValue="true"
                                                            displayExpr="name" :dataSource="wards"
                                                            :input-attr="{ 'aria-label': 'Simple Product' }"
                                                            noDataText="Chọn Phường/ xã" @ValueChanged="onWardChange" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Địa chỉ chi tiết: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrAddress" :text="textErorrAddress" />
                                                      <input type="text" placeholder="Địa chỉ chi tiết"
                                                            class="form-control input-sm" v-model="address"
                                                            @blur="onBlurValidateTypeInput(address, 'text', 'inpAddress')"
                                                            @input="onKeypressTypeInput(address, 'text', 'inpAddress')" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix text-center">
                                                <button type="submit" class="btn btn-green"> Cập nhật</button>
                                                <a href="/profile" class="btn btn-green">Quay lại</a>
                                          </div>
                                    </form>
                              </div>
                              <div v-else class="section-content col-md-12">
                                    <h1 class="text-center col-md-12">Đổi mật khẩu</h1>
                                    <div class="breadcrumb-small text-center">
                                          <a href="/">Trang chủ</a>
                                          <span aria-hidden="true">/</span>
                                          <span>Đổi mật khẩu</span>
                                    </div>
                                    <div class="clearfix"></div>
                                    <form @submit.prevent="submitForm" id="formAcount"
                                          class="formAcount validate col-sm-8 col-xs-12 clearfix">
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Mật khẩu cũ: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrPasOld" :text="textErorrPasOld" />
                                                      <input type="password" placeholder="Mật khẩu cũ" class="form-control input-sm"
                                                            v-model="pasOld"
                                                            @blur="onBlurValidateTypeInput(pasOld, 'text', 'inpOld')"
                                                            @input="onKeypressTypeInput(pasOld, 'text', 'inpOld')" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Mật khẩu mới: </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrPasNew" :text="textErorrPasNew" />
                                                      <input type="password" placeholder="Mật khẩu mới:" class="form-control input-sm"
                                                            v-model="pasNew"
                                                            @blur="onBlurValidateTypeInput(pasNew, 'text', 'inpNew')"
                                                            @input="onKeypressTypeInput(pasNew, 'text', 'inpNew')" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix">
                                                <label class="col-sm-3 control-label"> Xác Mật khẩu : </label>
                                                <div class="col-lg-9">
                                                      <erorr-validate :isErorr="erorrConf" :text="textErorrConf" />
                                                      <input type="password" placeholder="Mật khẩu cũ" class="form-control input-sm"
                                                            v-model="confirm"
                                                            @blur="onBlurValidateTypeInput(confirm, 'text', 'inpConf')"
                                                            @input="onKeypressTypeInput(confirm, 'text', 'inpConf')" />
                                                </div>
                                          </div>
                                          <div class="form-group clearfix text-center">
                                                <button type="submit" class="btn btn-green"> Xác Nhận </button>
                                          </div>
                                    </form>
                              </div>
                        </div>
                  </div>
            </section>
      </main>
</template>
<script>
import DxSelectBox from "devextreme-vue/select-box";
import { validateEmail, validatePhoneNumber } from '@/methods/index';
import { mapState, mapActions } from "vuex";
export default {
      name: "FormCustomer",
      components: { DxSelectBox },
      created() {
            this.fetchProvinces();
            document.title = this.$route.meta.title;
            if(Object.keys(this.$store.state.customer).length > 0){
                  this.name =  this.$store.state.customer.fullName,
                  this.phone = this.$store.state.customer.phone,
                  this.email = this.$store.state.customer.email,
                  this.selectedProvince = this.$store.state.customer.city,
                  this.selectedDistrict = this.$store.state.customer.quan,
                  this.selectedWard = this.$store.state.customer.phuong,
                  this.address = this.$store.state.customer.address
            }
            if(this.$route.name == "edit"){
                  this.storeCustomerInfo = true;
            }else{
                  this.storeCustomerInfo = false;
            }
      },
      computed: {
            ...mapState(["provinces", "districts", "wards"]),
      },
      
      mounted() {
            document.querySelector(".container").classList.add("fadeIn");
      },
      data() {
            return {
                  erorrName: false,
                  erorrAddress: false,
                  erorrMobile: false,
                  erorrEmail: false,
                  textErorrName: "",
                  textErorrAddress:"",
                  textErorrEmail:"",
                  textErorrMobile:"",
                  name: "",
                  email: "",
                  phone: "",
                  address: "",
                  selectedProvince: null, // Tỉnh được chọn
                  selectedDistrict: null, // Quận được chọn
                  selectedWard: null, // Phường được chọn
                  phuong: "Chọn Phường/ xã",
                  quan: "Chọn Quận/ huyện",
                  city: "Chọn Tỉnh/ thành phố",
                  erorrProvince: false,
                  erorrDistrict: false,
                  erorrWard: false,
                  erorrPasOld: false,
                  erorrPasNew: false,
                  erorrConf:false,
                  textErorrPasOld: "",
                  textErorrPasNew:"",
                  textErorrConf:"",
                  pasOld:"",
                  pasNew:"",
                  confirm:"",
                  storeCustomerInfo: true,
                  getCustomer: {}
            }
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
            submitForm() {
                  this.getCustomer = {
                        customer_id : this.$store.state.customer.customer_id,
                        fullName: this.name,
                        email: this.email,
                        phone: this.phone,
                        address: this.address,
                        city: this.selectedProvince, // Tỉnh được chọn
                        quan: this.selectedDistrict, // Quận được chọn
                        phuong: this.selectedWard, 
                        pasOld: this.pasOld,
                        pasNew: this.pasNew,
                        confirm: this.confirm,

                  }
                  console.log(this.getCustomer);

            },
            onBlurValidateTypeInput(value, type, display) {
                  if (value == "") {
                        if (display == "inpName") {
                              this.erorrName = true;
                              this.textErorrName = "Trường này bắt buộc";
                        } else if (display == "inpMobile") {
                              this.erorrMobile = true;
                              this.textErorrMobile = "Trường này bắt buộc";
                        } else if (display == "inpEmail") {
                              this.erorrEmail = true;
                              this.textErorrEmail = "Trường này bắt buộc";
                        }else if(display == 'inpOld') {
                              this.erorrPasOld = true;
                              this.textErorrPasOld = "Trường này bắt buộc"
                        } 
                        else if(display == 'inpNew') {
                              this.erorrPasNew = true;
                              this.textErorrPasNew = "Trường này bắt buộc"
                        } 
                        else if(display == 'inpConf') {
                              this.erorrConf = true;
                              this.textErorrConf = "Trường này bắt buộc"
                        } 
                        else {
                              this.erorrAddress = true;
                              this.textErorrAddress = "Trường này bắt buộc";
                        }

                  } else {
                        if (validateEmail(value) && type == "email") {
                              this.erorrEmail = false;
                        } else if (validatePhoneNumber(value) && type == "mobile") {
                              this.erorrMobile = false;
                        } else if (type == "text") {
                              if (display == "inpName") {
                                    this.erorrName = false;
                              }else if(display == "inpOld"){
                                    this.erorrPasOld =false;
                              }else if(display == "inpNew"){
                                    this.erorrPasNew = false;
                              }else if(display == "inpConf"){
                                    if(this.confirm == this.pasNew){
                                          this.erorrConf = false;
                                    }else {
                                          this.textErorrConf = "Mật Khẩu chưa trùng khớp!"
                                          this.erorrConf = true;
                                    }
                              }
                              else {
                                    this.erorrAddress = false;
                              }
                        } else {
                              if (display == "inpMobile") {
                                    this.erorrMobile = true;
                                    this.textErorrMobile = "Dữ liệu không hợp lệ";
                              } else if (display == "inpEmail") {
                                    this.erorrEmail = true;
                                    this.textErorrEmail = "Dữ liệu không hợp lệ";
                              }
                        }
                  }
            },

            onKeypressTypeInput(value, type,display) {
                  setTimeout(() => {
                        if (value == "") {
                        if (display == "inpName") {
                              this.erorrName = true;
                              this.textErorrName = "Trường này bắt buộc";
                        } else if (display == "inpMobile") {
                              this.erorrMobile = true;
                              this.textErorrMobile = "Trường này bắt buộc";
                        } else if (display == "inpEmail") {
                              this.erorrEmail = true;
                              this.textErorrEmail = "Trường này bắt buộc";
                        }else if(display == 'inpOld') {
                              this.erorrPasOld = true;
                              this.textErorrPasOld = "Trường này bắt buộc"
                        } 
                        else if(display == 'inpNew') {
                              this.erorrPasNew = true;
                              this.textErorrPasNew = "Trường này bắt buộc"
                        } 
                        else if(display == 'inpConf') {
                              this.erorrConf = true;
                              this.textErorrConf = "Trường này bắt buộc"
                        } 
                        else {
                              this.erorrAddress = true;
                              this.textErorrAddress = "Trường này bắt buộc";
                        }

                  } else {
                        if (validateEmail(value) && type == "email") {
                              this.erorrEmail = false;
                        } else if (validatePhoneNumber(value) && type == "mobile") {
                              this.erorrMobile = false;
                        } else if (type == "text") {
                              if (display == "inpName") {
                                    this.erorrName = false;
                              }else if(display == "inpOld"){
                                    this.erorrPasOld =false;
                              }else if(display == "inpNew"){
                                    this.erorrPasNew = false;
                              }else if(display == "inpConf"){
                                    if(this.confirm == this.pasNew){
                                          this.erorrConf = false;
                                    }else {
                                          this.textErorrConf = "Mật Khẩu chưa trùng khớp!"
                                          this.erorrConf = true;
                                    }
                              }
                              else {
                                    this.erorrAddress = false;
                              }
                        } else {
                              if (display == "inpMobile") {
                                    this.erorrMobile = true;
                                    this.textErorrMobile = "Dữ liệu không hợp lệ";
                              } else if (display == "inpEmail") {
                                    this.erorrEmail = true;
                                    this.textErorrEmail = "Dữ liệu không hợp lệ";
                              }
                        }
                  }
                  }, 500)
            },
      }
}
</script>
<style scoped>
article,
aside,
details,
figcaption,
figure,
footer,
header,
hgroup,
main,
menu,
nav,
section,
summary {
      display: block;
}

main {
      padding-top: 30px;
}

.container {

      padding-right: 15px;
      padding-left: 15px;
      margin-right: auto;
      margin-left: auto;
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

@media (min-width: 1200px) {
      .container {
            width: 1170px;
      }
}

@media (min-width: 1200px) {
      .container {
            max-width: 1175px;
            width: auto;
            padding: 0;
      }
}

.animated {
      -webkit-animation-duration: 1s;
      animation-duration: 1s;
      -webkit-animation-fill-mode: both;
      animation-fill-mode: both;
}

.fadeIn {
      -webkit-animation-name: fadeIn;
      animation-name: fadeIn;
}

@keyframes fadeIn {
      0% {
            opacity: 0;
      }

      100% {
            opacity: 1;
      }
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

.row {
      margin-right: -15px;
      margin-left: -15px;
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
      .col-md-12 {
            width: 100%;
      }
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

h1 {
      font-size: 36px;
}

.text-center {
      text-align: center;
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
      .col-sm-8 {
            width: 66.66666667%;
            left: 50%;
            transform: translateX(-50%);
      }
}

.form-group {
      margin-bottom: 15px;
}

label {
      display: inline-block;
      max-width: 100%;
      margin-bottom: 5px;
      font-weight: 700;
}

@media (min-width: 768px) {
      .col-sm-3 {
            width: 25%;
      }
}

@media (min-width: 1200px) {

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
      .col-lg-15 {
            float: left;
      }
}

@media (min-width: 1200px) {
      .col-lg-9 {
            width: 75%;
      }
}

.form-control {
      display: block;
      width: 100%;
      height: 34px;
      padding: 6px 12px;
      font-size: 14px;
      line-height: 1.42857143;
      color: #555;
      background-color: #fff;
      background-image: none;
      border: 1px solid #ccc;
      border-radius: 4px;
      -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
      box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
      -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
      -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
      transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
}

.input-sm {
      height: 44px;
      border-radius: 4px;
      padding: 5px 10px;
      font-size: 15px;
      line-height: 1.5;
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
      transition: opacity 150ms linear, color 150ms linear, background 150ms linear;
}
.breadcrumb-small {
      margin-bottom: 20px;
}
.breadcrumb-small a ,.breadcrumb-small span {
      font-size: 15px;
}
.breadcrumb-small span:nth-child(2) {
      margin: 0 3px;
}
</style>