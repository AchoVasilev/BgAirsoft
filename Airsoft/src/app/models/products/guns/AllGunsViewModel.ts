import { AllGunViewModel } from "./AllGunViewModel";

export interface AllGunsViewModel{
    allGuns: AllGunViewModel[],
    colors: string[],
    manufacturers: string[],
    dealers: string[],
    powers: number[]
};