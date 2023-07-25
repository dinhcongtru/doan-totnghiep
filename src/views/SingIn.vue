<template>
  <main class="main-site main-childs">
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
        <!-- <a rel="nofollow" :class="{active : isSingUp}" @click="onSingUp">Đăng ký</a> -->
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
        <div class="form-group">
          <input
            v-model="username"
            type="text"
            id="username"
            :placeholder="[
              item.isSingin ? 'Nhập email hoặc Tên đăng nhập' : 'Họ tên',
            ]"
            autocomplete="off"
          />
        </div>
        <div class="form-group" v-if="!item.isSingin">
          <input
            v-model="mobile"
            type="text"
            id="mobile"
            placeholder="Điện Thoại"
            autocomplete="off"
          />
        </div>
        <div class="form-group" v-if="!item.isSingin">
          <input
            v-model="email"
            type="text"
            id="email"
            placeholder="Email"
            autocomplete="off"
          />
        </div>
        <div class="form-group">
          <input
            v-model="password"
            type="password"
            id="password"
            :placeholder="[item.isSingin ? 'Mật khẩu' : 'Mật khẩu của bạn']"
            autocomplete="off"
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
        <!-- <button
          type="submit"
          id="btnsignin"
          class="btn btn-organ w__100"
          :class="{ btnsingup: !item.isSingin }"
          v-else
        >
          Đăng Ký
        </button> -->
        <div class="user-foot text-center" v-show="item.isSingin">
          <a href="/user/getpassword" class="clearfix" rel="nofollow"
            >Quên mật khẩu?</a
          >
          <p class="clearfix">Hoặc đăng nhập với</p>
          <li class="loginFb" rel="nofollow">
            <span>
              <i class="fa fa-facebook"></i>
            </span>
            <a href="/user/fbsignin?redirect=/">Đăng nhập bằng Facebook</a>
          </li>
          <li class="loginGg" rel="nofollow">
            <span>
              <i class="fa fa-google"></i>
            </span>
            <a href="/user/ggsignin">Đăng nhập bằng Google</a>
          </li>
        </div>
      </form>
    </div>
  </main>
</template>
<script>
import {convertNameSingin} from '@/methods/index'
import { store } from "@/store";
export default {
  name: "SingIn",
  created() {
    document.title = this.$route.meta.title;
  },
  mounted() {
    console.log(this.$store.state.customer.product);
  },
  data() {
    return {
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
    };
  },
  methods: {
    onSingIn(item) {
      this.listSingIn.forEach((item) => (item.selected = false));
      item.selected = !item.selected;
    },
    getCustomer(item) {
      this.customer = {
        idCustom: 1,
        name: convertNameSingin(this.username),
        phone: this.mobile,
        email: this.email,
        password: this.password,
        product: [],
      };
      
      item.isSingin ? window.location.href = "/" : window.location.href = "/user/signin" ;
      if(item.isSingin)  store.commit("handleAddCustomer" ,this.customer);
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
  padding: 0 5px;
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
