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
            <span>{{ categoryName}}</span>
          </div>
        </div>
      </div>
      <div class="padding-lf-40">
        <div class="wrap-collection-body">
          <div class="wrap-collection-title">
            <div class="heading-collection">
              <div class="col-md-8 col-sm-12 col-xs-12">
                <h2 class="title tp_title titleCategory">{{ categoryName}}</h2>
                <filter-product
                :colorData="colorData"
                :sizeData="sizeData"
                :princeData="princeData"/>
              </div>
              <div class="col-md-4 col-sm-12 col-xs-12">
                <the-dropdown
                :disabled="true"
                :itemData="itemSort"
                 />
              </div>
            </div>
          </div>
          <product-list 
          :isHasLabel = false
          :listProduct = listNewProducts
          />
        </div>
      </div>
    </div>
  </main>
</template>
<script>
import{itemSort,listNewProducts,colorData,sizeData,princeData} from '@/resource/TestData'
export default {

  name: "CategoryPage",
  data(){
    return{
      categoryName : this.$route.query.name,
      itemSort:itemSort,
      newLeast:"Mới nhất",
      listNewProducts:listNewProducts,
      colorData:colorData,
      sizeData:sizeData,
      princeData:princeData,
      
    }
  },
  // watch:{
  //   categoryName(value){
  //     if(value){
  //       this.dynamicTitleName();
  //     }
  //   }
  // },
  created() {
    this.$watch(
      () => this.$route.params,
      (toParams) => {
        this.dynamicTitleName(toParams)
        // document.title = this.categoryName;
      }
    );
   
  },
  methods:{
    async dynamicTitleName(){
      this.categoryName = this.$route.query.name;
      document.title = this.$route.query.name;
    }
  },
  
};
</script>
<style scoped>
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
  text-transform: uppercase;
  font-weight: 700;
}


</style>
