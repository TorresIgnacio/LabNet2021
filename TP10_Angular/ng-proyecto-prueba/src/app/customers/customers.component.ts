import { Customers } from 'src/app/customers/models/customers';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {

  public updateableCustomer: Customers;
  public refreshCustomersTable: Boolean;
  constructor() { }

  ngOnInit(): void {
    this.refreshCustomersTable = false;
  }

  gotCustomer(customer: Customers) {
    this.updateableCustomer = customer;
  }

  gotNewCustomersData(bool: Boolean) {
    this.refreshCustomersTable = bool;
  }

}
