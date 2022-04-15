import { ImageViewModel } from "../image/imageViewModel";

export interface OrderGunViewModel {
    id: number,
    name: string,
    manufacturer: string,
    dealerName: string,
    color: string,
    price: number,
    image: ImageViewModel
}