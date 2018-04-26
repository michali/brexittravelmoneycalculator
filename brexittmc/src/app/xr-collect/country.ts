import { ICurrency } from "../verdict/currency";
import { ILocalProduct } from "../verdict/localProduct";

export interface ICountry {
    id: string,
    name: string,
    currency:ICurrency,
    localProduct:ILocalProduct
}