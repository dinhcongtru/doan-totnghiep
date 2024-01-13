import Repository from "./Repository";

const resource = "/Products";

export default {
    getAllProduct() {
        return Repository.get(`${resource}/products`);
    },

    getProductsBestSeller() {
        return Repository.get(`${resource}/best_seller`);
    },

    getProductByID(proudctID) {
        return Repository.get(`${resource}/GetByID/${proudctID}`);
    },
    getNewProductCode() {
        return Repository.get(`${resource}/newCode`);
    },
    getProductByFilterAndPagding(pageSize,pageNumber,filter,price,listcolors,listSizes) {
        return Repository.get(`${resource}/filter?keyword=${filter}&price=${price}&Flitercolor=${listcolors}&Filtersize=${listSizes}&PageSize=${pageSize}&PageNumber=${pageNumber}`);
    },
    deleteBatch(VendorIDs) {
        return Repository.post(`${resource}/deleteBatch` , VendorIDs);
    },
    exportExcel() {
        return Repository.post(`${resource}/exportToExcel`);
    },
    updateVendor(vendorID,payload) {
        return Repository.put(`${resource}/${vendorID}`,payload);
    },
     deleteVendorByID(vendorID) {
        return Repository.delete(`${resource}/${vendorID}`);
    },
    getProductByCategory(categoryID) {
        return Repository.get(`${resource}/GetProductsBycategory/${categoryID}`);
    },

}