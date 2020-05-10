import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { LoadingSpinnerComponent } from "./loading-spinner/loading-spinner.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";

@NgModule({
    imports: [ CommonModule, RouterModule ],
    exports: [ NavMenuComponent, RouterModule, LoadingSpinnerComponent ],
    declarations: [ NavMenuComponent, LoadingSpinnerComponent ],
    providers: []
})

export class SharedModule {}