import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Project } from 'src/app/models/project';
import { ProjectsService } from 'src/app/services/projects.service';
import { ProjectAddComponent } from '../project-add/project-add.component';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  projects:Project[]=new Array<Project>();
   constructor(private projectsService:ProjectsService,public dialog: MatDialog,private router:Router) {
    projectsService.GetAll().subscribe(
      (data)=>{
      this.projects=data;
      }
    )
   }
  ngOnInit(): void {
  }
  AddNewProject(){
    let dialogRef = this.dialog.open(ProjectAddComponent, {
      height: '400px',
      width: '400px',
      disableClose:true,
      closeOnNavigation:true,
      data: {}
    });
    dialogRef.afterClosed().subscribe(result => { 
      this.projectsService.GetAll().subscribe(x=>this.projects=x);
       
    });
  }
  Details(id:number){
    this.router.navigateByUrl('project/'+id);
  }
  Delete(id:number){
    if(confirm("Are you sure you want to delete this employee?"))
    {
      this.projectsService.Delete(id).subscribe(data=>this.projectsService.GetAll().subscribe(x=>this.projects=x));
    }
  }
}
