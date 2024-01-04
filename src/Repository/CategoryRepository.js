import Repository from "./Repository";

const resource = "/ProductCategorys";

export default {
     GetAllCategory(){
      return Repository.get(`${resource}/GetAll`);
     },
}