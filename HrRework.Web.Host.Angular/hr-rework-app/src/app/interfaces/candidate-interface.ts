import { Interview } from "./interview-interface";

export interface Candidate {
    id: number;
    firstName: string;
    lastName: string;
    birthdate: Date;
    phone: string;
    email: string;
    interviews: Interview[]
}

export interface CandidateGraphQlResponse {
    data: { candidate: Candidate, candidates: Array<Candidate> };
}   