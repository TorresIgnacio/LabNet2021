import { NorthwindCustomersService } from 'src/app/customers/services/northwind-customers.service';
import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { Customers, CustomersResponse } from 'src/app/customers/models/customers';
import { MatTable } from '@angular/material/table';
import { Subscription, Observable } from 'rxjs';


@Component({
  selector: 'app-customers-table',
  templateUrl: './customers-table.component.html',
  styleUrls: ['./customers-table.component.scss']
})
export class CustomersTableComponent implements OnInit {

  @Output() sendOutParent = new EventEmitter<Customers>();
  @ViewChild('myTable') myTable: MatTable<any>;
  public customersData = new CustomersResponse();
  public customerData = new Customers();
  tableData: Observable<CustomersResponse>;
  public subscription: Subscription;
  displayedColumns: string[] = ['ID', 'contactName', 'companyName', 'delete', 'update'];

  constructor(private northwindCustomersService: NorthwindCustomersService) {
    this.tableData = this.northwindCustomersService.readAllCustomers();
    this.tableData.subscribe(resp => { }, error => { alert(error.message); });
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe;
  }

  deleteCustomer(id) {
    this.northwindCustomersService.deleteCustomers(id).subscribe(resp => { this.customerData = resp; },
      error => { alert(error.message); });
    this.tableData = this.northwindCustomersService.readAllCustomers();
    this.tableData.subscribe(resp => { }, error => { alert(error.message); });
    this.myTable.renderRows;
  }

  sendParent(customer: Customers) {
    this.sendOutParent.emit(customer);
  }

}
