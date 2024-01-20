<template>
  <main class="main-site main-childs">
    <the-loading :is_loading="isLoading"/>
    <div class="user-wrapper">
      <div class="user-nav anonymous-awe">
        <a
          rel="nofollow"
          :class="{ active: item.selected }"
          @click="onSingIn(item)"
          v-for="(item, index) in listSingIn"
          :key="index"
          >{{ item.name }}</a
        >
      </div>
      <form
        @submit.prevent="getCustomer(item)"
        id="formAcount"
        class="validate"
        v-show="item.selected"
        v-for="(item, index) in listSingIn"
        :key="index"
      >
        <input type="hidden" name="csrf" id="csrf" />
        <div class="form-group" v-if="!item.isSingin">
          <erorr-validate :isErorr="erorrUser" />
          <input
            v-model="username"
            type="text"
            id="username"
            placeholder="Họ tên"
            autocomplete="off"
            @blur="onBlur"
            @input="onKeypressUser"
          />
        </div>
        <div class="form-group" v-if="!item.isSingin">
          <erorr-validate :isErorr="erorrMobile" :text="textErorr" />
          <input
            v-model="mobile"
            type="text"
            id="mobile"
            placeholder="Điện Thoại"
            autocomplete="off"
            @blur="onBlurMobile"
            @input="onKeypress"
          />
        </div>
        <div class="form-group">
          <erorr-validate :isErorr="erorrEmail" :text="textErorrEmail" />
          <input
            v-model="email"
            type="text"
            id="email"
            :placeholder="[
              item.isSingin ? 'Nhập email hoặc Tên đăng nhập' : 'Email',
            ]"
            autocomplete="off"
            @blur="onBlurEmail"
            @input="onKeypressEmail"
          />
        </div>
        <div class="form-group">
          <erorr-validate :isErorr="erorrPassW" />
          <input
            v-model="password"
            type="password"
            id="password"
            :placeholder="[item.isSingin ? 'Mật khẩu' : 'Mật khẩu của bạn']"
            autocomplete="off"
            @blur="onBlurPass"
            @input="onKeypressPass"
          />
        </div>
        <button
          type="submit"
          id="btnsignin"
          class="btn btn-organ w__100"
          :class="[!item.isSingin ? 'btnsingup' : '']"
        >
          {{ item.name }}
        </button>
        <div class="user-foot text-center" v-show="item.isSingin">
          <a href="/user/getpassword" class="clearfix" rel="nofollow"
            >Quên mật khẩu?</a
          >
          <p class="clearfix">Hoặc đăng nhập với</p>
          <li class="loginFb" rel="nofollow">
            <span>
              <i class="fa fa-facebook"></i>
            </span>

            <a href="#">Đăng nhập bằng Facebook</a>
          </li>
          <li class="loginGg" rel="nofollow" style="position: relative">
            <span>
              <i class="fa fa-google"></i>
            </span>
            <GoogleLogin :callback="callback" />
            <a>Đăng nhập bằng Google</a>
          </li>
        </div>
      </form>
    </div>
  </main>
  <the-alert :erorr="erorrAlert" :message="message" :isAlert="isAlert" />
