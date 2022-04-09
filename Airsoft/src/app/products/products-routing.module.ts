import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from "../guards/auth.guard";
import { DealerGuard } from "../guards/dealer.guard";
import { CreateComponent } from "./create/create.component";
import { DetailsComponent } from "./details/details.component";

const routes: Routes = [
    {
        path: 'products',
        canActivate: [AuthGuard, DealerGuard],
        children: [
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
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class ProductsRoutingModule{}