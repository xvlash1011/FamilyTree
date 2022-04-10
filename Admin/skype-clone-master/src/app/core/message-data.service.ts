import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MessageDataService {
  constructor(private http: HttpClient) {}

  getByRoom(roomId: number): Observable<any> {
    const url = `${environment.apiUrl}message/get-by-room?id=${roomId}`;
    return this.http.get<any>(url);
  }

  get(id: number): Observable<any> {
    const url = `${environment.apiUrl}message/get?id=${id}`;
    return this.http.get<any>(url);
  }

  add(args: {
    roomId: number;
    content: string;
    userId: number;
  }): Observable<any> {
    let data: any = args;
    data.timeStamp = Date.now;

    const url = `${environment.apiUrl}message/add`;
    return this.http.post<any>(url, data);
  }
}
