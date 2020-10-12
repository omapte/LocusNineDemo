import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:5000/api/Users';  //TODO: change the url.

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  public get() {
    // Get all  data
    return this.http.get(this.accessPointUrl, {headers: this.headers});
  }

  public add(payload) {
    let createdUser;
    createdUser = this.http.post(this.accessPointUrl, payload, {headers: this.headers});
    console.log(createdUser);
    return createdUser;
  }

  public remove(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.id, {headers: this.headers});
  }

  public update(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.id, payload, {headers: this.headers});
  }
}