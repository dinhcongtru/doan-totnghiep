<template>
  
  <header>
    <add-to-cart :isAddToCart="isAddToCart" @onCloseModal="onToggleAddToCart" :cartQty="cartQty"/>
    <div class="mert">
      <span class="mert-row--phone">
        <div class="phone-contac">
          <div class="iconTop icon-1-top"></div>
          <div class="telephone">{{ Resource.HEADER.telephone }}</div>
        </div>
      </span>
      <span class="mert-row--cart">
        <div class="account">
          <a href="#">
            <div class="iconTop icon-4-top"></div>
            <div class="account-name">{{ Resource.HEADER.accountName }}</div>
          </a>
        </div>
        <div class="cart" @click="onToggleAddToCart">
          <a href="#">
            <div class="iconTop icon-5-top"></div>
            <div class="cart-title">{{ Resource.HEADER.cartTitle }}</div>
            <span class="red-color">({{ cartQty }})</span>
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
          <li v-for="(menu,index) in menuLayout" :key="index">
            <router-link :to="{ name: 'CategoryName', params: { name: menu.url },query: {name: menu.nameCate }}">{{ menu.nameCate }}</router-link>
            <!-- option -->
            <div class="option" v-show="menu.isHasOption">
              <div class="option-menu">
                <ul>
                  <li v-for="(option,ind) in menu.optionMenus" :key="ind" :class="{'relative' : menu.children}">
                    <router-link :to="{ name: 'CategoryName', params: { name: option.url },query: {name: option.name }}">
                    {{ option.name }}
                    </router-link>
                    <div class="somi-menu" v-show="option.isHasChildren">
                      <div v-for="(option,index) in menu.optionChildren" :key="index">
                        <router-link :to="{name : 'CategoryName',params : {name: option.url},query:{name : option.name}}">{{
                          option.name
                        }}</router-link>
                      </div>
                    </div>
                  </li>
                </ul>
              </div>
              <div class="option-img">
                <router-link :to="{name : 'product', params :{name: itemPro.url},query:{category:itemPro.category,name:itemPro.name}}" v-for="(itemPro,index) in menu.itemProducts" :key="index">
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
        </ul>
      </div>
      <div class="input-search">
        <span>
          <input type="text" placeholder="Tìm kiếm..." />
        </span>
        <div class="icon-search"></div>
      </div>
    </div>
    <phi-story />
  </header>
</template>

