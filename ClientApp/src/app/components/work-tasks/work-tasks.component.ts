import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Project } from 'src/app/models/project'; 
import { Router } from '@angular/router';
import { WorktaskService } from 'src/app/services/worktask.service';
import { WorkTaskDetailsComponent } from '../work-task-details/work-task-details.component';

@Component({
  selector: 'app-work-tasks',
  templateUrl: './work-tasks.component.html',
  styleUrls: ['./work-tasks.component.css']
})
export class WorkTasksComponent implements OnInit {
  @Input() project:Project=new Project();
  constructor(private workTaskService:WorktaskService, public dialog: MatDialog, private router:Router) 
  { 
    
  }

  ngOnInit(): void {
  }
  Delete(id:number){
    this.workTaskService.Delete(id).subscribe(()=>
    this.router.navigateByUrl('project/'+this.project.id));
  }
  Details(id:number){
    let dialogRef = this.dialog.open(WorkTaskDetailsComponent, {
      height: '70%',
      width: '80%',
      disableClose:true,
      closeOnNavigation:true,
      data: 
      {
        workTask:this.project.workTasks.find(x=>x.id==id),
        projectId:this.project.id
      }
    });
    dialogRef.afterClosed().subscribe(result => { 
      this.router.navigateByUrl('project/'+this.project.id);
       
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
      this.router.navigateByUrl('project/'+this.project.id);
       
    });
  }
}
