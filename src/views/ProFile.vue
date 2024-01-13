<template>
      <div class="page-user">
            <div class="container">
                  <h1 class="title-user">Tài Khoản</h1>
                  <div class="clearfix"></div>
                  <div class="row">
                        <div class="interlist col-sm-6 col-xs-12">
                              <div class="inter-title">Thông tin tài khoản</div>
                              <div class="clearfix"></div>
                              <div class="inter-info">
                                    <a href="#" class="text-green checkPoints">Điểm Tích lũy của bạn:
                                          <strong>4</strong>
                                    </a>
                                    <a href="#" class="text-green">Cấp độ khách hàng:
                                          <strong>DIAMOND</strong>
                                    </a>
                                    <a href="/profile/edit" class="text-green">Thay đổi thông tin tài khoản</a>
                                    <a href="/profile/changepassword" class="text-green">Thay đổi mật khẩu</a>
                                    <a href="#singOut" class="text-green" @click="logOut">
                                          <i class="fa fa-sign-out"></i>
                                          Đăng Xuất
                                    </a>
                              </div>
                        </div>
                        <div class="interlist col-sm-6 col-xs-12">
                              <div class="inter-title">Lịch sử order</div>
                              <div class="clearfix"></div>
                              <div class="inter-info">
                                    <a href="#" class="text-green">Lịch sử order</a>
                              </div>
                        </div>
                        <div class="clearfix"></div>
                  </div>
            </div>
      </div>
</template>
<script>
import { store } from '@/store';
export default {
      name: "ProFile",
      created() {
            document.title = this.$route.meta.title;
      },
      methods: {
            logOut() {
                  if (Object.keys(this.$store.state.customer).length > 0) {
                        window.location.href = "/";                     
                        store.commit("removeCustomer");                                   
                  }
            },
      
      }
}
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

.page-user {
      font-size: 14px;
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

:after,
:before {
      -webkit-box-sizing: border-box;
      -moz-box-sizing: border-box;
      box-sizing: border-box;
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

h1.title-user {

      font-size: 31px;
      font-weight: bold;
      color: #394a5d;
      text-align: center;
      margin-top: 40px;
      margin: 0 0 13px 0;
      line-height: 1.2;
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
      .col-sm-6 {
            width: 50%;
      }
}

.interlist {
      min-height: 100px;
      margin-top: 30px;
}

.inter-title {
      font-size: 18px;
      font-weight: 700;
      color: #545454;
      padding-bottom: 10px;
      margin-bottom: 10px;
      border-bottom: 1px solid #545454;
}

.inter-info {
      font-size: 14px;
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

.inter-info a {
      display: block;
      width: 100%;
      clear: both;
      margin-bottom: 15px;
      font-size: 14px;
}

strong {
      font-weight: 700;
}</style>