<script>
import resource from "@/resource";
import {dynamicUrlProduct} from '@/methods/index'
import addToCart from '@/views/addToCart.vue';
export default {
  components: { addToCart },
  name: "TheHeader",
  methods:{
    onToggleAddToCart(){
      this.isAddToCart = !this.isAddToCart;
    }
  },
  data() {
    return {
      isAddToCart : false,
      Resource: resource,
      cartQty: 1,
      menuLayout:[
          {
            url :dynamicUrlProduct('Sale'),
            nameCate : "Sale",
            children : false,
            optionMenus : [
            {
                url :dynamicUrlProduct('Sale Đồng Giá 99k'),
                name : 'Sale Đồng Giá 99k',
                isHasChildren : false
              },
              {
                url :dynamicUrlProduct('Sale Đồng Giá 149K'),
                name :'Sale Đồng Giá 149K',
                isHasChildren : false
              },
              {
                url:dynamicUrlProduct('Sale Off 50%'),
                name : 'Sale Off 50%',
                isHasChildren : true
              }
            ],
            itemProducts :[
              {
                url:dynamicUrlProduct('Áo Phông Regular Cotton 1063'),
                name : 'Áo Phông Regular Cotton 1063',
                category :"Áo Polo",
                img : 'sale1.jpeg'
              },
              {
                url:dynamicUrlProduct('Áo Sơ Mi Cổ Đức Dài Tay Slim Polyster 3022'),
                name : 'Áo Sơ Mi Cổ Đức Dài Tay Slim Polyster 3022',
                category :"Áo Sơ Mi",
                img : 'sale2.jpeg'
              },
              {
                url:dynamicUrlProduct('Áo Sơ Mi Cổ Đức Dài Tay Regular Cotton 3010'),
                name : 'Áo Sơ Mi Cổ Đức Dài Tay Regular Cotton 3010',
                category :"Áo Sơ Mi",
                img : 'sale3.jpeg'
              },
            ],
            isHasOption : true,
          },
          {
            url :dynamicUrlProduct('Áo Nam'),
            nameCate : "Áo Nam",
            children : true,
            optionMenus : [
              {
                url : dynamicUrlProduct('Áo Blazer'),
                name :'Áo Blazer',
                isHasChildren : false
              },
              {
                url : dynamicUrlProduct('Áo Phông'),
                name :'Áo Phông',
                isHasChildren : false
              },
              {
                url : dynamicUrlProduct('Áo Sơ Mi'),
                name :'Áo Sơ Mi',
                isHasChildren : true
              },
              {
                url : dynamicUrlProduct('Áo Tanktop'),
                name :'Áo Tanktop',
                isHasChildren : false
              },
              {
                url : dynamicUrlProduct('Áo Polo'),
                name :'Áo Polo',
                isHasChildren : false
              }
            ],
            itemProducts :[
              {
                url:dynamicUrlProduct('Áo Polo Cổ Đức Regular Cotton 2068'),
                name : 'Áo Polo Cổ Đức Regular Cotton 2068',
                category:"Áo Polo",
                img : 'áo1.jpeg'
              },
              {
                url:dynamicUrlProduct('Áo Phông Classic Cotton 1094'),
                name : 'Áo Phông Classic Cotton 1094',
                category:"Áo Phông",
                img : 'áo2.jpeg'
              },
              {
                url:dynamicUrlProduct('Áo Polo Cổ Đức Classic Cotton 2065'),
                name : 'Áo Polo Cổ Đức Classic Cotton 2065',
                category:"Áo Polo",
                img : 'áo3.jpeg'
              },
            ],
            optionChildren:[
              {
                url:dynamicUrlProduct('Sơ mi cộc tay'),
                name :'Sơ mi cộc tay'
              },
              {
                url:dynamicUrlProduct('Sơ mi dài tay'),
                name :'Sơ mi dài tay'
              }
            ],
            isHasOption : true,
          },
          {
            url:dynamicUrlProduct('quần nam'),
            nameCate : "quần nam",
            children : false,
            optionMenus : [
              {
                url:dynamicUrlProduct('Quần Jeans'),
                name :'Quần Jeans',
                isHasChildren : false
              },
              {
                url:dynamicUrlProduct('Quần Short'),
                name :'Quần Short',
                isHasChildren : false
              },
              {
                url:dynamicUrlProduct('Quần Âu'),
                name :'Quần Âu',
                isHasChildren : true
              },
              {
                url:dynamicUrlProduct('Quần Jogge'),
                name :'Quần Jogge',
                isHasChildren : false
              },
              {
                url:dynamicUrlProduct('Quần Kaki'),
                name :'Quần Kaki',
                isHasChildren : false
              }
            ],
            itemProducts :[
              {
                url:dynamicUrlProduct('Quần Linen Loosefit Cotton 6511'),
                name : 'Quần Linen Loosefit Cotton 6511',
                category:"Quần Jeans",
                img : 'quan1.jpeg'
              },
              {
                url:dynamicUrlProduct('Quần Short Regular Kaki 8036'),
                name : 'Quần Short Regular Kaki 8036',
                category:"Quần Short",
                img : 'quan2.jpeg'
              },
              {
                url:dynamicUrlProduct('Quần Kaki Slim Cotton 6507'),
                name : 'Quần Kaki Slim Cotton 6507',
                category:"Quần Kaki",
                img : 'quan3.webp'
              },
            ],
            isHasOption : true,
          },
          {
            url:dynamicUrlProduct('phụ kiện'),
            nameCate : "phụ kiện",
            children : false,
            optionMenus : [
            {
                url:dynamicUrlProduct('Dây Lưng'),
                name :'Dây Lưng',
                isHasChildren : false
              },
              {
                url:dynamicUrlProduct('Balo + Cặp Xách'),
                name :'Balo + Cặp Xách',
                isHasChildren : false
              },
              {
                url:dynamicUrlProduct('Giày Dép'),
                name :'Giày Dép',
                isHasChildren : true
              },
              {
                url:dynamicUrlProduct('Mũ Nam'),
                name :'Mũ Nam',
                isHasChildren : false
              },
              {
                url:dynamicUrlProduct('Tất Nam'),
                name :'Tất Nam',
                isHasChildren : false
              },
              {
                url:dynamicUrlProduct('Quần Lót'),
                name :'Quần Lót',
                isHasChildren : false
              }
            ],
            itemProducts :[
              {
                url:dynamicUrlProduct('Giày Oxford 0026'),
                name : 'Giày Oxford 0026',
                category:"Giày Dép",
                img : 'pk1.jpeg'
              },
              {
                url:dynamicUrlProduct('Giày Loafer 0025'),
                name : 'Giày Loafer 0025',
                category:"Giày Dép",
                img : 'pk2.jpeg'
              },
              {
                url:dynamicUrlProduct('Balo Da 0020'),
                name : 'Balo Da 0020',
                category:"Ballo + Cặp xách",
                img : 'pk3.jpeg'
              },
            ],
            isHasOption : true,
          },
          {
            url:dynamicUrlProduct('album'),
            nameCate : "album",
            children : false,
            isHasOption : false,
          },
          {
            url:dynamicUrlProduct('Tin tức'),
            nameCate : "Tin tức",
            children : false,
            isHasOption : false,
          },
      ]
    };
  },
};
</script>
