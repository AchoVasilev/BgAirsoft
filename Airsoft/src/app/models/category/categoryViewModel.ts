import { ImageViewModel } from "../image/imageViewModel";
import { SubCategoryViewModel } from "../subCategory/subCategoryViewModel";

export interface CategoryViewModel{
    id: string,
    name: string,
    image: ImageViewModel,
    subCategories: SubCategoryViewModel[]
}