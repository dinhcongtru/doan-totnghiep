<template>
  <header>
    <div class="mert">
      <span class="mert-row--phone">
        <div class="phone-contac">
          <div class="iconTop icon-1-top"></div>
          <div class="telephone">{{ Resource.HEADER.telephone }}</div>
        </div>
      </span>
      <span class="mert-row--cart">
        <div class="account">
          <a href="/user/signin" @click="logOut">
            <div class="iconTop icon-4-top"></div>
            <div class="account-name">{{ customer }}</div>
            <i v-if="Object.keys(this.$store.state.customer).length > 0" class="fa-light fa-right-from-bracket" style="font: normal normal normal 14px/1 FontAwesome;color: #adadad"></i>
          </a>
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
            <img
              src="@/assets/img/20140514_zDIzVUPzsug50Im3jvclQm0H.webp"
              alt=""
            />
          </span>
        </div>
      </a>
      <div class="menu">
        <ul>
          <li v-for="(menu, index) in menuLayout" :key="index">
            <router-link
              :to="{
                name: 'CategoryName',
                params: { name: menu.url },
                query: { name: menu.nameCate },
              }"
              >{{ menu.nameCate }}</router-link
            >
            <!-- option -->
            <div class="option" v-show="menu.isHasOption">
              <div class="option-menu">
                <ul>
                  <li
                    v-for="(option, ind) in menu.optionMenus"
                    :key="ind"
                    :class="{ relative: menu.children }"
                  >
                    <router-link
                      :to="{
                        name: 'CategoryName',
                        params: { name: option.url },
                        query: { name: option.name },
                      }"
                    >
                      {{ option.name }}
                    </router-link>
                    <div class="somi-menu" v-show="option.isHasChildren">
                      <div
                        v-for="(option, index) in menu.optionChildren"
                        :key="index"
                      >
                        <router-link
                          :to="{
                            name: 'CategoryName',
                            params: { name: option.url },
                            query: { name: option.name },
                          }"
                          >{{ option.name }}</router-link
                        >
                      </div>
                    </div>
                  </li>
                </ul>
              </div>
              <div class="option-img">
                <router-link
                  :to="{
                    name: 'product',
                    params: { name: itemPro.url },
                    query: { category: itemPro.category, name: itemPro.name },
                  }"
                  v-for="(itemPro, index) in menu.itemProducts"
                  :key="index"
                >
                  <div>
                    <img :src="require('@/assets/img/' + itemPro.img)" alt="" />
                    <div class="text-img">
                      {{ itemPro.name }}
                    </div>
                  </div>
                </router-link>
              </div>
            </div>
          </li>
          <li>
            <router-link :to="{name :'album'}">album</router-link>
          </li>
          <li>
            <router-link :to="{name :'news'}">Tin Tức</router-link>
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
import resource from "@/resource";
// import { dynamicUrlProduct } from "@/methods/index";
import {menuLayout} from '@/resource/TestData'
import { store } from '@/store';
export default {
  name: "TheHeader",
  methods: {
    onToggleAddToCart() {
      store.commit("handleOpenAddtoCart")
    },
    logOut(){

      if(Object.keys(this.$store.state.customer).length > 0){
        store.commit("removeCustomer")
      }
    },
    

  },
  computed: {
    isOpenAddToCart(){
      return this.$store.getters
    },
    totalProduct() {
      return this.$store.getters.getTotalProduct;
    },
    isAddToCart(){
      return this.$store.getters.getSatusOpenModal;
    },
    customer(){
      if(Object.keys(this.$store.state.customer).length === 0){
        return 'Tài khoản'
      }else  return this.$store.getters.getNameCustomer;
    },

  },
  data() {
    return {
      Resource: resource,
      menuLayout : menuLayout
    };
  },
};
</script>
