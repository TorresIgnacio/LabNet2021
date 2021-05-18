import { NorthwindCustomersService } from 'src/app/customers/services/northwind-customers.service';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Customers, CustomersResponse } from 'src/app/customers/models/customers';
import { Subscription, Observable } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';


@Component({
  selector: 'app-customers-table',
  templateUrl: './customers-table.component.html',
  styleUrls: ['./customers-table.component.scss']
})
export class CustomersTableComponent implements OnInit {
  @Input() refreshCustomersTable: Boolean;
  @Output() sendOutParent = new EventEmitter<Customers>();
  public customerData = new Customers();
  //public customersData = new Array<Customers>();
  customersData = new MatTableDataSource<Customers>();
  tableData: Observable<CustomersResponse>;
  displayedColumns: string[] = ['ID', 'contactName', 'companyName', 'delete', 'update'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(private northwindCustomersService: NorthwindCustomersService) {

  }

  ngAfterViewInit() {
    this.customersData.paginator = this.paginator;
  }

  ngOnInit(): void {
    // this.tableData = this.northwindCustomersService.readAllCustomers();
    // this.tableData.subscribe(resp => { }, error => { alert(error.message); });
    this.getTable();
  }

  ngOnChanges(): void {
    if (this.refreshCustomersTable) {
      this.getTable();
    }
  }

  getTable() {
    this.northwindCustomersService.readAllCustomers().subscribe(
      resp => {
        this.customersData.data = resp;
        this.ngAfterViewInit();
      },
      error => {
        alert(error.message);
        console.log(error);
      });
  }


  deleteCustomer(id) {
    if (confirm("Esta seguro de querer borrar " + id + "?")) {
      this.northwindCustomersService.deleteCustomers(id).subscribe(
        resp => {
          this.customerData = resp;
          //this.ngOnInit();
          this.getTable();
        },
        error => { alert(error.message); });

    }
  }

  sendParent(customer: Customers) {
    this.sendOutParent.emit(customer);
  }

}
