import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CurrentState } from '../models/currentstate.model';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:7009/api/currentstate';

@Injectable({
  providedIn: 'root'
})
export class CurrentstateService {
  http = inject(HttpClient);
  
  get(): Observable<CurrentState[]> {
    return this.http.get<CurrentState[]>(`${baseUrl}s`);
  }

  getById(id: number): Observable<CurrentState> {
    return this.http.get<CurrentState>(`${baseUrl}/${id}`);
  }

  create(data: CurrentState): Observable<CurrentState> {
    return this.http.post<CurrentState>(baseUrl,data);
  }

  update(id: number, data: CurrentState): Observable <CurrentState> {
    return this.http.put<CurrentState>(`${baseUrl}/${id}`,data);
  }

  delete(id: number): Observable<CurrentState> {
    return this.http.delete<CurrentState>(`${baseUrl}/${id}`);
  }
}
