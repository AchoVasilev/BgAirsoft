import { OrderGunViewModel } from "./orderGunViewModel";

export interface OrderListModel{
    orderId: string,
    createdOn: string,
    totalPrice: number,
    gun: OrderGunViewModel
}