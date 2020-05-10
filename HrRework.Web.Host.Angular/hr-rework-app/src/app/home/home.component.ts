import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CandidateRepositoy } from "../candidate/candidate-repository";
import { Candidate } from "../interfaces/candidate-interface";

@Component({
    selector: 'home',
    styleUrls: ["./home.component.scss"],
    templateUrl: "./home.component.html"
})
export class HomeComponent implements OnInit{
        candidates: Candidate[] = [];

    processing: boolean = true;
    height: number = 64;
    width: number = 64;

    constructor(public candidateRepository: CandidateRepositoy,
                public router: Router){
    }

    ngOnInit(): void {
        let candidate$ = this.candidateRepository.find();
        candidate$.subscribe(
            candidates => this.candidates = candidates,
            err => console.log(err),
            () => {
                this.toggleLoadingSpinner()
            }
        )
    }

    candidateDetails(id: number): void{
        this.router.navigate([`/candidatedetails`, id])
    }

    toggleLoadingSpinner() {
        this.processing = !this.processing;
    }
}