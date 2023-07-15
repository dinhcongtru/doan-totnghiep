import { createStore } from "vuex";

// Create a new store instance.
export const store = createStore({
  state() {
    return {
      count: 0,
      name: "Minh",
      isOpenAddtoCart: false,
      product: [
        // {
        //   id: 1,
        //   img: "sp1.jpeg",
        //   namePro: "Áo Blazer Casual 0391",
        //   color: "Be",
        //   size: "L",
        //   price: 1139000,
        //   qty: 1,
        // },
        //   {
        //     id : 2,
        //     img : "sp1.jpeg",
        //     namePro :"Áo Blazer Casual 0391",
        //     color :"Be",
        //     size: "L",
        //     price:1139000,
        //     qty: 2
        //   },
        //   {
        //     id : 3,
        //     img : "sp1.jpeg",
        //     namePro :"Áo Blazer Casual 0391",
        //     color :"Be",
        //     size: "L",
        //     price:1139000,
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
        console.log(product);
        let isExist = state.product.find((item) => item.id == product.id)
        // let cloneProductExitst = { ...isExist}
      
        if(isExist){
            isExist.qty++
        }else{
            state.product.push(product)
        }
    },
    handleRemoveProductToCart(state, id) {
        if(!id) return
        //logic xóa
        state.product = state.product.filter(product => product.id !== id)

    },
    handleOpenAddtoCart(state){
      state.isOpenAddtoCart = !state.isOpenAddtoCart;
    }
  },
});
