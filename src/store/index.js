import { createStore } from "vuex";
import createPersistedState from 'vuex-persistedstate'
// Create a new store instance.
export const store = createStore({
  state() {
    return {
      count: 0,
      name: "Trứ",
      isOpenAddtoCart: false,
      customer :{},
      product: [
        // {
        //   id: 1,
        //   img: "sp1.jpeg",
        //   namePro: "Áo Blazer Casual 0391",
        //   color: "Be",
        //   size: "L",
        //   price: 375000,
        //   qty: 1
        // },
        //   {
        //     id : 2,
        //     img : "sp1.jpeg",
        //     namePro :"Áo Blazer Casual 0391",
        //     color :"Be",
        //     size: "L",
        //     price:450000,
        //     qty: 2
        //   },
        //   {
        //     id : 3,
        //     img : "sp1.jpeg",
        //     namePro :"Áo Blazer Casual 0391",
        //     color :"Be",
        //     size: "L",
        //     price:550000,
        //     qty: 5
        //   }
      ],
    };
  },
  getters: {
    getNameProduct(state) {
      return state.name;
    },
    getTotalProduct(state){
      if(Object.keys(state.customer).length == 0){
        return state.product.reduce((total,product) => {
            return total + (product.qty)
        },0);
      }else{
        return state.customer.product.reduce((total,product) => {
          return total + (product.qty)
      },0);
      }
    },
    getTotalPrice(state){
      if(Object.keys(state.customer).length == 0){
        return state.product.reduce((total,product) => {
            return total + (product.price * product.qty)
        },0);
      }else{
        if(state.customer.product.length == 0){
          return 0;
        }else{
            return state.customer.product.reduce((total,product) => {
              return total + (product.price * product.qty)
          },0);
        }
       
      }
    },
    getProduct(state){
      if(Object.keys(state.customer).length == 0){
        return state.product;
      }else{
         return state.customer.product;
       
      }
    },
    getSatusOpenModal(state){
      return state.isOpenAddtoCart;
    },
    getNameCustomer(state){
      return state.customer.name;
    }
  },
  mutations: {
    handleAddProductToCart(state, product) {
      
        if(!product) return
        if(Object.keys(state.customer).length == 0){
            for(let item of state.product){
              if(product.id === item.id && product.color === item.color && product.size === item.size){
                item.qty += product.qty
                return
              }

            }
            state.product.push(product)
        }else{
          for(let item of state.customer.product){
            if(product.id === item.id && product.color === item.color && product.size === item.size){
              item.qty += product.qty
              return
            }

          }
          state.customer.product.push(product)
        }
    },
    handleRemoveProductToCart(state,param) {
        if(!param.id) return
        //logic xóa
        if(Object.keys(state.customer).length == 0){
            let index = state.product.findIndex(item => item.id == param.id && item.size == param.size && item.color == param.color);
            state.product.splice(index,1);
        }else{
          let index = state.customer.product.findIndex(item => item.id == param.id && item.size == param.size && item.color == param.color);
          state.customer.product.splice(index,1);
        }
        

    },
    handleOpenAddtoCart(state){
      state.isOpenAddtoCart = !state.isOpenAddtoCart;
    },
    handlePlusQuantity(state,payload){
      if(Object.keys(state.customer).length == 0){
          const productCurrent = state.product.filter(product => product.id == payload.id && product.color == payload.color && product.size == payload.size)[0]
          productCurrent.qty += 1;
      }else{
        const productCurrent = state.customer.product.filter(product => product.id == payload.id && product.color == payload.color && product.size == payload.size)[0]
         console.log(productCurrent);
         productCurrent.qty += 1;
      }
    },
    handleMinusQuantity(state,payload){
      if(Object.keys(state.customer).length == 0){
          const productCurrent = state.product.filter(product => product.id == payload.id && product.color == payload.color && product.size == payload.size)[0]
          productCurrent.qty -= 1;
      }else{
        const productCurrent = state.customer.product.filter(product => product.id == payload.id && product.color == payload.color && product.size == payload.size)[0]
        productCurrent.qty -= 1;
      }
    },
    handleAddCustomer(state,customer){
      state.customer = customer
    },
    removeCustomer(state){
      state.customer = {}
    }
  },

  plugins: [
    createPersistedState(
      {
        key: 'store-app-state', // Đặt tên key cho mảng
        paths: ['product','customer'], // Chỉ lưu trữ mảng này
        transformState: (state) => ({
          product: state.product.slice(0), // Tạo bản sao của mảng để lưu trữ
          customer: state.customer.slice(0)
        })
      })
  ]
});
