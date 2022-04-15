import { ImageViewModel } from "../image/imageViewModel";
import { OrderGunViewModel } from "../orders/orderGunViewModel";

export interface DealerGunsList{
    id: number,
    name: string,
    manufacturer: string,
    dealerName: string,
    color: string,
    price: number,
    dealerId: string,
    createdOn: string,
    image: ImageViewModel
}