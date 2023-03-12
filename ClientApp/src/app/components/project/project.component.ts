import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from 'src/app/models/project';
import { ProjectsService } from 'src/app/services/projects.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  projectId:number=0;
  project:Project=new Project();
  ProjectForm:FormGroup=new FormGroup({});
  constructor(private route:ActivatedRoute,private router:Router, private projectsService:ProjectsService) {
    this.ProjectForm=new FormGroup({
      'name':new FormControl("", Validators.required),
      'description':new FormControl("", Validators.required),
      'clientName':new FormControl("", Validators.required)
    }); 
   } 

  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.projectId=params['id'];
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
  
}
