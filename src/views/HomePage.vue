<template>
     <div class="main">
        <!-- main slide -->
        <div class="sec-slide">
            <span>
                <img src="@/assets/img/20230410_y32atDwK.webp" alt="">
            </span>
        </div>
        <!-- banner -->
        <aside>
            <div class="baner">
                <div class="baner1">
                    <span>
                       <a href="">
                         <img src="@/assets/img/ban1.webp" alt="">
                         <span></span> <span></span> <span></span> <span></span>
                       </a>
                        <div class="text-con">Đổi trả trong vòng 5 ngày</div>
                        <button class="banner-btn">Xem chi tiết</button>
                    </span>
                </div>
                <div class="baner1">
                    <span>
                       <a href="">
                         <img src="@/assets/img/ban2.webp" alt="">
                         <span></span> <span></span> <span></span> <span></span>
                       </a>
                        <div class="text-con">Kiểm tra hàng trước khi thanh toán</div>
                        <button class="banner-btn">Xem chi tiết</button>
                    </span>
                </div>
                <div class="baner1">
                    <span>
                       <a href="">
                         <img src="@/assets/img/ban3.webp" alt="">
                         <span></span> <span></span> <span></span> <span></span>
                       </a>
                        <div class="text-con">HỖ TRỢ SHIP cho đơn hàng từ 500K</div>
                        <button class="banner-btn">Xem chi tiết</button>
                    </span>
                </div>
            </div>
        </aside>
        <!-- sản phẩm mới -->
        <list-products 
            :labelText="labelTextProductNew"
            :listProducts = "listNewProducts"
        />
        <!-- sản phẩm bán chạy -->
        <list-products 
            :labelText="labelTextProductBestSeller"
            :listProducts = "listNewProducts"
        />
        <!-- sản phẩm sale -->
        <list-products 
            :labelText="labelTextProductSale"
            :isHasChildText = true
            :optionText = "optionProSale"
            :listProducts = "listNewProducts"
        />
        <!-- sản phâm áo nam -->
        <list-products 
            :labelText="labelTextProductMenshirt"
            :isHasChildText = true
            :optionText = "optionProMenshirt"
            :listProducts = "listNewProducts"
        />
        <!-- sản phẩm quần nam -->
        <list-products 
            :labelText="labelTextProductMentrousers"
            :isHasChildText = true
            :optionText = "optionProMentrousers"
            :listProducts = "listNewProducts"
        />
        <!-- phụ kiện -->
        <list-products 
            :labelText="labelTextPhukien"
            :isHasChildText = true
            :optionText = "optionProPhukien"
            :listProducts = "listNewProducts"
        />
        <!-- album -->
        <al-bum :labelText = "textAlbum"
                :listAlbum = "listAlbum"
        />
        <!-- tin tức -->
        <al-bum :labelText = "textTinTuc"
                :isHasDescribe = true
                :listAlbum = listAlbumTinTuc
        />
    </div>
</template>
<script>
import{optionProSale,optionProMenshirt,optionProMentrousers,optionProPhukien,listAlbum,listAlbumTinTuc,listNewProductHomePages} from '@/resource/TestData'
export default {
  name: 'HomePage',
  
  data(){
    return{
        labelTextProductNew : "Sản phẩm Mới",
        labelTextProductBestSeller: "sản phẩm bán chạy",
        labelTextProductSale : "sale",
        labelTextProductMenshirt: "áo nam",
        labelTextProductMentrousers:"quần nam",
        labelTextPhukien:"Phụ kiện",
        textAlbum:"look look",
        textTinTuc: "Tin tức",
        optionProSale:optionProSale,
        optionProMenshirt:optionProMenshirt,
        optionProMentrousers:optionProMentrousers,
        optionProPhukien:optionProPhukien,
        listAlbum:listAlbum,
        listAlbumTinTuc:listAlbumTinTuc,
        listNewProducts :listNewProductHomePages
    }

  }
}
</script>
<style scoped>
/* .innerHomeStore{
    width: 100%;
    height: 317px;
    padding: 30px 0;
}
.innerHomeStore > .imgeStore img{
    height: 317px;
} */
.main{
    margin-bottom: 100px;
}
.sec-slide{
    width: 100%;
   
}
.sec-slide > span > img{
    width: 100%;
}
.baner{
    display: flex;
    align-items: center;
    overflow: hidden;
    width: 100%;
    justify-content: center;
    margin: 50px 0;
    padding: 0 64px;
}
.baner1{
    width: 31%;
    padding: 0 15px;
}
.baner > .baner1 > a{
    position: relative;
}
.baner1 > span{
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin: 8% 0 0;
}
.baner1 > span > a{
    overflow: hidden;
    position: relative;
}
.baner1 > span > a span{
    position: absolute;
    background-color: rgba(255,255,255,.7);
    display: block;
    margin: 12px;
    transition: all 0.5s linear;
   
}
.baner1 > span > a span:nth-child(2){
    top: 0;
    left: 0;
    width: 0;
    height: 2px;
}
.baner1 > span > a span:nth-child(3){
    top: 0;
    right: 0;
    width: 2px;
    height: 0;
}
.baner1 > span > a span:nth-child(4){
    bottom: 0;
    right: 0;
    width: 0;
    height: 2px;
}
.baner1 > span > a span:nth-child(5){
    bottom: 0;
    left: 0;
    width: 2px;
    height: 0;
}
.baner1 > span > a:hover span:nth-child(odd){
    height: calc(100% - 24px);
}
.baner1 > span > a:hover span:nth-child(even){
    width: calc(100% - 24px);
}
.baner1 span a img{
 width: 100%;
 border-radius: 2px;
 opacity: 1;
transition: .3s;
}
.baner1 span a img{
   
    /* transform: scale(0,1); */
    border-left-color: transparent;
    border-right-color: transparent;
    top: 10px;
    bottom: 10px;
    left: 10px;
    right: 10px;
}
.text-con {
    margin: 7px 0;
    font-size: 14px;
}
a {
    transition: opacity .15s linear,color .15s linear,background .15s linear;
}
.banner-btn{
    border: 1px solid;
    padding: 5px 10px;
    display: inline-block;
    font-size: 13px;
    text-transform: uppercase;
}
.banner-btn:hover{
    background: #000;
    color: #fff;
    cursor: pointer;
}
</style>