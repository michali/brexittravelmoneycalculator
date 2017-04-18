import { ICurrency } from "./currency";
import { ILocalProduct } from "./localProduct";

export interface ICountry {
    name: string,
    currency: ICurrency,
    localProduct: ILocalProduct
}