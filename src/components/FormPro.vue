<template>
    <div class="col-md-4 col-sm-5 col-xs-12" id="detail-product">
                <div class="product-title">
                    <h1>{{ titlePro }}</h1>
                    <span class="pro-soldold">Tình trạng: 
                        <span class="statusProduct">{{ status }}</span>
                    </span>
                </div>
                <div class="product-price sale-undo" id="price-preview">
                    <p class="pro-price highlight tp_product_price">{{ price }}</p>
                </div>
                <form @submit="post" id="add-item-form" class="variants clearfix">
                    <div class="select-swatch clearfix ">
                        <div id="variant-swatch-0" class="borderImgRadius color_each swatch clearfix" >
                            <div class="header">Màu sắc   
                                <span class="nameColor" v-show="item.selected" v-for="(item,ind) in listcolors" :key="ind">{{ item.name }}</span>
                            </div>
                            <div class="select-swap attr-color req">
                                <div class=" n-sd swatch-element color" v-for="(itemColor,index) in listcolors" :key="index"  @mouseover="onSelectedColor(itemColor)" @click="onSelectedColor(itemColor)">
                                    <label for="" :class="[itemColor.selected ? 'active' : '']">
                                        <img :src="require('@/assets/img/' + itemColor.image)" alt="">
                                    </label>
                                   
                                </div>
                                <tool-tip 
                                    :isToolTip="isToolTip"
                                    :text="textToolTip"/>
                            </div>
                        </div>
                        <div id="variant-swatch-1" class=" swatch clearfix">
                            <div class="header">kích thước</div>
                            <div class="select-swap attr-size req">
                                <div class=" n-sd swatch-element" v-for="(item,index) in itemSize" :key="index" @click="onSelectSize(item)">
                                    <label for="" :class="{ active: item.selected}">
                                        <span class="spanP">{{ item.value }}</span>
                                        <img src="../assets/img/soldout.png" class="crossed-out" alt="">
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="selector-actions">
                        <div class="quantity-area clearfix hide">
                            <input type="button" class="qty-btn" value="-">
                            <input type="text" id="quantity" name="quantity" value="1" min="1" class="quantity-selector" max="80">
                            <input type="button" class="qty-btn" value="+">
                        </div>
                        <div class="wrap-addcart clearfix">
                            <button type="button" id="add-to-cart" class="btnAddToCart">SỞ HỮU NGAY</button>
                        </div>
                    </div>
                </form>
                <div class="product-description">
                    <div class="title-bl">
                        <h2>Thông số sản phẩm
                            <i v-if="!isOpenPlus" class="fa-solid fa-plus" @click="changeIcon"></i>
                            <i v-else class="fa-sharp fa-solid fa-minus" @click="changeIcon"></i>
                            <!-- <span class="icon-open"></span> -->
                        </h2>
                    </div>
                    <div class="description-content" :class="{disBlog : isOpenPlus}">
                        <div class="main_details">Đang cập nhật nội dung.</div>
                    </div>
                </div>
                <div class="product-description">
                    <div class="title-bl">
                        <h2>Mô Tả Sản Phẩm
                            <i v-if="!isOpenDes" class="fa-solid fa-plus" @click="changeDes"></i>
                            <i v-else class="fa-sharp fa-solid fa-minus" @click="changeDes"></i>
                            <!-- <span class="icon-open"></span> -->
                        </h2>
                    </div>
                    <div class="description-content" :class="{disBlog : isOpenDes}">
                        <div class="description-productdetail">
                            <p style="text-align:justify;">
                                <span style="font-family:Arial, Helvetica, sans-serif;">Chất liệu:</span>
                                <br>
                                <span style="font-family:Arial, Helvetica, sans-serif;">►100% Cotton mềm mại, thấm hút mồ hôi tốt, độ bền cao</span>
                            </p>
                            <p style="text-align:justify;"><span style="font-family:Arial, Helvetica, sans-serif;">Kiểu dáng:</span><br><span style="font-family:Arial, Helvetica, sans-serif;">►Form Classic rộng rãi thoải mái, phù hợp vóc dáng người Việt.</span></p>
                            <p style="text-align:justify;"><span style="font-family:Arial, Helvetica, sans-serif;">Chi tiết:</span><br><span style="font-family:Arial, Helvetica, sans-serif;">►Màu sắc cơ bản dễ phối đồ, có 3 màu: Đen, Trắng, Nâu</span><br><span style="font-family:Arial, Helvetica, sans-serif;">►Họa tiết chữ in trước ngực tạo điểm nhấn trẻ trung, năng động</span><br><span style="font-family:Arial, Helvetica, sans-serif;">►Đẹp hơn khi phối cùng quần âu, quần Kaki, quần Short.</span></p>
                        </div>
                    </div>
                </div>
                <center class="centerDetial">
                    <a href="#">Xem chi tiết sản phẩm &gt;&gt;</a>
                </center>
            </div>
