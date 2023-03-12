import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee';
import { WorkTask } from '../models/workTask';

@Injectable({
  providedIn: 'root'
})
export class WorktaskService {

  constructor(private httpClient:HttpClient) { }

  GetAll():Observable<Array<WorkTask>> {
    return this.httpClient.get<Array<WorkTask>>(environment.serverUrl + '/api/WorkTask'); 
  } 
  Get(id:number):Observable<WorkTask> {
    return this.httpClient.get<WorkTask>(environment.serverUrl + '/api/WorkTask/'+id); 
  } 
  Add(workTask:WorkTask):Observable<any> {
    return this.httpClient.post<any>(environment.serverUrl + '/api/WorkTask',workTask); 
  }
  Edit(workTask:WorkTask):Observable<any> {
    return this.httpClient.put<any>(environment.serverUrl + '/api/WorkTask/'+workTask.id,workTask); 
  }
  Delete(id:number):Observable<any> {
    return this.httpClient.delete<any>(environment.serverUrl + '/api/WorkTask/'+id); 
  } 
  Assign(workTaskId:number,employeeId:number):Observable<any>{
    return this.httpClient.post<any>(environment.serverUrl+'/api/WorkTask/Assign/'+workTaskId+'/'+employeeId,null);
  }
  ChangeState(workTaskId:number,state:number):Observable<any>{
    return this.httpClient.put<any>(environment.serverUrl+'/api/WorkTask/State/'+workTaskId+'/'+state,null);
  }
}
