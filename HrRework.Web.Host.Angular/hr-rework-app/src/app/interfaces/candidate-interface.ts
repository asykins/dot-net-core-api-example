import { Interview } from "./interview-interface";

export interface Candidate {
    id: number;
    firstName: string;
    lastName: string;
    interviews: Interview[]
}

export interface CandidateGraphQlResponse {
    data: { candidate: Candidate, candidates: Array<Candidate> };
}   