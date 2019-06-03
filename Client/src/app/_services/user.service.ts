import { Injectable } from '@angular/core';

import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { PaginatedResults } from '../models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.api;

  constructor(private http: HttpClient) { }

  getUsers(
    page?,
    itemsPerPage?,
    userParams?
  ): Observable<PaginatedResults<User[]>> {
    const paginatedResult: PaginatedResults<User[]> = new PaginatedResults<
      User[]
    >();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params
        .append('page', page)
        .append('size', itemsPerPage);
    }

    if (userParams != null) {
      params = params
        .append('minAge', userParams.minAge)
        .append('maxAge', userParams.maxAge)
        .append('gender', userParams.gender)
        .append('orderBy', userParams.orderBy);
    }

    return this.http
      .get<User[]>(this.baseUrl + '/users', { observe: 'response', params })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          return paginatedResult;
        })
      );
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + `/users/${id}`);
  }

  updateUser(id: number, user: User): Observable<User> {
    return this.http.patch<User>(this.baseUrl + `/users/${id}`, user);
  }

  setMainPhoto(userId: number, id: number) {
    return this.http.post(
      this.baseUrl + '/users/' + userId + '/photos/' + id + '/setMain',
      {}
    );
  }

  deletePhoto(userId: number, id: number) {
    return this.http.delete(
      this.baseUrl + '/users/' + userId + '/photos/' + id
    );
  }
}
