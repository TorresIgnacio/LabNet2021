import { NorthwindCustomersService } from 'src/app/customers/services/northwind-customers.service';
import { Component, OnInit } from '@angular/core';
import { Customers, CustomersResponse } from 'src/app/customers/models/customers';
import { MatTable } from '@angular/material/table';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-customers-table',
  templateUrl: './customers-table.component.html',
  styleUrls: ['./customers-table.component.scss']
})
export class CustomersTableComponent implements OnInit {

  displayedColumns: string[] = ['ID', 'contactName', 'companyName', 'delete'];
  public customersData = new CustomersResponse();
  public customerData = new Customers();
  @ViewChild('myTable') myTable: MatTable<any>;

  constructor(private northwindCustomersService: NorthwindCustomersService) {
    this.northwindCustomersService.readAllCustomers().subscribe(resp => {
      this.customersData = resp;
    });
  }

  ngOnInit(): void {
  }

  deleteCustomer(id) {
    this.northwindCustomersService.deleteCustomers(id).subscribe(resp => { this.customerData = resp; });
    this.northwindCustomersService.readAllCustomers();
    this.myTable.renderRows();
  }

}
