<template>
  <div class="col-md-4 col-sm-5 col-xs-12" id="detail-product">
    <div class="product-title">
      <h1>{{ titlePro }}</h1>
      <span v-if="!isDetail" class="pro-soldold"
        >Tình trạng:
        <span class="statusProduct">{{ status }}</span>
      </span>

      <span v-else class="statusProduct size-14">{{ status }}</span>
    </div>
    <div class="product-price sale-undo" id="price-preview">
      <p
        class="pro-price highlight tp_product_price"
        :class="{ 'size-21': isDetail }"
      >
        {{ price.toLocaleString("en-US", { minimumFractionDigits: 0 }) }}₫
      </p>
    </div>
    <form
      @submit.prevent="getDetailPro"
      id="add-item-form"
      class="variants clearfix"
    >
      <div class="select-swatch clearfix">
        <div
          id="variant-swatch-0"
          class="borderImgRadius color_each swatch clearfix"
        >
          <div class="header">
            Màu sắc
            <span
              class="nameColor"
              ref="color"
              :class="{ selectColor: item.selected }"
              v-show="item.selected"
              v-for="(item, ind) in listcolors"
              :key="ind"
              >{{ item.name }}</span
            >
          </div>
          <div class="select-swap attr-color req">
            <div
              class="n-sd swatch-element color"
              v-for="(itemColor, index) in listcolors"
              :key="index"
              @mouseout="onMouseout()"
              @mouseover="mouseOver(itemColor, index)"
              @click="onSelectedColor(itemColor)"
            >
              <label for="" :class="[itemColor.selected ? 'active' : '']">
                <img :src="require('@/assets/img/' + itemColor.image)" alt="" />
              </label>
              <tool-tip :isToolTip="isToolTip == index" :text="textToolTip" />
            </div>
          </div>
        </div>
        <div id="variant-swatch-1" class="swatch clearfix">
          <div class="header">kích thước</div>
          <div class="select-swap attr-size req">
            <div
              class="n-sd swatch-element"
              v-for="(item, index) in itemSize"
              :key="index"
              @click="onSelectSize(item)"
            >
              <label for="" :class="[item.selected ? 'active' : '']" ref="size">
                <span class="spanP">{{ item.value }}</span>
                <img
                  src="../assets/img/soldout.png"
                  class="crossed-out"
                  alt=""
                />
              </label>
            </div>
          </div>
        </div>
      </div>
      <div class="selector-actions">
        <div class="quantity-area clearfix" :class="[!isDetail ? 'hide' : '']">
          <input type="button" class="qty-btn" value="-" @click="onTru" />
          <input
            type="text"
            id="quantity"
            disabled
            name="quantity"
            ref="quantity"
            :value="qty"
            min="1"
            class="quantity-selector"
            max="80"
          />
          <input type="button" class="qty-btn" value="+" @click="onCong" />
        </div>
        <div v-if="!isDetail" class="wrap-addcart clearfix">
          <button
            type="button"
            id="add-to-cart"
            class="btnAddToCart"
            @click="onOpenModalInQiuckView"
          >
            SỞ HỮU NGAY
          </button>
        </div>
        <div v-else class="wrap-addcart clearfix">
          <button
            type="button"
            id="add-to-cart"
            class="btnAddToCart"
            @click="onToggleModal"
          >
            THÊM VÀO GIỎ HÀNG
          </button>
          <button
            type="button"
            id="add-to-cart"
            class="btnAddToCart"
            @click="onToggleCheckout"
          >
            MUA NGAY
          </button>
        </div>
        <div class="wishlist whist" v-if="isDetail">
          <div
            class="fb-like fb_iframe_widget"
            data-href="https://krik.vn/ao-blazer-casual-0391-p37689115.html"
            data-layout="button_count"
            data-action="like"
            data-size="small"
            data-show-faces="true"
            fb-xfbml-state="rendered"
            fb-iframe-plugin-query="action=like&amp;app_id=&amp;container_width=304&amp;href=https%3A%2F%2Fkrik.vn%2Fao-blazer-casual-0391-p37689115.html&amp;layout=button_count&amp;locale=vi_VN&amp;sdk=joey&amp;show_faces=true&amp;size=small"
          >
            <span style="vertical-align: bottom; width: 90px; height: 28px">
              <iframe
                name="f2460521e889a3c"
                width="1000px"
                height="1000px"
                data-testid="fb:like Facebook Social Plugin"
                :title="Thích + this.titlePro"
                frameborder="0"
                allowtransparency="true"
                allowfullscreen="true"
                scrolling="no"
                allow="encrypted-media"
                src="https://www.facebook.com/v13.0/plugins/like.php?action=like&amp;app_id=&amp;channel=https%3A%2F%2Fstaticxx.facebook.com%2Fx%2Fconnect%2Fxd_arbiter%2F%3Fversion%3D46%23cb%3Df3a34f66d7f5558%26domain%3Dkrik.vn%26is_canvas%3Dfalse%26origin%3Dhttps%253A%252F%252Fkrik.vn%252Ff1d9ba671f47868%26relation%3Dparent.parent&amp;container_width=304&amp;href=https%3A%2F%2Fkrik.vn%2Fao-blazer-casual-0391-p37689115.html&amp;layout=button_count&amp;locale=vi_VN&amp;sdk=joey&amp;show_faces=true&amp;size=small"
                style="
                  border: none;
                  visibility: visible;
                  width: 90px;
                  height: 28px;
                "
                class=""
              >
              </iframe>
            </span>
          </div>
          <i
            class="fa-solid fa-heart"
            style="position: absolute; left: 0; top: 17px"
          ></i>
          <span class="favorite">YÊU THÍCH</span>
        </div>
        <div class="share" v-if="isDetail">
          <span>Chia sẻ</span>
          <a href="https://www.facebook.com/krik.vn">
            <i class="fa fa-facebook"></i>
          </a>
          <a href=""><i class="fa fa-twitter"></i></a>
          <a href=""><i class="fa-brands fa-google-plus-g"></i></a>
        </div>
      </div>
    </form>
    <div class="sys-store" v-if="isDetail">
      <div class="numberStore">
        <span style="color: white; font-size: 17px">8</span> cửa hàng còn sản
        phẩm này
      </div>
      <div class="selectBox">
        <DxSelectBox
          placeholder=""
          :acceptCustomValue="true"
          :value="DataCity[0]"
          :searchEnabled="true"
          :items="simpleProducts"
          :dataSource="DataCity"
          :input-attr="{ 'aria-label': 'Simple Product' }"
        />
      </div>
      <div class="form-group col-sm-12 col-xs-12 nopadingMobile">
        <div id="stock-box">
          <div class="stock">
            <span class="dist">
              <img src="../assets/img/maps-and-flags.png" alt="icon store" />25C
              Đại La <span class="timeStore"><strong>(Còn hàng)</strong></span>
            </span>
          </div>
          <div class="stock">
            <span class="dist">
              <img src="../assets/img/maps-and-flags.png" alt="icon store" />23
              Chùa Bộc
              <span class="timeStore"><strong>(Còn hàng)</strong></span>
            </span>
          </div>
          <div class="stock">
            <span class="dist">
              <img src="../assets/img/maps-and-flags.png" alt="icon store" />132
              Cầu Giấy
              <span class="timeStore"><strong>(Còn hàng)</strong></span>
            </span>
          </div>
          <div class="stock">
            <span class="dist">
              <img src="../assets/img/maps-and-flags.png" alt="icon store" />
              189 Phố Nhổn
              <span class="timeStore"><strong>(Còn hàng)</strong></span>
            </span>
          </div>
          <div class="stock">
            <span class="dist">
              <img src="../assets/img/maps-and-flags.png" alt="icon store" />280
              Nguyễn Trãi
              <span class="timeStore"><strong>(Còn hàng)</strong></span>
            </span>
          </div>
          <div class="stock">
            <span class="dist">
              <img src="../assets/img/maps-and-flags.png" alt="icon store" />
              344 Cầu Giấy
              <span class="timeStore"><strong>(Còn hàng)</strong></span>
            </span>
          </div>
          <div class="stock">
            <span class="dist">
              <img src="../assets/img/maps-and-flags.png" alt="icon store" />167
              Chùa Bộc
              <span class="timeStore"><strong>(Còn hàng)</strong></span>
            </span>
          </div>
          <div class="stock">
            <span class="dist">
              <img
                src="../assets/img/maps-and-flags.png"
                alt="icon store"
              />307H Bạch Mai
              <span class="timeStore"><strong>(Còn hàng)</strong></span>
            </span>
          </div>
          <input type="hidden" class="hidden-totalAvaiableStores" value="8" />
        </div>
      </div>
    </div>
    <div class="product-description" v-if="!isDetail">
      <div class="title-bl">
        <h2>
          Thông số sản phẩm
          <i
            v-if="!isOpenPlus"
            class="fa-solid fa-plus"
            @click="changeIcon"
          ></i>
          <i v-else class="fa-sharp fa-solid fa-minus" @click="changeIcon"></i>
        </h2>
      </div>
      <div class="description-content" :class="{ disBlog: isOpenPlus }">
        <div class="main_details">Đang cập nhật nội dung.</div>
      </div>
    </div>
    <div class="product-description">
      <div class="title-bl">
        <h2 v-if="!isDetail">
          Mô Tả Sản Phẩm
          <i
            v-show="!isOpenDes"
            class="fa-solid fa-plus"
            @click="changeDes"
          ></i>
          <i
            v-show="isOpenDes"
            class="fa-sharp fa-solid fa-minus"
            @click="changeDes"
          ></i>
        </h2>
        <h2 v-else>
          THUỘC TÍNH SẢN PHẨM
          <i v-if="!isOpenDes" class="fa-solid fa-plus" @click="changeDes"></i>
          <i v-else class="fa-sharp fa-solid fa-minus" @click="changeDes"></i>
        </h2>
      </div>
      <div class="description-content" :class="{ disBlog: isOpenDes }">
        <div class="description-productdetail" v-show="!isDetail">
          <p style="text-align: justify">
            <span style="font-family: Arial, Helvetica, sans-serif"
              >Chất liệu:</span
            >

            <span style="font-family: Arial, Helvetica, sans-serif"
              >►100% Cotton mềm mại, thấm hút mồ hôi tốt, độ bền cao</span
            >
          </p>
          <p style="text-align: justify">
            <span style="font-family: Arial, Helvetica, sans-serif"
              >Kiểu dáng:</span
            ><br /><span style="font-family: Arial, Helvetica, sans-serif"
              >►Form Classic rộng rãi thoải mái, phù hợp vóc dáng người
              Việt.</span
            >
          </p>
          <p style="text-align: justif y">
            <span style="font-family: Arial, Helvetica, sans-serif"
              >Chi tiết:</span
            >
            <span style="font-family: Arial, Helvetica, sans-serif"
              >►Màu sắc cơ bản dễ phối đồ, có 3 màu: Đen, Trắng, Nâu</span
            >
            <span style="font-family: Arial, Helvetica, sans-serif"
              >►Họa tiết chữ in trước ngực tạo điểm nhấn trẻ trung, năng
              động</span
            >
            <span style="font-family: Arial, Helvetica, sans-serif"
              >►Đẹp hơn khi phối cùng quần âu, quần Kaki, quần Short.</span
            >
          </p>
        </div>
        <div v-show="isDetail" class="description-productdetail">
          <p style="text-align: justify">
            <span style="font-family: Arial, Helvetica, sans-serif"
              >Chất liệu:</span
            >

            <span
              style="font-family: Arial, Helvetica, sans-serif"
              v-for="(item, index) in chatlieu"
              :key="index"
              >►{{ item }}</span
            >
          </p>
          <p style="text-align: justify">
            <span style="font-family: Arial, Helvetica, sans-serif"
              >Kiểu dáng:</span
            >

            <span
              style="font-family: Arial, Helvetica, sans-serif"
              v-for="(item, index) in kieudang"
              :key="index"
              >►{{ item }}</span
            >
          </p>
          <p style="text-align: justif y">
            <span style="font-family: Arial, Helvetica, sans-serif"
              >Chi tiết:</span
            >

            <span
              style="font-family: Arial, Helvetica, sans-serif"
              v-for="(item, index) in chitiet"
              :key="index"
              >►{{ item }}</span
            >
          </p>
        </div>
      </div>
    </div>
    <div class="product-description" v-if="isDetail">
      <div class="title-bl">
        <h2>
          CHÍNH SÁCH TỪ KRIK
          <i
            v-if="!isOpenPlus"
            class="fa-solid fa-plus"
            @click="changeIcon"
          ></i>
          <i v-else class="fa-sharp fa-solid fa-minus" @click="changeIcon"></i>
        </h2>
      </div>
      <div class="description-content" :class="{ disBlog: isOpenPlus }">
        <div class="description-productdetail" v-if="isDetail">
          <p style="text-align: justif y">
            <span style="font-family: Arial, Helvetica, sans-serif"
              >►Đổi hàng trong vòng 5 ngày.</span
            >
            <br /><span style="font-family: Arial, Helvetica, sans-serif"
              >►Giảm đến 15% trên tổng hóa đơn khi mua hàng ( tại cửa hàng ) vào
              tháng sinh nhật.</span
            >
            <br /><span style="font-family: Arial, Helvetica, sans-serif"
              >►Giao hàng nội thành Hà Nội chỉ từ 15.000đ trong vòng 24
              giờ.</span
            >
            <br /><span style="font-family: Arial, Helvetica, sans-serif"
              >►Tích điểm 3-8% giá trị đơn hàng cho mỗi lần mua và trừ tiền vào
              lần mua tiếp theo.</span
            >
          </p>
        </div>
      </div>
    </div>
    <div class="product-description" v-if="isDetail">
      <div class="title-bl">
        <h2>
          HƯỚNG DẪN BẢO QUẢN
          <i
            v-if="!isOpenRule"
            class="fa-solid fa-plus"
            @click="changeIconRule"
          ></i>
          <i
            v-else
            class="fa-sharp fa-solid fa-minus"
            @click="changeIconRule"
          ></i>
        </h2>
      </div>
      <div class="description-content" :class="{ disBlog: isOpenRule }">
        <div class="main_details"></div>
      </div>
    </div>
    <center v-if="!isDetail" class="centerDetial">
      <router-link
        style="color: #252a2b !important"
        :to="{ name: 'product' }"
        href="#"
        >Xem chi tiết sản phẩm &gt;&gt;</router-link
      >
    </center>
  </div>
