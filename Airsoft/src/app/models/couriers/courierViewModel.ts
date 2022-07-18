import { ImageViewModel } from "../image/imageViewModel";

export interface CourierViewModel{
    id: number,
    name: string,
    deliveryPrice: number,
    deliveryDays: number,
    image: ImageViewModel
}