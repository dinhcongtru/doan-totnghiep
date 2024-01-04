<template>
  <header :class="{ 'header_active': scroll_active}">
    <div class="mert">
      <span class="mert-row--phone">
        <div class="phone-contac">
          <div class="iconTop icon-1-top"></div>
          <div class="telephone">{{ Resource.HEADER.telephone }}</div>
        </div>
      </span>
      <span class="mert-row--cart">
        <div class="account">
          <router-link :to="{ name: 'singin' }" @click="logOut">
            <div class="iconTop icon-4-top"></div>
            <div class="account-name">{{ customer }}</div>
            <i v-if="Object.keys(this.$store.state.customer).length > 0" class="fa-light fa-right-from-bracket"
              style="font: normal normal normal 14px/1 FontAwesome;color: #adadad"></i>
          </router-link>
        </div>
        <div class="cart" @click="onToggleAddToCart">
          <a href="#">
            <div class="iconTop icon-5-top"></div>
            <div class="cart-title">{{ Resource.HEADER.cartTitle }}</div>
            <span class="red-color">({{ totalProduct }})</span>
          </a>
        </div>
      </span>
    </div>
    <div class="content-head">
      <a href="/">
        <div class="logo">
          <span>
            <img src="@/assets/img/20140514_zDIzVUPzsug50Im3jvclQm0H.webp" alt="" />
          </span>
        </div>
      </a>
      <div class="menu">
        <ul>
          <li v-for="(menu, index) in menuLayout" :key="index">
            <router-link :to="{
              name: 'CategoryName',
              params: { name: dynamicUrlProduct(menu.productCategoryName) }
            }" @click="onClickCategory(menu.productCategoryID,menu.productCategoryName)">{{ menu.productCategoryName }}</router-link>
            <!-- option -->
            <div class="option">
              <div class="option-menu">
                <ul>
                  <li v-for="(option, ind) in menu.optionMenus" :key="ind" class="relative">
                    <router-link :to="{
                      name: 'CategoryName',
                      params: {name : dynamicUrlProduct(option.productCategoryName) },
                    }" @click="onClickCategory(option.productCategoryID,option.productCategoryName)">
                      {{ option.productCategoryName }}
                    </router-link>
                    <div class="somi-menu">
                      <div v-for="(optionChild, index) in option.optionMenus" :key="index">
                        <router-link :to="{
                          name: 'CategoryName',
                          params: { name: dynamicUrlProduct(optionChild.productCategoryName) }
                        }" @click="onClickCategory(optionChild.productCategoryID,optionChild.productCategoryName)">{{ optionChild.productCategoryName }}</router-link>
                      </div>
                    </div>
                  </li>
                </ul>
              </div>
              <div class="option-img">
                <!-- <router-link :to="{
                  name: 'product',
                  query: {category: itemPro.productCategoryName,name: itemPro.productName }
                }" v-for="(itemPro, index) in menu.itemProducts" :key="index">
                  <div>
                    <img :src="itemPro.listColors[0].imageItem[0].productImageUrl" alt="" />
                    <div class="text-img">
                      {{ itemPro.productName }}
                    </div>
                  </div>
                </router-link> -->
              </div>
            </div>
          </li>
          <li>
            <router-link :to="{ name: 'album' }">album</router-link>
          </li>
          <li>
            <router-link :to="{ name: 'news' }">Tin Tức</router-link>
          </li>
        </ul>
      </div>
      <div class="input-search">
        <span>
          <input type="text" placeholder="Tìm kiếm..." />
        </span>
        <div class="icon-search"></div>
      </div>
    </div>
  </header>
  <add-to-cart :isAddToCart="isAddToCart" @onCloseModal="onToggleAddToCart" />
  <phi-story />
</template>

<script>
import { dynamicUrlProduct } from "@/methods";
import resource from "@/resource";
import { store } from '@/store';
import { RepositoryFactory } from "@/Repository/RepositoryFactory";
const categoryRepository = RepositoryFactory.get("Categoris");
const productRepository = RepositoryFactory.get("Products");
export default {
  name: "TheHeader",
  async created() {
    window.addEventListener('scroll', await this.handleScroll);
    await this.getMenus();
  },
  methods: {
    onClickCategory(id,name){
      store.commit("handleAddCategoryID",{id,name});
    },
    async getMenus(){
      try {
        await categoryRepository.GetAllCategory().then((res) => {
            if(res.status == 200) {
              this.menuLayout = res.data.filter(item => item.productCategoryName !== "AlBum" && item.productCategoryName !== "Tin Tức");
              this.menuLayout.forEach(item => {
                let result = this.getproductsByCate(item.productCategoryID);
                item.itemProducts = result;
              });
            }
        });
      } catch (error) {
        console.log(error);
      }
    },
    // api lấy 3 product theo category
    async getproductsByCate(cateID){
      try {
        await productRepository.getProductByCategory(cateID).then((res) => {
           if(res.status == 200) {
              return res.data.slice(0,3);
           }
        });
      } catch (error) {
        console.log(error);
      }
    },
    onToggleAddToCart() {
      store.commit("handleOpenAddtoCart")
    },
    logOut() {
      if (Object.keys(this.$store.state.customer).length > 0) {
        store.commit("removeCustomer")
      }
    },
    handleScroll() {
      if (window.scrollY > 108) {
        this.scroll_active = true;
      }
      else {
        this.scroll_active = false;
      }
    }
  },
  computed: {
    isOpenAddToCart() {
      return this.$store.getters
    },
    totalProduct() {
      return this.$store.getters.getTotalProduct;
    },
    isAddToCart() {
      return this.$store.getters.getSatusOpenModal;
    },
    customer() {
      if (Object.keys(this.$store.state.customer).length === 0) {
        return 'Tài khoản'
      } else return this.$store.getters.getNameCustomer;
    },

  },
  data() {
    return {
      Resource: resource,
      menuLayout: [],
      scroll_active: false,
      dynamicUrlProduct: dynamicUrlProduct,
    };
  },
};
</script>
