import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  protected headers: HttpHeaders;
  protected apiURL = environment.api;

  constructor(
    private http: HttpClient
  ) {
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-type', 'application/json');
  }

  public setApiUrl(url: string) {
    this.apiURL = url;
  }
  public post(path: string, body?: any): Observable<any> {
    return this.http.post(`${this.apiURL}${path}`, body, { headers: this.headers });
  }

  public put(path: string, body?: any): Observable<any> {
    return this.http.put(`${this.apiURL}${path}`, body, { headers: this.headers });
  }

  public patch(path: string, body?: any): Observable<any> {
    return this.http.patch(`${this.apiURL}${path}`, body, { headers: this.headers });
  }

  public get(path: string): Observable<any> {
    return this.http.get(`${this.apiURL}${path}`, { headers: this.headers });
  }

  public getFullResponse(path: string): Observable<HttpResponse<any>> {
    return this.http.get(`${this.apiURL}${path}`, { observe: 'response', headers: this.headers });
  }

  public delete(path: string): Observable<any> {
    return this.http.delete(`${this.apiURL}${path}`, { headers: this.headers });
  }

  public upload(path: string, body: any): Observable<any> {
    return this.http.post(`${this.apiURL}${path}`, body, { observe: 'events', reportProgress: true });
  }
}
