import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { routes } from "./routes";

@NgModule({
    imports: [ 
        CommonModule, 
        RouterModule,
        RouterModule.forRoot(routes) 
    ],
    declarations: [],
    exports: [],
    providers: [],
})

export class RouteModule {}