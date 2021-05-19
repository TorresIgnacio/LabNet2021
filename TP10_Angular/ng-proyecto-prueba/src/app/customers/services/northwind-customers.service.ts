import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customers } from 'src/app/customers/models/customers';

@Injectable({
  providedIn: 'root'
})
export class NorthwindCustomersService {

  constructor(private http: HttpClient) { }

  readAllCustomers(): Observable<Array<Customers>> {
    return this.http.get<Array<Customers>>(environment.northwind + 'customers');
  }
  readCustomer(id: string): Observable<Customers> {
    return this.http.get<any>(environment.northwind + 'customers/' + id);
  }
  postCustomer(request: Customers): Observable<Customers> {
    return this.http.post<Customers>(environment.northwind + 'customers', request);
  }
  deleteCustomers(id: string): Observable<Customers> {
    return this.http.delete<any>(environment.northwind + 'customers/' + id);
  }
  patchCustomers(id: string, customer: Customers): Observable<Customers> {
    return this.http.patch<any>(environment.northwind + 'customers/' + id, customer);
  }
}
