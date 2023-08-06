<template>
    <div id="modalSize" class="modal fade" role="dialog" :class="{'in' : isModalSize}">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close tp_button" data-dismiss="modal" @click="closeModal">×</button>
                    <h4 class="modal-title">Hướng dẫn chọn size</h4>
                </div>
                <div class="modal-body">
                    <img :src="typeContentImage" alt="20230731_bRBjdoBN.png">
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name: "ModalSize",
    props:{
        isModalSize:{
            type: Boolean,
            default : false
        },
        typeContentImage:{
            type:String,
            default: "https://pos.nvncdn.net/be3159-662/ps/content/20230731_bRBjdoBN.png"
        }
    },
    methods:{
        closeModal(){
            this.$emit("closeModal")
        }
    }
}
</script>
<style scoped>
*,body{
    font-family: roboto;
   
}

    .fade {
    opacity: 0;
    visibility: hidden;
    -webkit-transition: opacity .15s linear;
    -o-transition: opacity .15s linear;
    transition: opacity .15s linear;
}
.modal {
    position: fixed;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    z-index: 1050;
    overflow-x: hidden;
    overflow-y: auto;
    -webkit-overflow-scrolling: touch;
    outline: 0;
    background: rgb(0 0 0 / 50%)
}
.fade.in {
    opacity: 1;
    visibility: visible;
    /* display: block; */
}
/* .modal {
    overflow-x: hidden;
    overflow-y: auto;
} */
.modal-dialog {
    position: relative;
    width: auto;
    margin: 10px;
}
@media (min-width: 768px){
.modal-dialog {
    width: 600px;
    margin: 30px auto;
}
}
@media (min-width: 1024px){
.modal-dialog {
    width: 900px;
    margin: 30px auto;
}
}
.modal.fade .modal-dialog {
    -webkit-transition: -webkit-transform .3s ease-out;
    -o-transition: -o-transform .3s ease-out;
    /* transition: transform .3s ease-out; */
    transition: all .3s;
    -webkit-transform: translate(0,-25%);
    -ms-transform: translate(0,-25%);
    -o-transform: translate(0,-25%);
    transform: translate(0,-25%);
}
.modal.in .modal-dialog {
    -webkit-transform: translate(0,0);
    -ms-transform: translate(0,0);
    -o-transform: translate(0,0);
    transform: translate(0,0);
}
.modal-content {
    position: relative;
    background-color: #fff;
    -webkit-background-clip: padding-box;
    background-clip: padding-box;
    border: 1px solid #999;
    border: 1px solid rgba(0,0,0,.2);
    border-radius: 6px;
    outline: 0;
    -webkit-box-shadow: 0 3px 9px rgba(0,0,0,.5);
    box-shadow: 0 3px 9px rgba(0,0,0,.5);
}
@media (min-width: 768px){
.modal-content {
    -webkit-box-shadow: 0 5px 15px rgba(0,0,0,.5);
    box-shadow: 0 5px 15px rgba(0,0,0,.5);
}
}
#modalSize .modal-content, #modalGift .modal-content, #showStore .modal-content {
    border-radius: 0;
    box-shadow: none;
    -webkit-box-shadow: none;
    border: none;
}
.modal-header {
    min-height: 16.43px;
    padding: 15px;
    border-bottom: 1px solid #e5e5e5;
}
#modalSize .modal-header, #modalGift .modal-header, #showStore .modal-header {
    background: #e6e6e6;
}
button, input, optgroup, select, textarea {
    margin: 0;
    font: inherit;
    color: inherit;
}
button {
    overflow: visible;
}
button, select {
    text-transform: none;
}
button, html input[type=button], input[type=reset], input[type=submit] {
    -webkit-appearance: button;
    cursor: pointer;
}
.close {
    float: right;
    font-size: 21px;
    font-weight: 700;
    line-height: 1;
    color: #000;
    text-shadow: 0 1px 0 #fff;
    filter: alpha(opacity=20);
    opacity: .2;
}
button.close {
    -webkit-appearance: none;
    padding: 0;
    cursor: pointer;
    background: 0 0;
    border: 0;
}
.modal-header .close {
    margin-top: -2px;
}
.modal-content .close, #quickview-cart-desktop .close {
    opacity: 1;
    position: absolute;
    right: 15px;
    top: 15px;
    cursor: pointer;
    z-index: 9999;
}
#modalSize .close, #modalGift .close, #showStore .close {
    position: absolute;
    right: 14px;
    opacity: 1;
}
h1, h2, h3, h4, h5, h6 {
    color: #252a2b;
    margin: 0 0 13px 0;
    font-weight: 500;
    line-height: 1.2;
}
.modal-title {
    margin: 0;
    line-height: 1.42857143;
}
#modalSize .modal-title, #modalGift .modal-title, #showStore .modal-title {
    font-size: 15px;
    text-transform: uppercase;
    text-align: center;
}
.modal-body {
    position: relative;
    padding: 15px;
}
#modalSize .modal-body, #modalGift .modal-body {
    text-align: center;
}
img {
    border: 0;
}
img {
    vertical-align: middle;
}
img {
    max-width: 100%;
    width: 100%;
    height: auto;
}
img {
    max-width: 100%;
}
::-webkit-scrollbar{
    width: 7px;
    background-color: #d3d3d3;
}
::-webkit-scrollbar-thumb{
    background-color: #d3d3d3;
    border-radius: 100px;
}
</style>