import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestService } from 'src/app/services/request-service.service';

@Injectable({
  providedIn: 'root'
})

export class ReceivingLocationService {
  private apiPath = 'receivinglocation';

  constructor(public requestService: RequestService) {

  }

  public post(body?: any): Observable<any> {
    return this.requestService.post(this.apiPath, body);
  }

  public get(): Observable<any> {
    return this.requestService.get(this.apiPath);
  }

}
