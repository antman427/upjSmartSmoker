import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ThermCam } from '../models/thermcam.model';

const baseUrl = 'https://localhost:7009/api/thermcam';

@Injectable({
  providedIn: 'root'
})
export class ThermcamService {
  http = inject(HttpClient);
  
  get(): Observable<ThermCam[]> {
    return this.http.get<ThermCam[]>(`${baseUrl}s`);
  }

  getById(id: number): Observable<ThermCam> {
    return this.http.get<ThermCam>(`${baseUrl}/${id}`);
  }

  create(data: ThermCam): Observable<ThermCam> {
    return this.http.post<ThermCam>(baseUrl,data);
  }

  update(id: number, data: ThermCam): Observable <ThermCam> {
    return this.http.put<ThermCam>(`${baseUrl}/${id}`,data);
  }

  delete(id: number): Observable<ThermCam> {
    return this.http.delete<ThermCam>(`${baseUrl}/${id}`);
  }
}
