import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeAddComponent } from './employee/employee-add/employee-add.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

export const routes: Routes = [
    { path: "", component: EmployeeListComponent },
    { path: "create", component: EmployeeAddComponent },
    { path: "update/:id", component: EmployeeEditComponent },
    { path: '', redirectTo: '/', pathMatch: 'full' },
    
];

// NgModule({
//     declarations: [EmployeeListComponent],
//     imports: [
//         CommonModule,
//         RouterModule.forRoot(routes)
//         ],
//     exports: [RouterModule]
// })
export const appRoutingModule = RouterModule.forRoot(routes);