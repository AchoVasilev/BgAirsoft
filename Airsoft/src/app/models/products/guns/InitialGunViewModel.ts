import { ImageViewModel } from "../../image/imageViewModel";

export interface InitialGunViewModel{
    id: number,
    name: string,
    dealerName: string,
    dealerSiteUrl: string,
    manufacturer: string,
    color: string,
    power: number,
    image: ImageViewModel
}