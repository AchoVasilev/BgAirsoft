import { ImageViewModel } from "../image/imageViewModel";
import { ClientViewModel } from "./clientViewModel";

export interface UserClientViewModel{
    id: string,
    email: string,
    username: string,
    clientId: string,
    client: ClientViewModel,
    image: ImageViewModel
}