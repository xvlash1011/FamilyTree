import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserDataService {
  constructor(private http: HttpClient) {}

  get(id: number): Observable<any> {
    const url = `${environment.apiUrl}user/get?id=${id}`;
    return this.http.get<any>(url);
  }

  register(name: string): Observable<any> {
    const url = `${environment.apiUrl}user/register`;
    return this.http.post<any>(url, {
      name: name,
    });
  }
}
