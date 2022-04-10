import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FriendDataService {
  constructor(private http: HttpClient) {}

  getAllOf(id: number): Observable<any> {
    const url = `${environment.apiUrl}friend/get-all-of?id=${id}`;
    return this.http.get<any>(url);
  }

  add(leftId: number, rightId: number): Observable<any> {
    const url = `${environment.apiUrl}friend/add`;
    return this.http.post<any>(url, {
      leftId: leftId,
      rightId: rightId
    });
  }

  remove(leftId: number, rightId: number): Observable<any> {
    const url = `${environment.apiUrl}friend/remove`;
    return this.http.post<any>(url, {
      leftId: leftId,
      rightId: rightId
    });
  }
}
