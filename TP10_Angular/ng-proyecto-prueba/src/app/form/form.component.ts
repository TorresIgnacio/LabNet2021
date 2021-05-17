import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, RequiredValidator, Validators } from '@angular/forms';
import { Customers } from 'src/app/customers/models/customers';
import { NorthwindCustomersService } from 'src/app/customers/services/northwind-customers.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {

  @Input() parentData: Customers;
  @Output() refreshTable = new EventEmitter<Boolean>();
  customerForm: FormGroup;
  public customersData = new Customers();

  get customerIDCtrl(): AbstractControl {
    return this.customerForm.get('ID');
  }

  get contactNameCtrl(): AbstractControl {
    return this.customerForm.get('contactName');
  }

  get companyNameCtrl(): AbstractControl {
    return this.customerForm.get('companyName');
  }

  constructor(private readonly fb: FormBuilder, private northwindCustomersService: NorthwindCustomersService) {
    this.customerForm = this.fb.group({
      ID: ['', [Validators.required, Validators.maxLength(5), Validators.minLength(5)]],
      contactName: ['', Validators.maxLength(30)],
      companyName: ['', [Validators.required, Validators.maxLength(40)]]
    });
  }

  ngOnChanges(): void {
    if (this.parentData != null) {
      this.customerForm.setValue({
        ID: this.parentData.ID,
        contactName: this.parentData.contactName,
        companyName: this.parentData.companyName
      });
    }
  }
  ngOnInit(): void {

  }
  onSubmit(): void {
    console.log(this.customerForm.value);
    var customer = new Customers();
    customer.ID = this.customerForm.get('ID').value;
    customer.contactName = this.customerForm.get('contactName').value;
    customer.companyName = this.customerForm.get('companyName').value;
    this.northwindCustomersService.postCustomer(customer).subscribe(
      resp => {
        this.customersData = resp;
        this.sendParent(true);
      },
      error => { alert(error.message) });
  }

  updateCustomer(): void {
    var customer = new Customers();
    var id = this.customerForm.get('ID').value;
    customer.ID = id;
    customer.contactName = this.customerForm.get('contactName').value;
    customer.companyName = this.customerForm.get('companyName').value;
    this.northwindCustomersService.patchCustomers(id, customer).subscribe(
      resp => {
        this.customersData = resp;
        this.sendParent(true);
      },
      error => { alert(error.message) });
  }

  sendParent(refresh: Boolean) {
    this.refreshTable.emit(refresh);
  }

}
