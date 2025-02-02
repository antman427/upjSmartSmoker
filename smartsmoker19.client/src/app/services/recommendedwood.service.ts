import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RecommendedWood } from '../models/recommendedwood.model';

const baseUrl = 'https://localhost:7009/recommendedwood'

@Injectable({
  providedIn: 'root'
})
export class RecommendedwoodService {

  http = inject(HttpClient);
  
  get(): Observable<RecommendedWood[]> {
    return this.http.get<RecommendedWood[]>(`${baseUrl}s`);
  }

  getById(id: number): Observable<RecommendedWood> {
    return this.http.get<RecommendedWood>(`${baseUrl}/${id}`);
  }

  create(data: RecommendedWood): Observable<RecommendedWood> {
    return this.http.post<RecommendedWood>(baseUrl,data);
  }

  update(id: number, data: RecommendedWood): Observable <RecommendedWood> {
    return this.http.put<RecommendedWood>(`${baseUrl}/${id}`,data);
  }

  delete(id: number): Observable<RecommendedWood> {
    return this.http.delete<RecommendedWood>(`${baseUrl}/${id}`);
  }
}
