import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink, RouterLinkActive } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
employees:any = [];
  constructor(private route :ActivatedRoute,private service:EmployeeService) { }
  ngOnInit() {
    // Retrieve the email from the query parameters
    this.getAll();
   
  }

  getAll(){
    this.service.getAll().subscribe((response)=>{
      this.employees = response;
    }, error => {
      console.log(error)
    });
  }
  delete(id:any,index:any){
    this.service.delete(id).subscribe((response)=>{
      alert('successfully deleted');
      this.getAll();
    })
  }
}
