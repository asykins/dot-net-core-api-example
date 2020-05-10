import { Routes } from '@angular/router';
import { AppComponent } from '../app.component';
import { CandidateComponent } from '../candidate/candidate.component';

export const routes: Routes = [
    { component: AppComponent, path: ""},
    { component: CandidateComponent, path: "candidate"}
]