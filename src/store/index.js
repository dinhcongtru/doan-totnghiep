import { createStore } from "vuex";
import axios from "axios";
import createPersistedState from "vuex-persistedstate";
// Create a new store instance.
export const store = createStore({
  state() {
    return {
      count: 0,
      isOpenAddtoCart: false,
      provinces: [], // Danh sách các tỉnh
      districts: [], // Danh sách các quận/huyện
      wards: [], // Danh sách các phường/xã
      province: {
        code: 999,
        name: "Chọn Tỉnh/ thành phố"
      }, // Tỉnh được chọn
      district: {
        code: 999,
        name: "Chọn Quận/ huyện"
      }, // Quận được chọn
      ward: {
        code: 999,
        name: "Chọn Phường/ xã"
      }, // Phường được chọn
      customer: {},
      cloneProduct: [],
      product: [],
      categoryID: null,
      categoryName: null,
      paramsRouterProduct: {},
      
    };
  },
  getters: {
    getNameProduct(state) {
      return state.name;
    },
    getTotalProduct(state) {
      if (Object.keys(state.customer).length == 0 && state.product.length !== 0) {
        return state.product.reduce((total, product) => {
          return total + product.quantity;
        }, 0);
      } else if (Object.keys(state.customer).length > 0 && state.customer.product.length !== 0) {
        return state.customer.product.reduce((total, product) => {
          return total + product.quantity;
        }, 0);
      } else {
        return 0;
      }
    },
    getTotalPrice(state) {
      if (Object.keys(state.customer).length == 0 && state.product.length !== 0) {
        return state.product.reduce((total, product) => {
          return total + product.productPrice * product.quantity;
        }, 0);
      } else if (Object.keys(state.customer).length > 0 && state.customer.product.length !== 0) {

        return state.customer.product.reduce((total, product) => {
          return total + product.productPrice * product.quantity;
        }, 0);

      } else {
        return 0;
      }
    },
    getProduct(state) {
      if (Object.keys(state.customer).length == 0) {
        return state.product;
      } else {
        return state.customer.product;
      }
    },
    getSatusOpenModal(state) {
      return state.isOpenAddtoCart;
    },
    getNameCustomer(state) {
      return state.customer.fullName;
    },
    getCloneProduct(state) {
      return state.cloneProduct;
    },

  },
  mutations: {
    resetProduct(state) {
      if(Object.keys(state.customer).length == 0){
        state.product = [];
      }else {
        state.customer.product = [];
      }
    },
    handelSaveRouterProduct(state, payload) {
      state.paramsRouterProduct = payload;
    },
    handleAddCategoryID(state, payload) {
      state.categoryID = payload.id;
      state.categoryName = payload.name;
    },
    handleAddProductToCart(state, product) {
      if (!product) return;
      if (Object.keys(state.customer).length == 0) {
        for (let item of state.product) {
          if (
            product.productID === item.productID &&
            product.listColors.productColorID === item.listColors.productColorID &&
            product.selectedSize.productSizeID === item.selectedSize.productSizeID
          ) {
            item.quantity += product.quantity;
            return;
          }
        }
        state.product.push(product);
      } else {
        for (let item of state.customer.product) {
          if (
            product.productID === item.productID &&
            product.listColors.productColorID === item.listColors.productColorID &&
            product.selectedSize.productSizeID === item.selectedSize.productSizeID
          ) {
            item.quantity += product.quantity;
            return;
          }
        }
        if (state.customer.product.length == 0) {
          state.customer.product = [];
          state.customer.product.push(product);
        } else {
          state.customer.product.push(product);
        }

      }
    },
    handleRemoveProductToCart(state, param) {
      
      if (!param.id) return;
      //logic xóa
      if (Object.keys(state.customer).length == 0) {
        let index = state.product.findIndex(
          (item) =>
          param.id === item.productID &&
          param.color === item.listColors.productColorID &&
          param.size === item.selectedSize.productSizeID
        );
        state.product.splice(index, 1);
      } else {
        let index = state.customer.product.findIndex(
          (item) =>
          param.id === item.productID &&
          param.color === item.listColors.productColorID &&
          param.size === item.selectedSize.productSizeID
        );
        state.customer.product.splice(index, 1);
      }
    },
    handleOpenAddtoCart(state) {
      state.isOpenAddtoCart = !state.isOpenAddtoCart;
    },
    handlePlusQuantity(state, payload) {
      if (Object.keys(state.customer).length == 0) {
        const productCurrent = state.product.filter(
          (product) =>
          payload.id === product.productID &&
          payload.color.productColorID === product.listColors.productColorID &&
          payload.size.productSizeID === product.selectedSize.productSizeID
        )[0];
        productCurrent.quantity += 1;
      } else {
        const productCurrent = state.customer.product.filter(
          (product) =>
          payload.id === product.productID &&
          payload.color.productColorID === product.listColors.productColorID &&
          payload.size.productSizeID === product.selectedSize.productSizeID
        )[0];
        productCurrent.quantity += 1;
      }
    },
    handleMinusQuantity(state, payload) {
      if (Object.keys(state.customer).length == 0) {
        const productCurrent = state.product.filter(
          (product) =>
          payload.id === product.productID &&
          payload.color.productColorID === product.listColors.productColorID &&
          payload.size.productSizeID === product.selectedSize.productSizeID
        )[0];
        productCurrent.quantity -= 1;
      } else {
        const productCurrent = state.customer.product.filter(
          (product) =>
          payload.id === product.productID &&
          payload.color.productColorID === product.listColors.productColorID &&
          payload.size.productSizeID === product.selectedSize.productSizeID
        )[0];
        productCurrent.quantity -= 1;
      }
    },
    handleAddCustomer(state, customer) {
      state.customer = customer;
      state.customer.product = [];
    },
    removeCustomer(state) {
      state.customer = {};
    },
    // Cập nhật danh sách các tỉnh
    SET_PROVINCES(state, provinces) {
      state.provinces = provinces;
      state.provinces.unshift(state.province)

    },
    // Cập nhật danh sách các quận/huyện của một tỉnh
    SET_DISTRICTS(state, districts) {
      state.districts = districts;
      state.districts.unshift(state.district)
    },
    // Cập nhật danh sách các phường/xã của một quận/huyện
    SET_WARDS(state, wards) {
      state.wards = wards;
      state.wards.unshift(state.ward)
    },
    handleAddProductClone(state, payload) {
      if (!payload) return
      const isExitPro = state.cloneProduct.filter(item => item.productID == payload.productID)
      if (Object.keys(isExitPro).length == 0) state.cloneProduct.unshift(payload);
    },
    SET_CART_BY_CUSTOMER(state, product) {
      state.customer.product = product;
    },
  },
  actions: {
    //lấy ra sản phẩm trong giỏ hàng theo customerID

    async getCartByCustomerID({ commit }, cusID) {
      try {
        await axios.get(`http://localhost:5041/api/v1/Customers/productByCustomer/${cusID}`).then((res) => {
          commit("SET_CART_BY_CUSTOMER", res.data);
        });
      } catch (error) {
        console.error(error);
      }
    },

    // Lấy danh sách các tỉnh từ API
    async fetchProvinces({ commit }) {
      try {
        await axios
          .get(`https://provinces.open-api.vn/api/`)
          .then((response) => {
            const provinces = response.data;
            commit("SET_PROVINCES", provinces);
          });
      } catch (error) {
        console.error(error);
      }
    },
    // Lấy danh sách các quận/huyện của một tỉnh từ API
    async fetchDistricts({ commit }, provinceId) {
      try {
        await axios
          .get(`https://provinces.open-api.vn/api/p/${provinceId}?depth=2`)
          .then((response) => {
            const districts = response.data.districts;
            commit("SET_DISTRICTS", districts);
          });
      } catch (error) {
        console.error(error);
      }
    },
    // Lấy danh sách các phường/xã của một quận/huyện từ API
    async fetchWards({ commit }, districtId) {
      try {
        await axios
          .get(`https://provinces.open-api.vn/api/d/${districtId}?depth=2`)
          .then((response) => {
            const wards = response.data.wards;
            commit("SET_WARDS", wards);
          });
      } catch (error) {
        console.error(error);
      }
    },
  },

  plugins: [
    createPersistedState({
      key: "store-app-state", // Đặt tên key cho mảng
      paths: ["categoryName","categoryID","product","customer", "cloneProduct", "paramsRouterProduct"], // Chỉ lưu trữ mảng này
      transformState: (state) => ({
        product: state.product.slice(0), // Tạo bản sao của mảng để lưu trữ
        customer: state.customer.slice(0),
        phiStoryProduct: state.cloneProduct.slice(0),
        paramsRouterProduct: state.paramsRouterProduct.slice(0),
      }),
    }),
  ],
});
