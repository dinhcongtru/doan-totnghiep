<template>
     <section class="sec-pro">
            <div class="sec-head">
                <h1>{{ labelText }}</h1>
               <div class="mert-row" v-show="isHasChildText">
                    <span class="text" v-for="(textItem, index) in optionText" :key="index">{{ textItem }}</span>
               </div>
            </div>
            
            <div class="list-pro">
                <span v-for="(itemPro,index) in listProducts" :key="index">
                    <div class="p1">
                        <a :href="itemPro.hrefPro">
                            <img class="img-main1" :src="require('@/assets/img/' + itemPro.imgProMain)" alt="">
                            <div class="image-pro--cover">
                                <img @click="changImage" :ref="count" class="img-cover" :src="require('@/assets/img/' + itemPro.imgProCover.img1)" alt="">
                                <img @click="changImage" :ref="count++" class="img-cover" :src="require('@/assets/img/' + itemPro.imgProCover.img2)" alt="">
                            </div>
                        </a>
                        <div class="name-pro">{{ itemPro.name }}</div>
                        <div class="cord">{{ itemPro.price }}</div>
                    </div>
                    <div class="addtocart">
                        <div class="cart-left">
                            <i class="fa-solid fa-cart-shopping"></i>
                            <span class="text-cart">{{ itemPro.textBuy }}</span>
                        </div>
                        <div class="cart-right">
                            <i class="fa-solid fa-eye"></i>
                            <span class="text-cart-right">{{ itemPro.textDes }}</span>
                        </div>
                    </div>
                </span>
            </div>
        </section>
</template>
<script>
    export default{
        name : "ListProducts",
        props: {
             // label h1
            labelText: {
            type: String,
            default: "default label", //mặc định label
            },
            // có child text hay không?
            isHasChildText:{
                type: Boolean,
                default: false // mặc định là false
            },
            //optionText danh mục sản phẩm
            optionText:{
                type: Array,
                 default: () => [
                   "text"
                ]
            },
            // list-ListProducts
            listProducts:{
                type:Array,
                default: () => [
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
                    }
                ]
            }
            
        },
        methods:{
            changImage(){
                // let imageCrrent = this.$refs.count;
            //    console.log(imageCrrent);
            }
        },
        mounted(){
            // console.log(this.$refs.count);
        },
        data(){
            return{
                count :1,
            }
        }
    }
</script>