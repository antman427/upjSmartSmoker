import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MeatWoodView } from '../models/meatwood.model';
import { MeatSmokingGuide } from '../models/meatsmokingguide.model';

const baseUrl = 'https://localhost:7009/api/meatsmokingguide';

@Injectable({
  providedIn: 'root'
})
export class MeatwoodviewService {

  http = inject(HttpClient);
  
  get(): Observable<MeatSmokingGuide[]> {
    return this.http.get<MeatSmokingGuide[]>(`${baseUrl}s`);
  }

  getById(id: number): Observable<MeatSmokingGuide> {
    return this.http.get<MeatSmokingGuide>(`${baseUrl}/${id}`);
  }

  getByTypeCut(meattype: string, meatcut:string): Observable<MeatWoodView[]> {
    return this.http.get<MeatWoodView[]>(`${baseUrl}/${meattype}/${meatcut}`);
  }

  create(data: MeatSmokingGuide): Observable<MeatSmokingGuide> {
    return this.http.post<MeatSmokingGuide>(baseUrl,data);
  }

  update(id: number, data: MeatSmokingGuide): Observable <MeatSmokingGuide> {
    return this.http.put<MeatSmokingGuide>(`${baseUrl}/${id}`,data);
  }

  delete(id: number): Observable<MeatSmokingGuide> {
    return this.http.delete<MeatSmokingGuide>(`${baseUrl}/${id}`);
  }
}
