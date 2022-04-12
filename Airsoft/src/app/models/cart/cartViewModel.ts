import { ImageViewModel } from "../image/imageViewModel";

export interface CartViewModel{
    id: number,
    name: string,
    color: string,
    price: number,
    manufacturer: string,
    image: ImageViewModel
}