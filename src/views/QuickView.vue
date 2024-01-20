<template>
  <div id="site-overlay" class="site-overlay"></div>
  <div class="quickview-cart" :class="{ trasition: ismodal }">
    <div class="quickview-cart-desktop">
      <button type="button" title="Đóng" class="close" @click="closeModal">
        <img src="../assets/img/iconclose.png" alt="Đóng" />
      </button>
      <slider-pro
        ref="refSlide"
        :imgSmallData="smallImage"
        :listColor="product.listColors"
        :indexColor="indexColor"
        owlItem="width-Quick"
        :isDetailPro="false"
        @reSetSelectColor="reSetSelectColor"
        @reSetFistItem="reSetFistItem"
        @prevSlide="prevSlide"
      />
      <form-pro
        ref="refForm"
        :product="product"
        @selectColor="selectColor"
        @selectedFirtImg="selectedFirtImg"
      />
    </div>
  </div>
</template>
<script>
export default {
  name: "QuickView",
  computed:{
    smallImage() {
      let listImgCover = [];
      if(Object.keys(this.product).length == 0) return ;
      if (this.product.listColors.length === 0 ) return;
      this.product.listColors.forEach((item) => {
        item.imageItem.forEach((img) => listImgCover.push(img));
      });
      listImgCover.forEach((item) => (item.selected = false));
      listImgCover[0].selected = true;
      console.log(listImgCover);
      return listImgCover;
    }
  },
  props: {
    // itemSize:{
    //     type:Array,
    //     default: () => [
    //         {
    //             value : "S",
    //             selected: false
    //         }
    //     ]
    // },
    ismodal: {
      type: Boolean,
      default: false,
    },
    product: {
      type: Object,
      default: () => ({}),
    },
  },

  data() {
    return {
      indexColor: 0,

    };
  },
 
  methods: {
    prevSlide(index, indexColor) {
      this.$emit("prevSlide", index, indexColor);
    },
    reSetFistItem(indexColor) {
      this.$emit("reSetFistItem", indexColor);
    },
    reSetSelectColor(index, indexColor) {
      this.$emit("reSetSelectColor", index, indexColor);
    },
    selectedFirtImg(index) {
      this.$emit("reSetSelected", index);
    },
    selectColor(index) {
      this.indexColor = index;
      this.$refs.refSlide.reSetTranslate3d();
    },
    closeModal() {
      this.$emit("closeModel");
      this.$refs.refForm.reSetForm();
      this.$refs.refSlide.reSetDefault();
    },
  },
};
</script>
<style scoped>
.quickview-cart {
  background: rgb(0 0 0 / 50%);
  /* display: block; */
  padding-right: 17px;
  overflow-x: hidden;
  overflow-y: auto;
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
  opacity: 0;
  visibility: hidden;
  transition: all 0.5s;
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
.trasition {
  opacity: 1;
  visibility: visible;
}
.close {
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
.close > img {
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
