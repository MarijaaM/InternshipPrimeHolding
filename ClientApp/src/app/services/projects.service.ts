import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Project } from '../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {


  constructor(private httpClient:HttpClient) { }

  GetAll():Observable<Array<Project>> {
    return this.httpClient.get<Array<Project>>(environment.serverUrl + '/api/Project'); 
  } 
  Get(id:number):Observable<Project> {
    return this.httpClient.get<Project>(environment.serverUrl + '/api/Project/'+id); 
  } 
  Add(project:Project):Observable<any>{
    return this.httpClient.post<any>(environment.serverUrl+'/api/Project',project);
  }
  Delete(id:number):Observable<any>{
    return this.httpClient.delete<any>(environment.serverUrl+'/api/Project/'+id);
  }
  Update(project:Project):Observable<any>{
    return this.httpClient.put<any>(environment.serverUrl+'/api/Project/'+project.id,project);
  }
}
