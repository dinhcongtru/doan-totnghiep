
import ProductRepository from "./ProductRepository";
import CustomerRepository from "./CustomerRepository";
import CategoryRepository from "./CategoryRepository";
const repositories = {
    Products: ProductRepository,
    Customers: CustomerRepository,
    Categoris: CategoryRepository,
};

export const RepositoryFactory = {
    get:name => repositories[name]
};