import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { DesiredState } from '../models/desiredstate.model';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:7009/api/desiredstate';

@Injectable({
  providedIn: 'root'
})
export class DesiredstateService {
  http = inject(HttpClient);
  
  get(): Observable<DesiredState[]> {
    return this.http.get<DesiredState[]>(`${baseUrl}s`);
  }

  getById(id: number): Observable<DesiredState> {
    return this.http.get<DesiredState>(`${baseUrl}/${id}`);
  }

  getMostCurrent(): Observable<DesiredState> {
    return this.http.get<DesiredState>(`${baseUrl}/mostcurrent`);
  }

  create(data: DesiredState): Observable<DesiredState> {
    return this.http.post<DesiredState>(baseUrl,data);
  }

  update(id: number, data: DesiredState): Observable <DesiredState> {
    return this.http.put<DesiredState>(`${baseUrl}/${id}`,data);
  }

  delete(id: number): Observable<DesiredState> {
    return this.http.delete<DesiredState>(`${baseUrl}/${id}`);
  }
}
