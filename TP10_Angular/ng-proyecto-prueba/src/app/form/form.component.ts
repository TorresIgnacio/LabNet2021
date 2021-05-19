import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  public customersIDs: string[];
  public addFlag: boolean;
  public selectFirstOption: "newCustomer";
  get customerIDCtrl(): AbstractControl {
    return this.customerForm.get('IDSelect');
  }

  get contactNameCtrl(): AbstractControl {
    return this.customerForm.get('contactName');
  }

  get companyNameCtrl(): AbstractControl {
    return this.customerForm.get('companyName');
  }

  constructor(private readonly fb: FormBuilder, private northwindCustomersService: NorthwindCustomersService) {
    this.getCustomersIDs();
    this.customerForm = this.fb.group({
      IDSelect: ['', Validators.required],
      contactName: ['', Validators.maxLength(30)],
      companyName: ['', [Validators.required, Validators.maxLength(40)]]
    });
  }

  ngOnChanges(): void {
    if (this.parentData != null) {
      this.customerForm.setValue({
        IDSelect: this.parentData.ID,
        contactName: this.parentData.contactName,
        companyName: this.parentData.companyName
      });
      this.addFlag = false;
    }
  }

  ngOnInit(): void {
  }

  onOptionsSelected(IDSelect) {
    var id = IDSelect.value;
    if (id == "newCustomer") {
      this.addFlag = true;
      this.customerForm.reset();
      this.customerForm.controls['IDSelect'].setValue("newCustomer");
    }
    else {
      this.northwindCustomersService.readCustomer(id).subscribe(
        resp => {
          this.addFlag = false;
          this.customerForm.setValue({
            IDSelect: resp.ID,
            contactName: resp.contactName,
            companyName: resp.companyName
          });
        },
        error => { alert(error.message); }
      );
    }
  }

  onSubmit(): void {
    var customer = new Customers();
    customer.ID = this.generateID(this.customerForm.get('companyName').value);
    customer.contactName = this.customerForm.get('contactName').value;
    customer.companyName = this.customerForm.get('companyName').value;
    this.northwindCustomersService.postCustomer(customer).subscribe(
      resp => {
        this.customersData = resp;
        this.getCustomersIDs();
        this.sendParent(true);
      },
      error => { alert(error.message) });
  }

  updateCustomer(): void {
    var customer = new Customers();
    var id = this.customerForm.get('IDSelect').value;
    customer.ID = id;
    customer.contactName = this.customerForm.get('contactName').value;
    customer.companyName = this.customerForm.get('companyName').value;
    this.northwindCustomersService.patchCustomers(id, customer).subscribe(
      resp => {
        this.customersData = resp;
        this.sendParent(true);
      },
      error => { alert(error.message); });
  }

  sendParent(refresh: Boolean) {
    this.refreshTable.emit(refresh);
  }

  getCustomersIDs() {
    this.northwindCustomersService.readAllCustomers().subscribe(resp => {
      this.customersIDs = resp.map(c => c.ID);
    });
  }

  generateID(companyName: string): string {
    companyName = companyName.replace(/\s/g, "");
    var position = 4;
    if (companyName.length >= 5)
      var id = companyName.slice(0, 5).toUpperCase();
    else
      var id = this.makeString();
    while (this.customersIDs.includes(id)) {
      if (id.charAt(position) == 'Z') {
        position -= 1;
        continue;
      }
      // id = id.substring(0, position) + String.fromCharCode(id.charCodeAt(position) + 1);
      id = this.replaceAt(position, id, String.fromCharCode(id.charCodeAt(position) + 1));
    }
    return id;
  }

  replaceAt(index: number, id: String, replacement: String): string {
    return id.substr(0, index) + replacement + id.substr(index + replacement.length, id.length);
  }

  makeString(): string {
    let outString: string = '';
    let inOptions: string = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

    for (let i = 0; i < 5; i++) {

      outString += inOptions.charAt(Math.floor(Math.random() * inOptions.length));

    }
    return outString;
  }



}
