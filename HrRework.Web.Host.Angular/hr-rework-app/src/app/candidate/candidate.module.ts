import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { CandidateDetailsComponent } from "./candidate-details.component";
import { CandidateDetailsResolver } from "./candidate-details.resolver";
import { CandidateRepositoy } from "./candidate-repository";

@NgModule({
    imports: [CommonModule, SharedModule],
    declarations: [ CandidateDetailsComponent],
    exports: [CandidateDetailsComponent],
    providers: [CandidateRepositoy, CandidateDetailsResolver]
})
export class CandidateModule { }