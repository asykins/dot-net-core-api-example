import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Candidate } from "../interfaces/candidate-interface";

@Component({
    selector: "candidate-details",
    templateUrl: "./candidate-details.component.html",
    styleUrls: ["candidate-details.component.scss"] 
})
export class CandidateDetailsComponent implements OnInit{
    candidate: Candidate;
    processing: boolean = false;
    cardHeader: string = "Candidate Information";
    
    constructor(public activatedRoute: ActivatedRoute){
    }

    ngOnInit(): void {
        this.toggleLoadingSpinner();
        this.candidate = this.activatedRoute.snapshot.data["candidate"];
        this.toggleLoadingSpinner();
    }

    toggleLoadingSpinner(): void {
        this.processing = !this.processing;
    }
}