</template>
<script>
// import VueFacebookLogin from 'vue-facebook-login';
import { decodeCredential } from "vue3-google-login";
import { convertNameSingin,validateEmail,validatePhoneNumber } from "@/methods/index";
import { store } from "@/store";
import { mapActions } from "vuex";
import { RepositoryFactory } from "@/Repository/RepositoryFactory";
const customerRepository = RepositoryFactory.get("Customers");
export default {
  name: "SingIn",
  // components:{VueFacebookLogin},
  created() {
    document.title = this.$route.meta.title;
  },
  mounted() {
  
  },
  data() {
    return {
      erorrAlert: false,
      message:"",
      isAlert:false,
      isLoading: false,
      username: "",
      mobile: "",
      email: "",
      password: "",
      customer: {},
      listSingIn: [
        {
          isSingin: true,
          name: "Đăng nhập",
          selected: true,
        },
        {
          isSingin: false,
          name: "Đăng ký",
          selected: false,
        },
      ],
      erorrUser: false,
      erorrPassW: false,
      erorrEmail: false,
      erorrMobile: false,
      textErorr: "Trường này bắt buộc",
      textErorrEmail: "Trường này bắt buộc",
    };
  },
  methods: {
    ...mapActions(["getCartByCustomerID"]),
    callback(response){
      this.customer = {
        fullName: decodeCredential(response.credential).name,
        email: decodeCredential(response.credential).email,
      };
      this.loginBySocial(this.customer);
    },
    async loginBySocial(payload){
      try{ 
        await customerRepository.loginBySocial(payload).then((res) => {
          if(res.status == 200){
            this.customer = res.data;
            this.message = "Đăng nhập thành công !";
            this.isAlert = true;
            setInterval(() => {
              this.isAlert = false;
              window.location.href = "/";
            },1000)
            store.commit("handleAddCustomer", this.customer);
            this.getCartByCustomerID(this.customer.customer_id);
          }
        })
      }catch(erorr){
        console.log(erorr);
        this.erorrAlert = true;
        this.message = "Đăng nhập thất bại!";
        this.isAlert = true;
        setInterval(() => {
          this.isAlert = false;
        },1000)
      }
    },
    onKeypress() {
      setTimeout(() => {
        if (this.mobile == "") {
          this.erorrMobile = true;
          this.textErorr = "Trường này bắt buộc";
        } else {
          if (validatePhoneNumber(this.mobile)) {
            this.erorrMobile = false;
          } else {
            this.erorrMobile = true;
            this.textErorr = "Số điện thoại không hợp lệ";
          }
        }
      }, 500);
    },
    onKeypressUser() {
      setTimeout(() => {
        if (this.username == "") {
          this.erorrUser = true;
        } else this.erorrUser = false;
      }, 500);
    },
    onKeypressPass() {
      if (this.password == "") {
        this.erorrPassW = true;
      } else this.erorrPassW = false;
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
      }, 500);
    },
    onBlur() {
      if (this.username == "") {
        this.erorrUser = true;
      } else this.erorrUser = false;
    },
    onBlurPass() {
      if (this.password == "") {
        this.erorrPassW = true;
      } else this.erorrPassW = false;
    },
    onBlurMobile() {
      if (this.mobile == "") {
        this.erorrMobile = true;
        this.textErorr = "Trường này bắt buộc";
      } else {
        if (validatePhoneNumber(this.mobile)) {
          this.erorrMobile = false;
        } else {
          this.erorrMobile = true;
          this.textErorr = "Số điện thoại không hợp lệ";
        }
      }
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
   
    onSingIn(item) {
      this.isLoading = true;
      setTimeout(() => {
        this.listSingIn.forEach((item) => (item.selected = false));
        item.selected = !item.selected;
        this.username = "";
        this.mobile = "";
        this.email = "";
        this.password = "";
        this.erorrPassW = false;
        this.erorrUser = false;
        this.erorrEmail = false;
        this.erorrMobile = false;
        this.isLoading = false;
      },1000)
      
    },
    async getCustomer(item) {
      let invalidEmail = validateEmail(this.email);
      let invalidMobile = validatePhoneNumber(this.mobile);
      this.customer = {
          fullName: convertNameSingin(this.username),
          phone: this.mobile,
          email: this.email,
          password: this.password,
          product: [],
        };
        // trạng thái đăng Nhập
        if(item.isSingin){
          if(!invalidEmail && this.password == ""){
            this.erorrEmail = true;
            this.erorrPassW = true;
          }
          else if(!invalidEmail){
            this.erorrEmail = true;
          }else if(this.password == ""){
            this.erorrPassW = true;
          }
          else{
            // gọi api loggin
            try {
              await customerRepository.loginCustomer(this.customer).then((res) => {
                if (res.status == 200) {
                  this.customer = res.data;
                  this.message = "Đăng nhập thành công !";
                  this.isAlert = true;
                  setInterval(() => {
                    this.isAlert = false;
                    window.location.href = "/";
                  },1000)
                 
                  store.commit("handleAddCustomer", this.customer);
                  this.getCartByCustomerID(this.customer.customer_id);
                }            
              });             
            }catch(error) {
              console.log(error);
              this.erorrAlert = true;
              this.message = "Đăng nhập thất bại!";
              this.isAlert = true;
              setInterval(() => {
                this.isAlert = false;
              },1000)
            }
          }
        }else{
          // trạng thái đăng ký
          
          if(this.username == "" && this.password == "" && this.email == "" && this.mobile == "" && !invalidEmail && !invalidMobile ){
            this.erorrEmail = true;
            this.erorrMobile = true;
            this.erorrPassW = true;
            this.erorrUser = true;
          } else if(this.username == ""){
            this.erorrUser = true;
          }else if(this.password == ""){
            this.erorrPassW = true;
          }
          else if(!invalidEmail){
            this.erorrEmail = true;
          }
          else if(!invalidMobile){
            this.erorrMobile = true;
          }
          else{
            // get dữ liệu khách hàng đăng ký
            try {
              await customerRepository.registerCustomer(this.customer).then((res) => {
                console.log(res);
                if(res.status == 201) {
                  window.location.href = "/user/signin";
                }
              })
            } catch (error) {
              console.log(error);
              alert("Email này đã được đăng ký trước đó!")
            }
          }
        } 
    },
  },
};
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
  position: relative;
}
.user-wrapper {
  max-width: 600px;
  margin: auto;
  border: 1px solid #ccc;
}
.user-nav {
  border-bottom: 2px solid #cccccc63;
  overflow: hidden;
  box-shadow: 0 1px 3px rgba(146, 146, 146, 0.14);
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
.user-nav a {
  cursor: pointer;
  width: 50%;
  /* float: left; */
  display: inline-block;
  text-transform: uppercase;
  font-size: 18px;
  text-align: center;
  padding: 5px 10px;
  border-bottom: 2px solid transparent;
}
.user-nav a.active,
.user-nav a:hover {
  border-bottom: 2px solid #10a2f7;
}
.user-wrapper #formAcount {
  padding: 20px;
}
button,
input,
optgroup,
select,
textarea {
  margin: 0;
  font: inherit;
  color: inherit;
}
input {
  line-height: normal;
}
button,
input,
select,
textarea {
  font-family: inherit;
  font-size: inherit;
  line-height: inherit;
}
#formAcount input {
  font-size: 14px;
  width: 100%;
  clear: both;
  padding: 8px 12px;
  border: none;
  border-bottom: 1px solid #ccc;
}
.form-group {
  margin-bottom: 15px;
  position: relative;
}
button {
  overflow: visible;
}
button,
select {
  text-transform: none;
}
button,
html input[type="button"],
input[type="reset"],
input[type="submit"] {
  appearance: auto;
  -webkit-appearance: button;
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
#formAcount button {
  text-transform: uppercase;
  font-size: 18px;
  background: #000;
  color: #fff;
  border-color: #000;
}
#formAcount button,
#formAcount button:hover,
#formAcount button:focus {
  outline: 0;
}
.user-foot {
  font-size: 17px;
}

