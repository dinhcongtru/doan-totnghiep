<template>
  <div
    id="pbOverlay"
    :class="{overlay : isZoom}"
    @click="onClose"
  >
    <div id="pbCloseBtn"></div>
  </div>
  <img
    @click="onClose"
    id="pbImage"
    class="clickOutside"
    :class="{ trasition: isZoom }"
    :style="[
      `top: ${top}px; left: ${left}px; width: ${width}px; height: ${height}px;`,
    ]"
    :src="imgaeSrc"
  />
  <div id="pbBottom" style="opacity: 1; display: block">
    <div id="pbCaption">Click để xem</div>
    <div id="pbNav" v-show="isZoom">
      <a
        id="pbPrevBtn"
        href="#"
        class=""
        style="display: block"
        @click="onprev"
      ></a>
      <a
        id="pbZoomBtn"
        href="#"
        style="display: block"
        class=""
        @click="onZoom"
        :class="{ pbzoomed: zoomIn }"
      ></a>
      <a
        id="pbNextBtn"
        href="#"
        class=""
        style="display: block"
        @click="onNext"
      ></a>
    </div>
  </div>
</template>
<script>
export default {
  name: "ZoomProduct",
  props: {
    isZoom: {
      type: Boolean,
      default: false,
    },
    imgaeSrc: {
      type: String,
      default: "sale1.jpeg",
    },
  },
  watch:{
  
  },
  data() {
    return {
      zoomIn: false,
      top: 0,
      left: 510,
      width: 497.744,
      height: 747,
    };
  },
  
  methods: {
    onClose() {
      this.$emit("onClose");
      this.reSetSizeImage();
      this.zoomIn = false;
    },
    onZoom() {
      this.zoomIn = !this.zoomIn;
      if (this.zoomIn) {
        this.top = -599;
        this.left = 111;
        this.width = 1296;
        this.height = 1945;
      } else {
        this.reSetSizeImage();
      }
    },
    reSetSizeImage() {
      this.top = 0;
      this.left = 510;
      this.width = 497.744;
      this.height = 747;
    },
    onNext() {
      this.zoomIn = false;
      this.reSetSizeImage();
      this.$emit("onNextImage", this.imgaeSrc);
    },
    onprev() {
      this.zoomIn = false;
      this.reSetSizeImage();
      this.$emit("onPrevImage", this.imgaeSrc);
    },
  
  },
};
</script>
<style scoped>
#pbOverlay,
#pbImage,
#pbBottom,
#pbCloseBtn {
  position: fixed;
  z-index: 9999;
}
#pbImage {
  transition: all 0.4s;
  transform: scale(0);
  opacity: 0;
  visibility: hidden;
}

#pbOverlay {
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  opacity: 0;
  visibility: hidden;
  background: #fff;
  cursor: pointer;
  transition: all 0.3s;
}
body.tp_background,
div,
dl,
dt,
dd,
ul,
ol,
li,
h1,
h2,
h3,
h4,
h5,
h6,
pre,
code,
form,
fieldset,
legend,
input,
button,
textarea,
select,
span,
a,
p,
sub,
blockquote,
th,
td {
  font-family: Roboto;
}
#pbCloseBtn {
  top: 16px;
  right: 16px;
  display: block;
  width: 45px;
  height: 45px;
  background: url(../assets/img/closebutton1.png) no-repeat top left;
  background-size: cover;
}
#pbBottom {
  font-family: Verdana, Arial, Geneva, Helvetica, sans-serif;
  font-size: 10px;
  text-align: center;
  color: #eee;
  line-height: 1.4em;
  left: 50%;
  bottom: 20px;
  width: 400px;
  margin-left: -200px;
}
#pbBottom {
  z-index: 99999;
}
#pbCaption {
  font-weight: bold;
  padding: 4px;
  display: inline-block;
  display: inline;
  background-color: rgba(0, 0, 0, 0.7);
  filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr=#B0000000, EndColorStr=#B0000000);
  zoom: 1;
  opacity: 0;
}
#pbNav {
  display: block;
  width: 200px;
  height: 65px;
  margin: auto;
  margin-top: 5px;
}
#pbPrevBtn,
#pbNextBtn,
#pbZoomBtn {
  display: inline-block;
  width: 70px;
  height: 65px;
  outline: none;
  text-indent: -9000px;
  background: url(../assets/img/ico_control_galery.png) no-repeat;
  transition: all 0.3s;
}
#pbPrevBtn {
  background-position: -70px 0;
  float: left;
}
#pbPrevBtn.pbgreyed {
  background-position: 0 0;
}
#pbZoomBtn {
  width: 60px;
  background-position: -140px 0;
  float: left;
}
#pbNextBtn {
  background-position: -320px 0;
  float: right;
}
#pbZoomBtn.pbzoomed {
  background-position: -260px 0;
}
.trasition {
  left: 50% !important;
  transform: scale(1) translateX(-50%) !important;
  opacity: 1 !important;
  visibility: visible !important;
}
.overlay{
  opacity: 1 !important;
  visibility: visible !important;
}
</style>
