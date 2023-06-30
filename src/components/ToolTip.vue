<template>
    <div class="tooltip" v-show="isToolTip">
      <span
        class="tooltiptext"
        :class="{ top: isTop, bottom: !isTop, rectangle: isRectangle }"
        >{{ text }}</span
      >
    </div>
</template>
<script>
export default {
    name: "ToolTip",
    props:{
        isToolTip:{
            type:Boolean,
            default:false
        },
        text: {
        type: String,
        default: "Trắng",
      },
      //vị trí của mũi tên (tên/dưới)
      isTop: {
        type: Boolean,
        default: false, //mặc định bên dưới
      },
      isRectangle: {
        //có phải hình chữ nhật không
        type: Boolean,
        default: false, //mặc định có mũi tên
      },
    }
}
</script>
<style scoped>
    /*------------------------------------
    Custom Tooltip
--------------------------------------*/

.tooltip {

    display: inline-block;
}

.tooltiptext {
   
    visibility: visible;
    background-color: #000;
    color: #fff;
    text-align: center;
    border-radius: 4px;
    padding: 5px;
    position: absolute;
    z-index: 1;
    bottom: 113%;
    left: -6px;
    width: 45px;
}


/*mũi tên bên dưới*/

.bottom.tooltiptext::after {
    content: "";
    position: absolute;
    top: 100%;
    left: 50%;
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: #505050 transparent transparent transparent;
}

.top.tooltiptext::after {
    content: "";
    position: absolute;
    top: -30%;
    left: 50%;
    transform: rotate(180deg);
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: #505050 transparent transparent transparent;
}

.rectangle.tooltiptext {
    border-radius: 0px;
}

.rectangle.tooltiptext::after {
    display: none;
    content: "";
    position: absolute;
    top: -30%;
    left: 50%;
    transform: rotate(180deg);
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: #505050 transparent transparent transparent;
}

.tooltip:hover .tooltiptext {
    visibility: visible;
}
</style>