import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { Candidate } from "../interfaces/candidate-interface";
import { CandidateRepositoy } from "./candidate-repository";

export class CandidateDetailsResolver implements Resolve<Candidate> {
    constructor(private candidateRepository: CandidateRepositoy){ 
    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Candidate>{
        var candidateId: number = +route.params["id"]
        return this.candidateRepository.findById(candidateId);
    }
    
}