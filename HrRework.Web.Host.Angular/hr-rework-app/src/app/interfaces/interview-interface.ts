import { Candidate } from "./candidate-interface";
import { Interviewer } from "./interviewer-interface";

export interface Interview {
    id: number;
    comment: string;
    note: number;
    candidate: Candidate;
    interviewer: Interviewer;
}