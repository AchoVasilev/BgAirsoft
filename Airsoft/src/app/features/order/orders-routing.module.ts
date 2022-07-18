import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ClientGuard } from "src/app/guards/client.guard";
import { AuthGuard } from "../../guards/auth.guard";
import { ClientComponent } from "./client/client.component";
import { DetailsComponent } from "./details/details.component";

export const routes: Routes = [
    {
        path: '',
        canActivate: [AuthGuard],
        children: [
            {
                path: 'client',
                component: ClientComponent,
                pathMatch: 'full',
                canActivate: [ClientGuard]
            },
            {
                path: 'client/:id',
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
export class OrdersRoutingModule { }