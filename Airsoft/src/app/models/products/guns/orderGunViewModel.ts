import { ImageViewModel } from "../../image/imageViewModel";

export interface OrderGunViewModel{
    id: number,
    name: string,
    color: string,
    price: number,
    manufacturer: string,
    dealerName: string,
    image: ImageViewModel
}