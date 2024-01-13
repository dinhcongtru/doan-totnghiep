<template>
  <div class="col-md-8 col-sm-7 col-xs-12">
    <div class="clearfix hidden-xs col-sm-1 thumbnails small-img">
      <div class="row">
        <div>
          <div
            class="caroufredsel_wrapper"
            style="
              display: block;
              text-align: start;
              float: none;
              position: relative;
              inset: auto;
              z-index: auto;
              width: 100%;
              margin: 0px;
              overflow: hidden;
            "
            :style="[screen1200 ? `height: ${heighNext}px;` : '']"
          >
            <div
              class="pview-thumb-slide"
              style="
                text-align: left;
                float: none;
                position: absolute;
                margin: 0px;
                height: 3150px;
                transition: all 0.5s linear;
                z-index: auto;
              "
              :style="[screen1200 ? `top: ${top}px;` : '']"
            >
              <div
                class="thumbnail thumdelete clickItem"
                :class="{ active: imgSmall.selected }"
                v-for="(imgSmall, index) in dynamicListColor"
                :key="index"
                @click="selectedImage(imgSmall, index)"
              >
                <img
                  class="img-fluid img-thumbnail"
                  :src="imgSmall.productImageUrl"
                  alt=""
                />
              </div>
            </div>
          </div>
          <div class="pview-thumb-nav" v-show="hideCenter">
            <div class="prevSlideZ" @click="prevImg">
              <i class="fa-solid fa-angle-left"></i>
            </div>
            <div class="nextSlideZ" @click="nextImg">
              <i class="fa-solid fa-angle-right"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-sm-11">
      <div id="slide-image" class="owl-carousel owl-theme owl-loaded">
        <div class="owl-stage-outer">
          <div
            class="owl-stage"
            :class="owlStage"
            style="display: flow-root"
            :style="[
              screen1200
                ? `transform: translate3d(${translate3d}px, 0px, 0px);width: 9970em;transition:all ${fadeIn}s ease 0s`
                : `transform :translate3d(${translate3d}px, 0px, 0px);width: 5540em;transition:all ${fadeIn}s ease 0s`,
            ]"
          >
            <div
              class="owl-item"
              :class="owlItem"
              v-for="(item, index) in dynamicListColor"
              :key="index"
            >
              <div class="item itemdelete">
                <a title="Click Để Xem" @click="onOpenZoom">
                  <img
                    :src="item.productImageUrl"
                    class="img-fluid img-responsive"
                    alt=""
                  />
                </a>
              </div>
              <div class="owl-controls">
                <div class="owl-nav">
                  <div
                    class="owl-prev"
                    style=""
                    @click="prevSlide(index)"
                  ></div>
                  <div
                    class="owl-next"
                    style=""
                    @click="nextSlide(index)"
                  ></div>
                </div>
                <div class="owl-dots" style="display: none"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <zoom-product :isZoom="isZoom" :imgaeSrc="newImage" @onClose="onOpenZoom" @onNextImage="onNextImage"  @onPrevImage="onPrevImage"/>
