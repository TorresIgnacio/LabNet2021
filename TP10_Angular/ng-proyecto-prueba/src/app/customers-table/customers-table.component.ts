import { NorthwindCustomersService } from 'src/app/customers/services/northwind-customers.service';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Customers, CustomersResponse } from 'src/app/customers/models/customers';
import { Subscription, Observable } from 'rxjs';


@Component({
  selector: 'app-customers-table',
  templateUrl: './customers-table.component.html',
  styleUrls: ['./customers-table.component.scss']
})
export class CustomersTableComponent implements OnInit {
  @Input() refreshCustomersTable: Boolean;
  @Output() sendOutParent = new EventEmitter<Customers>();
  public customersData = new CustomersResponse();
  public customerData = new Customers();
  tableData: Observable<CustomersResponse>;
  public subscription: Subscription;
  displayedColumns: string[] = ['ID', 'contactName', 'companyName', 'delete', 'update'];

  constructor(private northwindCustomersService: NorthwindCustomersService) {
  }

  ngOnInit(): void {
    this.tableData = this.northwindCustomersService.readAllCustomers();
    this.tableData.subscribe(resp => { }, error => { alert(error.message); });
  }

  ngOnChanges(): void {
    if (this.refreshCustomersTable) {
      this.ngOnInit();
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe;
  }

  deleteCustomer(id) {
    this.northwindCustomersService.deleteCustomers(id).subscribe(
      resp => {
        this.customerData = resp;
        this.ngOnInit();
      },
      error => { alert(error.message); });
  }

  sendParent(customer: Customers) {
    this.sendOutParent.emit(customer);
  }

}
