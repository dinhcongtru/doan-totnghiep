<template>
    <!-- <div class="wrap-phistory"> -->
        <div class="phistory-bar" :class="{width500 : toggle}">
            <div class="phistor-icon" @click="togglePhiStoryIcon">
                <i class="fa fa-angle-double-left" :class="{rotate180 : toggle}"></i>
            </div>
            <div class="phistory-title">Đã xem</div>
            <div class="phistory-content">
                <div class="phis-v-box" v-if="!toggle">
                    <div class="caroufredsel_wrapper">
                        <div class="phistor-v-slider" :class="{insetNext_90 : toggleNext}">
                            <div class="phistory-v-item" v-for="(item,index) in itemCover" :key="index">
                                <a :href="item.urlHref" :title="item.title">
                                    <img :src="require('@/assets/img/' + item.imgCover)" alt="">
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="phistor-v-nav">
                        <div class="prevSlideZ" v-show="!toggle" @click="prevToggle">
                            <i class="fa-solid fa-angle-left"></i>
                        </div>
                        <div class="nextSlideZ" v-show="!toggle" @click="nextToggle">
                            <i class="fa-solid fa-angle-right"></i>
                        </div>
                    </div>
                </div>
                <!-- v-if -->
                <div v-else class="phis-h-box" style="width: 475px; padding: 0 0px;">
                    <div class="styleArrowOwl">
                        <div class="phistor-h-slider owl-carousel owl-theme owl-loaded">
                            <div class="owl-stage-outer">
                                <div class="owl-stage" style="transform: translate3d(0px, 0px, 0px); transition: all 0s ease 0s; width: 791.665px;">
                                    <div class="owl-item active" style="margin-right: 0px;display: flex;overflow: hidden;width: 100%;">
                                        <div class="phistory-v-item" v-for="(item,index) in itemCover" :key="index">
                                            <a :href="item.urlHref" :title="item.title">
                                            <img :src="require('@/assets/img/' + item.imgCover)" alt="">
                                            </a><p class="pHis-name"><a :href="item.urlHref">{{ item.name }}</a></p>
                                            <span class="pHis-price">{{ item.price }}</span>
                                        </div>
                                    </div>
                                    <div class="owl-item active" style="width: 158.333px; margin-right: 0px;"></div>
                                </div>
                            </div>
                            <div class="owl-controls">
                                <div class="owl-nav">
                                    <div class="owl-prev" style="">prev</div>
                                    <div class="owl-next" style="">next</div>
                                </div>
                                <div class="owl-dots" style="">
                                    <div class="owl-dot active">
                                        <span></span>
                                    </div>
                                    <div class="owl-dot">
                                        <span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end if -->
            </div>
        </div>
        <div class="bttop" @click="scrollToTop" v-show="visible">
            <span class="text-bttop">Về đầu trang</span>
            <svg version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" viewBox="0 0 32.635 32.635" style="enable-background:new 0 0 32.635 32.635;" xml:space="preserve">
                <g>
                <path d="M32.135,16.817H0.5c-0.276,0-0.5-0.224-0.5-0.5s0.224-0.5,0.5-0.5h31.635c0.276,0,0.5,0.224,0.5,0.5
                S32.411,16.817,32.135,16.817z"></path>
                <path d="M19.598,29.353c-0.128,0-0.256-0.049-0.354-0.146c-0.195-0.195-0.195-0.512,0-0.707l12.184-12.184L19.244,4.136
                c-0.195-0.195-0.195-0.512,0-0.707s0.512-0.195,0.707,0l12.537,12.533c0.094,0.094,0.146,0.221,0.146,0.354
                s-0.053,0.26-0.146,0.354L19.951,29.206C19.854,29.304,19.726,29.353,19.598,29.353z"></path>
                </g>
            </svg>
        </div>
    <!-- </div> -->
</template>

<script>
 export default{
    name : "PhiStory",
    data(){
        return{
            visible:false,
            toggle : false,
            togglePrev : false,
            toggleNext : false,
            itemCover:[
                {
                    urlHref : "#",
                    title : "Áo Polo Cổ Đức Regular Cotton 2068",
                    imgCover : "sp1.jpeg",
                    name:"Áo Polo Cổ Đức Regular Cotton 2068",
                    price : "349,000"
                },
                {
                    urlHref : "#",
                    title : "Áo Polo Cổ Đức Regular Cotton 2068",
                    imgCover : "sp2.webp",
                    name:"Áo Polo Cổ Đức Regular Cotton 2068",
                    price : "349,000"
                },
                {
                    urlHref : "#",
                    title : "Áo Polo Cổ Đức Regular Cotton 2068",
                    imgCover : "sp3.webp",
                    name:"Áo Polo Cổ Đức Regular Cotton 2068",
                    price : "349,000"
                },
                {
                    urlHref : "#",
                    title : "Áo Polo Cổ Đức Regular Cotton 2068",
                    imgCover : "sp4.jpeg",
                    name:"Áo Polo Cổ Đức Regular Cotton 2068",
                    price : "349,000"
                }
            ]

        }
    },
    methods:{
        scrollToTop(){
            this.intervalId = setInterval(() => {
                if (window.pageYOffset === 0) {
                clearInterval(this.intervalId)
                }
                window.scroll(0, window.pageYOffset - 50)
            }, 17)
        },
        scrollListener(){
            this.visible = window.scrollY > 0
        },
        togglePhiStoryIcon(){
            this.toggle = !this.toggle;
        },
        prevToggle(){
            this.togglePrev = !this.togglePrev;
        },
        nextToggle(){
            this.toggleNext = !this.toggleNext;
        }
    },
    mounted(){
        window.addEventListener('scroll', this.scrollListener);

    },
    
 }
