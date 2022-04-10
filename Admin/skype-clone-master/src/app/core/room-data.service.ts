import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class RoomDataService {
  constructor(private http: HttpClient) {}

  get(id: number): Observable<any> {
    const url = `${environment.apiUrl}room/get?id=${id}`;
    return this.http.get<any>(url);
  }

  getParticipatedIn(id: number): Observable<any> {
    const url = `${environment.apiUrl}room/get-participated-in?id=${id}`;
    return this.http.get<any>(url);
  }

  add(args: {
    name: string;
    members: {
      userId: number;
      role: number;
    }[];
  }): Observable<any> {
    const url = `${environment.apiUrl}room/create`;
    return this.http.post<any>(url, args);
  }
}
