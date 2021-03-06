import { ImageViewModel } from "../../image/imageViewModel"

export interface AllGunViewModel {
    id: number,
    dealerName: string,
    name: string,
    manufacturer: string,
    weight: number,
    propulsion: string,
    power: number,
    color: string,
    price: number,
    image: ImageViewModel
}