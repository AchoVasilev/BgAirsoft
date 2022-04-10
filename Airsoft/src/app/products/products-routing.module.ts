import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CreateComponent } from "./create/create.component";
import { DetailsComponent } from "./details/details.component";
import { GunListComponent } from "./gun-list/gun-list.component";
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
                path: 'create',
                component: CreateComponent,
                pathMatch: 'full'
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