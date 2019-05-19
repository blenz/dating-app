import { Injectable } from '@angular/core';

import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

const HTTP_HEADERS = {
  headers: new HttpHeaders({
    Authorization: `Bearer ${localStorage.getItem('token')}`
  })
};

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.api;

  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + '/users', HTTP_HEADERS);
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + `/users/${id}`, HTTP_HEADERS);
  }
}
