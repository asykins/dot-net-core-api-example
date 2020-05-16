import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Candidate, CandidateGraphQlResponse } from "../interfaces/candidate-interface";
import { GraphQlRepository } from "../shared/repository/graphql-repository";

@Injectable()
export class CandidateRepositoy extends GraphQlRepository<Candidate, CandidateGraphQlResponse> {
    constructor(protected httpClient: HttpClient){
        super(httpClient);
    }

    protected findByIdFlatMap(response$: Observable<CandidateGraphQlResponse>): Observable<Candidate> {
        return response$.pipe(
            map(response => response.data.candidate)
        );
    }

    protected findByIdQuery(id: number): string {
        return `{
                "query": "{
                    candidate(id: ${id}) {
                        firstName,
                        lastName,
                        id,
                        birthdate,
                        phone,
                        email,
                        interviews {
                            id
                        }
                    }
                }"
        }`
    };

    protected findQuery(): string {
        return `{
            "query": "{
                candidates {
                    firstName,
                    lastName,
                    id
                }
            }"
        }`
    }
    protected findFlatMap(response$: Observable<CandidateGraphQlResponse>): Observable<Candidate[]> {
        return response$.pipe(
            map(response => response.data.candidates)
        )
    }
}