.text-center {
  text-align: center;
}
.user-foot a.clearfix {
  color: #007bff;
}

.user-foot a {
  margin: 10px 0;
  display: block;
  font-size: 17px;
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
p {
  margin: 0 0 10px;
}
p {
  margin: 0 0 10px 0;
  line-height: 21px;
  font-size: 17px;
}
.loginFb {
  width: 275px;
  background: #3b5998;
  display: inline-block;
}
.loginFb span,
.loginGg span {
  float: left;
  width: 50px;
  height: 100%;
  font-size: 31px;
  color: #fff;
  border-right: 1px solid #15416f;
}
.loginFb a,
.loginGg a {
  color: #fff;
}
.loginGg {
  width: 250px;
  background: #000;
  color: #fff;
  display: inline-block;
  margin-left: 20px;
}
.loginGg span {
  border-right: 1px solid #646668;
}
.fa {
  color: white;
  display: inline-block;
  font: normal normal normal 14px/1 FontAwesome;
  font-size: inherit;
  text-rendering: auto;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  font-size: 27px;
}
main {
  margin-bottom: 50px;
}
#formAcount .btnsingup {
  text-transform: uppercase;
  font-size: 18px;
  background: #fd6e1d;
  background: -webkit-gradient(
    linear,
    0% 0%,
    0% 100%,
    from(#fd6e1d),
    to(#f59000)
  );
  background: -webkit-linear-gradient(top, #f59000, #fd6e1d);
  background: -moz-linear-gradient(top, #f59000, #fd6e1d);
  background: -ms-linear-gradient(top, #f59000, #fd6e1d);
  background: -o-linear-gradient(top, #f59000, #fd6e1d);
  border: hidden;
  color: #252a2b;
}
</style>
