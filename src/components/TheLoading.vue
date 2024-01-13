<template>
      <div class="container_loading" v-show="is_loading">
            <div class="thumb">
                  <img src="../assets/img/loading_tool.gif" alt="">
            </div>
      </div>
</template>
<script>
export default {
      name: "TheLoading",
      mounted(){
            document.querySelector("body").style.overflow = "hidden";
      },
      props :{
            is_loading: {
                  type :Boolean,
                  default: false
            }
      }
}
</script>
<style scoped>

.container_loading {
      width: 100%;
      height: 100%;
      display: flex;
      align-items: center;
      justify-content: center;
      position: absolute;
      top: 0;
      z-index: 10000;

}

.thumb {
      width: 100px;
      height: 100px;
}

img {
      width: 100%;
      height: 100%;
      object-fit: cover;
}
</style>