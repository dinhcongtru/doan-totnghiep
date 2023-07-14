<template>
    <div id="site-overlay" class="site-overlay"></div>
    <div class="quickview-cart" v-show="ismodal">
        <div class="quickview-cart-desktop">
            <button type="button" title="Đóng" class="close" @click="closeModal">
                <img src="../assets/img/iconclose.png" alt="Đóng">
            </button>
            <slider-pro 
            :imgSmallData="imgSmallData"
            :mainImage ="mainImage"
            />
            <form-pro 
            :titlePro="titlePro"
            :status="status"
            :price="price"
            :listcolors="listcolors"
            :itemSize="itemSize"
            />
            
        </div>
    </div>
</template>
<script>
export default {
    name: "QuickView",
    props:{
        itemSize:{
            type:Array,
            default: () => [
                {
                    value : "S",
                    selected: false
                }
            ]
        },
        ismodal:{
            type:Boolean,
            default:false
        },
        // imgCoverData:{
        //     type:Array,
        //     default : () => [
        //         {
        //             selected : false,
        //             image :"sp1.jpeg"

        //         }
        // ]
            
        // },
        
        mainImage:{
            type:String,
            default: "sp1.jpeg"
        },
        titlePro:{
            type:String,
            default: "",
        },
        status:{
            type: String,
            default: "Còn Hàng"
        },
        price:{
            type:Number,
            default:0
        },
        listcolors:{
            type:Array,
            default: () => [
                {
                    selected : false,
                    name : "Be",
                    image : "sp1.jpeg"
                }
            ]
        }
    },
    data(){
        return{
        // isOpenPlus : false,
        // isOpenDes:false,
            imgSmallData:[
                "sp1.jpeg","sp2.webp","sp3.webp"
            ]
        }
    },
    methods:{
        // changeIcon(){
        //     this.isOpenPlus = !this.isOpenPlus;
        // },
        // changeDes(){
        //     this.isOpenDes = !this.isOpenDes;
        // },
        closeModal(){
            this.$emit("closeModel");
        },
        // onSelectedColor(color){
        //     color.selected = true;
        // }
    }   

}
</script>
<style scoped>
    .quickview-cart{
    background:rgb(0 0 0 / 50%);
    display: block;
    padding-right: 17px;
    overflow-x: hidden;
    overflow-y: auto;
    opacity: 1;
    position: fixed;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    z-index: 1050;
    /* display: none;
    overflow: hidden; */
    -webkit-overflow-scrolling: touch;
    outline: 0;
    transition: opacity .15s linear;
}
.quickview-cart-desktop {
    background: #fff;
    width: 90%;
    margin: 3% auto;
    padding: 30px 15px;
    overflow: auto;
    position: relative;
    max-width: 1000px;
    min-height: 80%;
}
.close{
    opacity: 1;
    position: absolute;
    right: 15px;
    top: 15px;
    cursor: pointer;
    z-index: 9999;
    background: 0 0;
    border: 0;
    padding: 0;
    font-size: 21px;
    font-weight: 700;
    line-height: 1;
    color: #000;
    text-shadow: 0 1px 0 #fff;
   
}
.close > img{
    width: 20px;
}

#quickview-cart-desktop #detail-product {
    max-height: 600px;
    overflow: auto;
}
.dx-theme-generic-typography a {
    color: #252a2b;
}

</style>