<template>
    <div class="tooltip" v-show="isErorr">
      <span
        class="tooltiptext"
        :class="{ top: isTop, bottom: !isTop, rectangle: isRectangle }"
        :style="[`right:${right}px;left:${left}px;width:${width}px;bottom:${bottom}%;`]"
        >* {{ text }}</span
      >
    </div>
</template>
<script>
export default {
    name: "ErorrValidate",
    props:{
        right:{
            type:Number,
            default:-90
        },
        left:{
            type: [String,Number],
            default:"unset"
        },
        width:{
            type:[String,Number],
            default:"auto"
        },
        bottom:{
            type: Number,
            default: 113
        },
        isErorr:{
            type:Boolean ,
            default:false
        },
        text: {
        type: String,
        default: "Trường này bắt buộc",
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

.tooltiptext {
   
    visibility: visible;
    background-color: #ee0101;
    color: #fff;
    text-align: center;
    border-radius: 4px;
    padding: 5px;
    position: absolute;
    z-index: 1;
    bottom: 113%;
    left: unset;
    width: auto;
    border: 2px solid #ddd;
    box-shadow: 0 0 6px #000;
    -moz-box-shadow: 0 0 6px #000;
    -webkit-box-shadow: 0 0 6px #000;
    -o-box-shadow: 0 0 6px #000;
    padding: 4px 10px;
    border-radius: 6px;
    -moz-border-radius: 6px;
    -webkit-border-radius: 6px;
    -o-border-radius: 6px;
}


/*mũi tên bên dưới*/

.bottom.tooltiptext::after {
    content: "";
    position: absolute;
    top: 102%;
    left: 12%;
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: #ee0101 transparent transparent transparent;
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
    border-color: #ee0101 transparent transparent transparent;
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
    border-color: #ee0101 transparent transparent transparent;
}

.tooltip:hover .tooltiptext {
    visibility: visible;
}
</style>