import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Project } from 'src/app/models/project';
import { ProjectsService } from 'src/app/services/projects.service';

@Component({
  selector: 'app-project-add',
  templateUrl: './project-add.component.html',
  styleUrls: ['./project-add.component.css']
})
export class ProjectAddComponent implements OnInit {
  AddProjectForm:FormGroup=new FormGroup({});
  project:Project=new Project();
  constructor(private projectsService:ProjectsService, public dialogRef: MatDialogRef<ProjectAddComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public input: any) 
    {
      this.project=input['employee'];
       
    }

  ngOnInit(): void {
    this.AddProjectForm=new FormGroup({
      'name':new FormControl(this.project?.name, Validators.required),
      'description':new FormControl(this.project?.description, Validators.required),
      'clientName':new FormControl(this.project?.clientName, Validators.required)
  }); 
  }
  Close()
  { 
    this.dialogRef.close();
  }
  SubmitForm()
  {
    if(this.AddProjectForm.valid)
    {

      var project=new Project();
      
      project.name=this.AddProjectForm.value['name'];
      project.description=this.AddProjectForm.value['description'];
      project.clientName=this.AddProjectForm.value['clientName'];
     
        this.projectsService.Add(project).subscribe(data=>this.dialogRef.close());
     
    }
    else
    {
      alert("Invalid input");
    }
  }

}
