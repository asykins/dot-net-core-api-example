import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

export abstract class GraphQlRepository<T, U> {
    constructor(protected httpClient: HttpClient){ }

    findById(id: number): Observable<T>{
        try {
            const body = this.findByIdQuery(id);
            const options = { 
                headers: {
                    "Content-Type": "application/json", 
                    'Access-Control-Allow-Origin':'*'
                },
            }
            return this.findByIdFlatMap(this.httpClient.post<U>
            ("https://localhost:44391/graphql", body, options))
        } catch(err) {
            console.log(err);
        }
    }

    find(): Observable<T[]> {
        try {
            const body = this.findQuery();
            const options = { 
                headers: {
                    "Content-Type": "application/json", 
                    'Access-Control-Allow-Origin':'*'
                },
            }
            return this.findFlatMap(this.httpClient.post<U>
            ("https://localhost:44391/graphql", body, options))
        } catch(err) {
            console.log(err);
        }
    }
    
    protected abstract findByIdQuery(id: number): string;
    protected abstract findByIdFlatMap(response$: Observable<U>) : Observable<T>;
    
    protected abstract findQuery(): string;
    protected abstract findFlatMap(response$: Observable<U>) : Observable<T[]>;
}