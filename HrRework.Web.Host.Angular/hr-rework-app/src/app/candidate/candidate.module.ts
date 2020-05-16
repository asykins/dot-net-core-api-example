import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { SharedModule } from "../shared/shared.module";
import { CandidateDetailsComponent } from "./candidate-details.component";
import { CandidateDetailsResolver } from "./candidate-details.resolver";
import { CandidateRepositoy } from "./candidate-repository";

@NgModule({
    imports: [CommonModule, SharedModule, FormsModule],
    declarations: [ CandidateDetailsComponent],
    exports: [CandidateDetailsComponent],
    providers: [CandidateRepositoy, CandidateDetailsResolver]
})
export class CandidateModule { }