</template>
<script>

export default {
    name:"FormPro",
    props:{
        titlePro:{
            type:String,
            default: "",
        },
        status:{
            type: String,
            default: "Còn Hàng"
        },
        price:{
            type:String,
            default:""
        },
        listcolors:{
            type:Array,
            default: () => [
                {
                    selected : false,
                    name : "Be",
                    image : "sp3.webp"
                }
            ]
        },
        itemSize:{
            type:Array,
            default: () => [
                {
                    value : "M",
                    selected: false
                }
            ]
        },
    },
    data(){
        return{
            isOpenPlus : false,
            isOpenDes:false,
            isToolTip:false,
            textToolTip: ""
        }
    },
    methods:{
        changeIcon(){
            this.isOpenPlus = !this.isOpenPlus;
        },
        changeDes(){
            this.isOpenDes = !this.isOpenDes;
        },
        onSelectedColor(color){
            color.selected = !color.selected;
            this.isToolTip = !this.isToolTip;
            this.textToolTip = color.name;
        },
        onSelectSize(size){
            size.selected = !size.selected;
             
        }
    }
}
</script>
<style scoped>
.col-md-4 {
    width: 33.33333333%;
    float: left;
    position: relative;
    min-height: 1px;
    padding-right: 15px;
    padding-left: 15px;
}
.product-title {
    padding: 0 0 10px;
    border-bottom: 1px dotted #dfe0e1;
}
.product-title h1 {
    font-size: 16px;
    font-weight: 700;
    margin: 0 0 10px;
    line-height: initial;
}
.statusProduct {
    color: #000;
    font-weight: 700;
}
.product-price {
    padding: 10px 0;
}
p.pro-price.highlight {
    font-weight: 700;
    line-height: 21px;
}

p.pro-price {
    color: #000;
    font-size: 14px;
    margin: 0;
}
#add-item-form {
    margin: 0 0 20px;
}
.swatch {
    padding: 10px 0;
    width: 100%;
    float: left;
}
.swatch .header {
    margin: 0 0 10px;
    font-size: 13px;
    text-align: left;
    line-height: initial;
    font-weight: 700;
    text-transform: uppercase;
    float: left;
    width: 100%;
}
.nameColor {
    font-weight: 400;
    margin-left: 20px;
    text-transform: capitalize;
}
.swatch .select-swap {
    vertical-align: middle;
    float: left;
    position: relative;
}
.swatch .swatch-element {
    display: inline-block;
    margin-right: 8px;
    position: relative;
    vertical-align: bottom;
}


.swatch .swatch-element.color label {
    width: 35px;
    height: 35px;
    padding: 1px;
    border-radius: 50%;
    line-height: 28px;
    border: 1px solid #b0b0b0;
}
.swatch .swatch-element label.sd, .swatch .swatch-element label.active {
    border: 1.4px solid #000;
}
.swatch .swatch-element label {
    display: block;
    margin: 0;
    background: #fff;
    width: 40px;
    height: 40px;
    line-height: 38px;
    position: relative;
    border: 1px solid #d7d7d7;
    font-size: 14px;
    font-weight: 500;
    text-align: center;
    cursor: pointer;
    color: #333;
}
label {
    display: inline-block;
    max-width: 100%;
    margin-bottom: 5px;
    font-weight: 700;
}
.borderImgRadius.swatch .select-swap img {
    width: 27px;
    height: 27px;
    display: inline-block;
    border-radius: 100%;
    max-width: 100%;
    vertical-align: middle;
    border: 0;

}
.swatch .attr-size .swatch-element label {
    min-width: 40px;
    padding: 0 3px;
    width: auto;
    margin-bottom: 5px;
}

