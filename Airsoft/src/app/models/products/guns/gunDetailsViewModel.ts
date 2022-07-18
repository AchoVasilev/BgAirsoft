import { ImageViewModel } from "../../image/imageViewModel";

export interface GunDetailsViewModel{
    id: number,
    name: string,
    manufacturer: string,
    image: ImageViewModel,
    power: number,
    color: string,
    weight: number,
    magazine: string,
    capacity: number,
    speed: number,
    firing: string,
    length: number,
    barrel: number,
    propulsion: string,
    material: string,
    blowback: string,
    hopup: string,
    price: number,
    dealerName: string,
    dealerUrl: string,
    dealerId: string
}