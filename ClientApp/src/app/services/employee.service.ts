import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  

  constructor(private httpClient:HttpClient) { }

  
  GetAll():Observable<Array<Employee>> {
    return this.httpClient.get<Array<Employee>>(environment.serverUrl + '/api/Employee'); 
  } 
  Get(id:number):Observable<Employee> {
    return this.httpClient.get<Employee>(environment.serverUrl + '/api/Employee/'+id); 
  } 
  Add(employee:Employee):Observable<any> {
    return this.httpClient.post<any>(environment.serverUrl + '/api/Employee',employee); 
  }
  Edit(employee:Employee):Observable<any> {
    return this.httpClient.put<any>(environment.serverUrl + '/api/Employee/'+employee.id,employee); 
  }
  Delete(id:number):Observable<any> {
    return this.httpClient.delete<any>(environment.serverUrl + '/api/Employee/'+id); 
  } 
  GetBest():Observable<Array<Employee>> {
    return this.httpClient.get<Array<Employee>>(environment.serverUrl + '/api/Employee/Best'); 
  } 

}
