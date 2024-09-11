import { Component } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, RequiredValidator, Validators } from '@angular/forms';
import { RedirectCommand, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-employee-add',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './employee-add.component.html',
  styleUrl: './employee-add.component.css'
})
export class EmployeeAddComponent {
  constructor(private employeeService: EmployeeService, private formBuilder: FormBuilder, private router: Router) {
    
  }
  employee : FormGroup;
  

  onSubmit() {
    this.employeeService.add(this.employee.value).subscribe(response => {
      alert('Employee added successfully');
      this.router.navigate(['/']);      
      // Handle successful addition (e.g., show a success message or reset the form)
    }, error => {
      console.error('There was an error adding the employee!', error);
      // Handle error (e.g., show an error message)
    });
  }

  getEmployeeForm(){
    this.employee = this.formBuilder.group({
      firstName: new FormControl('',Validators.required),
      lastName: new FormControl(''),
      phone: new FormControl(''),
      email: new FormControl(''),
      address: new FormControl('')
    });
  }
}
