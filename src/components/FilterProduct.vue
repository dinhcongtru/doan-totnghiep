<template>
    <div class="filter-custom">
        <span>Bộ lọc</span>
        <div class="groupFilterNew">
            <div class="titleFilter">
                <div class="layered_subtitle">
                    <span>Màu sắc</span>
                    <i class="fa fa-sort-down"></i>
                </div>
                <div class="layered_subtitle">
                    <span>Kích cỡ</span>
                    <i class="fa fa-sort-down"></i>
                </div>
                <div class="layered_subtitle">
                    <span>Khoảng giá</span>
                    <i class="fa fa-sort-down"></i>
                </div>
            </div>
            <div class="contentFilter">
                <div class="filter-color">
                    <ul class="check-box-list">
                        <li class="filter-item" v-for="(itemColor,index) in colorData" :key="index">
                            <input type="checkbox" :checked="itemColor.checkedColor"/>
                            <label :title="itemColor.title" :style="{ backgroundColor: itemColor.background }" @click="changeColorInput(itemColor)">
                                <span class="button tp_button"></span>
                            </label>
                        </li>
                    </ul>
                </div>
                <div class="filter-size">
                    <ul class="check-box-list">
                        <li class="active filter-item" v-for="(itemSize,index) in sizeData" :key="index">
                            <input type="checkbox" :checked = itemSize.checkedSize />
                            <label>
                            <span class="tp_button" :class="{button : itemSize.checkedSize}" @click="changeColorSize(itemSize)"></span>
                            {{ itemSize.size }} </label>
                        </li>
                    </ul>
                </div>
                <div class="filter-price">
                    <ul class="check-box-list">
                        <li class="filter-item" v-for="(itemPrice,index) in princeData" :key="index">
                            <input type="checkbox" :checked="itemPrice.checkedPrice">
                            <label>
                                <span class="tp_button" :class="{button : itemPrice.checkedPrice}" @click="changeColorPrice(itemPrice)"></span>
                                {{ itemPrice.price }}
                            </label>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default{
    name: "FiterProduct",
    props:{
        //option color filter
        colorData:{
            type:Array,
            default: () => 
            [
                {
                    checkedColor : false, 
                    title : "Đỏ", 
                    background : "#FF0000" 
                },
            ]
        },
        // option size filter
        sizeData:{
            type:Array,
            default: () =>
            [
                {
                    checkedSize : false,
                    size : "S"
                }
            ]
        },
        // option price filter
        princeData:{
            type:Array,
            default: () =>
            [
                {
                    checkedPrice : false, 
                    price : "Dưới 200,000"
                }
            ]
        }
    },
    methods:{
        changeColorInput(color){
            color.checkedColor = !color.checkedColor
        },
        changeColorSize(item){
            item.checkedSize = !item.checkedSize;
        },
        changeColorPrice(item){
            item.checkedPrice = !item.checkedPrice;
        }
    }
}
</script>
<style scoped>
.filter-custom {
  display: flex;
  margin: 10px 0 30px;
  align-items: center;
}
.filter-custom > span {
  margin-right: 15px;
  padding: 10px 0;
  text-transform: uppercase;
  font-size: 15px;
}
.groupFilterNew {
  padding: 10px 0;
  width: 40%;
  position: relative;
  cursor: pointer;
}
.titleFilter {
  display: flex;
  justify-content: space-between;
}
.layered_subtitle {
  display: flex;
}
.layered_subtitle > span {
  font-size: 15px;
  font-weight: 700;
  margin-right: 5px;
}
.fa-sort-down:before {
  color: #ccc;
  
}
.fa{
    margin-top: 2.5px;
}
.contentFilter {
    border: 1px solid #f1f1f1;
    padding: 10px;
    position: absolute;
    z-index: 99;
    background: #fff;
    top: 41px;
    width: 180%;
    padding-bottom: 25px;
    /* display: flex; */
    opacity: 0;
    visibility: hidden;
    transition: opacity 0.5s linear;
}
.groupFilterNew:hover .contentFilter{
    display: flex;
    opacity: 1;
    visibility: visible;
   
}
.contentFilter > .filter-color{
    max-height: 250px;
    overflow-y: auto;
    margin-right: 20px;
    width: 140px;
}
.contentFilter > .filter-color > ul{
    display: flex;
    flex-wrap: wrap;
    align-items: center;
}
.contentFilter > .filter-color > ul > li{
    margin: 0 5px 0 0;
}
input[type="checkbox"] {
    display: none;
}
.contentFilter > .filter-color > ul > li > label{
    border: 1px solid #eaeaea;
    width: 25px;
    height: 25px;
    padding-top: 6px;
    padding-left: 6px;
    float: left;
    margin-bottom: 5px;
    cursor: pointer;
}
.filter-color li input[type=checkbox]:checked+label {
    border-color: #f36;
    background-image: url(../assets/img/select-pro.png);
    background-position: right bottom;
    background-repeat: no-repeat;
}
.filter-size{
    width: 140px;
    max-height: 250px;
    overflow-y: auto;
    margin-right: 20px;
}
ul.check-box-list {
    margin-bottom: 10px;
}
.filter-size > ul > li > label{
    font-family: 'Quicksand';
    display: inline-block;
    cursor: pointer;
    line-height: 12px;
    font-weight: 400;
    margin-bottom: 10px;
    font-size: 15px;
}
.check-box-list input[type=checkbox]:checked+label span.button {
    background: #f36 url(../assets/img/checked.png) no-repeat center center;
}



.filter-size > ul > li > input[type=checkbox]+label span.tp_button {
    display: inline-block;
    width: 12px;
    height: 12px;
    margin-right: 5px;
    padding: 0;
    border: 1px solid #ebebeb;
}
.filter-price{
    width: 195px;
}
.filter-price > ul > li > label{
    font-family: 'Quicksand';
    display: inline-block;
    cursor: pointer;
    line-height: 12px;
    font-weight: 400;
    margin-bottom: 10px;
    font-size: 15px;
}
.filter-price > ul > li > input[type=checkbox]+label span.tp_button {
    display: inline-block;
    width: 12px;
    height: 12px;
    margin-right: 5px;
    padding: 0;
    border: 1px solid #ebebeb;
}

</style>
