import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-employee-edit',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './employee-edit.component.html',
  styleUrl: './employee-edit.component.css'
})
export class EmployeeEditComponent {
  employeeForm : FormGroup;
  employee : any;
  employeeId : number = 0;
  constructor(private route: ActivatedRoute, private router: Router, private service : EmployeeService, private formBuilder : FormBuilder){
    debugger;
    this.route.params.subscribe(params => {
      this.employeeId = params['id'];
    });
    this.getEmployeeForm();
    this.getEmployeeById();    
  }

  getEmployeeById(){
    this.service.getById(this.employeeId).subscribe((response)=>{
      this.employee = response;
      this.setEmployeeFormValue()
    })
  }

  getEmployeeForm(){
    this.employeeForm = this.formBuilder.group({
      firstName: new FormControl('',Validators.required),
      lastName: new FormControl(''),
      phone: new FormControl(''),
      email: new FormControl(''),
      address: new FormControl('')
    });
  }

  setEmployeeFormValue(){
    this.employeeForm.patchValue({
      firstName: this.employee.firstName,
      lastName: this.employee.lastName,
      phone:this.employee.phone,
      email: this.employee.email,
      address: this.employee.address
    });    
  }

  onSubmit(){
    this.service.update(this.employeeId,this.employeeForm.value).subscribe((response)=>{
      alert('successfully updated');
      this.router.navigate(['/']);      
    }, error => {
      console.error('There was an error updating the employee!', error);
      // Handle error (e.g., show an error message)
    });
  }
}
