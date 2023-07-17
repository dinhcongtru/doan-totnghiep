import { createStore } from "vuex";
import createPersistedState from 'vuex-persistedstate'
// Create a new store instance.
export const store = createStore({
  state() {
    return {
      count: 0,
      name: "Trứ",
      isOpenAddtoCart: false,
      product: [
        {
          id: 1,
          img: "sp1.jpeg",
          namePro: "Áo Blazer Casual 0391",
          color: "Be",
          size: "L",
          price: 375000,
          qty: 1
        },
          {
            id : 2,
            img : "sp1.jpeg",
            namePro :"Áo Blazer Casual 0391",
            color :"Be",
            size: "L",
            price:450000,
            qty: 2
          },
          {
            id : 3,
            img : "sp1.jpeg",
            namePro :"Áo Blazer Casual 0391",
            color :"Be",
            size: "L",
            price:550000,
            qty: 5
          }
      ],
    };
  },
  getters: {
    getNameProduct(state) {
      return state.name;
    },
    getTotalProduct(state){
        return state.product.reduce((total,product) => {
            return total + (product.qty)
        },0);
    },
    getTotalPrice(state){
        return state.product.reduce((total,product) => {
            return total + (product.price * product.qty)
        },0);
    },
    getSatusOpenModal(state){
      return state.isOpenAddtoCart;
    }
  },
  mutations: {
    handleAddProductToCart(state, product) {
      
        if(!product) return
        for(let item of state.product){
          if(product.id === item.id && product.color === item.color && product.size === item.size){
            item.qty += product.qty
            return
          }

        }
        state.product.push(product)
    },
    handleRemoveProductToCart(state,param) {
        if(!param.id) return
        //logic xóa
        
        let index = state.product.findIndex(item => item.id == param.id && item.size == param.size && item.color == param.color);
        state.product.splice(index,1);
        
        

    },
    handleOpenAddtoCart(state){
      state.isOpenAddtoCart = !state.isOpenAddtoCart;
    },
    handlePlusQuantity(state,id){
      const productCurrent = state.product.filter(product => product.id == id)[0]
      productCurrent.qty += 1;

    },
    handleMinusQuantity(state,id){
      const productCurrent = state.product.filter(product => product.id == id)[0]
      productCurrent.qty -= 1;
    }
  },

  plugins: [
    createPersistedState({
      key: 'pro-Cart', // Đặt tên key cho mảng
      paths: ['product'], // Chỉ lưu trữ mảng này
      transformState: (state) => ({
        product: state.product.slice(0) // Tạo bản sao của mảng để lưu trữ
      })
    })
  ]
});
