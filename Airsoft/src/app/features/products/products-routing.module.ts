import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from "../../guards/auth.guard";
import { DealerGuard } from "../../guards/dealer.guard";
import { CreateComponent } from "./create/create.component";
import { DetailsComponent } from "../products/details/details.component";
import { GunListComponent } from "../products/gun-list/gun-list.component";
import { ListComponent } from "./list/list.component";

export const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'all',
                component: ListComponent,
                pathMatch: 'full'
            },
            {
                path: 'guns/all',
                component: GunListComponent,
                pathMatch: 'full'
            },
            {
                path: 'guns/:name',
                component: GunListComponent,
                pathMatch: 'full'
            },
            {
                path: 'create',
                component: CreateComponent,
                pathMatch: 'full',
                canActivate: [AuthGuard, DealerGuard]
            },
            {
                path: ':name/:id',
                component: DetailsComponent,
                pathMatch: 'full'
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProductsRoutingModule{}