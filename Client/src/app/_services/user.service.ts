import { Injectable } from '@angular/core';

import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.api;

  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + '/users');
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + `/users/${id}`);
  }

  updateUser(id: number, user: User): Observable<User> {
    return this.http.patch<User>(this.baseUrl + `/users/${id}`, user);
  }
}