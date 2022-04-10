import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  currentUser: any = null;

  constructor() {}
}
