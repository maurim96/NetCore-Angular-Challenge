import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  getAccessToken(): string {
    return 'This should return the current user logged in token';
  }

  isLoggedIn(): boolean {
    //Must check if any user is logged in and return a boolean accordingly
    return true;
  }
}
