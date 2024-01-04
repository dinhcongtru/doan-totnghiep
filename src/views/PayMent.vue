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
import { RepositoryFactory } from "@/Repository/RepositoryFactory";
const productRepository = RepositoryFactory.get("Products");
const customerRepository = RepositoryFactory.get("Customers");
export default {
   name: "PayMent",
   data() {
      return {
         products: [],
         customer: {
            id: 1,
            fullName: "trứ",
            password: "dsadwe7",
            // email: "trudc@caerux.com"       
         },
         logginSocial: {
            fullName: "trudc",
            email: "trud@đa.com.vn"
         },
         cateID : "47782bc9-1bf1-7c7b-6ee3-2ceaa9cf3765",
      }
   },
   mounted() {
      this.getAllProduct();
      this.logInCustomer();
      this.logInSocial();
      this.getProductByCategory();
   },
   methods: {
      async getAllProduct() {
         try {
            await productRepository.getAllProduct().then((response) => {
               this.products = response.data;
               console.log(this.products);
            });
         } catch (error) {
            console.log(error);
         }
      },
      async getProductByCategory() {
         try {
            await productRepository.getProductByCategory(this.cateID).then((response) => {
               console.log("bycate",response.data);
            });
         } catch (error) {
            console.log(error);
         }
      },
      async logInCustomer() {
         try {
            await customerRepository.loginCustomer(this.customer).then((res) => {
               console.log(res);
            })
         }catch(error){
            console.log(error);
         }
      },
      async logInSocial() {
         try {
            await customerRepository.loginBySocial(this.logginSocial).then((res) => {
               console.log(res.data);
            })
         }catch(error){
            console.log(error);
         }
      },
   }
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