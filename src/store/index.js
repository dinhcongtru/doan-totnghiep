import { createStore } from "vuex";
import axios from "axios";
// import { dataChooseCity } from '@/resource/TestData'
import createPersistedState from "vuex-persistedstate";
// Create a new store instance.
export const store = createStore({
  state() {
    return {
      count: 0,
      name: "Trứ",
      isOpenAddtoCart: false,
      provinces: [], // Danh sách các tỉnh
      districts: [], // Danh sách các quận/huyện
      wards: [], // Danh sách các phường/xã
      province: {
        code : 999,
        name : "Chọn Tỉnh/ thành phố"
      }, // Tỉnh được chọn
      district: {
        code : 999,
        name : "Chọn Quận/ huyện"
      }, // Quận được chọn
      ward: {
        code : 999,
        name : "Chọn Phường/ xã"
      }, // Phường được chọn
      customer: {},
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
    getTotalProduct(state) {
      if (Object.keys(state.customer).length == 0) {
        return state.product.reduce((total, product) => {
          return total + product.qty;
        }, 0);
      } else {
        return state.customer.product.reduce((total, product) => {
          return total + product.qty;
        }, 0);
      }
    },
    getTotalPrice(state) {
      if (Object.keys(state.customer).length == 0) {
        return state.product.reduce((total, product) => {
          return total + product.price * product.qty;
        }, 0);
      } else {
        if (state.customer.product.length == 0) {
          return 0;
        } else {
          return state.customer.product.reduce((total, product) => {
            return total + product.price * product.qty;
          }, 0);
        }
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
      return state.customer.name;
    },
  },
  mutations: {
    handleAddProductToCart(state, product) {
      if (!product) return;
      if (Object.keys(state.customer).length == 0) {
        for (let item of state.product) {
          if (
            product.id === item.id &&
            product.color === item.color &&
            product.size === item.size
          ) {
            item.qty += product.qty;
            return;
          }
        }
        state.product.push(product);
      } else {
        for (let item of state.customer.product) {
          if (
            product.id === item.id &&
            product.color === item.color &&
            product.size === item.size
          ) {
            item.qty += product.qty;
            return;
          }
        }
        state.customer.product.push(product);
      }
    },
    handleRemoveProductToCart(state, param) {
      if (!param.id) return;
      //logic xóa
      if (Object.keys(state.customer).length == 0) {
        let index = state.product.findIndex(
          (item) =>
            item.id == param.id &&
            item.size == param.size &&
            item.color == param.color
        );
        state.product.splice(index, 1);
      } else {
        let index = state.customer.product.findIndex(
          (item) =>
            item.id == param.id &&
            item.size == param.size &&
            item.color == param.color
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
            product.id == payload.id &&
            product.color == payload.color &&
            product.size == payload.size
        )[0];
        productCurrent.qty += 1;
      } else {
        const productCurrent = state.customer.product.filter(
          (product) =>
            product.id == payload.id &&
            product.color == payload.color &&
            product.size == payload.size
        )[0];
        productCurrent.qty += 1;
      }
    },
    handleMinusQuantity(state, payload) {
      if (Object.keys(state.customer).length == 0) {
        const productCurrent = state.product.filter(
          (product) =>
            product.id == payload.id &&
            product.color == payload.color &&
            product.size == payload.size
        )[0];
        productCurrent.qty -= 1;
      } else {
        const productCurrent = state.customer.product.filter(
          (product) =>
            product.id == payload.id &&
            product.color == payload.color &&
            product.size == payload.size
        )[0];
        productCurrent.qty -= 1;
      }
    },
    handleAddCustomer(state, customer) {
      state.customer = customer;
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
  },
  actions: {
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
      paths: ["product", "customer"], // Chỉ lưu trữ mảng này
      transformState: (state) => ({
        product: state.product.slice(0), // Tạo bản sao của mảng để lưu trữ
        customer: state.customer.slice(0),
      }),
    }),
  ],
});
