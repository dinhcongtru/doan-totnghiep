import Repository from "./Repository";

const resource = "/Customers";

export default {
      adtoCartByCustomer(payload) {
          return Repository.post(`${resource}/adtocart`,payload);
      },
      loginCustomer(payload) {
            return Repository.post(`${resource}/logginCustomer`,payload);
      },
      loginBySocial(payload){
            return Repository.post(`${resource}/loginCustomerBySocial`,payload);
      },
      registerCustomer(payload){
            return Repository.post(`${resource}/registerCustomer`,payload);
      },
      getCartItemByCustomer(customerID){
            return Repository.get(`${resource}/productByCustomer/${customerID}`);
      },
      deleteCartByCustomer(cartID) {
            return Repository.delete(`${resource}/deleteProuct/${cartID}`);
      },
      logOutCustomer(payload) {
            return Repository.post(`${resource}/LogOutCustomer`,payload);
      }
}