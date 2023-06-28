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
          <list-products
          styleSection="padding0"
          :isHasimgCover=false
          :isHasLabel = false
          :listProducts = listNewProducts />
        </div>
      </div>
    </div>
  </main>
</template>
<script>
import FilterProduct from '@/components/FilterProduct.vue';
import ListProducts from '@/components/ListProducts.vue';

export default {
  components: { FilterProduct, ListProducts },
  name: "CategoryPage",
  data(){
    return{
      categoryName : "",
      itemSort : ["Mới nhất" , "Giá giảm dần","Giá tăng dần","Sale"],
      newLeast:"Mới nhất",
      listNewProducts : [
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : "#",
                imgProMain : "sp2.webp",
                imgProCover : {
                    img1 : "sp3.webp",
                    img2 : "sp4.jpeg"
                },                      
                name : "name default",
                price : "price default",
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
        ],
        colorData:[
          { checkedColor : false, title : "Đỏ", background : "#FF0000" },     
          { checkedColor : false, title : "Than Tím", background : "#000044" },     
          { checkedColor : false, title : "Xanh", background : "#0000FF" },     
          { checkedColor : false, title : "Vàng", background : "#FFFF00" },     
          { checkedColor : false, title : "Ghi Đậm", background : "#808080" },     
          { checkedColor : false, title : "Nâu", background : "#663300" },     
          { checkedColor : false, title : "Hồng", background : "#FF0066" },     
          { checkedColor : false, title : "Be", background : "#" },     
          { checkedColor : false, title : "Đen", background : "#000000" },     
          { checkedColor : false, title : "Trắng", background : "#FFFFFF" },     
          { checkedColor : false, title : "Ghi", background : "#" },     
      ],
      sizeData:[
          {  checkedSize : false, size : "S" },
          {  checkedSize : false, size : "M" },
          {  checkedSize : false, size : "L" },
          {  checkedSize : false, size : "XL" },
          {  checkedSize : false, size : "2XL" },
      ],
      princeData:[
          { checkedPrice : false, price : "Dưới 200,000" },
          { checkedPrice : false, price : "Từ 200,000 - 500,000" },
          { checkedPrice : false, price : "Từ 500,000 - 1,000,000" },
          { checkedPrice : false, price : "Hơn 1,000,000" },
      ],
    
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
  }
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
}


</style>
