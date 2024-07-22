import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginatedResult } from '@app/models/Pagination';
import { Palestrante } from '@app/models/Palestrante';
import { environment } from '@environments/environment';
import { Observable, map, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PalestranteService {
  baseURL = environment.apiURL + 'api/palestrantes';

  constructor(private http: HttpClient) { }

  public getPalestrantes(page?: number, itemsPerPage?: number, termos?: string): Observable<PaginatedResult<Palestrante[]>> {
    const paginatedResult: PaginatedResult<Palestrante[]> = new PaginatedResult<Palestrante[]>();

    let params = new HttpParams;

    if(page != null && itemsPerPage != null){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }

    if(termos != null && termos != '')
      params = params.append('termos', termos)

    return this.http
      .get<Palestrante[]>(this.baseURL + '/all', {observe: 'response', params })
    .pipe(take(1),
    map((response) => {
      paginatedResult.result = response.body;
      if(response.headers.has('Pagination')) {
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
      }
      return paginatedResult;
    }));
  }

  public getPalestrante(): Observable<Palestrante> {
    return this.http.get<Palestrante>(`${this.baseURL}`)
    .pipe(take(1));
  }

  public post(): Observable<Palestrante> {
    return this.http.post<Palestrante>(this.baseURL, {} as Palestrante)
    .pipe(take(1));
  }

  public put(palestrante: Palestrante): Observable<Palestrante> {
    return this.http.put<Palestrante>(`${this.baseURL}`, palestrante)
    .pipe(take(1));
  }
}
