import { Customers } from 'src/app/customers/models/customers';
import { NorthwindCustomersService } from 'src/app/customers/services/northwind-customers.service';
import { Component, OnInit } from '@angular/core';
import { CustomersResponse } from 'src/app/customers/models/customers';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {

  // public customersResponse = new CustomersResponse();
  public updateableCustomer: Customers;
  constructor() {
    // this.northwindCustomersService.readAllCustomers().subscribe(resp => {
    //   this.customersResponse = resp;
    // });
  }

  ngOnInit(): void {
  }

  gotCustomer(customer: Customers) {
    console.log(customer);
    this.updateableCustomer = customer;
  }

}
