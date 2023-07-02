<template>
     <section class="sec-pro" :class="styleSection">
            <div class="sec-head" v-show="isHasLabel">
                <h1>{{ labelText }}</h1>
               <div class="mert-row" v-show="isHasChildText">
                    <span class="text" v-for="(textItem, index) in optionText" :key="index">{{ textItem }}</span>
               </div>
            </div>
            
            <div class="list-pro">
                <span v-for="(itemPro,index) in listProducts" :key="index">
                    <router-link :to="{ name: 'product-detail', params: { id: index }, query: {name: itemPro.name }}">
                        <div class="p1">
                            <a>
                                <img class="img-main1" :src="require('@/assets/img/' + itemPro.imgProMain)" alt="">
                                <div class="image-pro--cover">
                                    <img @click="changImage" :ref="count" class="img-cover" v-for="(imgCover,ind) in itemPro.listcolors" :key="ind" :src="require('@/assets/img/' + imgCover.image)" alt="">
                                    <!-- <img @click="changImage" :ref="count++" class="img-cover" :src="require('@/assets/img/' + itemPro.imgProCover.img2)" alt=""> -->
                                </div>
                            </a>
                        
                            <div class="name-pro">{{ itemPro.name }}</div>
                                <div class="cord">{{ itemPro.price }}</div>
                            
                            
                        </div>
                    </router-link>
                    <div class="addtocart">
                        <div class="cart-left" @click="onQuickView(itemPro)">
                            <i class="fa-solid fa-cart-shopping"></i>
                            <span class="text-cart">{{ itemPro.textBuy }}</span>
                        </div>
                        <div class="cart-right">
                            <a href="/ao-polo-co-duc-regular-cotton-2068-p37883259.html">
                                <i class="fa-solid fa-eye"></i>
                                <span class="text-cart-right">{{ itemPro.textDes }}</span>
                            </a>
                        </div>
                    </div>
                </span>
            </div>
        </section>
        <quick-view 
        :mainImage="this.productCurrent.imgProMain"
        :ismodal="isOpenModal"
        :itemSize="itemSize"
        :titlePro="this.productCurrent.name"
        :status="status"
        :price="this.productCurrent.price"
        :listcolors="this.productCurrent.listcolors"
        @closeModel="oncloseModal"
        />
       
</template>
<script>
    export default{
        name : "ListProducts",
        props: {
           
            styleSection:{
                type:String,
                default :""
            },
            isHasLabel:{
                type:Boolean,
                default: true,
            },
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
                        listcolors : [
                            {
                                selected : false,
                                name : "Be",
                                image : "sp3.webp"
                             },
                             {
                                selected : false,
                                name : "Trắng",
                                image : "sp4.jpeg"
                             },
                        ],           
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
            },
            onQuickView(item){
                this.isOpenModal = !this.isOpenModal;
                this.productCurrent = item;
            },
            oncloseModal(){
                this.isOpenModal = !this.isOpenModal;
            }

        },
        mounted(){
            // console.log(this.listProducts.name);
        },
        data(){
            return{
                count :1,
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
                isOpenModal: false,
                productCurrent : {},
                status:"Còn Hàng"
            }
        }
    }
</script>
<style scoped>
.padding0{
  padding: 0;
}
</style>