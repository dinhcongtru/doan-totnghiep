<template lang="">
    <div class="qr-code">
   <div class="qr-code-image">
      <img src="../assets/img/z4402029676278_4465c134aadb160635f83d6c1b762da6.jpg" alt="QR code">
   </div>
   <div class="qr-code-text">
      <p>Quét mã để thanh toán</p>
   </div>
</div>
</template>
<script>
export default {
    name: "PayMent"
}
</script>
<style scoped>
    .qr-code {
   text-align: center;
   margin-top: 20px;
}

.qr-code-image {
   display: inline-block;
   position: relative;
}

.qr-code-image:before {
   content: '';
   display: block;
   padding-bottom: 100%;
}

.qr-code-image img {
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
}

.qr-code-text {
   margin-top: 10px;
   animation: pulse 1s alternate infinite;
}

@keyframes pulse {
   0% {
      transform: scale(1);
   }
   50% {
      transform: scale(1.2);
   }
   100% {
      transform: scale(1);
   }
}
</style>