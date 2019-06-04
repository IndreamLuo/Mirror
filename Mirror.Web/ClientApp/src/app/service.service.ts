import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Service } from 'src/models/Service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(
    private http: HttpClient
  ) { }

  private allUrl = '/Service/All';

  getAll(): Observable<Service[]> {
    return this.http.get<Service[]>(this.allUrl);
  }
}
