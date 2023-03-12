import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from 'src/app/models/employee';
import { WorkTask } from 'src/app/models/workTask';
import { EmployeeService } from 'src/app/services/employee.service';
import { WorktaskService } from 'src/app/services/worktask.service';

@Component({
  selector: 'app-work-task-details',
  templateUrl: './work-task-details.component.html',
  styleUrls: ['./work-task-details.component.css']
})
export class WorkTaskDetailsComponent implements OnInit {
  workTask:WorkTask=new WorkTask();
  formChangeState:FormGroup=new FormGroup({}); 
  formChangeAssignee:FormGroup=new FormGroup({}); 
  formWorkTask:FormGroup=new FormGroup({}); 
  editForm:boolean=false;
  employees:Array<Employee>=new Array<Employee>();
  projectId: number=0;
  constructor(private employeeService:EmployeeService, private workTaskService:WorktaskService, public dialogRef: MatDialogRef<WorkTaskDetailsComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public input: any) 
    {
      this.workTask=input['workTask'];
      this.projectId=input['projectId'];
      this.editForm=this.workTask!=null;  

      employeeService.GetAll().subscribe(
        (data)=>{
          this.employees=data;
        }
      )
    }

  ngOnInit(): void {
    this.formWorkTask=new FormGroup({
      'title':new FormControl(this.workTask?.title, Validators.required),
      'description':new FormControl(this.workTask?.description, Validators.required),
      'dueDate':new FormControl(this.workTask?.dueDate.toString().substring(0,10), Validators.required),
  }); 
  this.formChangeState=new FormGroup({
    'state':new FormControl(this.workTask.state, Validators.required)
  }); 
  this.formChangeAssignee=new FormGroup({
    'assignee':new FormControl(this.workTask.assignee?.id, Validators.required)
  }); 
  }
  Close()
  { 
    this.dialogRef.close();
  }
  ChangeState()
  { 
    var stateNum=0;
    var state=this.formChangeState.value['state'];
    switch (state){
      case "ToDo": 
        stateNum=0;
        break;
      case "InProgress":
        stateNum=1;
        break;
      case "InQA":
        stateNum=2;
        break;
      case "Done":
        stateNum=3;
        break;
      default:
        return;
    }
    this.workTaskService.ChangeState(this.workTask.id,stateNum).subscribe(
      (data)=>{
        alert('Successfully changed');
        this.workTaskService.Get(this.workTask.id).subscribe(x=>this.workTask=x);
      }
    )
  }
  ChangeAssignee()
  { 
    var employeeId=this.formChangeAssignee.value['assignee'];
    this.workTaskService.Assign(this.workTask.id,employeeId).subscribe(
      (data)=>{
        alert('Successfully assigned');
      }
    )
  }
  AddOrUpdateTask()
  {
    if(this.formWorkTask.valid)
    {

      var workTask=new WorkTask();
      workTask.projectId=this.projectId;
      workTask.title=this.formWorkTask.value['title'];
      workTask.description=this.formWorkTask.value['description'];
      workTask.dueDate=this.formWorkTask.value['dueDate'];
      if(this.editForm)
      {
        workTask.id=this.workTask.id;
        this.workTaskService.Edit(workTask).subscribe(data=>alert("Successful update"));
      }
      else
      {
        this.workTaskService.Add(workTask).subscribe(data=>this.dialogRef.close());
      }
    }
    else
    {
      alert("Invalid input");
    }
  }
 

}
