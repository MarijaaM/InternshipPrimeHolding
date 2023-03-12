import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from 'src/app/models/project';
import { ProjectsService } from 'src/app/services/projects.service';
import { WorktaskService } from 'src/app/services/worktask.service';
import { WorkTaskDetailsComponent } from '../work-task-details/work-task-details.component';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  projectId:number=0;
  project:Project=new Project();
  ProjectForm:FormGroup=new FormGroup({});
  constructor(private route:ActivatedRoute,private router:Router, private projectsService:ProjectsService,
    private workTaskService:WorktaskService, public dialog: MatDialog) {
    this.ProjectForm=new FormGroup({
      'name':new FormControl("", Validators.required),
      'description':new FormControl("", Validators.required),
      'clientName':new FormControl("", Validators.required)
    }); 
   } 
  getProject()
  {
    this.projectsService.Get(this.projectId).subscribe(data=>{
      if(data==null)
      {
        this.router.navigateByUrl('/projects');
      }
      this.project=data;
      this.ProjectForm=new FormGroup({
        'name':new FormControl(this.project?.name, Validators.required),
        'description':new FormControl(this.project?.description, Validators.required),
        'clientName':new FormControl(this.project?.clientName, Validators.required)
      }); 
    }); 
  }
  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.projectId=params['id'];
      this.getProject();
    }); 
  }
  Save(){
    if(this.ProjectForm.valid){
      var project=new Project();
      project.id=this.projectId;
      project.name=this.ProjectForm.value['name'];
      project.description=this.ProjectForm.value['description'];
      project.clientName=this.ProjectForm.value['clientName'];

      this.projectsService.Update(project).subscribe(data=>alert("Successfully updated"));
      
    }
  }
  Delete(id:number){
    this.workTaskService.Delete(id).subscribe(()=>this.getProject());
  }
  Details(id:number){
    let dialogRef = this.dialog.open(WorkTaskDetailsComponent, {
      height: '650px',
      width: '1400px',
      disableClose:true,
      closeOnNavigation:true,
      data: 
      {
        workTask:this.project.workTasks.find(x=>x.id==id),
        projectId:this.project.id
      }
    });
    dialogRef.afterClosed().subscribe(result => { 
      this.getProject();
       
    });
  }
  AddNewTask(){
    let dialogRef = this.dialog.open(WorkTaskDetailsComponent, {
      height: '400px',
      width: '400px',
      disableClose:true,
      closeOnNavigation:true,
      data: 
      {
        projectId:this.project.id
      }
    });
    dialogRef.afterClosed().subscribe(() => { 
      this.getProject();
       
    });
  }
}
