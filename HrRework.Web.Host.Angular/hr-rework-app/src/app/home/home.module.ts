import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { HomeComponent } from "./home.component";

@NgModule({
    imports: [ CommonModule, SharedModule ],
    exports : [ HomeComponent ],
    declarations: [ HomeComponent ],
    providers: []
})

export class HomeModule {}