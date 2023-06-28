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
            <span>Áo Nam</span>
          </div>
        </div>
      </div>
      <div class="padding-lf-40">
        <div class="wrap-collection-body">
          <div class="wrap-collection-title">
            <div class="heading-collection">
              <div class="col-md-8 col-sm-12 col-xs-12">
                <h2 class="title tp_title titleCategory">Áo Nam</h2>
                <div class="filter-custom">
                  <span>Bộ lọc</span>
                  <div class="groupFilterNew">
                    <div class="titleFilter">
                      <div class="layered_subtitle">
                        <span>Màu sắc</span>

                        <i class="fa fa-sort-down"></i>
                      </div>
                      <div class="layered_subtitle">
                        <span>Kích cỡ</span>

                        <i class="fa fa-sort-down"></i>
                      </div>
                      <div class="layered_subtitle">
                        <span>Khoảng giá</span>

                        <i class="fa fa-sort-down"></i>
                      </div>
                    </div>
                    <div class="contentFilter"></div>
                  </div>
                </div>
              </div>
              <div class="col-md-4 col-sm-12 col-xs-12">
                <the-dropdown
                :itemData="itemSort"
                 />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>
<script>
export default {
  name: "CategoryPage",
  data(){
    return{
      itemSort : ["Mới nhất" , "Giá giảm dần","Giá tăng dần","Sale"],
      newLeast:"Mới nhất",
    }
  }
};
</script>
<style scoped>
*,
body {
  line-height: 1.4;
}
.main-content {
  height: 100vh;
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
.col-md-8 {
  width: calc(100% * (2 / 3));
}
.col-md-4 {
  width: calc(100% / 3);
 
}

h2 {
  font-size: 28px;
  margin-bottom: 13px;
}

.filter-custom {
  display: flex;
  margin: 10px 0 30px;
  align-items: center;
}
.filter-custom > span {
  margin-right: 15px;
  padding: 10px 0;
  text-transform: uppercase;
  font-size: 15px;
}
.groupFilterNew {
  padding: 10px 0;
  width: 40%;
}
.titleFilter {
  display: flex;
  justify-content: space-between;
}
.layered_subtitle {
  display: flex;
}
.layered_subtitle > span {
  font-size: 15px;
  font-weight: 700;
  margin-right: 5px;
}
.fa-sort-down:before {
  color: #ccc;
}
</style>
