import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../environments/environment';
import { Observable } from "rxjs";
@Injectable({
    providedIn: 'root'
  })
  export class EmployeeService {

    env = environment.apiUrl+'Employee/';
    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
          'accept': '*/*'
        })
      };
    constructor(private http: HttpClient, ) { }
  
    add(emp:any): Observable<any> {
      return this.http.post<any>(this.env+"Add",emp, this.httpOptions);
    }
    getAll(): Observable<any> {
        return this.http.get<any>(this.env+"GetAll");
      }
      getById(empId:number): Observable<any> {
        return this.http.get<any>(this.env+"GetById?id="+empId);
      }
      update(empId:number,emp:any): Observable<any> {
        return this.http.put<any>(this.env+"update/"+empId,emp);
      }
      delete(empId:number): Observable<any> {
        return this.http.delete<any>(this.env+"delete/"+empId);
      }
  }
  