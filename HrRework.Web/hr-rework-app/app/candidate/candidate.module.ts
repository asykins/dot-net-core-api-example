import { NgModule } from "@angular/core";
import { SharedModule } from '../shared/shared.module';
import { CandidateComponent } from './candidate.component';

@NgModule({
    imports: [ SharedModule ],
    exports: [ CandidateComponent ],
    declarations: [ CandidateComponent ],
    providers: []
})

export class CandidateModule {}