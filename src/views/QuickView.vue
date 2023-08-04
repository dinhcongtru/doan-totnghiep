<template>
  <div id="site-overlay" class="site-overlay"></div>
  <div class="quickview-cart" :class="{ trasition: ismodal }">
    <div class="quickview-cart-desktop">
      <button type="button" title="Đóng" class="close" @click="closeModal">
        <img src="../assets/img/iconclose.png" alt="Đóng" />
      </button>
      <slider-pro
        ref="refSlide"
        :imgSmallData="product.listColors"
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
      default: () => ({
        id: 1,
        code: "NPMCODE001",
        productName: "Quần Jeans Loose Fit Cotton 6005",
        categoryName: "Áo NAM",
        listColors: [
          {
            selected: false,
            name: "Be",
            itemSize: [
              {
                value: "S",
                selected: false,
                quantity: 10,
              },
              {
                value: "M",
                selected: false,
                quantity: 10,
              },
              {
                value: "L",
                selected: false,
                quantity: 10,
              },
              {
                value: "XL",
                selected: false,
                quantity: 10,
              },
            ],
            listImages: [
              {
                selected: true,
                image: "sp1.jpeg",
              },
              {
                selected: false,
                image: "sp2.webp",
              },
              {
                selected: false,
                image: "sp3.webp",
              },
            ],
          },
          {
            selected: false,
            name: "Trắng",
            itemSize: [
              {
                value: "S",
                selected: false,
                quantity: 10,
              },
              {
                value: "M",
                selected: false,
                quantity: 10,
              },
              {
                value: "L",
                selected: false,
                quantity: 10,
              },
              {
                value: "XL",
                selected: false,
                quantity: 10,
              },
            ],
            listImages: [
              {
                selected: true,
                image: "sale1.jpeg",
              },
              {
                selected: false,
                image: "sale2.jpeg",
              },
              {
                selected: false,
                image: "sale3.jpeg",
              },
            ],
          },
          {
            selected: false,
            name: "xanh",
            itemSize: [
              {
                value: "S",
                selected: false,
                quantity: 10,
              },
              {
                value: "M",
                selected: false,
                quantity: 10,
              },
              {
                value: "L",
                selected: false,
                quantity: 10,
              },
              {
                value: "XL",
                selected: false,
                quantity: 10,
              },
            ],
            listImages: [
              {
                selected: true,
                image: "quan1.jpeg",
              },
              {
                selected: false,
                image: "quan2.jpeg",
              },
              {
                selected: false,
                image: "quan3.webp",
              },
            ],
          },
          {
            selected: false,
            name: "Nâu",
            itemSize: [
              {
                value: "S",
                selected: false,
                quantity: 10,
              },
              {
                value: "M",
                selected: false,
                quantity: 10,
              },
              {
                value: "L",
                selected: false,
                quantity: 10,
              },
              {
                value: "XL",
                selected: false,
                quantity: 10,
              },
            ],
            listImages: [
              {
                selected: true,
                image: "áo1.jpeg",
              },
              {
                selected: false,
                image: "áo2.jpeg",
              },
              {
                selected: false,
                image: "áo3.jpeg",
              },
            ],
          },
        ],
        statusProduct: "Còn Hàng",
        price: 435000,
        itemSizes: [
          {
            value: "S",
            selected: false,
          },
          {
            value: "M",
            selected: false,
          },
          {
            value: "L",
            selected: false,
          },
          {
            value: "XL",
            selected: false,
          },
        ],
        chatlieu: [
          "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
          "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
          "2% Spandex tạo độ co giãn, thoải mái khi vận động",
        ],
        kieudang: [
          "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
        ],
        chitiet: [
          "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
          "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
          "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
        ],
      }),
    },
  },
  
  data() {
    return {
      indexColor: 0,
      //   imgSmallData: [
      //     {
      //       selected: true,
      //       image: "sp1.jpeg",
      //     },
      //     {
      //       selected: false,
      //       image: "sp2.webp",
      //     },
      //     {
      //       selected: false,
      //       image: "sp3.webp",
      //     },
      //   ],
    };
  },
  methods: {
    prevSlide(index,indexColor){
      this.$emit("prevSlide",index,indexColor)
    },
    reSetFistItem(indexColor){
      this.$emit("reSetFistItem",indexColor);
    },
    reSetSelectColor(index,indexColor){
      this.$emit("reSetSelectColor",index,indexColor)
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
  transition: opacity 0.5s linear, opacity 0.4s ease-out;
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