.swatch .swatch-element label {
    display: block;
    margin: 0;
    background: #fff;
    width: 40px;
    height: 40px;
    line-height: 38px;
    position: relative;
    border: 1px solid #d7d7d7;
    font-size: 14px;
    font-weight: 500;
    text-align: center;
    cursor: pointer;
    color: #333;
}
label {
    display: inline-block;
    max-width: 100%;
    margin-bottom: 5px;
    font-weight: 700;
}
.swatch .select-swap img.crossed-out {
    position: absolute;
    width: 100%;
    height: 100%;
    left: 0;
    top: 0;
}
.swatch .swatch-element .crossed-out {
    display: none;
    max-width: 100%;
    vertical-align: middle;
    border: 0;
}
.spanP{
    color: #333;
    font-size: 14px;
}
.selector-actions {
    width: 100%;
    float: left;
}
.quantity-area {
    margin-bottom: 15px;
    display: flex;
}

.hide {
    display: none!important;
}
.quantity-area input.qty-btn {
    float: left;
    outline: none;
    border-radius: 0;
    display: block;
    margin: 0;
    background: #fff;
    width: 40px;
    height: 40px;
    line-height: 20px;
    position: relative;
    border: 1px solid #e5e5e5;
    font-weight: 400;
    text-align: center;
    cursor: pointer;
    font-size: 20px;
}

button, html input[type=button], input[type=reset], input[type=submit] {
    /* -webkit-appearance: button; */
    cursor: pointer;
}
button, input, select, textarea {
    /* font-family: inherit; */
    font-size: inherit;
    line-height: inherit;
}
input {
    line-height: normal;
}
button, input, optgroup, select, textarea {
    margin: 0;
    font: inherit;
    color: inherit;
}
.quantity-area input#quantity {
    padding: 0;
    /* -webkit-appearance: none; */
    float: left;
    outline: none;
    border-radius: 0;
    display: block;
    margin: 0;
    background: #fff;
    width: 60px;
    height: 40px;
    line-height: 20px;
    position: relative;
    border: 1px solid #e5e5e5;
    font-weight: 400;
    text-align: center;
    cursor: pointer;
    font-size: 14px;
    border-left: none;
    border-right: none;
}
.wrap-addcart {
    margin-bottom: 15px;
    display: flex;
}
.wrap-addcart button.btnAddToCart:first-child {
    margin-right: 10px;
}
.wrap-addcart button {
    width: 47%;
    min-height: 50px;
    background: #000;
    border: none;
    font-size: 15px;
    text-transform: uppercase;
    color: #fff;
    outline: none;
    transition: all .3s ease-in-out 0s;
    -moz-transition: all .3s ease-in-out 0s;
    -o-transition: all .3s ease-in-out 0s;
    -webkit-transition: all .3s ease-in-out 0s;
    -ms-transition: all .3s ease-in-out 0s;
    float: left;
    padding: 7px 0;
}
.product-description {
    margin: 0 0 10px;
    padding: 0 0 10px;
    border-bottom: 1px solid #e7e7e7;
}
.product-description .title-bl h2 {
    text-transform: uppercase;
    font-size: 13px;
    margin: 0;
    position: relative;
}
.icon-open {
    font-family: 'FontAwesome' !important;
    position: absolute;
    right: 0;
    top: 0;
    cursor: pointer;
}
.main_details {
    margin: 10px 0 0;
    overflow: hidden;
}
.description-productdetail {
    margin: 15px 0 0;
}
.description-productdetail * {
    font-family: Arial,Helvetica,sans-serif;
}

.description-productdetail * {
    font-size: 13px !important;
}
p {
    margin: 0 0 10px;
    line-height: 21px;
}
.centerDetial a {
    text-decoration: underline;
}
.fa-solid, .fas {
    /* font-weight: 900; */
    position: absolute;
    right: 0;
    font-size: 17px;
    cursor: pointer;
}
.description-content{
    display: none;
    transform: scaleY(0);
    transform-origin: top;
    transition: transform .57s ease;
}
.disBlog{
    display: block;
    transform: scaleY(1);
}
.disNon{
    display: none;
}
form{
    display: flex;
    flex-direction: column;
}
    
</style>