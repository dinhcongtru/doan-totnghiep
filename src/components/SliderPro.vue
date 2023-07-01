<template>
     <div class="col-md-8 col-sm-7 col-xs-12">
                <div class="hidden-xs col-sm-1 thumbnails small-img">
                    <div class="row">
                        <div class="thumbnail thumdelete clickItem" v-for="(imgSmall,index) in imgSmallData" :key="index">
                            <img class="img-fluid img-thumbnail" :src="require('@/assets/img/' + imgSmall)" alt="">
                        </div>

                    </div>
                </div>
                <div class="col-sm-11">
                    <div id="slide-image" class="owl-carousel owl-theme owl-loaded">
                        <div class="owl-stage-outer">
                            <div class="owl-stage" :class="owlStage">
                                <div class="owl-item" :class="owlItem">
                                    <div class="item itemdelete">
                                        <a href="" title="Click Để Xem">
                                            <img :src="require('@/assets/img/' + mainImage)" class="img-fluid img-responsive" alt="">
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</template>
<script>
export default {
    name: "SliderPro",
    props:{
        imgSmallData:{
            type:Array,
            default: () => ["sp1.jpeg","sp2.webp","sp3.webp"]
        },
        mainImage:{
            type:String,
            default :"sp1.jpeg"
        },
        owlStage:{
            type:String,
            default:""
        },
        owlItem:{
            type:String,
            default:""
        }
    },
}
</script>
<style scoped>
    .col-md-8 {
    width: calc(100% * 2/3);
    float: left;
    padding: 0 15px;
} 
.thumbnails{
    width: 8.33333333%;
    float: left;
}
.row{
    margin-right: -15px;
    margin-left: -15px;
}
.thumbnail{
    border-radius: 0;
    cursor: pointer;
    text-align: center;
    margin: 0 10px;
    border: 1px solid #ddd;
    padding: 5px;
    margin-bottom: 10px;
    /* padding-bottom: 3px; */
}
.thumbnail > img{
    border-radius: 0;
    margin: 0;
    display: inline-block;
    border: none;
    padding: 0;
    width: 100%;
    height: auto;
}
.col-sm-11{
    width: 91.66666667%;
    float: left;
    min-height: 1px;
    padding-right: 15px;
    padding-left: 15px;
}

#slide-image {
    margin: 0 auto;
    text-align: center;
    background: #fff;
    overflow: hidden;
}
.owl-carousel.owl-loaded {
    display: block;
}
.owl-carousel {
    /* display: none; */
    width: 100%;
    z-index: 1;
}
.owl-carousel, .owl-carousel .owl-item {
    -webkit-tap-highlight-color: transparent;
    position: relative;
}
.owl-carousel .owl-stage-outer {
    position: relative;
    overflow: hidden;
    /* -webkit-transform: translate3d(0,0,0); */
}
.owl-carousel .owl-stage {
    position: relative;
    /* -ms-touch-action: pan-Y; */
    transform: translate3d(0px, 0px, 0px);
    width: 3210px;
    transition: all 0.5s ease 0s;
}
.owl-carousel .owl-item {
    min-height: 1px;
    float: left;
    /* -webkit-backface-visibility: hidden; */
    -webkit-touch-callout: none;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    width: 535px;
    margin-right: 0px;
}
.owl-carousel .owl-item img {
    display: block;
    width: 100%;
    -webkit-transform-style: preserve-3d;
    transform-style: preserve-3d;
}

.carousel-inner > .item > a > img, .carousel-inner > .item > img, .img-responsive, .thumbnail a > img, .thumbnail > img {
    display: block;
    max-width: 100%;
    height: auto;
}


.width-100{
  width: 100% !important;
  height: auto;
}
</style>