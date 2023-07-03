<template>
    <main>
         <!-- main content -->
    <div class="main-content">
      <div class="breadcrumb-shop clearfix">
        <div class="padding-lf-40 clearfix">
          <div class="head-left">
            <a href="/">
              <i class="fa-sharp fa-solid fa-house-chimney"></i>
              <span>Trang chủ</span>
            </a>
            <a href="/quan-lot-pc501330.html">
                <span>{{ categoryName}}</span>
            </a>
            
            <span>{{ categoryName}}</span>
            
          </div>
        </div>
      </div>
      <div style="display: flex;">
          <div class="container">
            <div class="row product-detail-wrapper">
              <div class="clearfix product-detail-main pr_style_01">
                <div class="row">
                  <slider-pro 
                  owlStage="width-100"
                  owlItem="width-100"
                  />
                  <form-pro
                  :isDetail= true 
                  :chatlieu="chatlieu"
                  :kieudang="kieudang"
                  :chitiet="chitiet"
                  :itemSize="itemSize"
                  titlePro="Quần nam cao cấp"/>
                </div>
              </div>
            </div>
          </div>
      </div>
    </div>
    </main>
</template>
<script>
// import { dynamicUrlProduct } from '@/methods/index'
export default {
    name: "DetailtProduct",
    data(){
        return{
            categoryName : "",
            chatlieu:[
              "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
              "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
              "2% Spandex tạo độ co giãn, thoải mái khi vận động"
            ],
            kieudang:["Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch."],
            chitiet:[
              "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
              "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
              "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung."
            ],
            itemSize:[
                {
                    value : "S",
                    selected: false
                },
                {
                    value : "M",
                    selected: false
                },
                {
                    value : "L",
                    selected: false
                },
                {
                    value : "XL",
                    selected: false
                },
                
                ],
            // nameP:"Áo Dài Việt Nam"
        }
    },
    methods:{
    async dynamicTitleName(){
      this.categoryName = this.$route.meta.title;
    }
  },
   async created()  {
    await this.dynamicTitleName();
    // console.log(this.$route.path);
  },
  mounted(){
    // console.log(dynamicUrlProduct(this.nameP));
  }
}
</script>
<style scoped>
main{
  display: block;
}
*,
body {
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
.head-left > a:nth-child(2) > span{
    color: #777 !important;
    font-weight: 500;
}
.head-left > a:nth-child(2)::before{
    content: "|";
    padding: 0 10px;
    color: #ccc;
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
.container {
    max-width: 1175px;
    width: auto;
    padding: 0;
    margin-right: auto;
    margin-left: auto;
}
.product-detail-wrapper {
    padding: 30px 0 60px;
    display: flow-root;
}

.row {
    margin-right: -15px;
    margin-left: -15px;
}
.product-detail-main {
    margin-bottom: 80px;
    display: flow-root;
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

</style>