import { Routes } from "@angular/router";
import { CandidateDetailsComponent } from "../candidate/candidate-details.component";
import { CandidateDetailsResolver } from "../candidate/candidate-details.resolver";
import { HomeComponent } from "../home/home.component";

export const routes: Routes = [
    { component: HomeComponent, path: "" },
    { component: HomeComponent, path: "home" },
    { 
        component: CandidateDetailsComponent, 
        path: "candidatedetails/:id",
        resolve: { candidate: CandidateDetailsResolver } }
];