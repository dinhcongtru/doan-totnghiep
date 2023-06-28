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
          <a href="#">
            <div class="iconTop icon-4-top"></div>
            <div class="account-name">{{ Resource.HEADER.accountName }}</div>
          </a>
        </div>
        <div class="cart">
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
          <li>
            <a href="/sale-pc95934.html">{{ Resource.HEADER.sale }}</a>
            <!-- option -->
            <div class="option">
              <div class="option-menu">
                <ul>
                  <li>
                    <a href="/sale-dong-gia-99k.html">{{
                      Resource.HEADER.optionSale.op1
                    }}</a>
                  </li>
                  <li>
                    <a href="/sale-dong-gia-149k.html">{{
                      Resource.HEADER.optionSale.op2
                    }}</a>
                  </li>
                  <li>
                    <a href="/sale-off-50.html">{{
                      Resource.HEADER.optionSale.op3
                    }}</a>
                  </li>
                </ul>
              </div>
              <div class="option-img">
                <a href="#">
                  <div>
                    <img src="@/assets/img/sale1.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optiontitleImgSale.titleImg1 }}
                    </div>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <img src="@/assets/img/sale2.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optiontitleImgSale.titleImg2 }}
                    </div>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <img src="@/assets/img/sale3.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optiontitleImgSale.titleImg3 }}
                    </div>
                  </div>
                </a>
              </div>
            </div>
          </li>
          <li>
            <a href="/ao-nam-pc95934.html">{{ Resource.HEADER.shortMen }}</a>
            <!-- option -->
            <div class="option">
              <div class="option-menu">
                <ul>
                  <li>
                    <a href="/ao-blazer-pc564635.html">{{
                      Resource.HEADER.optionShortMen.op1
                    }}</a>
                  </li>
                  <li>
                    <a href="/ao-phong-pc6379.html">{{
                      Resource.HEADER.optionShortMen.op2
                    }}</a>
                  </li>
                  <li class="relative">
                    <a href="/ao-so-mi-pc76944.html">{{
                      Resource.HEADER.optionShortMen.op3
                    }}</a>
                    <div class="somi-menu">
                      <div>
                        <a href="/so-mi-coc-tay-pc565515.html">{{
                          Resource.HEADER.optionSoMi.op1
                        }}</a>
                      </div>
                      <div>
                        <a href="/so-mi-dai-tay-pc565516.html">{{
                          Resource.HEADER.optionSoMi.op2
                        }}</a>
                      </div>
                    </div>
                  </li>
                  <li>
                    <a href="/ao-tanktop-pc321491.html">{{
                      Resource.HEADER.optionShortMen.op4
                    }}</a>
                  </li>
                  <li>
                    <a href="/ao-polo-pc490701.html">{{
                      Resource.HEADER.optionShortMen.op5
                    }}</a>
                  </li>
                </ul>
              </div>
              <div class="option-img">
                <a href="#">
                  <div>
                    <img src="@/assets/img/áo1.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgShortMen.title1 }}
                    </div>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <img src="@/assets/img/áo2.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgShortMen.title2 }}
                    </div>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <img src="@/assets/img/áo3.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgShortMen.title3 }}
                    </div>
                  </div>
                </a>
              </div>
            </div>
          </li>
          <li>
            <a href="/quan-nam-pc6405.html">{{ Resource.HEADER.malePant }}</a>
            <!-- option -->
            <div class="option">
              <div class="option-menu">
                <ul>
                  <li>
                    <a href="/quan-jeans-pc6415.html">{{ Resource.HEADER.optionMalePant.op1 }}</a>
                  </li>
                  <li>
                    <a href="/quan-short-pc6416.html">{{ Resource.HEADER.optionMalePant.op2 }}</a>
                  </li>
                  <li>
                    <a href="/quan-au-pc119402.html">{{ Resource.HEADER.optionMalePant.op3 }}</a>
                  </li>
                  <li>
                    <a href="/quan-jogger-pc123044.html">{{ Resource.HEADER.optionMalePant.op4 }}</a>
                  </li>
                  <li>
                    <a href="/quan-kaki-pc123044.html">{{ Resource.HEADER.optionMalePant.op5 }}</a>
                  </li>
                </ul>
              </div>
              <div class="option-img">
                <a href="#">
                  <div>
                    <img src="@/assets/img/quan1.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgMalePant.op1 }}
                    </div>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <img src="@/assets/img/quan2.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgMalePant.op2 }}
                    </div>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <img src="@/assets/img/quan3.webp" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgMalePant.op3 }}
                    </div>
                  </div>
                </a>
              </div>
            </div>
          </li>
          <li>
            <a href="/phu-kien-pc501328.html">{{ Resource.HEADER.pk }}</a>
            <!-- option -->
            <div class="option">
              <div class="option-menu">
                <ul>
                  <li>
                    <a href="/day-lung-pc501329.html">{{ Resource.HEADER.optionPk.op1 }}</a>
                  </li>
                  <li>
                    <a href="/balo-cap-xach-pc501330.html">{{ Resource.HEADER.optionPk.op2 }}</a>
                  </li>
                  <li>
                    <a href="/giay-dep-pc501330.html">{{ Resource.HEADER.optionPk.op3 }}</a>
                  </li>
                  <li>
                    <a href="/mu-nam-pc501330.html">{{ Resource.HEADER.optionPk.op4 }}</a>
                  </li>
                  <li>
                    <a href="/tat-nam-pc501330.html">{{ Resource.HEADER.optionPk.op5 }}</a>
                  </li>
                  <li>
                    <a href="quan-lot-pc501330.html">{{ Resource.HEADER.optionPk.op6 }}</a>
                  </li>
                </ul>
              </div>
              <div class="option-img">
                <a href="#">
                  <div>
                    <img src="@/assets/img/pk1.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgPk.op1 }}
                    </div>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <img src="@/assets/img/pk2.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgPk.op2 }}
                    </div>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <img src="@/assets/img/pk3.jpeg" alt="" />
                    <div class="text-img">
                      {{ Resource.HEADER.optionTitleImgPk.op3 }}
                    </div>
                  </div>
                </a>
              </div>
            </div>
          </li>
          <li>
            <a href="/album">{{ Resource.HEADER.album }}</a>
          </li>
          <li>
            <a href="/news">{{ Resource.HEADER.new }}</a>
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
</template>

<script>
import resource from "@/resource";
export default {
  name: "TheHeader",
  data() {
    return {
      Resource: resource,
      cartQty: 0,
    };
  },
};
</script>