</template>
<script>
export default {
  name: "SliderPro",
  computed: {
    dynamicListColor() {
      return !this.default
        ? this.listImgCover
        : this.imgSmallData[this.indexColor].imageItem;
    },
  },
  created() {

    if (this.isDetailPro) {
        if (this.default == true) {
          if (this.imgSmallData.length < 10) {
            this.heighNext =
              109 * this.imgSmallData.length;
            this.hideCenter = false;
          } else {
            this.heighNext = 980;
          }
        } 
      } else {
        if (this.default == true) {
          if (this.imgSmallData.length < 10) {
            this.heighNext =
              119 * this.imgSmallData.length;
            this.hideCenter = false;
          } else {
            this.heighNext = 790;
          }
         }
      }

  },
  mounted() {
    if (this.imgSmallData.length === 0) return;
    this.imgSmallData.forEach((item) => {
      item.imageItem.forEach((img) => this.listImgCover.push(img));
    });
    this.listImgCover.forEach((item) => (item.selected = false));
    this.listImgCover[0].selected = true;
    if (this.isDetailPro) {
        if (this.default == true) {
          if (this.imgSmallData[this.indexColor].imageItem.length < 10) {
            this.heighNext =
              109 * this.imgSmallData[this.indexColor].imageItem.length;
            this.hideCenter = false;
          } else {
            this.heighNext = 980;
          }
        } else {
          if (this.listImgCover.length < 10) {
            this.heighNext = 109 * this.listImgCover.length;
            this.hideCenter = false;
          } else {
            this.heighNext = 980;
          }
        }
      } else {
        if (this.default == true) {
          if (this.imgSmallData[this.indexColor].imageItem.length < 10) {
            this.heighNext =
              119 * this.imgSmallData[this.indexColor].imageItem.length;
            this.hideCenter = false;
          } else {
            this.heighNext = 790;
          }
         }else {
          if (this.dynamicListColor.length < 10) {
            this.heighNext = 790;
          } else {
            this.heighNext = 790;
          }
        }
      }
  },
  watch: {
    // default(value) {
    //   if (this.isDetailPro) {
    //     if (value == true) {
    //       if (this.imgSmallData.length < 10) {
    //         this.heighNext =
    //           109 * this.imgSmallData.length;
    //         this.hideCenter = false;
    //       } else {
    //         this.heighNext = 980;
    //       }
    //     }
    //   } else {
    //     if (value == true) {
    //       if (this.imgSmallData.length < 10) {
    //         this.heighNext =
    //           119 * this.imgSmallData.length;
    //         this.hideCenter = false;
    //       } else {
    //         this.heighNext = 950;
    //       }
    //     }
    //   }
    // },
  },
  data() {
    return {
      listImgCover: [],
      newImage :"sale1.jpeg",
      isZoom: false,
      default: false,
      slide: "#slide-",
      screen1200: true,
      translate3d: 0,
      fadeIn: 0,
      clone: 0,
      heighNext: 980,
      top: 0,
      slideIndex: 1,
      count: 1,
      next: 0,
      hideCenter: true,
      dataImg: [],
    };
  },
  props: {
    indexColor: {
      type: Number,
      default: 0,
    },
    isDetailPro: {
      type: Boolean,
      default: true,
    },
    imgSmallData: {
      type: Array,
      default: () =>[]
    },
    // mainImage: {
    //   type: String,
    //   default: "sp1.jpeg",
    // },
    owlStage: {
      type: String,
      default: "",
    },
    owlItem: {
      type: String,
      default: "",
    },
  },
  methods: {
    
    onNextImage(imgaeSrc){
      let index = this.dynamicListColor.findIndex(item => item.image == imgaeSrc);
      if(index < this.dynamicListColor.length - 1){
        let nextImage = this.dynamicListColor[index + 1];
        this.newImage = nextImage.image;

      }
      
    },
    onPrevImage(imgaeSrc){
      let index = this.dynamicListColor.findIndex(item => item.image == imgaeSrc);
      if(index > 0){
        let nextImage = this.dynamicListColor[index - 1];
        this.newImage = nextImage.image;

      }
    },
    onOpenZoom(){
      this.isZoom = !this.isZoom;
      this.newImage = this.dynamicListColor.find(item => item.selected == true).image;
    },
    reSetTranslate3d() {
      this.default = true;
      this.translate3d = 0;
      this.fadeIn = 0;
      this.top = 0;
      this.clone = 0;
    },
    reSetDefault(){
      this.default = false;
    },
    selectedImage(item, index) {
      this.translate3d = 0;
      this.dynamicListColor.forEach(
        (item) => (item.selected = false)
      );
      this.listImgCover.forEach((item) => (item.selected = false));
      item.selected = !item.selected;
      if (this.isDetailPro) {
        this.translate3d -= 697 * index;
      } else {
        this.translate3d -= 535 * index;
      }

      this.fadeIn = 0.5 * Math.abs(this.clone - index);
      this.clone = index;
    },
    prevImg() {
      if(this.isDetailPro){
        if (this.top < 0) this.top += 109;
      }else{
        if (this.top < 0) this.top += 79;
      }
    },
    nextImg() {
      // màn product detailt
      if(this.isDetailPro){
      if (this.default) {
        if (
          this.top >
          -109 * (this.imgSmallData[this.indexColor].imageItem.length - 9)
        )
          this.top -= 109;
      } else {
        if (this.top > -109 * (this.listImgCover.length - 9)) this.top -= 109;
      }
    }else{
      // màn quick-view
      if (this.default) {
        if (
          this.top >
          -79 * (this.imgSmallData[this.indexColor].imageItem.length - 10)
        )
          this.top -= 79;
      } else {
        if (this.top > -79 * (this.listImgCover.length - 10)) this.top -= 79;
      }
    }
    },
    nextSlide(index) {
      // view product details
      this.fadeIn = 0;
      if (this.isDetailPro) {
        if (this.default) {
          if (
            this.translate3d >
            -697 * (this.imgSmallData[this.indexColor].imageItem.length - 1)
          ) {
            this.translate3d -= 697;
            this.fadeIn = 0.5;
            this.$emit("reSetSelectColor", index, this.indexColor);
            this.clone = index + 1;
          } else {
            this.translate3d = 0;
            this.$emit("reSetFistItem", this.indexColor);
            this.fadeIn =
              0.5 * (this.imgSmallData[this.indexColor].imageItem.length - 1);
            this.clone = 0;
          }
        } else {
          if (this.translate3d > -697 * (this.listImgCover.length - 1)) {
            this.translate3d -= 697;
            this.fadeIn = 0.5;
            this.listImgCover.forEach((el) => (el.selected = false));
            this.listImgCover[index + 1].selected = true;
            this.clone = index + 1;
          } else {
            this.translate3d = 0;
            this.fadeIn = 0.5 * (this.listImgCover.length - 1);
            this.listImgCover.forEach((item) => (item.selected = false));
            this.listImgCover[0].selected = true;
            this.clone = 0;
          }
        }
      } else {
        // view QuickView
        if (this.default) {
          if (
            this.translate3d >
            -535 * (this.imgSmallData[this.indexColor].imageItem.length - 1)
          ) {
            this.translate3d -= 535;
            this.fadeIn = 0.5;
            this.$emit("reSetSelectColor", index, this.indexColor);
            this.clone = index + 1;
          } else {
            this.translate3d = 0;
            this.fadeIn =
              0.5 * (this.imgSmallData[this.indexColor].imageItem.length - 1);
            this.$emit("reSetFistItem", this.indexColor);
            this.clone = 0;
          }
        } else {
          if (this.translate3d > -535 * (this.listImgCover.length - 1)) {
            this.translate3d -= 535;
            this.fadeIn = 0.5;
            this.listImgCover.forEach((item) => (item.selected = false));
            this.listImgCover[index + 1].selected = true;
            this.clone = index + 1;
          } else {
            this.translate3d = 0;
            this.fadeIn = 0.5 * (this.listImgCover.length - 1);
            this.listImgCover.forEach((item) => (item.selected = false));
            this.listImgCover[0].selected = true;
            this.clone = 0;
          }
        }
      }
    },
    prevSlide(index) {
      if (this.isDetailPro) {
        if (this.default) {
          if (this.translate3d < 0) {
            this.translate3d += 697;
            this.$emit("prevSlide", index, this.indexColor);
            this.clone = index - 1;
          }
        } else {
          // màn default pro
          if (this.translate3d < 0) {
            this.translate3d += 697;
            this.listImgCover.forEach((item) => (item.selected = false));
            this.listImgCover[index - 1].selected = true;
            this.clone = index - 1;
          }
        }
      } else {
        // màn quick-view
        if (this.default) {
          if (this.translate3d < 0) {
            this.translate3d += 535;
            this.$emit("prevSlide", index, this.indexColor);
            this.clone = index - 1;
          }
        } else {
          if (this.translate3d < 0) {
            this.translate3d += 535;
            this.listImgCover.forEach((item) => (item.selected = false));
            this.listImgCover[index - 1].selected = true;
            this.clone = index - 1;
          }
        }
      }
      this.fadeIn = 0.5;
    },
  },
};
</script>
<style scoped>
.col-md-8 {
  width: calc(100% * 2 / 3);
  float: left;
  padding: 0 15px;
}
.thumbnails {
  width: 11.33333333%;
  float: left;
}
.row {
  margin-right: -15px;
  margin-left: -15px;
}
.thumbnail {
  border-radius: 0;
  cursor: pointer;
  text-align: center;
  margin: 0 10px;
  border: 1px solid #ddd;
  padding: 5px;
  margin-bottom: 10px;
  /* padding-bottom: 3px; */
}
.thumbnail > img {
  border-radius: 0;
  margin: 0;
  display: inline-block;
  border: none;
  padding: 0;
  width: 100%;
  height: auto;
}
.col-sm-11 {
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
.owl-carousel {
  display: none;
  width: 100%;
  z-index: 1;
}

.owl-carousel.owl-loaded {
  display: block;
}
.owl-carousel,
.owl-carousel .owl-item {
  -webkit-tap-highlight-color: transparent;
  position: relative;
}
.owl-carousel .owl-stage-outer {
  position: relative;
  overflow: hidden;
  transform: translate3d(0, 0, 0);
  -webkit-transform: translate3d(0, 0, 0);
}
.owl-carousel .owl-stage {
  position: relative;
  touch-action: pan-y;
  -ms-touch-action: pan-Y;
}
.owl-carousel .owl-item {
  min-height: 1px;
  float: left;
  width: 697px;
  margin-right: 0px;
  backface-visibility: hidden;
  -webkit-backface-visibility: hidden;
  -webkit-touch-callout: none;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}
.owl-carousel .owl-item img {
  display: block;
  width: 100%;
  transform-style: preserve-3d;
  -webkit-transform-style: preserve-3d;
}

.carousel-inner > .item > a > img,
.carousel-inner > .item > img,
.img-responsive,
.thumbnail a > img,
.thumbnail > img {
  display: block;
  max-width: 100%;
  height: auto;
}
.thumbnails .thumbnail.active {
  border: 1px solid #000000;
}

.width-100 {
  /* width: 100% !important; */
  height: auto;
}
.col-lg-1,
.col-lg-10,
.col-lg-11,
.col-lg-12,
.col-lg-2,
.col-lg-3,
.col-lg-4,
.col-lg-5,
.col-lg-6,
.col-lg-7,
.col-lg-8,
.col-lg-9,
.col-md-1,
.col-md-10,
.col-md-11,
.col-md-12,
.col-md-2,
.col-md-3,
.col-md-4,
.col-md-5,
.col-md-6,
.col-md-7,
.col-md-8,
.col-md-9,
.col-sm-1,
.col-sm-10,
.col-sm-11,
.col-sm-12,
.col-sm-2,
.col-sm-3,
.col-sm-4,
.col-sm-5,
.col-sm-6,
.col-sm-7,
.col-sm-8,
.col-sm-9,
.col-xs-1,
.col-xs-10,
.col-xs-11,
.col-xs-12,
.col-xs-2,
.col-xs-3,
.col-xs-4,
.col-xs-5,
.col-xs-6,
.col-xs-7,
.col-xs-8,
.col-xs-9,
.col-xs-15,
.col-sm-15,
.col-md-15,
.col-lg-15 {
  position: relative;
  min-height: 1px;
  padding-right: 15px;
  padding-left: 15px;
}
@media (min-width: 1200) {
  .owl-item {
    width: 697px;
    margin-right: 0px;
  }
}
@media (max-width: 1200) {
  .owl-item {
    width: 554px;
    margin-right: 0px;
  }
}
@media (min-width: 768px) {
  .col-sm-1,
  .col-sm-10,
  .col-sm-11,
  .col-sm-12,
  .col-sm-2,
  .col-sm-3,
  .col-sm-4,
  .col-sm-5,
  .col-sm-6,
  .col-sm-7,
  .col-sm-8,
  .col-sm-9,
  col-sm-15 {
    float: left;
  }
}
@media (min-width: 768px) {
  .col-sm-11 {
    width: 88.666667%;
  }
}
.btn-group-vertical > .btn-group:after,
.btn-group-vertical > .btn-group:before,
.btn-toolbar:after,
.btn-toolbar:before,
.clearfix:after,
.clearfix:before,
.container-fluid:after,
.container-fluid:before,
.container:after,
.container:before,
.dl-horizontal dd:after,
.dl-horizontal dd:before,
.form-horizontal .form-group:after,
.form-horizontal .form-group:before,
.modal-footer:after,
.modal-footer:before,
.nav:after,
.nav:before,
.navbar-collapse:after,
.navbar-collapse:before,
.navbar-header:after,
.navbar-header:before,
.navbar:after,
.navbar:before,
.pager:after,
.pager:before,
.panel-body:after,
.panel-body:before,
.row:after,
.row:before {
  display: table;
  content: " ";
}

:after,
:before {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
.pview-thumb-nav {
  font-size: 21px;
  color: #999;
}
.prevSlideZ,
.nextSlideZ {
  transform: translateX(-50%);
  position: absolute;
  left: 50%;
  cursor: pointer;
}
.prevSlideZ {
  top: 1px;
}
.pview-thumb-nav .prevSlideZ {
  top: -10px;
}
.nextSlideZ {
  bottom: 1px;
}
.pview-thumb-nav .nextSlideZ {
  bottom: 0;
}
.fa {
  display: inline-block;
  font: normal normal normal 14px/1 FontAwesome;
  font-size: inherit;
  text-rendering: auto;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
.fa-solid {
  font-weight: 900;
  font-size: 25px;
  transform: rotate(90deg);
  color: #999;
}
.btn-group-vertical > .btn-group:after,
.btn-group-vertical > .btn-group:before,
.btn-toolbar:after,
.btn-toolbar:before,
.clearfix:after,
.clearfix:before,
.container-fluid:after,
.container-fluid:before,
.container:after,
.container:before,
.dl-horizontal dd:after,
.dl-horizontal dd:before,
.form-horizontal .form-group:after,
.form-horizontal .form-group:before,
.modal-footer:after,
.modal-footer:before,
.nav:after,
.nav:before,
.navbar-collapse:after,
.navbar-collapse:before,
.navbar-header:after,
.navbar-header:before,
.navbar:after,
.navbar:before,
.pager:after,
.pager:before,
.panel-body:after,
.panel-body:before,
.row:after,
.row:before {
  display: table;
  content: " ";
}

:after,
:before {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
.owl-carousel .owl-controls .owl-dot,
.owl-carousel .owl-controls .owl-nav .owl-next,
.owl-carousel .owl-controls .owl-nav .owl-prev {
  cursor: pointer;
  cursor: hand;
  -webkit-user-select: none;
  -khtml-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}
#slide-image .owl-next,
#slide-image .owl-prev {
  position: absolute;
  width: 30px;
  height: 40px;
  top: calc(50% - 15px);
  cursor: pointer;
  font-size: 0;
  opacity: 0.5;
}
#slide-image .owl-prev {
  background: url(../assets/img/rowleft.png) center no-repeat;
  border-radius: 0 5px 5px 0;
  left: 10px;
}
#slide-image .owl-next {
  background: url(../assets/img/rowright.png) center no-repeat;
  border-radius: 5px 0 0 5px;
  right: 34px;
}
.activeImg {
  inset: -105px auto auto 0;
}
.width-Quick {
  width: 535px !important;
}
.img-fluid{
  cursor: pointer;
}
</style>