</script>
<style scoped>

.phistory-bar{
    position: fixed;
    right: 0;
    top: 35%;
    z-index: 99;
    background: #fff;
    border: 2px solid #000;
    height: 320px;
    width: 100px;
    transition: .3s;
}
.width500{
    width: 500px;
}
.phistor-icon{
    position: absolute;
    top: 50px;
    left: -25px;
    z-index: 0;
    background: #000;
    color: #fff;
    padding: 7px 20px 7px 8px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 19px;
    border-radius: 50%;
    cursor: pointer;
}
.phistory-title{
    background: #000;
    color: #fff;
    padding: 6px;
    font-size: 13px;
    text-align: center;
    margin-top: -1px;
}

.fa{
    line-height: 1.5;
}
.rotate180{
    transform: rotate(180deg);
}
.fa::before{
    color: white;
}
.bttop{
    text-align: center;
    position: fixed;
    bottom: 90px;
    right: -40px;
    cursor: pointer;
    color: #000;
    font-size: 11px;
    font-weight: 900;
    transform: rotate(-90deg);
    z-index: 99;
}

.bttop span{
    float: left;
    margin: 4px 10px;
}
.bttop svg {
    height: 25px;
}

svg:not(:root) {
    overflow: hidden;
}
.phistory-content{
    position: relative;
    z-index: 1;
    display: flex;
    align-items: center;
    justify-content: center;
    width: 100%;
    height: calc(100% - 29px);
    background: #fff;
}
.caroufredsel_wrapper{
    display: block;
    text-align: start;
    float: none; 
    position: relative; 
    inset: auto; 
    z-index: auto; 
    width: 96px; 
    height: 258px; 
    margin: 0px; 
    overflow: hidden;
}
.phistor-v-slider{
    text-align: left; 
    float: none; 
    position: absolute; 
    inset: 0px auto auto 0px; 
    margin: 0px; 
    height: 1118px; 
    width: 96px;
}
.insetPrev_90{
    inset: 90px auto auto 0px; 
}
.insetNext_90{
    inset: -90px auto auto 0px; 

}
.phistory-v-item {
    padding: 5px 10px;
    text-align: center;
    width: 20%;
}
.phis-v-box img {
    width: 76px;
    height: 76px;
    object-fit: scale-down;
}
.phistor-v-nav {
    font-size: 17px;
}
.prevSlideZ, .nextSlideZ {
    transform: translateX(-50%);
    position: absolute;
    left: 50%;
    cursor: pointer;
}
.prevSlideZ {
    top: 1px;
}
.nextSlideZ {
    bottom: -2px;
}
.fa-solid{
    font-weight: 900;
    font-size: 20px;
    transform: rotate(90deg);
}
.owl-carousel .owl-item img {
    display: block;
    width: 100%;
    -webkit-transform-style: preserve-3d;
    transform-style: preserve-3d;
}

.phis-h-box img {
    height: 135px;
    object-fit: scale-down;
}
.pHis-name {
    margin-bottom: 3px;
    font-size: 13px;
}
p {
    margin: 0 0 10px;
    line-height: 21px;
}
.owl-carousel .owl-controls .owl-dot, .owl-carousel .owl-controls .owl-nav .owl-next, .owl-carousel .owl-controls .owl-nav .owl-prev {
    cursor: pointer;
    cursor: hand;
    -webkit-user-select: none;
    -khtml-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}

.styleArrowOwl .owl-nav>.owl-prev {
    background-image: url(../assets/img/left_arrow_fix1.png);
    left: 13px;
}
.styleArrowOwl .owl-nav>div {
    position: absolute;
    z-index: 999;
    top: 40%;
    border: none;
    background: 0 0;
    font-size: 0;
    width: 35px;
    height: 40px;
    background-repeat: no-repeat;
    background-size: contain;
}
.styleArrowOwl .owl-nav>.owl-next {
    background-image: url(../assets/img/right_arrow_fix1.png);
    right: 0;
}
</style>