</template>
<script>
import { DataCity } from "@/resource/TestData";
import DxSelectBox from "devextreme-vue/select-box";
import { store } from "@/store";
export default {
  components: { DxSelectBox },
  name: "FormPro",
  props: {
    chatlieu: {
      type: Array,
      default: () => ["test"],
    },
    kieudang: {
      type: Array,
      default: () => ["test"],
    },
    chitiet: {
      type: Array,
      default: () => ["test"],
    },
    isDetail: {
      type: Boolean,
      default: false,
    },
    titlePro: {
      type: String,
      default: "",
    },
    status: {
      type: String,
      default: "Còn Hàng",
    },
    price: {
      type: Number,
      default: 1139000,
    },
    listcolors: {
      type: Array,
      default: () => [
        {
          selected: false,
          name: "Be",
          image: "sp3.webp",
        },
      ],
    },
    itemSize: {
      type: Array,
      default: () => [
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
    },
    mainImg: {
      type: String,
      default: "sp3.webp",
    },
    productID: {
      type: Number,
      default: 1,
    },
  },
  created(){
   
  },
  data() {
    return {
      DataCity: DataCity,
      isOpenPlus: false,
      isOpenDes: true,
      isOpenRule: false,
      isToolTip: null,
      textToolTip: "",
      disableSize: false,
      qty: 1,
      getColor: "",
      getSize: "",
      getQty: "",
      infoPro: {},
      count: 100,
      disableColor: false,
    };
  },
  methods: {
    changeIconRule() {
      this.isOpenRule = !this.isOpenRule;
    },
    changeIcon() {
      this.isOpenPlus = !this.isOpenPlus;
    },
    changeDes() {
      this.isOpenDes = !this.isOpenDes;
    },
    onSelectedColor(color) {
      this.listcolors.forEach((color) => (color.selected = false));
      color.selected = !color.selected;
      this.disableColor = true;
    },
    mouseOver(color, index) {
      this.textToolTip = color.name;
      index != undefined ? (this.isToolTip = index) : (this.isToolTip = null);
    },
    onMouseout() {
      this.isToolTip = null;
    },
    onSelectSize(size) {
      if (this.disableColor) {
        this.itemSize.forEach((size) => (size.selected = false));
        size.selected = !size.selected;
        this.disableSize = true;
      } else alert("Bạn phải chọn màu trước");
    },
    onToggleModal() {
      if (this.disableSize == true && this.disableColor == true) {
        this.getDetailPro();
        store.commit("handleAddProductToCart", this.infoPro);
        this.$emit("openAddtoCart");
      }else if(this.disableSize == false && this.disableColor == true){
        alert("Bạn chưa chọn size")
      } else alert("chưa chọn size và màu");
    },
    onOpenModalInQiuckView() {
      if (this.disableSize == true && this.disableColor == true) {
        this.getDetailPro();
        console.log(this.infoPro);
        store.commit("handleAddProductToCart", this.infoPro);
        store.commit("handleOpenAddtoCart");
      } else if(this.disableSize == false && this.disableColor == true){
        alert("Bạn chưa chọn size")
      } else alert("chưa chọn size và màu");
    },

    onToggleCheckout() {
      if (this.disableSize == true && this.disableColor == true) {
        this.getDetailPro();
        store.commit("handleAddProductToCart", this.infoPro);
        this.$emit("onToggleCheckout");
      }else if(this.disableSize == false && this.disableColor == true){
        alert("Bạn chưa chọn size")
      } else alert("chưa chọn size và màu");
    },
    onCong() {
      if (this.qty < 40) {
        this.qty++;
      }
    },
    onTru() {
      if (this.qty > 1) this.qty--;
    },
    getDetailPro() {
      this.getColor = this.$refs.color.filter(
        (item) => item.className == "nameColor selectColor"
      )[0].innerText;
      this.getSize = this.$refs.size.filter(
        (item) => item.className == "active"
      )[0].innerText;
      this.getQty = parseInt(this.$refs.quantity.value);
      this.infoPro = {
        id: this.productID,
        img: this.mainImg,
        namePro: this.titlePro,
        price: this.price,
        qty: this.getQty,
        size: this.getSize,
        color: this.getColor,
      };
    },
    reSetForm(){
        this.disableColor = false;
        this.disableSize = false;
        this.listcolors.forEach(item => item.selected = false);
        this.itemSize.forEach(item => item.selected = false);
    }
    
  },
};
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
  font-family: "Quicksand-Bold";
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
.swatch .swatch-element label.sd,
.swatch .swatch-element label.active {
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
.spanP {
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
  display: none !important;
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

button,
html input[type="button"],
input[type="reset"],
input[type="submit"] {
  /* -webkit-appearance: button; */
  cursor: pointer;
}
button,
input,
select,
textarea {
  /* font-family: inherit; */
  font-size: inherit;
  line-height: inherit;
}
input {
  line-height: normal;
}
button,
input,
optgroup,
select,
textarea {
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
  transition: all 0.3s ease-in-out 0s;
  -moz-transition: all 0.3s ease-in-out 0s;
  -o-transition: all 0.3s ease-in-out 0s;
  -webkit-transition: all 0.3s ease-in-out 0s;
  -ms-transition: all 0.3s ease-in-out 0s;
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
  font-family: "FontAwesome" !important;
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
  font-family: Arial, Helvetica, sans-serif;
}

.description-productdetail * {
  font-size: 13px !important;
  display: block;
}
p {
  margin: 0 0 10px;
  line-height: 21px;
}
.centerDetial a {
  text-decoration: underline;
}
.fa-solid,
.fas {
  /* font-weight: 900; */
  position: absolute;
  right: 0;
  font-size: 17px;
  cursor: pointer;
}
.description-content {
  /* transform: scaleY(0);
    transform-origin: top;
    transition: transform .57s ease; */
  transition: opacity 0.75s linear, height 0.75s linear;
  opacity: 0;
  visibility: hidden;
  height: 0;
}
.disBlog {
  /* display: block;
    transform: scaleY(1); */
  opacity: 1;
  visibility: visible;
  height: auto;
}
.disNon {
  display: none;
}
form {
  display: flex;
  flex-direction: column;
}
.size-14 {
  font-size: 14px;
}
.size-21 {
  font-size: 21px !important;
}
.wishlist {
  color: #545454;
  border: 1px solid #7b5450;
  text-align: center;
  padding: 7px 0;
  text-transform: uppercase;
  cursor: pointer;
  width: 80%;
  margin-top: 7px;
  margin: 0 auto;
  position: relative;
}
.fb_iframe_widget {
  display: inline-block;
  position: relative;
}
.fb_iframe_widget span {
  display: inline-block;
  position: relative;
  text-align: justify;
}
.fb_iframe_widget iframe {
  position: absolute;
}
.wishlist i {
  color: lightsteelblue;
  padding-right: 5px;
  margin-left: 35px;
}
.fa {
  display: inline-block;
  font: normal normal normal 14px/1 FontAwesome;
  font-size: inherit;
  text-rendering: auto;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
.wishlist .favorite {
  font-size: 14px;
  color: #4d4d4d;
  line-height: 26px;
  text-transform: uppercase;
  font-weight: 700;
  letter-spacing: 0.09em;
  margin-left: 60px;
}
.share {
  font-size: 12px;
  text-transform: uppercase;
  font-weight: 700;
  padding: 20px 0 0;
  text-align: center;
}
.share span {
  font-weight: 400;
  font-size: 11px;
  text-align: left;
}
.share a {
  display: inline-block;
  width: 30px;
  height: 30px;
  border-radius: 50%;
  background: #adadad;
  color: #fff;
  line-height: 31px;
  text-align: center;
  margin: 7px 10px;
  font-size: 13px;
}
.share > a > i {
  color: white;
}
.sys-store {
  border: 1px solid #eee;
  margin-bottom: 1.5rem;
  border-radius: 5px 5px 0 0;
}

.sys-store {
  display: inline-block;
  width: 100%;
}
.sys-store .numberStore {
  border-radius: 5px 5px 0 0;
  padding: 0.7rem 0.5rem;
  background: #000;
  width: 100%;
  display: block;
  color: #fff;
  text-align: center;
  font-size: 17px;
}
#stock-box {
  overflow-y: scroll;
  max-height: 200px;
  margin-bottom: 15px;
  width: 100%;
  font-weight: 700;
  color: #333;
  border-color: #dcdbdb;
  position: relative;
  overflow-x: hidden;
  padding: 0 0 15px;
  text-align: left;
}
#stock-box .stock {
  float: left;
  width: 100%;
  margin: 0 0 15px;
}
#stock-box div .dist {
  font-weight: 700;
  display: flex;
  align-items: center;
  justify-content: start;
}

#stock-box div .dist,
.bst-tks a {
  font-weight: 700;
}
#stock-box div .dist img {
  width: 15px;
  margin: 0 5px 0 0;
  display: inline-block;
}
#stock-box .timeStore {
  padding-left: 4px;
}

#stock-box .timeStore {
  font-weight: 400;
  padding-left: 4px;
}
.sys-store .timeStore strong {
  color: #4caf50;
}

strong {
  font-weight: 700;
}
::-webkit-scrollbar {
  width: 7px;
  background-color: #d3d3d3;
}
::-webkit-scrollbar-thumb {
  background-color: #000;
  border-radius: 100px;
}
.form-group {
  margin-bottom: 15px;
  position: relative;
  min-height: 1px;
  padding-right: 15px;
  padding-left: 15px;
}
.selectBox {
  padding: 5px;
}
</style>
